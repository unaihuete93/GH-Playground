using FootballResultsWeb.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace FootballResultsWeb.Tests;

// written by Copilot
/// <summary>
/// Unit tests for the command allow-list of DemoVulnerableController
/// </summary>
public class DemoVulnerableControllerTests
{
    [Theory]
    [InlineData("rm -rf /")]
    [InlineData("date; rm -rf /")]
    [InlineData("DATE")]
    [InlineData("")]
    public void RunCommand_RejectsCommandsOutsideAllowList(string command)
    {
        // Arrange
        var controller = new DemoVulnerableController();

        // Act
        var result = controller.RunCommand(command);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }
}
