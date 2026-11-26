using FootballResultsWeb.Pages;
using FootballResultsWeb.Models;
using FootballResultsWeb.Services;

namespace FootballResultsWeb.Tests;

// written by Copilot
/// <summary>
/// Unit tests for the IndexModel page
/// </summary>
public class IndexModelTests
{
    private static IndexModel CreatePageModel() =>
        new(new InMemoryFootballMatchRepository());

    [Fact]
    public async Task OnGet_PopulatesMatchesList()
    {
        // Arrange
        var pageModel = CreatePageModel();

        // Act
        await pageModel.OnGetAsync();

        // Assert
        Assert.NotNull(pageModel.Matches);
        Assert.NotEmpty(pageModel.Matches);
    }

    [Fact]
    public async Task OnGet_ReturnsCorrectNumberOfMatches()
    {
        // Arrange
        var pageModel = CreatePageModel();

        // Act
        await pageModel.OnGetAsync();

        // Assert
        Assert.Equal(17, pageModel.Matches.Count);
    }

    [Fact]
    public async Task OnGet_AllMatchesHaveRequiredProperties()
    {
        // Arrange
        var pageModel = CreatePageModel();

        // Act
        await pageModel.OnGetAsync();

        // Assert
        foreach (var match in pageModel.Matches)
        {
            Assert.NotEmpty(match.HomeTeam);
            Assert.NotEmpty(match.AwayTeam);
            Assert.NotEmpty(match.Competition);
            Assert.True(match.HomeScore >= 0);
            Assert.True(match.AwayScore >= 0);
            Assert.NotEqual(default(DateTime), match.MatchDate);
        }
    }

    [Fact]
    public async Task OnGet_MatchDatesAreInThePast()
    {
        // Arrange
        var pageModel = CreatePageModel();

        // Act
        await pageModel.OnGetAsync();

        // Assert
        foreach (var match in pageModel.Matches)
        {
            Assert.True(match.MatchDate <= DateTime.Now);
        }
    }

    [Fact]
    public async Task OnGet_ContainsPremierLeagueMatches()
    {
        // Arrange
        var pageModel = CreatePageModel();

        // Act
        await pageModel.OnGetAsync();

        // Assert
        var premierLeagueMatches = pageModel.Matches.Where(m => m.Competition == "Premier League").ToList();
        Assert.NotEmpty(premierLeagueMatches);
    }

    [Fact]
    public async Task OnGet_MatchScoresAreNonNegative()
    {
        // Arrange
        var pageModel = CreatePageModel();

        // Act
        await pageModel.OnGetAsync();

        // Assert
        foreach (var match in pageModel.Matches)
        {
            Assert.True(match.HomeScore >= 0, "Home score should be non-negative");
            Assert.True(match.AwayScore >= 0, "Away score should be non-negative");
        }
    }
}
