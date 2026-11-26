using FootballResultsWeb.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;

namespace FootballResultsWeb.Services;

/// <summary>
/// Reads and seeds football match results stored in an Azure Cosmos DB
/// container, replacing the previously hardcoded in-page match list.
/// </summary>
public class CosmosDbFootballMatchRepository : IFootballMatchRepository
{
    private readonly CosmosClient _cosmosClient;
    private readonly CosmosDbOptions _options;
    private Container? _container;
    private readonly SemaphoreSlim _initializationLock = new(1, 1);

    public CosmosDbFootballMatchRepository(CosmosClient cosmosClient, IOptions<CosmosDbOptions> options)
    {
        _cosmosClient = cosmosClient;
        _options = options.Value;
    }

    public async Task<List<FootballMatch>> GetMatchesAsync()
    {
        var container = await GetContainerAsync();

        var matches = new List<FootballMatch>();
        var query = container.GetItemQueryIterator<FootballMatch>(
            new QueryDefinition("SELECT * FROM c ORDER BY c.MatchDate DESC"));

        while (query.HasMoreResults)
        {
            var response = await query.ReadNextAsync();
            matches.AddRange(response);
        }

        return matches;
    }

    private async Task<Container> GetContainerAsync()
    {
        if (_container is not null)
        {
            return _container;
        }

        await _initializationLock.WaitAsync();
        try
        {
            if (_container is null)
            {
                var database = await _cosmosClient.CreateDatabaseIfNotExistsAsync(_options.DatabaseName);
                var containerResponse = await database.Database.CreateContainerIfNotExistsAsync(
                    _options.ContainerName, "/id");

                await SeedIfEmptyAsync(containerResponse.Container);

                _container = containerResponse.Container;
            }
        }
        finally
        {
            _initializationLock.Release();
        }

        return _container;
    }

    private static async Task SeedIfEmptyAsync(Container container)
    {
        var countQuery = container.GetItemQueryIterator<int>(
            new QueryDefinition("SELECT VALUE COUNT(1) FROM c"));
        var countResponse = await countQuery.ReadNextAsync();
        var count = countResponse.FirstOrDefault();

        if (count > 0)
        {
            return;
        }

        foreach (var match in FootballMatchSeedData.GetMatches())
        {
            await container.CreateItemAsync(match, new PartitionKey(match.Id));
        }
    }
}
