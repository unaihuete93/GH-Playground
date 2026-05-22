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

    [HttpGet("run-command")]
    public IActionResult RunCommand([FromQuery] string command)
    {
        Process.Start("/bin/bash", "-c " + command);
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