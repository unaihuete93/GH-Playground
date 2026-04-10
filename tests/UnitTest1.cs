using FootballResultsWeb.Pages;
using FootballResultsWeb.Models;

namespace FootballResultsWeb.Tests;

// written by Copilot
/// <summary>
/// Unit tests for the IndexModel page
/// </summary>
public class IndexModelTests
{
    [Fact]
    public void OnGet_PopulatesMatchesList()
    {
        // Arrange
        var pageModel = new IndexModel();

        // Act
        pageModel.OnGet();

        // Assert
        Assert.NotNull(pageModel.Matches);
        Assert.NotEmpty(pageModel.Matches);
    }

    [Fact]
    public void OnGet_ReturnsCorrectNumberOfMatches()
    {
        // Arrange
        var pageModel = new IndexModel();

        // Act
        pageModel.OnGet();

        // Assert
        Assert.Equal(12, pageModel.Matches.Count);
    }

    [Fact]
    public void OnGet_AllMatchesHaveRequiredProperties()
    {
        // Arrange
        var pageModel = new IndexModel();

        // Act
        pageModel.OnGet();

        // Assert
        foreach (var match in pageModel.Matches)
        {
            Assert.NotEmpty(match.Country);
            Assert.NotEmpty(match.HomeTeam);
            Assert.NotEmpty(match.AwayTeam);
            Assert.NotEmpty(match.Competition);
            Assert.True(match.HomeScore >= 0);
            Assert.True(match.AwayScore >= 0);
            Assert.NotEqual(default(DateTime), match.MatchDate);
        }
    }

    [Fact]
    public void OnGet_MatchDatesAreInThePast()
    {
        // Arrange
        var pageModel = new IndexModel();

        // Act
        pageModel.OnGet();

        // Assert
        foreach (var match in pageModel.Matches)
        {
            Assert.True(match.MatchDate <= DateTime.Now);
        }
    }

    [Fact]
    public void OnGet_ContainsPremierLeagueMatches()
    {
        // Arrange
        var pageModel = new IndexModel();

        // Act
        pageModel.OnGet();

        // Assert
        var premierLeagueMatches = pageModel.Matches.Where(m => m.Competition == "Premier League").ToList();
        Assert.NotEmpty(premierLeagueMatches);
    }

    [Fact]
    public void OnGet_MatchScoresAreNonNegative()
    {
        // Arrange
        var pageModel = new IndexModel();

        // Act
        pageModel.OnGet();

        // Assert
        foreach (var match in pageModel.Matches)
        {
            Assert.True(match.HomeScore >= 0, "Home score should be non-negative");
            Assert.True(match.AwayScore >= 0, "Away score should be non-negative");
        }
    }

    [Fact]
    public void OnGet_OrganizesMatchesByCountry()
    {
        // Arrange
        var pageModel = new IndexModel();

        // Act
        pageModel.OnGet();

        // Assert
        Assert.NotEmpty(pageModel.MatchesByCountry);
        Assert.Equal(pageModel.Matches.Count, pageModel.MatchesByCountry.Sum(group => group.Count()));
        Assert.All(pageModel.MatchesByCountry, group => Assert.All(group, match => Assert.Equal(group.Key, match.Country)));
    }
}
