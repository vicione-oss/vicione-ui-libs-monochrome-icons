---
name: improve-comment-clarity
description: >-
  Write and rework comments and documentation so they explain intent rather than
  restating code. Use when adding comments, reviewing or simplifying comments or
  XML documentation, or updating comments made stale by a code change.
---

# Improve comment clarity

Write and rework comments and documentation without changing program behavior.

## Principles

- **Explain why, not what.** The code already shows what it does. Capture intent,
  rationale, and non-obvious consequences.
- **Make it understandable from the start.** Introduce a concept before using
  its specialized terminology.
- **Use a concrete example for a non-obvious concept** when a small example
  communicates it more clearly than an abstract explanation.
- **Do not comment the obvious.** Self-explanatory code, trivial data holders,
  and simple accessors need no comment.
- **Keep comments truthful and current.** Update or delete comments invalidated
  by a code change.
- **Do not duplicate authoritative documentation.** Reference the relevant
  guide or README when a substantial decision is already documented there.
- **Preserve public API contracts.** Clarity edits must not alter the behavior
  described by XML documentation.
- **Match the surrounding style.** Follow the tone, format, and density of nearby
  comments.
- **Follow the repository documentation style.** Read and apply
  [`docs/documentation-style.md`](/docs/documentation-style.md).

## Review workflow

When asked to review a file, folder, or changeset:

1. Enumerate the in-scope source files. Exclude generated files such as
   `*.razor.css` and `*.generated.scss`, and exclude samples and tests unless the
   requested scope includes them.
2. Read every in-scope comment and judge it against the principles above.
3. Edit only comments and documentation whose clarity is genuinely lacking.
   Leave already-clear text untouched and do not change behavior.
4. Report unusual findings such as empty files, stray content, or genuine TODO
   markers. Do not rewrite or remove a genuine TODO unless explicitly asked.
5. Build the affected projects to verify that comment-only changes did not
   introduce errors.

## Sweeping terminology changes

When aligning wording across comments and documentation, change prose only.
Never rewrite code identifiers, file or import paths, external URLs, or package
identifiers. Build the affected projects afterward.
