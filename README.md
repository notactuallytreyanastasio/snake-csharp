# Snake (C#)

A terminal snake game written in C# — auto-generated from [Temper](https://temperlang.dev) source code.

## How to Play

**Prerequisites:** .NET 8 SDK

```bash
git clone https://github.com/notactuallytreyanastasio/snake-csharp.git
cd snake-csharp
dotnet run --project snake-game
```

Use **w/a/s/d** keys to steer the snake. No Enter key needed — input is raw mode.

## What Is This?

This code was not written by a human in C#. It was written once in [Temper](https://temperlang.dev) — a programming language that compiles to JavaScript, Python, Lua, Rust, Java, and C# — and then automatically compiled to C# and published here by CI.

Temper had no way to pause execution or read input. The only I/O was `console.log()`. To play snake, we had to add `sleep(ms)` and `readLine()` to the language itself — modifying the Temper compiler across all six backends.

## What Changed in the Temper Compiler for C#

C# has native `async`/`await` with `Task<T>`, making this the most natural fit of any backend. Three lines of meaningful code for sleep.

**Compiler changes:**
- `CSharpSupportNetwork.kt`: `StaticCall` entries for `stdSleep` and `stdReadLine`
- `CSharpBackend.kt`: resource registration for `std/Io/IoSupport.cs`
- `CsProj.kt` + `.csproj` templates: target framework updated from `net6.0` to `net8.0` (current LTS)
- `RegexSupport.cs`: `OrderedDictionary` and `AsReadOnly` fully namespace-qualified to avoid conflicts with `System.Collections.Generic.OrderedDictionary` introduced in .NET 9+

**Runtime** (`std/Io/IoSupport.cs`): `StdSleep` is `await Task.Delay(ms)`. `StdReadLine` uses `Console.ReadKey(true)` for single-keypress input (or `Console.ReadLine()` if input is redirected). The return type is `Task<Tuple<object?>>` because Temper's `Empty` maps to `System.Tuple` through the connected types system.

## All 6 Backends

The same snake game exists in 6 languages, all generated from [one Temper source](https://github.com/notactuallytreyanastasio/temper_snake):

| Language | Repository |
|----------|------------|
| JavaScript | [snake-js](https://github.com/notactuallytreyanastasio/snake-js) |
| Python | [snake-python](https://github.com/notactuallytreyanastasio/snake-python) |
| Lua | [snake-lua](https://github.com/notactuallytreyanastasio/snake-lua) |
| Rust | [snake-rust](https://github.com/notactuallytreyanastasio/snake-rust) |
| C# | [snake-csharp](https://github.com/notactuallytreyanastasio/snake-csharp) |
| Java | [snake-java](https://github.com/notactuallytreyanastasio/snake-java) |

## Source

- Game source: [notactuallytreyanastasio/temper_snake](https://github.com/notactuallytreyanastasio/temper_snake)
- Compiler branch: [`do-crimes-to-play-snake`](https://github.com/temperlang/temper/tree/do-crimes-to-play-snake) ([PR #376](https://github.com/temperlang/temper/pull/376))

---

*Auto-generated from commit [`26476b980303ae985689513527c1731356962183`](https://github.com/notactuallytreyanastasio/temper_snake/commit/26476b980303ae985689513527c1731356962183)*
