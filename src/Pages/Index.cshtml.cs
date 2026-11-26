using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FootballResultsWeb.Models;
using System.Diagnostics;

namespace FootballResultsWeb.Pages;

public class IndexModel : PageModel
{
    public List<FootballMatch> Matches { get; set; } = new();

    public List<string> CompetitionNames { get; private set; } = new();

    public string DemoOutput { get; private set; } = string.Empty;

    public void OnGet()
    {
        Matches = FootballMatchData.GetAllMatches().ToList();
        CompetitionNames = FootballMatchData.GetCompetitionNames().ToList();
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
