using S0 = SnakeClient.Support;
using S1 = System;
using G = System.Collections.Generic;
using T = System.Threading.Tasks;
using C = TemperLang.Core;
using I = TemperLang.Std.Io;
using W = TemperLang.Std.Ws;
namespace SnakeClient
{
    public static class SnakeClientGlobal
    {
        internal static C::ILoggingConsole console___18;
        internal static bool connected__11;
        static G::IEnumerable<S1::Tuple<object ?>> coroHelperfn__107()
        {
            bool t___101;
            W::IWsConnection t___63;
            string ? t___69;
            string t___71;
            T::Task<W::IWsConnection> promise___112;
            try
            {
                console___18.Log("Snake Multiplayer Client");
                console___18.Log("Connecting to ws://localhost:8080...");
                promise___112 = W::WsGlobal.WsConnect("ws://localhost:8080");
            }
            catch
            {
                goto CATCH___135;
            }
            yield return C::Async.AwakeUpon(promise___112);
            W::IWsConnection ws__14;
            try
            {
                t___63 = promise___112.Result;
                ws__14 = t___63;
            }
            catch
            {
                goto CATCH___135;
            }
            T::Task<S1::Tuple<object ?>> promise___113;
            try
            {
                promise___113 = W::WsGlobal.WsSend(ws__14, "join");
            }
            catch
            {
                goto CATCH___137;
            }
            yield return C::Async.AwakeUpon(promise___113);
            try
            {
                C::Core.Ignore(promise___113.Result);
            }
            catch
            {
                goto CATCH___137;
            }
            goto OK___138;
            CATCH___137:
            {
            }
            OK___138:
            {
            }
            G::IEnumerable<S1::Tuple<object ?>> coroHelperfn__95()
            {
                bool t___91;
                string ? t___51;
                string t___61;
                while (connected__11)
                {
                    T::Task<string ?> promise___114;
                    try
                    {
                        promise___114 = I::IoSupport.StdReadLine();
                    }
                    catch
                    {
                        goto CATCH___119;
                    }
                    yield return C::Async.AwakeUpon(promise___114);
                    string ? line__16;
                    try
                    {
                        t___51 = promise___114.Result;
                        line__16 = t___51;
                        if (!(line__16 == null))
                        {
                            t___91 = line__16 != null;
                        }
                        else
                        {
                            t___91 = false;
                        }
                    }
                    catch
                    {
                        goto CATCH___119;
                    }
                    if (t___91)
                    {
                        try
                        {
                            if (line__16 == null)
                            {
                                throw new S1::Exception();
                            }
                            else
                            {
                                t___61 = line__16!;
                            }
                        }
                        catch
                        {
                            goto CATCH___119;
                        }
                        bool cond___121;
                        try
                        {
                            cond___121 = t___61 == "w";
                        }
                        catch
                        {
                            goto CATCH___119;
                        }
                        if (cond___121)
                        {
                            T::Task<S1::Tuple<object ?>> promise___115;
                            try
                            {
                                promise___115 = W::WsGlobal.WsSend(ws__14, "u");
                            }
                            catch
                            {
                                goto CATCH___122;
                            }
                            yield return C::Async.AwakeUpon(promise___115);
                            try
                            {
                                C::Core.Ignore(promise___115.Result);
                            }
                            catch
                            {
                                goto CATCH___122;
                            }
                            goto OK___123;
                            CATCH___122:
                            {
                            }
                            OK___123:
                            {
                            }
                        }
                        else
                        {
                            bool cond___124;
                            try
                            {
                                cond___124 = t___61 == "s";
                            }
                            catch
                            {
                                goto CATCH___119;
                            }
                            if (cond___124)
                            {
                                T::Task<S1::Tuple<object ?>> promise___116;
                                try
                                {
                                    promise___116 = W::WsGlobal.WsSend(ws__14, "d");
                                }
                                catch
                                {
                                    goto CATCH___125;
                                }
                                yield return C::Async.AwakeUpon(promise___116);
                                try
                                {
                                    C::Core.Ignore(promise___116.Result);
                                }
                                catch
                                {
                                    goto CATCH___125;
                                }
                                goto OK___126;
                                CATCH___125:
                                {
                                }
                                OK___126:
                                {
                                }
                            }
                            else
                            {
                                bool cond___127;
                                try
                                {
                                    cond___127 = t___61 == "a";
                                }
                                catch
                                {
                                    goto CATCH___119;
                                }
                                if (cond___127)
                                {
                                    T::Task<S1::Tuple<object ?>> promise___117;
                                    try
                                    {
                                        promise___117 = W::WsGlobal.WsSend(ws__14, "l");
                                    }
                                    catch
                                    {
                                        goto CATCH___128;
                                    }
                                    yield return C::Async.AwakeUpon(promise___117);
                                    try
                                    {
                                        C::Core.Ignore(promise___117.Result);
                                    }
                                    catch
                                    {
                                        goto CATCH___128;
                                    }
                                    goto OK___129;
                                    CATCH___128:
                                    {
                                    }
                                    OK___129:
                                    {
                                    }
                                }
                                else
                                {
                                    bool cond___130;
                                    try
                                    {
                                        cond___130 = t___61 == "d";
                                    }
                                    catch
                                    {
                                        goto CATCH___119;
                                    }
                                    if (cond___130)
                                    {
                                        T::Task<S1::Tuple<object ?>> promise___118;
                                        try
                                        {
                                            promise___118 = W::WsGlobal.WsSend(ws__14, "r");
                                        }
                                        catch
                                        {
                                            goto CATCH___131;
                                        }
                                        yield return C::Async.AwakeUpon(promise___118);
                                        try
                                        {
                                            C::Core.Ignore(promise___118.Result);
                                        }
                                        catch
                                        {
                                            goto CATCH___131;
                                        }
                                        goto OK___132;
                                        CATCH___131:
                                        {
                                        }
                                        OK___132:
                                        {
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                goto OK___120;
                CATCH___119:
                {
                }
                OK___120:
                {
                }
            }
            C::IGenerator<S1::Tuple<object ?>> fn__95()
            {
                return C::Core.AdaptGenerator<S1::Tuple<object ?>>(coroHelperfn__95);
            }
            try
            {
                console___18.Log("Connected! Use w/a/s/d to move.");
                C::Async.LaunchGeneratorAsync((S1::Func<G::IEnumerable<S1::Tuple<object ?>>>) fn__95);
            }
            catch
            {
                goto CATCH___135;
            }
            while (connected__11)
            {
                T::Task<string ?> promise___133;
                try
                {
                    promise___133 = W::WsGlobal.WsRecv(ws__14);
                }
                catch
                {
                    goto CATCH___135;
                }
                yield return C::Async.AwakeUpon(promise___133);
                string ? msg__17;
                try
                {
                    t___69 = promise___133.Result;
                    msg__17 = t___69;
                    if (!(msg__17 == null))
                    {
                        t___101 = msg__17 != null;
                    }
                    else
                    {
                        t___101 = false;
                    }
                    if (t___101)
                    {
                        if (msg__17 == null)
                        {
                            throw new S1::Exception();
                        }
                        else
                        {
                            t___71 = msg__17!;
                        }
                        console___18.Log(t___71);
                    }
                    else
                    {
                        console___18.Log("Disconnected from server.");
                        connected__11 = false;
                    }
                }
                catch
                {
                    goto CATCH___135;
                }
            }
            T::Task<S1::Tuple<object ?>> promise___134;
            try
            {
                promise___134 = W::WsGlobal.WsClose(ws__14);
            }
            catch
            {
                goto CATCH___139;
            }
            yield return C::Async.AwakeUpon(promise___134);
            try
            {
                C::Core.Ignore(promise___134.Result);
            }
            catch
            {
                goto CATCH___139;
            }
            goto OK___140;
            CATCH___139:
            {
            }
            OK___140:
            {
            }
            goto OK___136;
            CATCH___135:
            {
            }
            OK___136:
            {
            }
        }
        internal static C::IGenerator<S1::Tuple<object ?>> fn__107()
        {
            return C::Core.AdaptGenerator<S1::Tuple<object ?>>(coroHelperfn__107);
        }
        static SnakeClientGlobal()
        {
            console___18 = S0::Logging.LoggingConsoleFactory.CreateConsole("SnakeClient");
            connected__11 = true;
            C::Async.LaunchGeneratorAsync((S1::Func<G::IEnumerable<S1::Tuple<object ?>>>) fn__107);
        }
    }
}
