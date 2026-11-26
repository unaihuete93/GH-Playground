# Documentation

This folder stores project documentation pages.

## Overview

Use these notes to install and verify development tools in GitHub Codespaces.

## Spec Kit in Codespaces

### Prerequisites

The [devcontainer configuration](../.devcontainer/devcontainer.json) provides
`uv` and installs Specify CLI v1.4.5 automatically when the Codespace is created.
The installation uses Python 3.12; `uv` downloads it if needed.

### Steps

1. After changing the devcontainer configuration, run **Codespaces: Rebuild Container**
   from the VS Code command palette.
2. To install the same version manually in a Codespace with `uv` available, run:

   ```bash
   uv tool install specify-cli --python 3.12 --from git+https://github.com/github/spec-kit.git@v1.4.5
   ```

   `vX.Y.Z` is a placeholder, not a valid release tag. Replace it with a published
   Spec Kit version, such as `v1.4.5`.

### Validation

```bash
specify version
specify check
```

The version should be `1.4.5`, and the check should report that Specify CLI is ready
to use. Other coding agents are optional when using GitHub Copilot in VS Code.

### Troubleshooting

- If `uv` is not found, rebuild the container to apply the new feature.
- If `specify` is not found after installation, open a new terminal. The
  devcontainer adds the user tool directory (`$HOME/.local/bin`) to `PATH`.

## Index
- [Documentation Home](README.md)

## Authoring Notes
- Add one page per topic.
- Use kebab-case for file names.
- Keep steps concrete and verifiable.

## Related Docs

- [Project README](../README.md)
