# GH-Playground ⚽ 

GitHub repo used for demoing many GH courses.

# GitHub Copilot

Many more examples found at: https://github.com/github/awesome-copilot

NOTES:
- custom instructions are taken by default or path based
- custom prompts can be played (button) or in chat using / commands
- custom agents can be used in chat
- custom skills (only available in VS Code Insiders? check https://docs.github.com/en/copilot/concepts/agents/about-agent-skills)
- demo skill added at .github/skills/docs-page-writer/SKILL.md to create docs pages in the docs folder

# About

**FootballResultsWeb** is an ASP.NET Core Razor Pages web application that displays football match results (for teams and countries) from around the world. It showcases a clean, responsive UI built with Bootstrap.

## Features

- 📊 Display football match results with scores
- 🏆 Show competition names and match dates
- 🎨 Color-coded score badges (green for winner, red for loser, gray for draw)
- 📱 Responsive design using Bootstrap

## Tech Stack

- **.NET 10** - Target framework
- **ASP.NET Core** - Web framework
- **Razor Pages** - UI framework
- **Bootstrap** - CSS framework

## Project Structure

```
├── src/
│   ├── Models/
│   │   └── FootballMatch.cs    # Match data model
│   ├── Pages/
│   │   ├── Index.cshtml        # Main results page
│   │   ├── Privacy.cshtml      # Privacy page
│   │   └── Shared/             # Shared layouts
│   ├── wwwroot/                # Static assets
│   ├── Program.cs              # Application entry point
│   └── appsettings.json        # Configuration
└── README.md
```

## Dependabot Demo

This repository intentionally includes older, known-vulnerable NuGet package versions so customers can see GitHub Dependabot alerts and version updates in action.

The demo dependencies are intentionally pinned to vulnerable releases:

- `Newtonsoft.Json` 12.0.1
- `System.Text.Encodings.Web` 4.7.1
- `System.Security.Cryptography.Xml` 10.0.5
- `Magick.NET-Q16-AnyCPU` 14.14.0
- `SSH.NET` 2025.1.0

These references are meant for demonstration and should not be used in a production application without updating to a patched version.

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)

### Build & Run

```bash
cd src

# Restore dependencies
dotnet restore

# Build the project
dotnet build

# Run the application
dotnet run
```

The app will be available at `https://localhost:5001` or `http://localhost:5000`.

## Using Spec Kit

[GitHub Spec Kit](https://github.com/github/spec-kit) supports specification-driven development: define what to build, create a plan, then implement it with GitHub Copilot.

### Set Up

Install [uv](https://docs.astral.sh/uv/getting-started/installation/) and ensure Git and Python 3.11+ are available. From the repository root, run:

```bash
uv tool install specify-cli --from git+https://github.com/github/spec-kit.git
specify init --here --ai copilot
```

Review any changes to existing files before committing. Open the repository in VS Code with GitHub Copilot enabled, then use the generated slash commands in Copilot Chat.

### Workflow

1. `/speckit.constitution` — Define project principles, such as accessibility, testing, and maintainability.
2. `/speckit.specify` — Describe a feature and its expected behavior, for example: “Allow users to filter football results by competition and date.”
3. `/speckit.clarify` — Resolve ambiguities in the specification before planning.
4. `/speckit.plan` — Create an implementation plan using .NET 10, ASP.NET Core Razor Pages, and Bootstrap.
5. `/speckit.tasks` — Break the plan into actionable tasks.
6. `/speckit.analyze` — Check consistency across the specification, plan, and tasks.
7. `/speckit.implement` — Implement the tasks, then review the changes and run builds and tests.

Spec Kit stores project principles in `.specify/` and feature specifications, plans, and tasks in `specs/`. Commit these artifacts alongside the implementation to keep requirements and code aligned.

