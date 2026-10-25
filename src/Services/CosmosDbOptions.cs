namespace FootballResultsWeb.Services;

/// <summary>
/// Configuration options for connecting to the Azure Cosmos DB account that
/// stores football match results.
/// </summary>
public class CosmosDbOptions
{
    public const string SectionName = "CosmosDb";

    public string ConnectionString { get; set; } = string.Empty;

    public string DatabaseName { get; set; } = "FootballResultsDb";

    public string ContainerName { get; set; } = "Matches";
}
