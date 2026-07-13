using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FootballResultsWeb.Models;
using System.Diagnostics;

namespace FootballResultsWeb.Pages;

public class IndexModel : PageModel
{
    public List<FootballMatch> Matches { get; set; } = new();

    public string DemoOutput { get; private set; } = string.Empty;

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
            },
            new FootballMatch
            {
                HomeTeam = "Argentina",
                AwayTeam = "France",
                HomeScore = 3,
                AwayScore = 3,
                MatchDate = DateTime.Now.AddDays(-7),
                Competition = "FIFA World Cup"
            },
            new FootballMatch
            {
                HomeTeam = "Morocco",
                AwayTeam = "Portugal",
                HomeScore = 1,
                AwayScore = 0,
                MatchDate = DateTime.Now.AddDays(-8),
                Competition = "FIFA World Cup"
            },
            new FootballMatch
            {
                HomeTeam = "Brazil",
                AwayTeam = "Croatia",
                HomeScore = 1,
                AwayScore = 1,
                MatchDate = DateTime.Now.AddDays(-9),
                Competition = "FIFA World Cup"
            },
            new FootballMatch
            {
                HomeTeam = "England",
                AwayTeam = "Senegal",
                HomeScore = 3,
                AwayScore = 0,
                MatchDate = DateTime.Now.AddDays(-10),
                Competition = "FIFA World Cup"
            },
            new FootballMatch
            {
                HomeTeam = "Netherlands",
                AwayTeam = "United States",
                HomeScore = 3,
                AwayScore = 1,
                MatchDate = DateTime.Now.AddDays(-11),
                Competition = "FIFA World Cup"
            }
        };
    }

    public IActionResult OnGetNavigate(string returnUrl)
    {
        return Redirect(returnUrl);
    }

    public IActionResult OnGetReadAnyFile(string path)
    {
        var content = System.IO.File.ReadAllText(path);
        DemoOutput = content;
        return Page();
    }

    public IActionResult OnGetRunCommand(string command)
    {
        var process = Process.Start("/bin/bash", "-c " + command);
        DemoOutput = process is null ? "Failed to execute command." : "Command executed.";
        return Page();
    }
}
