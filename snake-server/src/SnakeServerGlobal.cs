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
        internal static C::ILoggingConsole console___61;
        internal static int detectedCols__35;
        internal static int detectedRows__36;
        internal static int boardWidth__37;
        internal static int boardHeight__38;
        internal static S0::MultiSnakeGame game__39;
        internal static G::IList<W::IWsConnection> wsConns__40;
        internal static int nextId__41;
        internal static bool running__42;
        static G::IEnumerable<S2::Tuple<object ?>> coroHelperfn__330()
        {
            int t___311;
            G::IReadOnlyList<S0::PlayerSnake> t___312;
            S0::PlayerSnake t___316;
            G::IReadOnlyList<S0::IDirection> t___320;
            S0::MultiSnakeGame t___321;
            while (true)
            {
                T::Task<S2::Tuple<object ?>> promise___345;
                try
                {
                    if (!(game__39.Snakes.Count == 0))
                    {
                        break;
                    }
                    promise___345 = I::IoSupport.StdSleep(500);
                }
                catch
                {
                    goto CATCH___347;
                }
                yield return C::Async.AwakeUpon(promise___345);
                try
                {
                    C::Core.Ignore(promise___345.Result);
                }
                catch
                {
                    goto CATCH___347;
                }
            }
            try
            {
                console___61.Log("Game starting!");
            }
            catch
            {
                goto CATCH___347;
            }
            while (running__42)
            {
                G::IList<S0::IDirection> dirs__55;
                int i__56;
                string frame__58;
                G::IReadOnlyList<W::IWsConnection> conns__59;
                void fn__305(W::IWsConnection conn__60)
                {
                    W::WsGlobal.WsSend(conn__60, frame__58);
                }
                T::Task<S2::Tuple<object ?>> promise___346;
                try
                {
                    dirs__55 = new G::List<S0::IDirection>();
                    i__56 = 0;
                    while (true)
                    {
                        t___311 = game__39.Snakes.Count;
                        if (!(i__56 < t___311))
                        {
                            break;
                        }
                        t___312 = game__39.Snakes;
                        t___316 = new S0::PlayerSnake(0, C::Listed.CreateReadOnlyList<S0::Point>(), new S0::Right(), 0, new S0::Dead());
                        S0::PlayerSnake snake__57 = C::Listed.GetOr(t___312, i__56, t___316);
                        C::Listed.Add(dirs__55, snake__57.Direction);
                        i__56 = i__56 + 1;
                    }
                    t___320 = C::Listed.ToReadOnlyList(dirs__55);
                    t___321 = S0::SnakeGlobal.MultiTick(game__39, t___320);
                    game__39 = t___321;
                    frame__58 = S0::SnakeGlobal.MultiRender(game__39);
                    conns__59 = C::Listed.ToReadOnlyList(wsConns__40);
                    C::Listed.ForEach(conns__59, (S2::Action<W::IWsConnection>) fn__305);
                    promise___346 = I::IoSupport.StdSleep(200);
                }
                catch
                {
                    goto CATCH___347;
                }
                yield return C::Async.AwakeUpon(promise___346);
                try
                {
                    C::Core.Ignore(promise___346.Result);
                }
                catch
                {
                    goto CATCH___347;
                }
            }
            goto OK___348;
            CATCH___347:
            {
            }
            OK___348:
            {
            }
        }
        internal static C::IGenerator<S2::Tuple<object ?>> fn__330()
        {
            return C::Core.AdaptGenerator<S2::Tuple<object ?>>(coroHelperfn__330);
        }
        static G::IEnumerable<S2::Tuple<object ?>> coroHelperfn__329()
        {
            bool t___284;
            S0::MultiSnakeGame t___287;
            string t___289;
            bool t___291;
            S0::Up t___292;
            S0::MultiSnakeGame t___293;
            S0::Down t___294;
            S0::MultiSnakeGame t___295;
            S0::Left t___296;
            S0::MultiSnakeGame t___297;
            S0::Right t___298;
            S0::MultiSnakeGame t___299;
            W::IWsConnection t___151;
            string ? t___152;
            string ? t___154;
            string t___156;
            string t___171;
            W::IWsServer server__44;
            T::Task<W::IWsServer> promise___349;
            try
            {
                console___61.Log("Snake Multiplayer Server");
                console___61.Log("Starting on port 8080...");
                promise___349 = W::WsGlobal.WsListen(8080);
            }
            catch
            {
                goto CATCH___355;
            }
            yield return C::Async.AwakeUpon(promise___349);
            try
            {
                server__44 = promise___349.Result;
                console___61.Log("Listening on ws://localhost:8080");
                console___61.Log("Waiting for players to connect...");
            }
            catch
            {
                goto CATCH___355;
            }
            while (running__42)
            {
                T::Task<W::IWsConnection> promise___350;
                try
                {
                    promise___350 = W::WsGlobal.WsAccept(server__44);
                }
                catch
                {
                    goto CATCH___355;
                }
                yield return C::Async.AwakeUpon(promise___350);
                W::IWsConnection ws__45;
                try
                {
                    t___151 = promise___350.Result;
                    ws__45 = t___151;
                }
                catch
                {
                    goto CATCH___355;
                }
                T::Task<string ?> promise___351;
                try
                {
                    promise___351 = W::WsGlobal.WsRecv(ws__45);
                }
                catch
                {
                    goto CATCH___357;
                }
                yield return C::Async.AwakeUpon(promise___351);
                try
                {
                    t___152 = promise___351.Result;
                    t___154 = t___152;
                }
                catch
                {
                    goto CATCH___357;
                }
                goto OK___358;
                CATCH___357:
                {
                    t___154 = null;
                }
                OK___358:
                {
                }
                string ? firstMsgRaw__46;
                bool isSpectator__47;
                try
                {
                    firstMsgRaw__46 = t___154;
                    isSpectator__47 = false;
                    if (!(firstMsgRaw__46 == null))
                    {
                        t___284 = firstMsgRaw__46 != null;
                    }
                    else
                    {
                        t___284 = false;
                    }
                    if (t___284)
                    {
                        if (firstMsgRaw__46 == null)
                        {
                            throw new S2::Exception();
                        }
                        else
                        {
                            t___156 = firstMsgRaw__46!;
                        }
                        if (t___156 == "spectate")
                        {
                            isSpectator__47 = true;
                        }
                    }
                    if (isSpectator__47)
                    {
                        C::Listed.Add(wsConns__40, ws__45);
                        console___61.Log("Spectator connected!");
                    }
                    else
                    {
                        int playerId__48 = nextId__41;
                        nextId__41 = nextId__41 + 1;
                        t___287 = S0::SnakeGlobal.AddPlayer(game__39, playerId__48 * 7 + 13);
                        game__39 = t___287;
                        C::Listed.Add(wsConns__40, ws__45);
                        string symbol__49 = S0::SnakeGlobal.PlayerHeadChar(playerId__48);
                        t___289 = S2::Convert.ToString(playerId__48);
                        console___61.Log("Player " + t___289 + " (" + symbol__49 + ") connected!");
                        if (!(firstMsgRaw__46 == null))
                        {
                            t___291 = firstMsgRaw__46 != null;
                        }
                        else
                        {
                            t___291 = false;
                        }
                        if (t___291)
                        {
                            if (firstMsgRaw__46 == null)
                            {
                                throw new S2::Exception();
                            }
                            else
                            {
                                t___171 = firstMsgRaw__46!;
                            }
                            if (t___171 == "u")
                            {
                                t___292 = new S0::Up();
                                t___293 = S0::SnakeGlobal.ChangePlayerDirection(game__39, playerId__48, t___292);
                                game__39 = t___293;
                            }
                            else
                            {
                                if (t___171 == "d")
                                {
                                    t___294 = new S0::Down();
                                    t___295 = S0::SnakeGlobal.ChangePlayerDirection(game__39, playerId__48, t___294);
                                    game__39 = t___295;
                                }
                                else
                                {
                                    if (t___171 == "l")
                                    {
                                        t___296 = new S0::Left();
                                        t___297 = S0::SnakeGlobal.ChangePlayerDirection(game__39, playerId__48, t___296);
                                        game__39 = t___297;
                                    }
                                    else
                                    {
                                        if (t___171 == "r")
                                        {
                                            t___298 = new S0::Right();
                                            t___299 = S0::SnakeGlobal.ChangePlayerDirection(game__39, playerId__48, t___298);
                                            game__39 = t___299;
                                        }
                                    }
                                }
                            }
                        }
                        int connId__50 = playerId__48;
                        W::IWsConnection connWs__51 = ws__45;
                        G::IEnumerable<S2::Tuple<object ?>> coroHelperfn__279()
                        {
                            bool t___265;
                            S0::Up t___266;
                            S0::MultiSnakeGame t___267;
                            S0::Down t___268;
                            S0::MultiSnakeGame t___269;
                            S0::Left t___270;
                            S0::MultiSnakeGame t___271;
                            S0::Right t___272;
                            S0::MultiSnakeGame t___273;
                            string t___274;
                            string ? t___135;
                            string t___146;
                            while (running__42)
                            {
                                T::Task<string ?> promise___352;
                                try
                                {
                                    promise___352 = W::WsGlobal.WsRecv(connWs__51);
                                }
                                catch
                                {
                                    goto CATCH___353;
                                }
                                yield return C::Async.AwakeUpon(promise___352);
                                string ? msg__53;
                                try
                                {
                                    t___135 = promise___352.Result;
                                    msg__53 = t___135;
                                    if (!(msg__53 == null))
                                    {
                                        t___265 = msg__53 != null;
                                    }
                                    else
                                    {
                                        t___265 = false;
                                    }
                                    if (t___265)
                                    {
                                        if (msg__53 == null)
                                        {
                                            throw new S2::Exception();
                                        }
                                        else
                                        {
                                            t___146 = msg__53!;
                                        }
                                        if (t___146 == "u")
                                        {
                                            t___266 = new S0::Up();
                                            t___267 = S0::SnakeGlobal.ChangePlayerDirection(game__39, connId__50, t___266);
                                            game__39 = t___267;
                                        }
                                        else
                                        {
                                            if (t___146 == "d")
                                            {
                                                t___268 = new S0::Down();
                                                t___269 = S0::SnakeGlobal.ChangePlayerDirection(game__39, connId__50, t___268);
                                                game__39 = t___269;
                                            }
                                            else
                                            {
                                                if (t___146 == "l")
                                                {
                                                    t___270 = new S0::Left();
                                                    t___271 = S0::SnakeGlobal.ChangePlayerDirection(game__39, connId__50, t___270);
                                                    game__39 = t___271;
                                                }
                                                else
                                                {
                                                    if (t___146 == "r")
                                                    {
                                                        t___272 = new S0::Right();
                                                        t___273 = S0::SnakeGlobal.ChangePlayerDirection(game__39, connId__50, t___272);
                                                        game__39 = t___273;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        t___274 = S2::Convert.ToString(connId__50);
                                        console___61.Log("Player " + t___274 + " disconnected");
                                        break;
                                    }
                                }
                                catch
                                {
                                    goto CATCH___353;
                                }
                            }
                            goto OK___354;
                            CATCH___353:
                            {
                            }
                            OK___354:
                            {
                            }
                        }
                        C::IGenerator<S2::Tuple<object ?>> fn__279()
                        {
                            return C::Core.AdaptGenerator<S2::Tuple<object ?>>(coroHelperfn__279);
                        }
                        C::Async.LaunchGeneratorAsync((S2::Func<G::IEnumerable<S2::Tuple<object ?>>>) fn__279);
                    }
                }
                catch
                {
                    goto CATCH___355;
                }
            }
            goto OK___356;
            CATCH___355:
            {
            }
            OK___356:
            {
            }
        }
        internal static C::IGenerator<S2::Tuple<object ?>> fn__329()
        {
            return C::Core.AdaptGenerator<S2::Tuple<object ?>>(coroHelperfn__329);
        }
        static SnakeServerGlobal()
        {
            console___61 = S1::Logging.LoggingConsoleFactory.CreateConsole("SnakeServer");
            detectedCols__35 = I::IoGlobal.TerminalColumns();
            detectedRows__36 = I::IoGlobal.TerminalRows();
            if (detectedCols__35 > 100)
            {
                boardWidth__37 = detectedCols__35 - 4;
            }
            else
            {
                boardWidth__37 = 80;
            }
            if (detectedRows__36 > 30)
            {
                boardHeight__38 = detectedRows__36 - 12;
            }
            else
            {
                boardHeight__38 = 30;
            }
            game__39 = S0::SnakeGlobal.NewMultiGame(boardWidth__37, boardHeight__38, 0, 42);
            wsConns__40 = new G::List<W::IWsConnection>();
            nextId__41 = 0;
            running__42 = true;
            C::Async.LaunchGeneratorAsync((S2::Func<G::IEnumerable<S2::Tuple<object ?>>>) fn__330);
            C::Async.LaunchGeneratorAsync((S2::Func<G::IEnumerable<S2::Tuple<object ?>>>) fn__329);
        }
    }
}
