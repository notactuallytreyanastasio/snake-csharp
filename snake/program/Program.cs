using System.Runtime.CompilerServices;
using TemperLang.Core;

static class Program
{
    static void Main()
    {
        Core.InitSimpleLogging();
        RuntimeHelpers.RunClassConstructor(typeof(Snake.SnakeGlobal).TypeHandle);
        Async.WaitUntilSafeToExit();
    }
}
