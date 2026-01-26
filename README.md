# GH-Playground ⚽

GitHub repo used for demoing many GH courses.

# GitHub Copilot

Many more examples found at: https://github.com/github/awesome-copilot

NOTES:
- custom instructions are taken by default or path based
- custom prompts can be played (button) or in chat using / commands


# About

**FootballResultsWeb** is an ASP.NET Core Razor Pages web application that displays football match results from around the world. It showcases a clean, responsive UI built with Bootstrap.

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

