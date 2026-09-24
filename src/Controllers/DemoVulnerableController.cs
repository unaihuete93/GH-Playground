using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace FootballResultsWeb.Controllers;

[ApiController]
[Route("demo")]
public class DemoVulnerableController : ControllerBase
{
    [HttpGet("open-redirect")]
    public IActionResult OpenRedirect([FromQuery] string url)
    {
        return Redirect(url);
    }

    [HttpGet("read-file")]
    public IActionResult ReadFile([FromQuery] string path)
    {
        var content = System.IO.File.ReadAllText(path);
        return Content(content, "text/plain");
    }

    // written by Copilot
    /// <summary>
    /// Commands that are allowed to be executed, mapped from a caller-supplied key
    /// to a hard-coded command line. This prevents command line injection.
    /// </summary>
    private static readonly IReadOnlyDictionary<string, (string FileName, string Arguments)> AllowedCommands =
        new Dictionary<string, (string FileName, string Arguments)>(StringComparer.Ordinal)
        {
            ["date"] = ("/bin/date", string.Empty),
            ["uptime"] = ("/usr/bin/uptime", string.Empty),
            ["whoami"] = ("/usr/bin/whoami", string.Empty)
        };

    [HttpGet("run-command")]
    public IActionResult RunCommand([FromQuery] string command)
    {
        if (command is null || !AllowedCommands.TryGetValue(command, out var allowed))
        {
            return BadRequest("Unsupported command");
        }

        Process.Start(allowed.FileName, allowed.Arguments);
        return Ok("Executed");
    }

    [HttpGet("hash")]
    public IActionResult WeakHash([FromQuery] string input)
    {
        using var md5 = MD5.Create();
        var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
        var hex = Convert.ToHexString(hash);
        return Ok(hex);
    }
}