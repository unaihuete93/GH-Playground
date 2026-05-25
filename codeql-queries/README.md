# CodeQL Local Demo — Custom Queries

## Overview

This folder contains custom QL queries for analyzing the `FootballResultsWeb` C# project locally using the CodeQL CLI (`gh codeql`). The queries target intentional vulnerabilities in `src/Controllers/DemoVulnerableController.cs`.

## Audience

- Developers exploring static analysis tooling
- Security engineers demonstrating CodeQL in local environments

## Prerequisites

- GitHub CLI (`gh`) with the `gh-codeql` extension installed and on `PATH`
- .NET SDK 10 or later
- Workspace cloned at `/workspaces/GH-Playground`

Verify the toolchain:

```bash
gh codeql version
gh codeql resolve languages | grep csharp
```

## Queries in This Folder

| File | Rule ID | What it detects |
|---|---|---|
| `WeakHash.ql` | `local/weak-hash` | Use of `MD5.Create()` |
| `OpenRedirect.ql` | `local/open-redirect` | `Redirect()` called with raw user input |
| `PathTraversal.ql` | `local/path-traversal` | `File.ReadAllText()` called with raw user input |

## Steps

### 1. Create the CodeQL database

Run from the workspace root:

```bash
gh codeql database create codeql-db \
  --language=csharp \
  --command="dotnet build src/FootballResultsWeb.csproj" \
  --overwrite
```

### 2. Install pack dependencies

```bash
gh codeql pack download codeql/csharp-all
```

### 3. Run all queries — SARIF output

```bash
gh codeql database analyze codeql-db \
  codeql-queries/ \
  --format=sarif-latest \
  --output=results.sarif
```

### 4. Run a single query — terminal output

```bash
gh codeql query run codeql-queries/WeakHash.ql \
  --database=codeql-db \
  --output=weak-hash.bqrs

gh codeql bqrs decode weak-hash.bqrs --format=text
```

### 5. Upload SARIF results to GitHub

Upload the results to GitHub Code Scanning so findings appear in the **Security** tab of the repository.

```bash
gh codeql github upload-results \
  --repository=unaihuete93/GH-Playground \
  --ref=refs/heads/main \
  --commit=$(git rev-parse HEAD) \
  --sarif=results.sarif
```

> **Note:** The repository must have GitHub Advanced Security enabled. For public repositories this is on by default.
>
> **Required scope:** The GitHub token must have the `security_events` write permission. If you get a `403 Forbidden` error, re-authenticate with the required scope:
> ```bash
> gh auth refresh -h github.com -s security_events
> ```

## Validation

- `codeql-db/db-csharp/` exists after step 1.
- `results.sarif` is produced and is valid JSON after step 3.
- Each query reports exactly one finding in `DemoVulnerableController.cs`.

Quick check:

```bash
cat results.sarif | python3 -m json.tool | grep '"ruleId"'
```

Expected:

```
"ruleId": "local/weak-hash",
"ruleId": "local/open-redirect",
"ruleId": "local/path-traversal",
```

## Troubleshooting

- **Build fails during database create** — confirm `dotnet build src/FootballResultsWeb.csproj` succeeds on its own first.
- **Cannot resolve pack `codeql/csharp-all`** — run `gh codeql pack download codeql/csharp-all` then retry.
- **Query returns zero results** — inspect the compiled types with a simpler query or run the standard `codeql/csharp-queries` pack to confirm the database is valid.
