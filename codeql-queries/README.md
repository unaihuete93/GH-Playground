# CodeQL Local Demo — Custom Queries

## Overview

This folder contains custom QL queries for analyzing the `FootballResultsWeb` C# project locally. The queries target intentional vulnerabilities in `src/Controllers/DemoVulnerableController.cs`.

## Audience

- Developers exploring static analysis tooling
- Security engineers demonstrating CodeQL in local environments

## Prerequisites

- .NET SDK 10 or later
- Workspace cloned at `/workspaces/GH-Playground`
- One of the following CodeQL CLIs:
  - Standalone `codeql` binary on `PATH`
  - GitHub CLI (`gh`) with the `gh-codeql` extension

Verify the toolchain (standalone CLI):

```bash
codeql version
codeql resolve languages | grep csharp
```

Verify the toolchain (`gh` wrapper):

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
codeql database create codeql-db \
  --language=csharp \
  --command="dotnet build src/FootballResultsWeb.csproj" \
  --overwrite
```

Equivalent with `gh`:

```bash
gh codeql database create codeql-db \
  --language=csharp \
  --command="dotnet build src/FootballResultsWeb.csproj" \
  --overwrite
```

### 2. Install pack dependencies

```bash
codeql pack install  codeql-queries
```

Equivalent with `gh`:

```bash
gh codeql pack install  codeql-queries
```

### 3. Run custom queries only — SARIF output

```bash
gh codeql database analyze codeql-db \
  codeql-queries/ \
  --format=sarif-latest \
  --output=results.sarif
```

### 4. Run standard C# queries + custom queries — SARIF output

```bash
codeql database analyze codeql-db \
  codeql/csharp-queries \
  codeql-queries/ \
  --format=sarif-latest \
  --output=results.sarif
```

Equivalent with `gh`:

```bash
gh codeql database analyze codeql-db \
  codeql/csharp-queries \
  codeql-queries/ \
  --format=sarif-latest \
  --output=results.sarif
```

### 5. Run a single query — terminal output

```bash
codeql query run codeql-queries/WeakHash.ql \
  --database=codeql-db \
  --output=weak-hash.bqrs

codeql bqrs decode weak-hash.bqrs --format=text
```

Equivalent with `gh`:

```bash
gh codeql query run codeql-queries/WeakHash.ql \
  --database=codeql-db \
  --output=weak-hash.bqrs

gh codeql bqrs decode weak-hash.bqrs --format=text
```

### 6. Upload SARIF results to GitHub

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
- **`Could not resolve library path for .../codeql-queries`** — install pack dependencies first:
  - `codeql pack install --dir codeql-queries`
  - or `gh codeql pack install --dir codeql-queries`
- **`Pack 'codeql/csharp-all' was not found in the pack download cache`** — same fix as above (`pack install --dir codeql-queries`).
- **`codeql: command not found`** — start a new shell session or run `source ~/.bashrc` so the updated `PATH` is loaded.
- **`cache directory is already locked` / `.lock` error** — another CodeQL process is using the same database. Wait for the running analysis to finish, then retry.
- **Only custom queries appear in SARIF** — include `codeql/csharp-queries` explicitly in the analyze command to run standard C# queries too.
- **Query returns zero results** — inspect the compiled types with a simpler query or run the standard `codeql/csharp-queries` pack to confirm the database is valid.
