using S0 = Snake;
using S1 = SnakeServer.Support;
using S2 = System;
using G = System.Collections.Generic;
using T = System.Threading.Tasks;
using C = TemperLang.Core;
using I = TemperLang.Std.Io;
using W = TemperLang.Std.Ws;
namespace SnakeServer
{
    public static class SnakeServerGlobal
    {
        internal static C::ILoggingConsole console___56;
        internal static int detectedCols__31;
        internal static int detectedRows__32;
        internal static int boardWidth__33;
        internal static int boardHeight__34;
        internal static S0::MultiSnakeGame game__35;
        internal static G::IList<W::IWsConnection> wsConns__36;
        internal static int nextId__37;
        internal static bool running__38;
        static G::IEnumerable<S2::Tuple<object ?>> coroHelperfn__269()
        {
            int t___250;
            G::IReadOnlyList<S0::PlayerSnake> t___251;
            S0::PlayerSnake t___255;
            G::IReadOnlyList<S0::IDirection> t___259;
            S0::MultiSnakeGame t___260;
            int t___263;
            while (true)
            {
                T::Task<S2::Tuple<object ?>> promise___284;
                try
                {
                    if (!(game__35.Snakes.Count == 0))
                    {
                        break;
                    }
                    promise___284 = I::IoSupport.StdSleep(500);
                }
                catch
                {
                    goto CATCH___287;
                }
                yield return C::Async.AwakeUpon(promise___284);
                try
                {
                    C::Core.Ignore(promise___284.Result);
                }
                catch
                {
                    goto CATCH___287;
                }
            }
            try
            {
                console___56.Log("Game starting!");
            }
            catch
            {
                goto CATCH___287;
            }
            while (running__38)
            {
                G::IList<S0::IDirection> dirs__49;
                int i__50;
                string frame__52;
                G::IReadOnlyList<W::IWsConnection> conns__53;
                int ci__54;
                try
                {
                    dirs__49 = new G::List<S0::IDirection>();
                    i__50 = 0;
                    while (true)
                    {
                        t___250 = game__35.Snakes.Count;
                        if (!(i__50 < t___250))
                        {
                            break;
                        }
                        t___251 = game__35.Snakes;
                        t___255 = new S0::PlayerSnake(0, C::Listed.CreateReadOnlyList<S0::Point>(), new S0::Right(), 0, new S0::Dead());
                        S0::PlayerSnake snake__51 = C::Listed.GetOr(t___251, i__50, t___255);
                        C::Listed.Add(dirs__49, snake__51.Direction);
                        i__50 = i__50 + 1;
                    }
                    t___259 = C::Listed.ToReadOnlyList(dirs__49);
                    t___260 = S0::SnakeGlobal.MultiTick(game__35, t___259);
                    game__35 = t___260;
                    frame__52 = S0::SnakeGlobal.MultiRender(game__35);
                    conns__53 = C::Listed.ToReadOnlyList(wsConns__36);
                    ci__54 = 0;
                }
                catch
                {
                    goto CATCH___287;
                }
                while (true)
                {
                    try
                    {
                        t___263 = conns__53.Count;
                        if (!(ci__54 < t___263))
                        {
                            break;
                        }
                    }
                    catch
                    {
                        goto CATCH___287;
                    }
                    W::IWsConnection conn__55;
                    T::Task<S2::Tuple<object ?>> promise___285;
                    try
                    {
                        conn__55 = conns__53[ci__54];
                        promise___285 = W::WsGlobal.WsSend(conn__55, frame__52);
                    }
                    catch
                    {
                        goto CATCH___289;
                    }
                    yield return C::Async.AwakeUpon(promise___285);
                    try
                    {
                        C::Core.Ignore(promise___285.Result);
                    }
                    catch
                    {
                        goto CATCH___289;
                    }
                    goto OK___290;
                    CATCH___289:
                    {
                    }
                    OK___290:
                    {
                    }
                    try
                    {
                        ci__54 = ci__54 + 1;
                    }
                    catch
                    {
                        goto CATCH___287;
                    }
                }
                T::Task<S2::Tuple<object ?>> promise___286;
                try
                {
                    promise___286 = I::IoSupport.StdSleep(200);
                }
                catch
                {
                    goto CATCH___287;
                }
                yield return C::Async.AwakeUpon(promise___286);
                try
                {
                    C::Core.Ignore(promise___286.Result);
                }
                catch
                {
                    goto CATCH___287;
                }
            }
            goto OK___288;
            CATCH___287:
            {
            }
            OK___288:
            {
            }
        }
        internal static C::IGenerator<S2::Tuple<object ?>> fn__269()
        {
            return C::Core.AdaptGenerator<S2::Tuple<object ?>>(coroHelperfn__269);
        }
        static G::IEnumerable<S2::Tuple<object ?>> coroHelperfn__268()
        {
            string t___238;
            W::IWsConnection t___132;
            W::IWsServer server__40;
            T::Task<W::IWsServer> promise___291;
            try
            {
                console___56.Log("Snake Multiplayer Server");
                console___56.Log("Starting on port 8080...");
                promise___291 = W::WsGlobal.WsListen(8080);
            }
            catch
            {
                goto CATCH___296;
            }
            yield return C::Async.AwakeUpon(promise___291);
            try
            {
                server__40 = promise___291.Result;
                console___56.Log("Listening on ws://localhost:8080");
                console___56.Log("Waiting for players to connect...");
            }
            catch
            {
                goto CATCH___296;
            }
            while (running__38)
            {
                T::Task<W::IWsConnection> promise___292;
                try
                {
                    promise___292 = W::WsGlobal.WsAccept(server__40);
                }
                catch
                {
                    goto CATCH___296;
                }
                yield return C::Async.AwakeUpon(promise___292);
                W::IWsConnection ws__41;
                int playerId__42;
                string symbol__43;
                int connId__44;
                W::IWsConnection connWs__45;
                G::IEnumerable<S2::Tuple<object ?>> coroHelperfn__231()
                {
                    bool t___217;
                    S0::Up t___218;
                    S0::MultiSnakeGame t___219;
                    S0::Down t___220;
                    S0::MultiSnakeGame t___221;
                    S0::Left t___222;
                    S0::MultiSnakeGame t___223;
                    S0::Right t___224;
                    S0::MultiSnakeGame t___225;
                    string t___226;
                    string ? t___116;
                    string t___127;
                    while (running__38)
                    {
                        T::Task<string ?> promise___293;
                        try
                        {
                            promise___293 = W::WsGlobal.WsRecv(connWs__45);
                        }
                        catch
                        {
                            goto CATCH___294;
                        }
                        yield return C::Async.AwakeUpon(promise___293);
                        string ? msg__47;
                        try
                        {
                            t___116 = promise___293.Result;
                            msg__47 = t___116;
                            if (!(msg__47 == null))
                            {
                                t___217 = msg__47 != null;
                            }
                            else
                            {
                                t___217 = false;
                            }
                            if (t___217)
                            {
                                if (msg__47 == null)
                                {
                                    throw new S2::Exception();
                                }
                                else
                                {
                                    t___127 = msg__47!;
                                }
                                if (t___127 == "u")
                                {
                                    t___218 = new S0::Up();
                                    t___219 = S0::SnakeGlobal.ChangePlayerDirection(game__35, connId__44, t___218);
                                    game__35 = t___219;
                                }
                                else
                                {
                                    if (t___127 == "d")
                                    {
                                        t___220 = new S0::Down();
                                        t___221 = S0::SnakeGlobal.ChangePlayerDirection(game__35, connId__44, t___220);
                                        game__35 = t___221;
                                    }
                                    else
                                    {
                                        if (t___127 == "l")
                                        {
                                            t___222 = new S0::Left();
                                            t___223 = S0::SnakeGlobal.ChangePlayerDirection(game__35, connId__44, t___222);
                                            game__35 = t___223;
                                        }
                                        else
                                        {
                                            if (t___127 == "r")
                                            {
                                                t___224 = new S0::Right();
                                                t___225 = S0::SnakeGlobal.ChangePlayerDirection(game__35, connId__44, t___224);
                                                game__35 = t___225;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                t___226 = S2::Convert.ToString(connId__44);
                                console___56.Log("Player " + t___226 + " disconnected");
                                break;
                            }
                        }
                        catch
                        {
                            goto CATCH___294;
                        }
                    }
                    goto OK___295;
                    CATCH___294:
                    {
                    }
                    OK___295:
                    {
                    }
                }
                C::IGenerator<S2::Tuple<object ?>> fn__231()
                {
                    return C::Core.AdaptGenerator<S2::Tuple<object ?>>(coroHelperfn__231);
                }
                try
                {
                    t___132 = promise___292.Result;
                    ws__41 = t___132;
                    playerId__42 = nextId__37;
                    nextId__37 = nextId__37 + 1;
                    game__35 = S0::SnakeGlobal.AddPlayer(game__35, playerId__42 * 7 + 13);
                    C::Listed.Add(wsConns__36, ws__41);
                    symbol__43 = S0::SnakeGlobal.PlayerHeadChar(playerId__42);
                    t___238 = S2::Convert.ToString(playerId__42);
                    console___56.Log("Player " + t___238 + " (" + symbol__43 + ") connected!");
                    connId__44 = playerId__42;
                    connWs__45 = ws__41;
                    C::Async.LaunchGeneratorAsync((S2::Func<G::IEnumerable<S2::Tuple<object ?>>>) fn__231);
                }
                catch
                {
                    goto CATCH___296;
                }
            }
            goto OK___297;
            CATCH___296:
            {
            }
            OK___297:
            {
            }
        }
        internal static C::IGenerator<S2::Tuple<object ?>> fn__268()
        {
            return C::Core.AdaptGenerator<S2::Tuple<object ?>>(coroHelperfn__268);
        }
        static SnakeServerGlobal()
        {
            console___56 = S1::Logging.LoggingConsoleFactory.CreateConsole("SnakeServer");
            detectedCols__31 = I::IoGlobal.TerminalColumns();
            detectedRows__32 = I::IoGlobal.TerminalRows();
            if (detectedCols__31 > 100)
            {
                boardWidth__33 = detectedCols__31 - 4;
            }
            else
            {
                boardWidth__33 = 80;
            }
            if (detectedRows__32 > 30)
            {
                boardHeight__34 = detectedRows__32 - 12;
            }
            else
            {
                boardHeight__34 = 30;
            }
            game__35 = S0::SnakeGlobal.NewMultiGame(boardWidth__33, boardHeight__34, 0, 42);
            wsConns__36 = new G::List<W::IWsConnection>();
            nextId__37 = 0;
            running__38 = true;
            C::Async.LaunchGeneratorAsync((S2::Func<G::IEnumerable<S2::Tuple<object ?>>>) fn__269);
            C::Async.LaunchGeneratorAsync((S2::Func<G::IEnumerable<S2::Tuple<object ?>>>) fn__268);
        }
    }
}
