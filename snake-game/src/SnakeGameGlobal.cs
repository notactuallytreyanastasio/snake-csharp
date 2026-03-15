using S0 = Snake;
using S1 = SnakeGame.Support;
using S2 = System;
using G = System.Collections.Generic;
using T = System.Threading.Tasks;
using C = TemperLang.Core;
using I = TemperLang.Std.Io;
namespace SnakeGame
{
    public static class SnakeGameGlobal
    {
        internal static C::ILoggingConsole console___28;
        internal static S0::IDirection inputDirection__20;
        internal static S0::IDirection ? parseInput__6(string line__21)
        {
            S0::IDirection ? return__5;
            if (line__21 == "w")
            {
                return__5 = new S0::Up();
            }
            else if (line__21 == "s")
            {
                return__5 = new S0::Down();
            }
            else if (line__21 == "a")
            {
                return__5 = new S0::Left();
            }
            else if (line__21 == "d")
            {
                return__5 = new S0::Right();
            }
            else
            {
                return__5 = null;
            }
            return return__5;
        }
        static G::IEnumerable<S2::Tuple<object ?>> coroHelperfn__145()
        {
            bool t___135;
            bool t___136;
            string ? t___78;
            string t___82;
            while (true)
            {
                T::Task<string ?> promise___154;
                try
                {
                    promise___154 = I::IoSupport.StdReadLine();
                }
                catch
                {
                    goto CATCH___155;
                }
                yield return C::Async.AwakeUpon(promise___154);
                string ? line__24;
                try
                {
                    t___78 = promise___154.Result;
                    line__24 = t___78;
                    if (!(line__24 == null))
                    {
                        t___135 = line__24 != null;
                    }
                    else
                    {
                        t___135 = false;
                    }
                    if (t___135)
                    {
                        if (line__24 == null)
                        {
                            throw new S2::Exception();
                        }
                        else
                        {
                            t___82 = line__24!;
                        }
                        S0::IDirection ? dir__25 = parseInput__6(t___82);
                        if (!(dir__25 == null))
                        {
                            t___136 = dir__25 != null;
                        }
                        else
                        {
                            t___136 = false;
                        }
                        if (t___136)
                        {
                            if (dir__25 == null)
                            {
                                throw new S2::Exception();
                            }
                            else
                            {
                                inputDirection__20 = dir__25!;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                catch
                {
                    goto CATCH___155;
                }
            }
            goto OK___156;
            CATCH___155:
            {
            }
            OK___156:
            {
            }
        }
        internal static C::IGenerator<S2::Tuple<object ?>> fn__145()
        {
            return C::Core.AdaptGenerator<S2::Tuple<object ?>>(coroHelperfn__145);
        }
        static G::IEnumerable<S2::Tuple<object ?>> coroHelperfn__144()
        {
            S0::SnakeGame t___121;
            S0::SnakeGame t___124;
            string t___125;
            string t___127;
            string t___130;
            T::Task<S2::Tuple<object ?>> promise___157;
            try
            {
                console___28.Log("Snake! Use w/a/s/d + Enter to move.");
                console___28.Log("Starting in 1 second...");
                promise___157 = I::IoSupport.StdSleep(1000);
            }
            catch
            {
                goto CATCH___159;
            }
            yield return C::Async.AwakeUpon(promise___157);
            S0::SnakeGame game__27;
            try
            {
                C::Core.Ignore(promise___157.Result);
                t___121 = S0::SnakeGlobal.NewGame(20, 10, 42);
                game__27 = t___121;
            }
            catch
            {
                goto CATCH___159;
            }
            while (true)
            {
                T::Task<S2::Tuple<object ?>> promise___158;
                try
                {
                    if (!(game__27.Status is S0::Playing))
                    {
                        break;
                    }
                    game__27 = S0::SnakeGlobal.ChangeDirection(game__27, inputDirection__20);
                    t___124 = S0::SnakeGlobal.Tick(game__27);
                    game__27 = t___124;
                    t___125 = S0::SnakeGlobal.Render(game__27);
                    console___28.Log(t___125);
                    promise___158 = I::IoSupport.StdSleep(200);
                }
                catch
                {
                    goto CATCH___159;
                }
                yield return C::Async.AwakeUpon(promise___158);
                try
                {
                    C::Core.Ignore(promise___158.Result);
                }
                catch
                {
                    goto CATCH___159;
                }
            }
            try
            {
                t___127 = S0::SnakeGlobal.Render(game__27);
                console___28.Log(t___127);
                t___130 = S2::Convert.ToString(game__27.Score);
                console___28.Log("Final score: " + t___130);
            }
            catch
            {
                goto CATCH___159;
            }
            goto OK___160;
            CATCH___159:
            {
            }
            OK___160:
            {
            }
        }
        internal static C::IGenerator<S2::Tuple<object ?>> fn__144()
        {
            return C::Core.AdaptGenerator<S2::Tuple<object ?>>(coroHelperfn__144);
        }
        static SnakeGameGlobal()
        {
            console___28 = S1::Logging.LoggingConsoleFactory.CreateConsole("SnakeGame");
            inputDirection__20 = new S0::Right();
            C::Async.LaunchGeneratorAsync((S2::Func<G::IEnumerable<S2::Tuple<object ?>>>) fn__145);
            C::Async.LaunchGeneratorAsync((S2::Func<G::IEnumerable<S2::Tuple<object ?>>>) fn__144);
        }
    }
}
