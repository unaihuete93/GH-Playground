---
name: docs-page-writer
description: 'Create or update project documentation pages in the docs folder using a consistent structure, naming style, and writing checklist. Use when asked to write docs, add a docs page, improve existing docs, or standardize documentation formatting.'
argument-hint: 'Topic and target page, for example: api-authentication docs/api-authentication.md'
user-invocable: true
disable-model-invocation: false
---

# Docs Page Writer

Create clear and consistent documentation pages in the `docs` folder.

## When To Use
- User asks to create a new documentation page under `docs`.
- User asks to improve consistency across documentation files.
- User asks to rewrite docs with a standard structure.
- User asks to add how-to, reference, or concept pages.

## Inputs
- Topic name.
- Target file path under `docs`.
- Optional audience and prerequisites.

## Rules
1. Place authored pages only under `docs/`.
2. Use kebab-case file names, for example `release-process.md`.
3. Keep one page per topic.
4. Follow the structure in [Doc Page Template](./assets/doc-page-template.md).
5. Follow writing rules in [Doc Style Guide](./references/doc-style-guide.md).
6. Include practical steps and verification checks when the page is procedural.
7. Prefer concise language and concrete examples.

## Procedure
1. Confirm or infer the page purpose and target audience.
2. Determine the destination file path under `docs/`.
3. If the page does not exist, create it from [Doc Page Template](./assets/doc-page-template.md).
4. Fill each section with topic-specific content.
5. Ensure headings and terminology are consistent with existing docs.
6. For how-to content, include prerequisites, steps, expected results, and troubleshooting.
7. Add or update cross-links to related docs pages.
8. Run a final checklist from [Doc Style Guide](./references/doc-style-guide.md).

## Output
- A new or updated markdown file under `docs/`.
- Consistent section ordering and naming.
- Actionable content with verifiable instructions.
