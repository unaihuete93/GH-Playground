using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FootballResultsWeb.Models;

namespace FootballResultsWeb.Pages;

public class IndexModel : PageModel
{
    public List<FootballMatch> Matches { get; set; } = new();

    public void OnGet()
    {
        // Generate fake football match results
        Matches = new List<FootballMatch>
        {
            new FootballMatch
            {
                HomeTeam = "Manchester United",
                AwayTeam = "Liverpool",
                HomeScore = 2,
                AwayScore = 1,
                MatchDate = DateTime.Now.AddDays(-1),
                Competition = "Premier League"
            },
            new FootballMatch
            {
                HomeTeam = "Barcelona",
                AwayTeam = "Real Madrid",
                HomeScore = 3,
                AwayScore = 3,
                MatchDate = DateTime.Now.AddDays(-2),
                Competition = "La Liga"
            },
            new FootballMatch
            {
                HomeTeam = "Bayern Munich",
                AwayTeam = "Borussia Dortmund",
                HomeScore = 4,
                AwayScore = 2,
                MatchDate = DateTime.Now.AddDays(-3),
                Competition = "Bundesliga"
            },
            new FootballMatch
            {
                HomeTeam = "Paris Saint-Germain",
                AwayTeam = "Marseille",
                HomeScore = 1,
                AwayScore = 0,
                MatchDate = DateTime.Now.AddDays(-1),
                Competition = "Ligue 1"
            },
            new FootballMatch
            {
                HomeTeam = "Juventus",
                AwayTeam = "AC Milan",
                HomeScore = 2,
                AwayScore = 2,
                MatchDate = DateTime.Now.AddDays(-4),
                Competition = "Serie A"
            },
            new FootballMatch
            {
                HomeTeam = "Chelsea",
                AwayTeam = "Arsenal",
                HomeScore = 0,
                AwayScore = 3,
                MatchDate = DateTime.Now.AddHours(-6),
                Competition = "Premier League"
            },
            new FootballMatch
            {
                HomeTeam = "Inter Milan",
                AwayTeam = "Napoli",
                HomeScore = 1,
                AwayScore = 1,
                MatchDate = DateTime.Now.AddDays(-5),
                Competition = "Serie A"
            },
            new FootballMatch
            {
                HomeTeam = "Atletico Madrid",
                AwayTeam = "Sevilla",
                HomeScore = 2,
                AwayScore = 0,
                MatchDate = DateTime.Now.AddDays(-3),
                Competition = "La Liga"
            },
            new FootballMatch
            {
                HomeTeam = "Tottenham Hotspur",
                AwayTeam = "Manchester City",
                HomeScore = 1,
                AwayScore = 4,
                MatchDate = DateTime.Now.AddHours(-12),
                Competition = "Premier League"
            },
            new FootballMatch
            {
                HomeTeam = "RB Leipzig",
                AwayTeam = "Bayer Leverkusen",
                HomeScore = 3,
                AwayScore = 2,
                MatchDate = DateTime.Now.AddDays(-2),
                Competition = "Bundesliga"
            },
            new FootballMatch
            {
                HomeTeam = "Lyon",
                AwayTeam = "Monaco",
                HomeScore = 2,
                AwayScore = 1,
                MatchDate = DateTime.Now.AddDays(-6),
                Competition = "Ligue 1"
            },
            new FootballMatch
            {
                HomeTeam = "Porto",
                AwayTeam = "Benfica",
                HomeScore = 0,
                AwayScore = 2,
                MatchDate = DateTime.Now.AddDays(-1),
                Competition = "Primeira Liga"
            }
        };
    }
}
