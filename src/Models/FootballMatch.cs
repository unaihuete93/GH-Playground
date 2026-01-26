namespace FootballResultsWeb.Models;

public class FootballMatch
{
    public string HomeTeam { get; set; } = string.Empty;
    public string AwayTeam { get; set; } = string.Empty;
    public int HomeScore { get; set; }
    public int AwayScore { get; set; }
    public DateTime MatchDate { get; set; }
    public string Competition { get; set; } = string.Empty;
}
