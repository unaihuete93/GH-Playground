---
agent: 'agent'
description: 'Summarize the latest code changes in a short format, using local git state and optionally GitHub MCP context.'
---

# Latest Changes Summary

Generate a short summary of the latest code changes for this repository, latest 10 commits and merged pull requests (use github mcp if needed). Focus on what changed, potential impact, and keep it concise. Use local git commands to inspect the current state of the codebase, and enrich with GitHub MCP context if available.

## Inputs
- Compare target: [default: main]
- Summary length: [default: 4 bullets max]

## TOOLS
- `search/codebase`: for inspecting git logs and diffs
- `terminalCommand`: for running git commands to get the latest changes
- GITHUB MCP (if enabled): for fetching PR and commit context when available

## Instructions
1. Inspect local changes first.
2. Prefer these commands (or equivalents):
   - `git status --short`
   - `git log -1 --name-status --stat`
   - `git diff --name-status <compare-target>...HEAD`
3. If uncommitted changes are enabled, also inspect:
   - `git diff --name-status`
   - `git diff --cached --name-status`
4. If GitHub MCP is enabled, enrich the summary with remote context when available:
   - Active PR title/number/state
   - Latest commit message
   - Any notable review/check status if easily available
5. Keep the output concise and factual. Do not speculate.

## Output Format
- `Summary:` one sentence.
- `What changed:` up to 4 bullets focused on files/features.
- `Potential impact:` 1-2 bullets (risk, behavior, test impact), or `None obvious`.

## Constraints
- Avoid long explanations.
- Mention file paths only when helpful.
- If there are no meaningful changes, say: `No significant changes detected.`
