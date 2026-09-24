using FootballResultsWeb.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FootballResultsWeb.Pages;

public class CompetitionModel : PageModel
{
    public List<FootballMatch> Matches { get; private set; } = new();

    public string CompetitionName { get; private set; } = string.Empty;

    public string CompetitionSlug { get; private set; } = string.Empty;

    public void OnGet(string? competition)
    {
        CompetitionSlug = competition ?? string.Empty;
        CompetitionName = FootballMatchData.ResolveCompetitionName(competition) ?? "All competitions";
        Matches = FootballMatchData.GetMatchesForCompetition(competition).ToList();
    }
}
