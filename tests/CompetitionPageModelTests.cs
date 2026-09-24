using FootballResultsWeb.Pages;

namespace FootballResultsWeb.Tests;

public class CompetitionPageModelTests
{
    [Fact]
    public void OnGet_WithCompetitionSlug_FiltersMatchesByCompetition()
    {
        var pageModel = new CompetitionModel();

        pageModel.OnGet("premier-league");

        Assert.Equal("Premier League", pageModel.CompetitionName);
        Assert.Equal("premier-league", pageModel.CompetitionSlug);
        Assert.NotEmpty(pageModel.Matches);
        Assert.All(pageModel.Matches, match => Assert.Equal("Premier League", match.Competition));
    }

    [Fact]
    public void OnGet_WithUnknownCompetition_UsesFallbackTitle()
    {
        var pageModel = new CompetitionModel();

        pageModel.OnGet("some-unknown-competition");

        Assert.Equal("All competitions", pageModel.CompetitionName);
        Assert.Equal("some-unknown-competition", pageModel.CompetitionSlug);
        Assert.Empty(pageModel.Matches);
    }
}
