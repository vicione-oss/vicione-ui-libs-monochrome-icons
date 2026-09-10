---
description: Find and delete orphaned Blazor scoped Sass/CSS files that have no matching Razor component and can trigger BLAZOR102.
---

Delete all orphaned Blazor scoped style files in the workspace. Account for both
maintained `*.razor.scss` sources and generated `*.razor.css` outputs.

Apply the `delete-orphaned-css` skill at
`.claude/skills/delete-orphaned-css/SKILL.md`: read that file first and follow
its workflow exactly. The skill is the single source of truth for scanning,
removal, and validation.
