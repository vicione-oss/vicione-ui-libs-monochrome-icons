# AGENTS.md

## Code style
- Refer to `docs/csharp-code-style.md` for C# coding conventions
- Refer to `docs/scss-code-style.md` for SCSS coding conventions

## Documentation style
- Refer to `docs/documentation-style.md` for comment and documentation conventions, including consistent terminology

## Skills

Reusable skill definitions located in `.claude/skills/` following the [Agent Skills](https://agentskills.io/) open standard.
Supported by GitHub Copilot and Claude Code.

| Skill                                                                      | Description                                           |
|----------------------------------------------------------------------------|-------------------------------------------------------|
| [delete-orphaned-css](.claude/skills/delete-orphaned-css/SKILL.md)         | Delete orphaned Blazor scoped Sass and CSS files      |
| [improve-comment-clarity](.claude/skills/improve-comment-clarity/SKILL.md) | Improve the clarity of comments and documentation     |

Each skill can have an associated slash command (`.claude/commands/`) and custom
prompt (`.github/prompts/`) that delegate to it as the single source of truth.

When you **add, remove, or rename** any skill, slash command, or custom prompt
file, update the solution file (`ViciOne.MonochromeIcons.slnx`) accordingly so
these files stay listed as solution items.
