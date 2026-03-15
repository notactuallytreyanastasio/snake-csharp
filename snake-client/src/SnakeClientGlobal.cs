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
        static G::IEnumerable<S1::Tuple<object ?>> coroHelperfn__102()
        {
            bool t___96;
            W::IWsConnection t___61;
            string ? t___64;
            string t___66;
            T::Task<W::IWsConnection> promise___107;
            try
            {
                console___18.Log("Snake Multiplayer Client");
                console___18.Log("Connecting to ws://localhost:8080...");
                promise___107 = W::WsGlobal.WsConnect("ws://localhost:8080");
            }
            catch
            {
                goto CATCH___129;
            }
            yield return C::Async.AwakeUpon(promise___107);
            W::IWsConnection ws__14;
            G::IEnumerable<S1::Tuple<object ?>> coroHelperfn__90()
            {
                bool t___86;
                string ? t___49;
                string t___59;
                while (connected__11)
                {
                    T::Task<string ?> promise___108;
                    try
                    {
                        promise___108 = I::IoSupport.StdReadLine();
                    }
                    catch
                    {
                        goto CATCH___113;
                    }
                    yield return C::Async.AwakeUpon(promise___108);
                    string ? line__16;
                    try
                    {
                        t___49 = promise___108.Result;
                        line__16 = t___49;
                        if (!(line__16 == null))
                        {
                            t___86 = line__16 != null;
                        }
                        else
                        {
                            t___86 = false;
                        }
                    }
                    catch
                    {
                        goto CATCH___113;
                    }
                    if (t___86)
                    {
                        try
                        {
                            if (line__16 == null)
                            {
                                throw new S1::Exception();
                            }
                            else
                            {
                                t___59 = line__16!;
                            }
                        }
                        catch
                        {
                            goto CATCH___113;
                        }
                        bool cond___115;
                        try
                        {
                            cond___115 = t___59 == "w";
                        }
                        catch
                        {
                            goto CATCH___113;
                        }
                        if (cond___115)
                        {
                            T::Task<S1::Tuple<object ?>> promise___109;
                            try
                            {
                                promise___109 = W::WsGlobal.WsSend(ws__14, "u");
                            }
                            catch
                            {
                                goto CATCH___116;
                            }
                            yield return C::Async.AwakeUpon(promise___109);
                            try
                            {
                                C::Core.Ignore(promise___109.Result);
                            }
                            catch
                            {
                                goto CATCH___116;
                            }
                            goto OK___117;
                            CATCH___116:
                            {
                            }
                            OK___117:
                            {
                            }
                        }
                        else
                        {
                            bool cond___118;
                            try
                            {
                                cond___118 = t___59 == "s";
                            }
                            catch
                            {
                                goto CATCH___113;
                            }
                            if (cond___118)
                            {
                                T::Task<S1::Tuple<object ?>> promise___110;
                                try
                                {
                                    promise___110 = W::WsGlobal.WsSend(ws__14, "d");
                                }
                                catch
                                {
                                    goto CATCH___119;
                                }
                                yield return C::Async.AwakeUpon(promise___110);
                                try
                                {
                                    C::Core.Ignore(promise___110.Result);
                                }
                                catch
                                {
                                    goto CATCH___119;
                                }
                                goto OK___120;
                                CATCH___119:
                                {
                                }
                                OK___120:
                                {
                                }
                            }
                            else
                            {
                                bool cond___121;
                                try
                                {
                                    cond___121 = t___59 == "a";
                                }
                                catch
                                {
                                    goto CATCH___113;
                                }
                                if (cond___121)
                                {
                                    T::Task<S1::Tuple<object ?>> promise___111;
                                    try
                                    {
                                        promise___111 = W::WsGlobal.WsSend(ws__14, "l");
                                    }
                                    catch
                                    {
                                        goto CATCH___122;
                                    }
                                    yield return C::Async.AwakeUpon(promise___111);
                                    try
                                    {
                                        C::Core.Ignore(promise___111.Result);
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
                                        cond___124 = t___59 == "d";
                                    }
                                    catch
                                    {
                                        goto CATCH___113;
                                    }
                                    if (cond___124)
                                    {
                                        T::Task<S1::Tuple<object ?>> promise___112;
                                        try
                                        {
                                            promise___112 = W::WsGlobal.WsSend(ws__14, "r");
                                        }
                                        catch
                                        {
                                            goto CATCH___125;
                                        }
                                        yield return C::Async.AwakeUpon(promise___112);
                                        try
                                        {
                                            C::Core.Ignore(promise___112.Result);
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
                                }
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                goto OK___114;
                CATCH___113:
                {
                }
                OK___114:
                {
                }
            }
            C::IGenerator<S1::Tuple<object ?>> fn__90()
            {
                return C::Core.AdaptGenerator<S1::Tuple<object ?>>(coroHelperfn__90);
            }
            try
            {
                t___61 = promise___107.Result;
                ws__14 = t___61;
                console___18.Log("Connected! Use w/a/s/d to move.");
                C::Async.LaunchGeneratorAsync((S1::Func<G::IEnumerable<S1::Tuple<object ?>>>) fn__90);
            }
            catch
            {
                goto CATCH___129;
            }
            while (connected__11)
            {
                T::Task<string ?> promise___127;
                try
                {
                    promise___127 = W::WsGlobal.WsRecv(ws__14);
                }
                catch
                {
                    goto CATCH___129;
                }
                yield return C::Async.AwakeUpon(promise___127);
                string ? msg__17;
                try
                {
                    t___64 = promise___127.Result;
                    msg__17 = t___64;
                    if (!(msg__17 == null))
                    {
                        t___96 = msg__17 != null;
                    }
                    else
                    {
                        t___96 = false;
                    }
                    if (t___96)
                    {
                        if (msg__17 == null)
                        {
                            throw new S1::Exception();
                        }
                        else
                        {
                            t___66 = msg__17!;
                        }
                        console___18.Log(t___66);
                    }
                    else
                    {
                        console___18.Log("Disconnected from server.");
                        connected__11 = false;
                    }
                }
                catch
                {
                    goto CATCH___129;
                }
            }
            T::Task<S1::Tuple<object ?>> promise___128;
            try
            {
                promise___128 = W::WsGlobal.WsClose(ws__14);
            }
            catch
            {
                goto CATCH___131;
            }
            yield return C::Async.AwakeUpon(promise___128);
            try
            {
                C::Core.Ignore(promise___128.Result);
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
            goto OK___130;
            CATCH___129:
            {
            }
            OK___130:
            {
            }
        }
        internal static C::IGenerator<S1::Tuple<object ?>> fn__102()
        {
            return C::Core.AdaptGenerator<S1::Tuple<object ?>>(coroHelperfn__102);
        }
        static SnakeClientGlobal()
        {
            console___18 = S0::Logging.LoggingConsoleFactory.CreateConsole("SnakeClient");
            connected__11 = true;
            C::Async.LaunchGeneratorAsync((S1::Func<G::IEnumerable<S1::Tuple<object ?>>>) fn__102);
        }
    }
}
