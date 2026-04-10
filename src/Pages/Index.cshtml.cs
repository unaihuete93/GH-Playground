using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FootballResultsWeb.Models;

namespace FootballResultsWeb.Pages;

public class IndexModel : PageModel
{
    public List<FootballMatch> Matches { get; set; } = new();
    public IReadOnlyList<IGrouping<string, FootballMatch>> MatchesByCountry { get; private set; } = Array.Empty<IGrouping<string, FootballMatch>>();

    public void OnGet()
    {
        // Generate fake football match results
        Matches = new List<FootballMatch>
        {
            new FootballMatch
            {
                Country = "England",
                HomeTeam = "Manchester United",
                AwayTeam = "Liverpool",
                HomeScore = 2,
                AwayScore = 1,
                MatchDate = DateTime.Now.AddDays(-1),
                Competition = "Premier League"
            },
            new FootballMatch
            {
                Country = "Spain",
                HomeTeam = "Barcelona",
                AwayTeam = "Real Madrid",
                HomeScore = 3,
                AwayScore = 3,
                MatchDate = DateTime.Now.AddDays(-2),
                Competition = "La Liga"
            },
            new FootballMatch
            {
                Country = "Germany",
                HomeTeam = "Bayern Munich",
                AwayTeam = "Borussia Dortmund",
                HomeScore = 4,
                AwayScore = 2,
                MatchDate = DateTime.Now.AddDays(-3),
                Competition = "Bundesliga"
            },
            new FootballMatch
            {
                Country = "France",
                HomeTeam = "Paris Saint-Germain",
                AwayTeam = "Marseille",
                HomeScore = 1,
                AwayScore = 0,
                MatchDate = DateTime.Now.AddDays(-1),
                Competition = "Ligue 1"
            },
            new FootballMatch
            {
                Country = "Italy",
                HomeTeam = "Juventus",
                AwayTeam = "AC Milan",
                HomeScore = 2,
                AwayScore = 2,
                MatchDate = DateTime.Now.AddDays(-4),
                Competition = "Serie A"
            },
            new FootballMatch
            {
                Country = "England",
                HomeTeam = "Chelsea",
                AwayTeam = "Arsenal",
                HomeScore = 0,
                AwayScore = 3,
                MatchDate = DateTime.Now.AddHours(-6),
                Competition = "Premier League"
            },
            new FootballMatch
            {
                Country = "Italy",
                HomeTeam = "Inter Milan",
                AwayTeam = "Napoli",
                HomeScore = 1,
                AwayScore = 1,
                MatchDate = DateTime.Now.AddDays(-5),
                Competition = "Serie A"
            },
            new FootballMatch
            {
                Country = "Spain",
                HomeTeam = "Atletico Madrid",
                AwayTeam = "Sevilla",
                HomeScore = 2,
                AwayScore = 0,
                MatchDate = DateTime.Now.AddDays(-3),
                Competition = "La Liga"
            },
            new FootballMatch
            {
                Country = "England",
                HomeTeam = "Tottenham Hotspur",
                AwayTeam = "Manchester City",
                HomeScore = 1,
                AwayScore = 4,
                MatchDate = DateTime.Now.AddHours(-12),
                Competition = "Premier League"
            },
            new FootballMatch
            {
                Country = "Germany",
                HomeTeam = "RB Leipzig",
                AwayTeam = "Bayer Leverkusen",
                HomeScore = 3,
                AwayScore = 2,
                MatchDate = DateTime.Now.AddDays(-2),
                Competition = "Bundesliga"
            },
            new FootballMatch
            {
                Country = "France",
                HomeTeam = "Lyon",
                AwayTeam = "Monaco",
                HomeScore = 2,
                AwayScore = 1,
                MatchDate = DateTime.Now.AddDays(-6),
                Competition = "Ligue 1"
            },
            new FootballMatch
            {
                Country = "Portugal",
                HomeTeam = "Porto",
                AwayTeam = "Benfica",
                HomeScore = 0,
                AwayScore = 2,
                MatchDate = DateTime.Now.AddDays(-1),
                Competition = "Primeira Liga"
            }
        };

        MatchesByCountry = Matches
            .OrderBy(m => m.Country)
            .ThenByDescending(m => m.MatchDate)
            .GroupBy(m => m.Country)
            .ToList();
    }
}
