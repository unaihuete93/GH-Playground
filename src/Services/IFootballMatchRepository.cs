using FootballResultsWeb.Models;

namespace FootballResultsWeb.Services;

/// <summary>
/// Provides access to the football match results shown on the home page.
/// </summary>
public interface IFootballMatchRepository
{
    Task<List<FootballMatch>> GetMatchesAsync();
}
