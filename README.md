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

## The Story

This code was not written by a human in C#. It was written once in [Temper](https://github.com/temperlang/temper) — a programming language that compiles to 6 other languages — and then automatically compiled and published here by CI.

The same snake game exists in 6 languages, all generated from [one Temper source](https://github.com/notactuallytreyanastasio/temper_snake):

| Language | Repository |
|----------|------------|
| JavaScript | [snake-js](https://github.com/notactuallytreyanastasio/snake-js) |
| Python | [snake-python](https://github.com/notactuallytreyanastasio/snake-python) |
| Lua | [snake-lua](https://github.com/notactuallytreyanastasio/snake-lua) |
| Rust | [snake-rust](https://github.com/notactuallytreyanastasio/snake-rust) |
| **C#** | **snake-csharp** (you are here) |
| Java | [snake-java](https://github.com/notactuallytreyanastasio/snake-java) |

## What We Had to Do to the Compiler

Temper had no way to pause execution or read user input. The only I/O primitive was `console.log()`. To write a game loop that ticks every 200ms and reads keyboard input, we added `sleep()` and `readLine()` to the language itself — across all six compilation backends.

The compiler changes live on the [`do-crimes-to-play-snake`](https://github.com/temperlang/temper/tree/do-crimes-to-play-snake) branch ([PR #376](https://github.com/temperlang/temper/pull/376)).

### The Temper Declaration

Two new `@connected` primitives were added to `std/io` in commit [`0f31c89`](https://github.com/temperlang/temper/commit/0f31c89fabc1c938c6a4d2e72c80af658034aa17):

```temper
@connected("stdSleep")
export let sleep(ms: Int): Promise<Empty> { panic() }

@connected("stdReadLine")
export let readLine(): Promise<String?> { panic() }
```

The `@connected` decorator tells the compiler to replace the `panic()` body with a backend-specific native implementation at compile time.

### What Changed for C#

C# has native `async`/`await` with `Task<T>`, making this the most natural fit of any backend. Four Kotlin compiler files were modified.

**[`StandardNames.kt`](https://github.com/temperlang/temper/blob/0f31c89fabc1c938c6a4d2e72c80af658034aa17/be-csharp/src/commonMain/kotlin/lang/temper/be/csharp/StandardNames.kt)** — registered the namespace and member names:

```diff
+private val temperStdIo = temperStd.space("Io")
+private val temperStdIoIoSupport = temperStdIo.type("IoSupport")
+val temperStdIoStdSleep = temperStdIoIoSupport.member("StdSleep")
+val temperStdIoStdReadLine = temperStdIoIoSupport.member("StdReadLine")
```

**[`CSharpSupportNetwork.kt`](https://github.com/temperlang/temper/blob/0f31c89fabc1c938c6a4d2e72c80af658034aa17/be-csharp/src/commonMain/kotlin/lang/temper/be/csharp/CSharpSupportNetwork.kt)** — added `StaticCall` entries mapping connected keys to C# static methods:

```diff
+private val stdSleep = StaticCall(
+    "stdSleep",
+    StandardNames.temperStdIoStdSleep,
+)
+
+private val stdReadLine = StaticCall(
+    "stdReadLine",
+    StandardNames.temperStdIoStdReadLine,
+)
```

**[`CSharpBackend.kt`](https://github.com/temperlang/temper/blob/0f31c89fabc1c938c6a4d2e72c80af658034aa17/be-csharp/src/commonMain/kotlin/lang/temper/be/csharp/CSharpBackend.kt)** — registered the resource file:

```diff
             base = dirPath("lang", "temper", "be", "csharp", "std"),
+            filePath("Io", "IoSupport.cs"),
             filePath("Regex", "IntRangeSet.cs"),
```

**[`std/Io/IoSupport.cs`](https://github.com/temperlang/temper/blob/0f31c89fabc1c938c6a4d2e72c80af658034aa17/be-csharp/src/commonMain/resources/lang/temper/be/csharp/std/Io/IoSupport.cs)** — the native runtime implementation:

```csharp
using System;
using System.Threading.Tasks;

namespace TemperLang.Std.Io
{
    public static class IoSupport
    {
        public static async Task<Tuple<object?>> StdSleep(int ms)
        {
            await Task.Delay(ms);
            return Tuple.Create<object?>(null);
        }

        public static async Task<string?> StdReadLine()
        {
            return await Task.Run(() =>
            {
                try { return Console.ReadLine(); }
                catch (Exception) { return null; }
            });
        }
    }
}
```

Three lines of meaningful code for `StdSleep`. `Task.Delay` is non-blocking, `Console.ReadLine` is wrapped in `Task.Run` to avoid blocking the async context. The return type `Task<Tuple<object?>>` exists because C# maps Temper's `Empty` to `System.Tuple` through the connected types system.

## How It Works

1. The game logic lives in [`temper_snake`](https://github.com/notactuallytreyanastasio/temper_snake) as `.temper.md` files
2. A custom Temper compiler (branch [`do-crimes-to-play-snake`](https://github.com/temperlang/temper/tree/do-crimes-to-play-snake)) adds the `sleep()` and `readLine()` I/O primitives
3. GitHub Actions builds the compiler, compiles the game for all 6 backends, runs tests
4. If tests pass, the compiled output is automatically pushed to this repo

Every push to the source repo triggers a fresh build. This code is always in sync.

## Source

[notactuallytreyanastasio/temper_snake](https://github.com/notactuallytreyanastasio/temper_snake)
