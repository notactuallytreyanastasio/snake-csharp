using S = System;
using G = System.Collections.Generic;
using T = System.Text;
using C = TemperLang.Core;
namespace Snake
{
    public static class SnakeGlobal
    {
        public static IDirection Move(Point head__98, G::IReadOnlyList<Point> body__99, Point food__100, int width__101, int height__102)
        {
            return new Right();
        }
        public static bool PointEquals(Point a__115, Point b__116)
        {
            bool return__50;
            int t___2803;
            int t___2804;
            if (a__115.X == b__116.X)
            {
                t___2803 = a__115.Y;
                t___2804 = b__116.Y;
                return__50 = t___2803 == t___2804;
            }
            else
            {
                return__50 = false;
            }
            return return__50;
        }
        public static bool IsOpposite(IDirection a__118, IDirection b__119)
        {
            bool return__51;
            if (a__118 is Up)
            {
                return__51 = b__119 is Down;
            }
            else if (a__118 is Down)
            {
                return__51 = b__119 is Up;
            }
            else if (a__118 is Left)
            {
                return__51 = b__119 is Right;
            }
            else if (a__118 is Right)
            {
                return__51 = b__119 is Left;
            }
            else
            {
                return__51 = false;
            }
            return return__51;
        }
        public static Point DirectionDelta(IDirection dir__121)
        {
            Point return__52;
            if (dir__121 is Up)
            {
                return__52 = new Point(0, -1);
            }
            else if (dir__121 is Down)
            {
                return__52 = new Point(0, 1);
            }
            else if (dir__121 is Left)
            {
                return__52 = new Point(-1, 0);
            }
            else if (dir__121 is Right)
            {
                return__52 = new Point(1, 0);
            }
            else
            {
                return__52 = new Point(0, 0);
            }
            return return__52;
        }
        public static RandomResult NextRandom(int seed__128, int max__129)
        {
            int t___1687;
            int t___1689;
            int raw__131 = seed__128 * 1664525 + 1013904223;
            int masked__132 = raw__131 & 2147483647;
            int posVal__133;
            if (masked__132 < 0)
            {
                posVal__133 = -masked__132;
            }
            else
            {
                posVal__133 = masked__132;
            }
            int value__134 = 0;
            if (max__129 > 0)
            {
                try
                {
                    t___1687 = C::Core.Mod(posVal__133, max__129);
                    t___1689 = t___1687;
                }
                catch
                {
                    t___1689 = 0;
                }
                value__134 = t___1689;
            }
            return new RandomResult(value__134, masked__132);
        }
        internal static FoodPlacement placeFood__93(G::IReadOnlyList<Point> snake__157, int width__158, int height__159, int seed__160)
        {
            FoodPlacement return__61;
            int t___2770;
            Point t___2781;
            int t___1652;
            int t___1654;
            int t___1656;
            int t___1658;
            {
                {
                    int totalCells__162 = width__158 * height__159;
                    int currentSeed__163 = seed__160;
                    int attempt__164 = 0;
                    while (attempt__164 < totalCells__162)
                    {
                        RandomResult result__165 = NextRandom(currentSeed__163, totalCells__162);
                        t___2770 = result__165.NextSeed;
                        currentSeed__163 = t___2770;
                        int px__166 = 0;
                        int py__167 = 0;
                        if (width__158 > 0)
                        {
                            try
                            {
                                t___1652 = C::Core.Mod(result__165.Value, width__158);
                                t___1654 = t___1652;
                            }
                            catch
                            {
                                t___1654 = 0;
                            }
                            px__166 = t___1654;
                            try
                            {
                                t___1656 = C::Core.Div(result__165.Value, width__158);
                                t___1658 = t___1656;
                            }
                            catch
                            {
                                t___1658 = 0;
                            }
                            py__167 = t___1658;
                        }
                        Point candidate__168 = new Point(px__166, py__167);
                        bool occupied__169 = false;
                        void fn__2769(Point seg__170)
                        {
                            if (PointEquals(seg__170, candidate__168))
                            {
                                occupied__169 = true;
                            }
                        }
                        C::Listed.ForEach(snake__157, (S::Action<Point>) fn__2769);
                        if (!occupied__169)
                        {
                            return__61 = new FoodPlacement(candidate__168, currentSeed__163);
                            goto fn__161;
                        }
                        attempt__164 = attempt__164 + 1;
                    }
                    int y__171 = 0;
                    while (y__171 < height__159)
                    {
                        int x__172 = 0;
                        while (x__172 < width__158)
                        {
                            Point candidate__173 = new Point(x__172, y__171);
                            bool free__174 = true;
                            void fn__2768(Point seg__175)
                            {
                                if (PointEquals(seg__175, candidate__173))
                                {
                                    free__174 = false;
                                }
                            }
                            C::Listed.ForEach(snake__157, (S::Action<Point>) fn__2768);
                            if (free__174)
                            {
                                return__61 = new FoodPlacement(candidate__173, currentSeed__163);
                                goto fn__161;
                            }
                            x__172 = x__172 + 1;
                        }
                        y__171 = y__171 + 1;
                    }
                    t___2781 = new Point(0, 0);
                    return__61 = new FoodPlacement(t___2781, currentSeed__163);
                }
                fn__161:
                {
                }
            }
            return return__61;
        }
        public static SnakeGame NewGame(int width__176, int height__177, int seed__178)
        {
            int t___1635;
            int t___1637;
            int t___1638;
            int t___1640;
            int centerX__180 = 0;
            int centerY__181 = 0;
            if (width__176 > 0)
            {
                t___1635 = C::Core.DivSafe(width__176, 2);
                t___1637 = t___1635;
                centerX__180 = t___1637;
            }
            if (height__177 > 0)
            {
                t___1638 = C::Core.DivSafe(height__177, 2);
                t___1640 = t___1638;
                centerY__181 = t___1640;
            }
            G::IReadOnlyList<Point> snake__182 = C::Listed.CreateReadOnlyList<Point>(new Point(centerX__180, centerY__181), new Point(centerX__180 - 1, centerY__181), new Point(centerX__180 - 2, centerY__181));
            FoodPlacement foodResult__183 = placeFood__93(snake__182, width__176, height__177, seed__178);
            Right t___2763 = new Right();
            Point t___2764 = foodResult__183.Point;
            Playing t___2765 = new Playing();
            int t___2766 = foodResult__183.Seed;
            return new SnakeGame(width__176, height__177, snake__182, t___2763, t___2764, 0, t___2765, t___2766);
        }
        public static SnakeGame ChangeDirection(SnakeGame game__184, IDirection dir__185)
        {
            SnakeGame return__63;
            int t___2751;
            int t___2752;
            G::IReadOnlyList<Point> t___2753;
            Point t___2754;
            int t___2755;
            IGameStatus t___2756;
            int t___2757;
            if (IsOpposite(game__184.Direction, dir__185))
            {
                return__63 = game__184;
            }
            else
            {
                t___2751 = game__184.Width;
                t___2752 = game__184.Height;
                t___2753 = game__184.Snake;
                t___2754 = game__184.Food;
                t___2755 = game__184.Score;
                t___2756 = game__184.Status;
                t___2757 = game__184.RngSeed;
                return__63 = new SnakeGame(t___2751, t___2752, t___2753, dir__185, t___2754, t___2755, t___2756, t___2757);
            }
            return return__63;
        }
        public static SnakeGame Tick(SnakeGame game__187)
        {
            SnakeGame return__64;
            int t___2691;
            int t___2692;
            int t___2693;
            int t___2694;
            G::IReadOnlyList<Point> t___2695;
            IDirection t___2696;
            Point t___2697;
            int t___2698;
            GameOver t___2699;
            int t___2700;
            int t___2704;
            int t___2706;
            G::IReadOnlyList<Point> t___2707;
            Point t___2708;
            int t___2710;
            int t___2711;
            G::IReadOnlyList<Point> t___2712;
            IDirection t___2713;
            Point t___2714;
            int t___2715;
            GameOver t___2716;
            int t___2717;
            int t___2722;
            int t___2724;
            G::IReadOnlyList<Point> t___2725;
            Point t___2726;
            int t___2731;
            int t___2732;
            int t___2733;
            int t___2735;
            int t___2736;
            IDirection t___2737;
            Point t___2738;
            Playing t___2739;
            int t___2740;
            int t___2742;
            int t___2743;
            IDirection t___2744;
            Point t___2745;
            int t___2746;
            IGameStatus t___2747;
            int t___2748;
            bool t___1562;
            bool t___1563;
            bool t___1564;
            {
                {
                    if (game__187.Status is GameOver)
                    {
                        return__64 = game__187;
                        goto fn__188;
                    }
                    Point delta__189 = DirectionDelta(game__187.Direction);
                    Point head__190 = C::Listed.GetOr(game__187.Snake, 0, new Point(0, 0));
                    Point newHead__191 = new Point(head__190.X + delta__189.X, head__190.Y + delta__189.Y);
                    if (newHead__191.X < 0)
                    {
                        t___1564 = true;
                    }
                    else
                    {
                        if (newHead__191.X >= game__187.Width)
                        {
                            t___1563 = true;
                        }
                        else
                        {
                            if (newHead__191.Y < 0)
                            {
                                t___1562 = true;
                            }
                            else
                            {
                                t___2691 = newHead__191.Y;
                                t___2692 = game__187.Height;
                                t___1562 = t___2691 >= t___2692;
                            }
                            t___1563 = t___1562;
                        }
                        t___1564 = t___1563;
                    }
                    if (t___1564)
                    {
                        t___2693 = game__187.Width;
                        t___2694 = game__187.Height;
                        t___2695 = game__187.Snake;
                        t___2696 = game__187.Direction;
                        t___2697 = game__187.Food;
                        t___2698 = game__187.Score;
                        t___2699 = new GameOver();
                        t___2700 = game__187.RngSeed;
                        return__64 = new SnakeGame(t___2693, t___2694, t___2695, t___2696, t___2697, t___2698, t___2699, t___2700);
                        goto fn__188;
                    }
                    bool eating__192 = PointEquals(newHead__191, game__187.Food);
                    int checkLength__193;
                    if (eating__192)
                    {
                        t___2704 = game__187.Snake.Count;
                        checkLength__193 = t___2704;
                    }
                    else
                    {
                        t___2706 = game__187.Snake.Count;
                        checkLength__193 = t___2706 - 1;
                    }
                    int i__194 = 0;
                    while (i__194 < checkLength__193)
                    {
                        t___2707 = game__187.Snake;
                        t___2708 = new Point(-1, -1);
                        if (PointEquals(newHead__191, C::Listed.GetOr(t___2707, i__194, t___2708)))
                        {
                            t___2710 = game__187.Width;
                            t___2711 = game__187.Height;
                            t___2712 = game__187.Snake;
                            t___2713 = game__187.Direction;
                            t___2714 = game__187.Food;
                            t___2715 = game__187.Score;
                            t___2716 = new GameOver();
                            t___2717 = game__187.RngSeed;
                            return__64 = new SnakeGame(t___2710, t___2711, t___2712, t___2713, t___2714, t___2715, t___2716, t___2717);
                            goto fn__188;
                        }
                        i__194 = i__194 + 1;
                    }
                    G::IList<Point> newSnakeBuilder__195 = new G::List<Point>();
                    C::Listed.Add(newSnakeBuilder__195, newHead__191);
                    int keepLength__196;
                    if (eating__192)
                    {
                        t___2722 = game__187.Snake.Count;
                        keepLength__196 = t___2722;
                    }
                    else
                    {
                        t___2724 = game__187.Snake.Count;
                        keepLength__196 = t___2724 - 1;
                    }
                    int i__197 = 0;
                    while (i__197 < keepLength__196)
                    {
                        t___2725 = game__187.Snake;
                        t___2726 = new Point(0, 0);
                        C::Listed.Add(newSnakeBuilder__195, C::Listed.GetOr(t___2725, i__197, t___2726));
                        i__197 = i__197 + 1;
                    }
                    G::IReadOnlyList<Point> newSnake__198 = C::Listed.ToReadOnlyList(newSnakeBuilder__195);
                    if (eating__192)
                    {
                        int newScore__199 = game__187.Score + 1;
                        t___2731 = game__187.Width;
                        t___2732 = game__187.Height;
                        t___2733 = game__187.RngSeed;
                        FoodPlacement foodResult__200 = placeFood__93(newSnake__198, t___2731, t___2732, t___2733);
                        t___2735 = game__187.Width;
                        t___2736 = game__187.Height;
                        t___2737 = game__187.Direction;
                        t___2738 = foodResult__200.Point;
                        t___2739 = new Playing();
                        t___2740 = foodResult__200.Seed;
                        return__64 = new SnakeGame(t___2735, t___2736, newSnake__198, t___2737, t___2738, newScore__199, t___2739, t___2740);
                    }
                    else
                    {
                        t___2742 = game__187.Width;
                        t___2743 = game__187.Height;
                        t___2744 = game__187.Direction;
                        t___2745 = game__187.Food;
                        t___2746 = game__187.Score;
                        t___2747 = game__187.Status;
                        t___2748 = game__187.RngSeed;
                        return__64 = new SnakeGame(t___2742, t___2743, newSnake__198, t___2744, t___2745, t___2746, t___2747, t___2748);
                    }
                }
                fn__188:
                {
                }
            }
            return return__64;
        }
        internal static string cellChar__94(SnakeGame game__210, Point p__211)
        {
            string return__66;
            int t___2670;
            G::IReadOnlyList<Point> t___2671;
            Point t___2672;
            Point t___2673;
            Point t___2674;
            {
                {
                    Point head__213 = C::Listed.GetOr(game__210.Snake, 0, new Point(-1, -1));
                    if (PointEquals(p__211, head__213))
                    {
                        return__66 = "@";
                        goto fn__212;
                    }
                    int i__214 = 1;
                    while (true)
                    {
                        t___2670 = game__210.Snake.Count;
                        if (!(i__214 < t___2670)) break;
                        t___2671 = game__210.Snake;
                        t___2672 = new Point(-1, -1);
                        t___2673 = C::Listed.GetOr(t___2671, i__214, t___2672);
                        if (PointEquals(p__211, t___2673))
                        {
                            return__66 = "o";
                            goto fn__212;
                        }
                        i__214 = i__214 + 1;
                    }
                    t___2674 = game__210.Food;
                    if (PointEquals(p__211, t___2674))
                    {
                        return__66 = "*";
                        goto fn__212;
                    }
                    return__66 = " ";
                }
                fn__212:
                {
                }
            }
            return return__66;
        }
        public static string Render(SnakeGame game__201)
        {
            int t___2645;
            int t___2648;
            int t___2650;
            int t___2656;
            T::StringBuilder sb__203 = new T::StringBuilder();
            sb__203.Append("\u001b[2J\u001b[H");
            sb__203.Append("#");
            int x__204 = 0;
            while (true)
            {
                t___2645 = game__201.Width;
                if (!(x__204 < t___2645)) break;
                sb__203.Append("#");
                x__204 = x__204 + 1;
            }
            sb__203.Append("#\r\n");
            int y__205 = 0;
            while (true)
            {
                t___2648 = game__201.Height;
                if (!(y__205 < t___2648)) break;
                sb__203.Append("#");
                int x__206 = 0;
                while (true)
                {
                    t___2650 = game__201.Width;
                    if (!(x__206 < t___2650)) break;
                    Point p__207 = new Point(x__206, y__205);
                    sb__203.Append(cellChar__94(game__201, p__207));
                    x__206 = x__206 + 1;
                }
                sb__203.Append("#\r\n");
                y__205 = y__205 + 1;
            }
            sb__203.Append("#");
            int x__208 = 0;
            while (true)
            {
                t___2656 = game__201.Width;
                if (!(x__208 < t___2656)) break;
                sb__203.Append("#");
                x__208 = x__208 + 1;
            }
            sb__203.Append("#\r\n");
            string statusText__209;
            IGameStatus t___2659 = game__201.Status;
            if (t___2659 is Playing)
            {
                statusText__209 = "Playing";
            }
            else if (t___2659 is GameOver)
            {
                statusText__209 = "GAME OVER";
            }
            else
            {
                statusText__209 = "";
            }
            sb__203.Append("Score: " + S::Convert.ToString(game__201.Score) + "  " + statusText__209 + "\r" + "\n");
            return sb__203.ToString();
        }
        internal static SpawnInfo spawnPosition__95(int width__262, int height__263, int index__264, int seed__265)
        {
            SpawnInfo return__80;
            Point t___2624;
            Right t___2625;
            IDirection t___2631;
            IDirection t___2633;
            IDirection t___2635;
            IDirection t___2637;
            IDirection t___2639;
            Point t___2640;
            bool t___1463;
            int t___1464;
            int t___1466;
            int t___1467;
            int t___1469;
            {
                {
                    int buf__267 = 5;
                    int safeW__268 = width__262 - 10;
                    int safeH__269 = height__263 - 10;
                    if (safeW__268 < 1)
                    {
                        t___1463 = true;
                    }
                    else
                    {
                        t___1463 = safeH__269 < 1;
                    }
                    if (t___1463)
                    {
                        t___1464 = C::Core.DivSafe(width__262, 2);
                        t___1466 = t___1464;
                        t___1467 = C::Core.DivSafe(height__263, 2);
                        t___1469 = t___1467;
                        t___2624 = new Point(t___1466, t___1469);
                        t___2625 = new Right();
                        return__80 = new SpawnInfo(t___2624, t___2625);
                        goto fn__266;
                    }
                    RandomResult r1__270 = NextRandom(seed__265 * 7 + index__264 * 131 + 37, safeW__268);
                    RandomResult r2__271 = NextRandom(r1__270.NextSeed, safeH__269);
                    int x__272 = 5 + r1__270.Value;
                    int y__273 = 5 + r2__271.Value;
                    RandomResult r3__274 = NextRandom(r2__271.NextSeed, 4);
                    t___2631 = new Right();
                    IDirection dir__275 = t___2631;
                    if (r3__274.Value == 0)
                    {
                        t___2633 = new Right();
                        dir__275 = t___2633;
                    }
                    if (r3__274.Value == 1)
                    {
                        t___2635 = new Left();
                        dir__275 = t___2635;
                    }
                    if (r3__274.Value == 2)
                    {
                        t___2637 = new Down();
                        dir__275 = t___2637;
                    }
                    if (r3__274.Value == 3)
                    {
                        t___2639 = new Up();
                        dir__275 = t___2639;
                    }
                    t___2640 = new Point(x__272, y__273);
                    return__80 = new SpawnInfo(t___2640, dir__275);
                }
                fn__266:
                {
                }
            }
            return return__80;
        }
        internal static G::IReadOnlyList<Point> collectAllSegments__96(G::IReadOnlyList<PlayerSnake> snakes__276)
        {
            int t___2611;
            PlayerSnake t___2615;
            int t___2618;
            G::IReadOnlyList<Point> t___2619;
            Point t___2620;
            G::IList<Point> builder__278 = new G::List<Point>();
            int i__279 = 0;
            while (true)
            {
                t___2611 = snakes__276.Count;
                if (!(i__279 < t___2611)) break;
                t___2615 = new PlayerSnake(0, C::Listed.CreateReadOnlyList<Point>(), new Right(), 0, new Dead());
                PlayerSnake snake__280 = C::Listed.GetOr(snakes__276, i__279, t___2615);
                int j__281 = 0;
                while (true)
                {
                    t___2618 = snake__280.Segments.Count;
                    if (!(j__281 < t___2618)) break;
                    t___2619 = snake__280.Segments;
                    t___2620 = new Point(0, 0);
                    C::Listed.Add(builder__278, C::Listed.GetOr(t___2619, j__281, t___2620));
                    j__281 = j__281 + 1;
                }
                i__279 = i__279 + 1;
            }
            return C::Listed.ToReadOnlyList(builder__278);
        }
        public static MultiSnakeGame NewMultiGame(int width__241, int height__242, int numPlayers__243, int seed__244)
        {
            Alive t___2600;
            G::IList<PlayerSnake> snakeBuilder__246 = new G::List<PlayerSnake>();
            int currentSeed__247 = seed__244;
            int i__248 = 0;
            while (i__248 < numPlayers__243)
            {
                SpawnInfo spawn__249 = spawnPosition__95(width__241, height__242, i__248, currentSeed__247);
                IDirection dir__250 = spawn__249.Direction;
                int startX__251 = spawn__249.Point.X;
                int startY__252 = spawn__249.Point.Y;
                Point delta__253 = DirectionDelta(dir__250);
                G::IReadOnlyList<Point> segments__254 = C::Listed.CreateReadOnlyList<Point>(new Point(startX__251, startY__252), new Point(startX__251 - delta__253.X, startY__252 - delta__253.Y), new Point(startX__251 - delta__253.X * 2, startY__252 - delta__253.Y * 2));
                t___2600 = new Alive();
                C::Listed.Add(snakeBuilder__246, new PlayerSnake(i__248, segments__254, dir__250, 0, t___2600));
                i__248 = i__248 + 1;
            }
            G::IReadOnlyList<PlayerSnake> t___2603 = C::Listed.ToReadOnlyList(snakeBuilder__246);
            G::IReadOnlyList<Point> allSegments__255 = collectAllSegments__96(t___2603);
            FoodPlacement foodResult__256 = placeFood__93(allSegments__255, width__241, height__242, currentSeed__247);
            G::IReadOnlyList<PlayerSnake> t___2606 = C::Listed.ToReadOnlyList(snakeBuilder__246);
            Point t___2607 = foodResult__256.Point;
            int t___2608 = foodResult__256.Seed;
            return new MultiSnakeGame(width__241, height__242, t___2606, t___2607, t___2608, 0);
        }
        public static MultiSnakeGame MultiTick(MultiSnakeGame game__282, G::IReadOnlyList<IDirection> directions__283)
        {
            int t___2429;
            G::IReadOnlyList<PlayerSnake> t___2430;
            PlayerSnake t___2434;
            IDirection t___2436;
            int t___2444;
            G::IReadOnlyList<PlayerSnake> t___2445;
            PlayerSnake t___2449;
            G::IReadOnlyList<IDirection> t___2453;
            Right t___2454;
            int t___2472;
            G::IReadOnlyList<PlayerSnake> t___2473;
            PlayerSnake t___2477;
            Point t___2482;
            int t___2488;
            int t___2489;
            int t___2491;
            G::IReadOnlyList<Point> t___2492;
            Point t___2493;
            int t___2496;
            G::IReadOnlyList<PlayerSnake> t___2497;
            PlayerSnake t___2501;
            int t___2506;
            G::IReadOnlyList<Point> t___2507;
            Point t___2508;
            int t___2511;
            G::IReadOnlyList<PlayerSnake> t___2512;
            PlayerSnake t___2516;
            Point t___2520;
            int t___2525;
            Point t___2527;
            int t___2532;
            G::IReadOnlyList<PlayerSnake> t___2533;
            PlayerSnake t___2537;
            Point t___2550;
            IDirection t___2552;
            int t___2555;
            int t___2557;
            G::IReadOnlyList<Point> t___2560;
            Point t___2561;
            int t___2564;
            int t___2565;
            int t___2575;
            int t___2576;
            int t___2577;
            Point t___2579;
            int t___2580;
            bool t___1325;
            bool t___1326;
            bool t___1327;
            int t___1397;
            int t___1405;
            G::IList<IDirection> newDirs__285 = new G::List<IDirection>();
            int i__286 = 0;
            while (true)
            {
                t___2429 = game__282.Snakes.Count;
                if (!(i__286 < t___2429)) break;
                t___2430 = game__282.Snakes;
                t___2434 = new PlayerSnake(0, C::Listed.CreateReadOnlyList<Point>(), new Right(), 0, new Dead());
                PlayerSnake snake__287 = C::Listed.GetOr(t___2430, i__286, t___2434);
                t___2436 = snake__287.Direction;
                IDirection inputDir__288 = C::Listed.GetOr(directions__283, i__286, t___2436);
                if (IsOpposite(snake__287.Direction, inputDir__288)) C::Listed.Add(newDirs__285, snake__287.Direction);
                else C::Listed.Add(newDirs__285, inputDir__288);
                i__286 = i__286 + 1;
            }
            G::IList<Point> newHeads__289 = new G::List<Point>();
            int i__290 = 0;
            while (true)
            {
                t___2444 = game__282.Snakes.Count;
                if (!(i__290 < t___2444)) break;
                t___2445 = game__282.Snakes;
                t___2449 = new PlayerSnake(0, C::Listed.CreateReadOnlyList<Point>(), new Right(), 0, new Dead());
                PlayerSnake snake__291 = C::Listed.GetOr(t___2445, i__290, t___2449);
                if (snake__291.Status is Alive)
                {
                    t___2453 = C::Listed.ToReadOnlyList(newDirs__285);
                    t___2454 = new Right();
                    IDirection dir__292 = C::Listed.GetOr(t___2453, i__290, t___2454);
                    Point delta__293 = DirectionDelta(dir__292);
                    Point head__294 = C::Listed.GetOr(snake__291.Segments, 0, new Point(0, 0));
                    C::Listed.Add(newHeads__289, new Point(head__294.X + delta__293.X, head__294.Y + delta__293.Y));
                }
                else C::Listed.Add(newHeads__289, new Point(-1, -1));
                i__290 = i__290 + 1;
            }
            G::IReadOnlyList<Point> headsList__295 = C::Listed.ToReadOnlyList(newHeads__289);
            G::IReadOnlyList<IDirection> dirsList__296 = C::Listed.ToReadOnlyList(newDirs__285);
            G::IList<bool> aliveBuilder__297 = new G::List<bool>();
            int i__298 = 0;
            while (true)
            {
                t___2472 = game__282.Snakes.Count;
                if (!(i__298 < t___2472)) break;
                t___2473 = game__282.Snakes;
                t___2477 = new PlayerSnake(0, C::Listed.CreateReadOnlyList<Point>(), new Right(), 0, new Dead());
                PlayerSnake snake__299 = C::Listed.GetOr(t___2473, i__298, t___2477);
                if (!(snake__299.Status is Alive)) C::Listed.Add(aliveBuilder__297, false);
                else
                {
                    t___2482 = new Point(-1, -1);
                    Point nh__300 = C::Listed.GetOr(headsList__295, i__298, t___2482);
                    bool dead__301 = false;
                    if (nh__300.X < 0)
                    {
                        t___1327 = true;
                    }
                    else
                    {
                        if (nh__300.X >= game__282.Width)
                        {
                            t___1326 = true;
                        }
                        else
                        {
                            if (nh__300.Y < 0)
                            {
                                t___1325 = true;
                            }
                            else
                            {
                                t___2488 = nh__300.Y;
                                t___2489 = game__282.Height;
                                t___1325 = t___2488 >= t___2489;
                            }
                            t___1326 = t___1325;
                        }
                        t___1327 = t___1326;
                    }
                    if (t___1327)
                    {
                        dead__301 = true;
                    }
                    if (!dead__301)
                    {
                        int s__302 = 0;
                        while (true)
                        {
                            t___2491 = snake__299.Segments.Count;
                            if (!(s__302 < t___2491 - 1)) break;
                            t___2492 = snake__299.Segments;
                            t___2493 = new Point(-2, -2);
                            if (PointEquals(nh__300, C::Listed.GetOr(t___2492, s__302, t___2493)))
                            {
                                dead__301 = true;
                            }
                            s__302 = s__302 + 1;
                        }
                    }
                    if (!dead__301)
                    {
                        int j__303 = 0;
                        while (true)
                        {
                            t___2496 = game__282.Snakes.Count;
                            if (!(j__303 < t___2496)) break;
                            if (j__303 != i__298)
                            {
                                t___2497 = game__282.Snakes;
                                t___2501 = new PlayerSnake(0, C::Listed.CreateReadOnlyList<Point>(), new Right(), 0, new Dead());
                                PlayerSnake other__304 = C::Listed.GetOr(t___2497, j__303, t___2501);
                                if (other__304.Status is Alive)
                                {
                                    int s__305 = 0;
                                    while (true)
                                    {
                                        t___2506 = other__304.Segments.Count;
                                        if (!(s__305 < t___2506 - 1)) break;
                                        t___2507 = other__304.Segments;
                                        t___2508 = new Point(-2, -2);
                                        if (PointEquals(nh__300, C::Listed.GetOr(t___2507, s__305, t___2508)))
                                        {
                                            dead__301 = true;
                                        }
                                        s__305 = s__305 + 1;
                                    }
                                }
                            }
                            j__303 = j__303 + 1;
                        }
                    }
                    if (!dead__301)
                    {
                        int j__306 = 0;
                        while (true)
                        {
                            t___2511 = game__282.Snakes.Count;
                            if (!(j__306 < t___2511)) break;
                            if (j__306 != i__298)
                            {
                                t___2512 = game__282.Snakes;
                                t___2516 = new PlayerSnake(0, C::Listed.CreateReadOnlyList<Point>(), new Right(), 0, new Dead());
                                PlayerSnake otherSnake__307 = C::Listed.GetOr(t___2512, j__306, t___2516);
                                if (otherSnake__307.Status is Alive)
                                {
                                    t___2520 = new Point(-3, -3);
                                    Point otherHead__308 = C::Listed.GetOr(headsList__295, j__306, t___2520);
                                    if (PointEquals(nh__300, otherHead__308))
                                    {
                                        dead__301 = true;
                                    }
                                }
                            }
                            j__306 = j__306 + 1;
                        }
                    }
                    C::Listed.Add(aliveBuilder__297, !dead__301);
                }
                i__298 = i__298 + 1;
            }
            G::IReadOnlyList<bool> aliveList__309 = C::Listed.ToReadOnlyList(aliveBuilder__297);
            int eaterIndex__310 = -1;
            int i__311 = 0;
            while (true)
            {
                t___2525 = game__282.Snakes.Count;
                if (!(i__311 < t___2525)) break;
                if (C::Listed.GetOr(aliveList__309, i__311, false))
                {
                    t___2527 = new Point(-1, -1);
                    Point nh__312 = C::Listed.GetOr(headsList__295, i__311, t___2527);
                    if (PointEquals(nh__312, game__282.Food))
                    {
                        eaterIndex__310 = i__311;
                    }
                }
                i__311 = i__311 + 1;
            }
            G::IList<PlayerSnake> resultSnakes__313 = new G::List<PlayerSnake>();
            int i__314 = 0;
            while (true)
            {
                t___2532 = game__282.Snakes.Count;
                if (!(i__314 < t___2532)) break;
                t___2533 = game__282.Snakes;
                t___2537 = new PlayerSnake(0, C::Listed.CreateReadOnlyList<Point>(), new Right(), 0, new Dead());
                PlayerSnake snake__315 = C::Listed.GetOr(t___2533, i__314, t___2537);
                if (!(snake__315.Status is Alive)) C::Listed.Add(resultSnakes__313, snake__315);
                else if (!C::Listed.GetOr(aliveList__309, i__314, false)) C::Listed.Add(resultSnakes__313, new PlayerSnake(snake__315.Id, snake__315.Segments, snake__315.Direction, snake__315.Score, new Dead()));
                else
                {
                    t___2550 = new Point(0, 0);
                    Point nh__316 = C::Listed.GetOr(headsList__295, i__314, t___2550);
                    t___2552 = snake__315.Direction;
                    IDirection dir__317 = C::Listed.GetOr(dirsList__296, i__314, t___2552);
                    bool isEating__318 = i__314 == eaterIndex__310;
                    if (isEating__318)
                    {
                        t___2555 = snake__315.Segments.Count;
                        t___1397 = t___2555;
                    }
                    else
                    {
                        t___2557 = snake__315.Segments.Count;
                        t___1397 = t___2557 - 1;
                    }
                    int keepLen__319 = t___1397;
                    G::IList<Point> newSegs__320 = new G::List<Point>();
                    C::Listed.Add(newSegs__320, nh__316);
                    int s__321 = 0;
                    while (s__321 < keepLen__319)
                    {
                        t___2560 = snake__315.Segments;
                        t___2561 = new Point(0, 0);
                        C::Listed.Add(newSegs__320, C::Listed.GetOr(t___2560, s__321, t___2561));
                        s__321 = s__321 + 1;
                    }
                    if (isEating__318)
                    {
                        t___2564 = snake__315.Score;
                        t___1405 = t___2564 + 1;
                    }
                    else
                    {
                        t___2565 = snake__315.Score;
                        t___1405 = t___2565;
                    }
                    int newScore__322 = t___1405;
                    C::Listed.Add(resultSnakes__313, new PlayerSnake(snake__315.Id, C::Listed.ToReadOnlyList(newSegs__320), dir__317, newScore__322, new Alive()));
                }
                i__314 = i__314 + 1;
            }
            G::IReadOnlyList<PlayerSnake> resultSnakesList__323 = C::Listed.ToReadOnlyList(resultSnakes__313);
            Point t___2572 = game__282.Food;
            Point newFood__324 = t___2572;
            int t___2573 = game__282.RngSeed;
            int newSeed__325 = t___2573;
            if (eaterIndex__310 >= 0)
            {
                G::IReadOnlyList<Point> allSegs__326 = collectAllSegments__96(resultSnakesList__323);
                t___2575 = game__282.Width;
                t___2576 = game__282.Height;
                t___2577 = game__282.RngSeed;
                FoodPlacement foodResult__327 = placeFood__93(allSegs__326, t___2575, t___2576, t___2577);
                t___2579 = foodResult__327.Point;
                newFood__324 = t___2579;
                t___2580 = foodResult__327.Seed;
                newSeed__325 = t___2580;
            }
            int t___2581 = game__282.Width;
            int t___2582 = game__282.Height;
            int t___2583 = game__282.TickCount;
            return new MultiSnakeGame(t___2581, t___2582, resultSnakesList__323, newFood__324, newSeed__325, t___2583 + 1);
        }
        public static MultiSnakeGame ChangePlayerDirection(MultiSnakeGame game__328, int playerId__329, IDirection dir__330)
        {
            int t___2402;
            G::IReadOnlyList<PlayerSnake> t___2403;
            PlayerSnake t___2407;
            IDirection t___2412;
            int t___2413;
            G::IReadOnlyList<Point> t___2414;
            int t___2415;
            IPlayerStatus t___2416;
            bool t___1250;
            bool t___1251;
            G::IList<PlayerSnake> newSnakes__332 = new G::List<PlayerSnake>();
            int i__333 = 0;
            while (true)
            {
                t___2402 = game__328.Snakes.Count;
                if (!(i__333 < t___2402)) break;
                t___2403 = game__328.Snakes;
                t___2407 = new PlayerSnake(0, C::Listed.CreateReadOnlyList<Point>(), new Right(), 0, new Dead());
                PlayerSnake snake__334 = C::Listed.GetOr(t___2403, i__333, t___2407);
                if (snake__334.Id == playerId__329)
                {
                    if (snake__334.Status is Alive)
                    {
                        t___2412 = snake__334.Direction;
                        t___1250 = !IsOpposite(t___2412, dir__330);
                    }
                    else
                    {
                        t___1250 = false;
                    }
                    t___1251 = t___1250;
                }
                else
                {
                    t___1251 = false;
                }
                if (t___1251)
                {
                    t___2413 = snake__334.Id;
                    t___2414 = snake__334.Segments;
                    t___2415 = snake__334.Score;
                    t___2416 = snake__334.Status;
                    C::Listed.Add(newSnakes__332, new PlayerSnake(t___2413, t___2414, dir__330, t___2415, t___2416));
                }
                else C::Listed.Add(newSnakes__332, snake__334);
                i__333 = i__333 + 1;
            }
            return new MultiSnakeGame(game__328.Width, game__328.Height, C::Listed.ToReadOnlyList(newSnakes__332), game__328.Food, game__328.RngSeed, game__328.TickCount);
        }
        public static bool IsMultiGameOver(MultiSnakeGame game__335)
        {
            bool return__84;
            int t___2387;
            G::IReadOnlyList<PlayerSnake> t___2388;
            PlayerSnake t___2392;
            int aliveCount__337 = 0;
            int i__338 = 0;
            while (true)
            {
                t___2387 = game__335.Snakes.Count;
                if (!(i__338 < t___2387)) break;
                t___2388 = game__335.Snakes;
                t___2392 = new PlayerSnake(0, C::Listed.CreateReadOnlyList<Point>(), new Right(), 0, new Dead());
                PlayerSnake snake__339 = C::Listed.GetOr(t___2388, i__338, t___2392);
                if (snake__339.Status is Alive)
                {
                    aliveCount__337 = aliveCount__337 + 1;
                }
                i__338 = i__338 + 1;
            }
            if (game__335.Snakes.Count == 0)
            {
                return__84 = false;
            }
            else if (game__335.Snakes.Count == 1)
            {
                return__84 = aliveCount__337 == 0;
            }
            else
            {
                return__84 = aliveCount__337 <= 1;
            }
            return return__84;
        }
        public static MultiSnakeGame AddPlayer(MultiSnakeGame game__340, int seed__341)
        {
            int t___2365;
            G::IReadOnlyList<PlayerSnake> t___2366;
            PlayerSnake t___2370;
            int newId__343 = game__340.Snakes.Count;
            SpawnInfo spawn__344 = spawnPosition__95(game__340.Width, game__340.Height, newId__343, seed__341);
            IDirection dir__345 = spawn__344.Direction;
            Point delta__346 = DirectionDelta(dir__345);
            int startX__347 = spawn__344.Point.X;
            int startY__348 = spawn__344.Point.Y;
            G::IReadOnlyList<Point> segments__349 = C::Listed.CreateReadOnlyList<Point>(new Point(startX__347, startY__348), new Point(startX__347 - delta__346.X, startY__348 - delta__346.Y), new Point(startX__347 - delta__346.X * 2, startY__348 - delta__346.Y * 2));
            PlayerSnake newSnake__350 = new PlayerSnake(newId__343, segments__349, dir__345, 0, new Alive());
            G::IList<PlayerSnake> builder__351 = new G::List<PlayerSnake>();
            int i__352 = 0;
            while (true)
            {
                t___2365 = game__340.Snakes.Count;
                if (!(i__352 < t___2365)) break;
                t___2366 = game__340.Snakes;
                t___2370 = new PlayerSnake(0, C::Listed.CreateReadOnlyList<Point>(), new Right(), 0, new Dead());
                C::Listed.Add(builder__351, C::Listed.GetOr(t___2366, i__352, t___2370));
                i__352 = i__352 + 1;
            }
            C::Listed.Add(builder__351, newSnake__350);
            G::IReadOnlyList<PlayerSnake> t___2374 = C::Listed.ToReadOnlyList(builder__351);
            G::IReadOnlyList<Point> allSegs__353 = collectAllSegments__96(t___2374);
            int t___2376 = game__340.Width;
            int t___2377 = game__340.Height;
            FoodPlacement foodResult__354 = placeFood__93(allSegs__353, t___2376, t___2377, seed__341);
            return new MultiSnakeGame(game__340.Width, game__340.Height, C::Listed.ToReadOnlyList(builder__351), foodResult__354.Point, foodResult__354.Seed, game__340.TickCount);
        }
        public static MultiSnakeGame RemovePlayer(MultiSnakeGame game__355, int playerId__356)
        {
            int t___2327;
            G::IReadOnlyList<PlayerSnake> t___2328;
            PlayerSnake t___2332;
            G::IList<PlayerSnake> builder__358 = new G::List<PlayerSnake>();
            int i__359 = 0;
            while (true)
            {
                t___2327 = game__355.Snakes.Count;
                if (!(i__359 < t___2327)) break;
                t___2328 = game__355.Snakes;
                t___2332 = new PlayerSnake(0, C::Listed.CreateReadOnlyList<Point>(), new Right(), 0, new Dead());
                PlayerSnake snake__360 = C::Listed.GetOr(t___2328, i__359, t___2332);
                if (snake__360.Id != playerId__356) C::Listed.Add(builder__358, snake__360);
                i__359 = i__359 + 1;
            }
            return new MultiSnakeGame(game__355.Width, game__355.Height, C::Listed.ToReadOnlyList(builder__358), game__355.Food, game__355.RngSeed, game__355.TickCount);
        }
        public static string PlayerHeadChar(int id__373)
        {
            string return__88;
            if (id__373 == 0)
            {
                return__88 = "@";
            }
            else if (id__373 == 1)
            {
                return__88 = "#";
            }
            else if (id__373 == 2)
            {
                return__88 = "\u0024";
            }
            else if (id__373 == 3)
            {
                return__88 = "%";
            }
            else
            {
                return__88 = "&";
            }
            return return__88;
        }
        public static string PlayerBodyChar(int id__375)
        {
            string return__89;
            if (id__375 == 0)
            {
                return__89 = "o";
            }
            else if (id__375 == 1)
            {
                return__89 = "+";
            }
            else if (id__375 == 2)
            {
                return__89 = "~";
            }
            else if (id__375 == 3)
            {
                return__89 = "=";
            }
            else
            {
                return__89 = ".";
            }
            return return__89;
        }
        internal static string multiCellChar__97(MultiSnakeGame game__377, Point p__378)
        {
            string return__90;
            int t___2297;
            G::IReadOnlyList<PlayerSnake> t___2298;
            PlayerSnake t___2302;
            int t___2309;
            int t___2311;
            G::IReadOnlyList<PlayerSnake> t___2312;
            PlayerSnake t___2316;
            int t___2319;
            G::IReadOnlyList<Point> t___2320;
            Point t___2321;
            Point t___2322;
            int t___2323;
            Point t___2324;
            {
                {
                    int i__380 = 0;
                    while (true)
                    {
                        t___2297 = game__377.Snakes.Count;
                        if (!(i__380 < t___2297)) break;
                        t___2298 = game__377.Snakes;
                        t___2302 = new PlayerSnake(0, C::Listed.CreateReadOnlyList<Point>(), new Right(), 0, new Dead());
                        PlayerSnake snake__381 = C::Listed.GetOr(t___2298, i__380, t___2302);
                        if (snake__381.Segments.Count > 0)
                        {
                            Point head__382 = C::Listed.GetOr(snake__381.Segments, 0, new Point(-1, -1));
                            if (PointEquals(p__378, head__382))
                            {
                                t___2309 = snake__381.Id;
                                return__90 = PlayerHeadChar(t___2309);
                                goto fn__379;
                            }
                        }
                        i__380 = i__380 + 1;
                    }
                    int i__383 = 0;
                    while (true)
                    {
                        t___2311 = game__377.Snakes.Count;
                        if (!(i__383 < t___2311)) break;
                        t___2312 = game__377.Snakes;
                        t___2316 = new PlayerSnake(0, C::Listed.CreateReadOnlyList<Point>(), new Right(), 0, new Dead());
                        PlayerSnake snake__384 = C::Listed.GetOr(t___2312, i__383, t___2316);
                        int j__385 = 1;
                        while (true)
                        {
                            t___2319 = snake__384.Segments.Count;
                            if (!(j__385 < t___2319)) break;
                            t___2320 = snake__384.Segments;
                            t___2321 = new Point(-1, -1);
                            t___2322 = C::Listed.GetOr(t___2320, j__385, t___2321);
                            if (PointEquals(p__378, t___2322))
                            {
                                t___2323 = snake__384.Id;
                                return__90 = PlayerBodyChar(t___2323);
                                goto fn__379;
                            }
                            j__385 = j__385 + 1;
                        }
                        i__383 = i__383 + 1;
                    }
                    t___2324 = game__377.Food;
                    if (PointEquals(p__378, t___2324))
                    {
                        return__90 = "*";
                        goto fn__379;
                    }
                    return__90 = " ";
                }
                fn__379:
                {
                }
            }
            return return__90;
        }
        public static string MultiRender(MultiSnakeGame game__361)
        {
            int t___2264;
            int t___2267;
            int t___2269;
            int t___2275;
            int t___2279;
            G::IReadOnlyList<PlayerSnake> t___2280;
            PlayerSnake t___2284;
            IPlayerStatus t___2286;
            string t___1121;
            T::StringBuilder sb__363 = new T::StringBuilder();
            sb__363.Append("\u001b[2J\u001b[H");
            sb__363.Append("#");
            int x__364 = 0;
            while (true)
            {
                t___2264 = game__361.Width;
                if (!(x__364 < t___2264)) break;
                sb__363.Append("#");
                x__364 = x__364 + 1;
            }
            sb__363.Append("#\r\n");
            int y__365 = 0;
            while (true)
            {
                t___2267 = game__361.Height;
                if (!(y__365 < t___2267)) break;
                sb__363.Append("#");
                int x__366 = 0;
                while (true)
                {
                    t___2269 = game__361.Width;
                    if (!(x__366 < t___2269)) break;
                    Point p__367 = new Point(x__366, y__365);
                    sb__363.Append(multiCellChar__97(game__361, p__367));
                    x__366 = x__366 + 1;
                }
                sb__363.Append("#\r\n");
                y__365 = y__365 + 1;
            }
            sb__363.Append("#");
            int x__368 = 0;
            while (true)
            {
                t___2275 = game__361.Width;
                if (!(x__368 < t___2275)) break;
                sb__363.Append("#");
                x__368 = x__368 + 1;
            }
            sb__363.Append("#\r\n");
            int i__369 = 0;
            while (true)
            {
                t___2279 = game__361.Snakes.Count;
                if (!(i__369 < t___2279)) break;
                t___2280 = game__361.Snakes;
                t___2284 = new PlayerSnake(0, C::Listed.CreateReadOnlyList<Point>(), new Right(), 0, new Dead());
                PlayerSnake snake__370 = C::Listed.GetOr(t___2280, i__369, t___2284);
                t___2286 = snake__370.Status;
                if (t___2286 is Alive)
                {
                    t___1121 = "Playing";
                }
                else if (t___2286 is Dead)
                {
                    t___1121 = "DEAD";
                }
                else
                {
                    t___1121 = "";
                }
                string statusText__371 = t___1121;
                string symbol__372 = PlayerHeadChar(snake__370.Id);
                sb__363.Append("P" + S::Convert.ToString(snake__370.Id) + " " + symbol__372 + ": " + S::Convert.ToString(snake__370.Score) + "  " + statusText__371 + "\r" + "\n");
                i__369 = i__369 + 1;
            }
            return sb__363.ToString();
        }
        public static string DirectionToString(IDirection dir__386)
        {
            string return__91;
            if (dir__386 is Up)
            {
                return__91 = "up";
            }
            else if (dir__386 is Down)
            {
                return__91 = "down";
            }
            else if (dir__386 is Left)
            {
                return__91 = "left";
            }
            else if (dir__386 is Right)
            {
                return__91 = "right";
            }
            else
            {
                return__91 = "right";
            }
            return return__91;
        }
        public static IDirection ? StringToDirection(string s__388)
        {
            IDirection ? return__92;
            {
                {
                    if (s__388 == "up")
                    {
                        return__92 = new Up();
                        goto fn__389;
                    }
                    if (s__388 == "down")
                    {
                        return__92 = new Down();
                        goto fn__389;
                    }
                    if (s__388 == "left")
                    {
                        return__92 = new Left();
                        goto fn__389;
                    }
                    if (s__388 == "right")
                    {
                        return__92 = new Right();
                        goto fn__389;
                    }
                    return__92 = null;
                }
                fn__389:
                {
                }
            }
            return return__92;
        }
    }
}
