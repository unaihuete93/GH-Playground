using FootballResultsWeb.Models;

namespace FootballResultsWeb.Services;

/// <summary>
/// In-memory implementation used when no Cosmos DB connection string is
/// configured, such as local development or automated tests.
/// </summary>
public class InMemoryFootballMatchRepository : IFootballMatchRepository
{
    private readonly List<FootballMatch> _matches;

    public InMemoryFootballMatchRepository()
        : this(FootballMatchSeedData.GetMatches())
    {
    }

    public InMemoryFootballMatchRepository(List<FootballMatch> matches)
    {
        _matches = matches;
    }

    public Task<List<FootballMatch>> GetMatchesAsync() => Task.FromResult(_matches);
}
