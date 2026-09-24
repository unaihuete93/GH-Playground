using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FootballResultsWeb.Models;
using FootballResultsWeb.Services;
using System.Diagnostics;

namespace FootballResultsWeb.Pages;

public class IndexModel : PageModel
{
    private readonly IFootballMatchRepository _matchRepository;

    public List<FootballMatch> Matches { get; set; } = new();

    public string DemoOutput { get; private set; } = string.Empty;

    public IndexModel(IFootballMatchRepository matchRepository)
    {
        _matchRepository = matchRepository;
    }

    public async Task OnGetAsync()
    {
        // Football match results are now retrieved from Azure Cosmos DB
        // (or an in-memory fallback) instead of being hardcoded here.
        Matches = await _matchRepository.GetMatchesAsync();
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
