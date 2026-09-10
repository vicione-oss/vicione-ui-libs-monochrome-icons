# Documentation Style

This document contains rules and recommendations on how to write comments and
documentation (XML documentation comments, inline comments in `.cs`, `.razor`,
and `.scss` files, README files, and other Markdown documents) for this
repository.

## Consistent terminology

Pick one term per concept and use it everywhere—comments, XML documentation,
identifiers, README files, and other documentation. Favor consistency and
precision across the code base over locally shorter wording, and prefer spelling
a term out over an abbreviation when the scope is broad or the reader may not
have the local context to decode it.

When introducing a recurring term, match the wording already used by the
surrounding code base.

## Public API documentation

Applies to `///` on the shipped-package surface—the public and protected members
a consumer sees. A `public` member in an assembly nobody consumes counts as
internal.

Treat the implementation as a black box: document the contract, never the
mechanism.

- The **contract** is external even where it looks like implementation: thrown
  exceptions, thread safety, disposal requirements, ordering and timing
  guarantees, and observable side effects.
- The **mechanism** is not: data structures, locks, private helpers, caching,
  and algorithm names.
- Never restate the signature. No "Gets or sets", no `<param>` echoing the
  parameter name, and no `<summary>Disposes.</summary>`.
- For every part of the documentation, ask whether an external user needs it
  and whether it leaks internals. Delete what fails either question.
- Where documentation is mandatory, use `<inheritdoc/>` where reasonable;
  otherwise add documentation that describes the contract.

## Code comments

Covers code comments in `.cs`, `.razor`, and `.scss` files. It does not cover
README files or other Markdown documents.

Default to none. Every comment is a potential code smell—challenge each one
before writing it.

- A comment explaining **what or how** is refactorable: rename, extract, or
  restructure until the comment is redundant, then drop it.
- A comment explaining **why**—an external constraint, non-obvious ordering, or
  a workaround—is not exempt from the same test. Ask what could carry it
  instead: a name, a type, a guard, an enum member, or a test. Search the test
  suite before keeping it; where a test asserts the constraint, the test carries
  it and the comment goes. Drop it too if it is trivial or explains a decision
  no reader would question. Only a reason that no code structure can express and
  no test can reach survives.
- **Trimming is deletion first.** When a comment fails a check, the question is
  "does this go?", not "can this be shorter?". Rewriting a comment that should
  not exist launders it—it survives the review it should not have survived and
  becomes harder to spot.
- **A surviving why does not carry its neighbours.** Split it at sentence and
  clause boundaries and run every piece through the checks again. A clause that
  names an identifier, call, or value visible in the lines below is a
  restatement and goes, however sound the clause next to it is. Shrinking to a
  single clause is the normal outcome.
- **No history.** State what the code does and why, never what it used to do or
  what a change replaced. Version control carries that history, and the comment
  becomes wrong the next time the code changes.
- **Every claim is checked.** Verify a comment asserting something about another
  file, project, package, or consuming application before writing it.
- **Say it once, where the decision lives.** State a reason that spans files at
  the place that owns it. When the reason is architectural rather than local,
  put it in the relevant README or design document.
- **A reference is a last resort.** A path or section name can drift silently.
  Prefer stating the reason inline, then naming a symbol that refactoring tools
  can follow, and only then referencing a file. A reference is the address of a
  reason, never a substitute for the reason itself.

## Wording

These rules apply to comments and XML documentation alike. Follow the
terminology rules above when choosing terms.

- Use full sentences with capitalization and terminal punctuation.
- Use the plainest word that is still precise. Shorter and simpler wins, but
  never at the cost of precision.
- Name only concepts the code actually has. A domain noun should correspond to
  a searchable type, member, parameter, CSS class, or other established term.
- Do not introduce a commenting convention that exists nowhere else in the
  repository. Search first and match the surrounding style.
- A comment you touch, you own: fix or delete a stale comment in code you edit.
  A wrong comment is worse than none.
