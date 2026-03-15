using S = System;
using G = System.Collections.Generic;
using T = System.Text;
using C = TemperLang.Core;
namespace Snake
{
    public static class SnakeGlobal
    {
        public static IDirection Move(Point head__97, G::IReadOnlyList<Point> body__98, Point food__99, int width__100, int height__101)
        {
            return new Right();
        }
        public static bool PointEquals(Point a__114, Point b__115)
        {
            bool return__49;
            int t___2788;
            int t___2789;
            if (a__114.X == b__115.X)
            {
                t___2788 = a__114.Y;
                t___2789 = b__115.Y;
                return__49 = t___2788 == t___2789;
            }
            else
            {
                return__49 = false;
            }
            return return__49;
        }
        public static bool IsOpposite(IDirection a__117, IDirection b__118)
        {
            bool return__50;
            if (a__117 is Up)
            {
                return__50 = b__118 is Down;
            }
            else if (a__117 is Down)
            {
                return__50 = b__118 is Up;
            }
            else if (a__117 is Left)
            {
                return__50 = b__118 is Right;
            }
            else if (a__117 is Right)
            {
                return__50 = b__118 is Left;
            }
            else
            {
                return__50 = false;
            }
            return return__50;
        }
        public static Point DirectionDelta(IDirection dir__120)
        {
            Point return__51;
            if (dir__120 is Up)
            {
                return__51 = new Point(0, -1);
            }
            else if (dir__120 is Down)
            {
                return__51 = new Point(0, 1);
            }
            else if (dir__120 is Left)
            {
                return__51 = new Point(-1, 0);
            }
            else if (dir__120 is Right)
            {
                return__51 = new Point(1, 0);
            }
            else
            {
                return__51 = new Point(0, 0);
            }
            return return__51;
        }
        public static RandomResult NextRandom(int seed__127, int max__128)
        {
            int t___1684;
            int t___1686;
            int raw__130 = seed__127 * 1664525 + 1013904223;
            int masked__131 = raw__130 & 2147483647;
            int posVal__132;
            if (masked__131 < 0)
            {
                posVal__132 = -masked__131;
            }
            else
            {
                posVal__132 = masked__131;
            }
            int value__133 = 0;
            if (max__128 > 0)
            {
                try
                {
                    t___1684 = C::Core.Mod(posVal__132, max__128);
                    t___1686 = t___1684;
                }
                catch
                {
                    t___1686 = 0;
                }
                value__133 = t___1686;
            }
            return new RandomResult(value__133, masked__131);
        }
        internal static FoodPlacement placeFood__92(G::IReadOnlyList<Point> snake__156, int width__157, int height__158, int seed__159)
        {
            FoodPlacement return__60;
            int t___2755;
            Point t___2766;
            int t___1649;
            int t___1651;
            int t___1653;
            int t___1655;
            {
                {
                    int totalCells__161 = width__157 * height__158;
                    int currentSeed__162 = seed__159;
                    int attempt__163 = 0;
                    while (attempt__163 < totalCells__161)
                    {
                        RandomResult result__164 = NextRandom(currentSeed__162, totalCells__161);
                        t___2755 = result__164.NextSeed;
                        currentSeed__162 = t___2755;
                        int px__165 = 0;
                        int py__166 = 0;
                        if (width__157 > 0)
                        {
                            try
                            {
                                t___1649 = C::Core.Mod(result__164.Value, width__157);
                                t___1651 = t___1649;
                            }
                            catch
                            {
                                t___1651 = 0;
                            }
                            px__165 = t___1651;
                            try
                            {
                                t___1653 = C::Core.Div(result__164.Value, width__157);
                                t___1655 = t___1653;
                            }
                            catch
                            {
                                t___1655 = 0;
                            }
                            py__166 = t___1655;
                        }
                        Point candidate__167 = new Point(px__165, py__166);
                        bool occupied__168 = false;
                        void fn__2754(Point seg__169)
                        {
                            if (PointEquals(seg__169, candidate__167))
                            {
                                occupied__168 = true;
                            }
                        }
                        C::Listed.ForEach(snake__156, (S::Action<Point>) fn__2754);
                        if (!occupied__168)
                        {
                            return__60 = new FoodPlacement(candidate__167, currentSeed__162);
                            goto fn__160;
                        }
                        attempt__163 = attempt__163 + 1;
                    }
                    int y__170 = 0;
                    while (y__170 < height__158)
                    {
                        int x__171 = 0;
                        while (x__171 < width__157)
                        {
                            Point candidate__172 = new Point(x__171, y__170);
                            bool free__173 = true;
                            void fn__2753(Point seg__174)
                            {
                                if (PointEquals(seg__174, candidate__172))
                                {
                                    free__173 = false;
                                }
                            }
                            C::Listed.ForEach(snake__156, (S::Action<Point>) fn__2753);
                            if (free__173)
                            {
                                return__60 = new FoodPlacement(candidate__172, currentSeed__162);
                                goto fn__160;
                            }
                            x__171 = x__171 + 1;
                        }
                        y__170 = y__170 + 1;
                    }
                    t___2766 = new Point(0, 0);
                    return__60 = new FoodPlacement(t___2766, currentSeed__162);
                }
                fn__160:
                {
                }
            }
            return return__60;
        }
        public static SnakeGame NewGame(int width__175, int height__176, int seed__177)
        {
            int t___1632;
            int t___1634;
            int t___1635;
            int t___1637;
            int centerX__179 = 0;
            int centerY__180 = 0;
            if (width__175 > 0)
            {
                t___1632 = C::Core.DivSafe(width__175, 2);
                t___1634 = t___1632;
                centerX__179 = t___1634;
            }
            if (height__176 > 0)
            {
                t___1635 = C::Core.DivSafe(height__176, 2);
                t___1637 = t___1635;
                centerY__180 = t___1637;
            }
            G::IReadOnlyList<Point> snake__181 = C::Listed.CreateReadOnlyList<Point>(new Point(centerX__179, centerY__180), new Point(centerX__179 - 1, centerY__180), new Point(centerX__179 - 2, centerY__180));
            FoodPlacement foodResult__182 = placeFood__92(snake__181, width__175, height__176, seed__177);
            Right t___2748 = new Right();
            Point t___2749 = foodResult__182.Point;
            Playing t___2750 = new Playing();
            int t___2751 = foodResult__182.Seed;
            return new SnakeGame(width__175, height__176, snake__181, t___2748, t___2749, 0, t___2750, t___2751);
        }
        public static SnakeGame ChangeDirection(SnakeGame game__183, IDirection dir__184)
        {
            SnakeGame return__62;
            int t___2736;
            int t___2737;
            G::IReadOnlyList<Point> t___2738;
            Point t___2739;
            int t___2740;
            IGameStatus t___2741;
            int t___2742;
            if (IsOpposite(game__183.Direction, dir__184))
            {
                return__62 = game__183;
            }
            else
            {
                t___2736 = game__183.Width;
                t___2737 = game__183.Height;
                t___2738 = game__183.Snake;
                t___2739 = game__183.Food;
                t___2740 = game__183.Score;
                t___2741 = game__183.Status;
                t___2742 = game__183.RngSeed;
                return__62 = new SnakeGame(t___2736, t___2737, t___2738, dir__184, t___2739, t___2740, t___2741, t___2742);
            }
            return return__62;
        }
        public static SnakeGame Tick(SnakeGame game__186)
        {
            SnakeGame return__63;
            int t___2676;
            int t___2677;
            int t___2678;
            int t___2679;
            G::IReadOnlyList<Point> t___2680;
            IDirection t___2681;
            Point t___2682;
            int t___2683;
            GameOver t___2684;
            int t___2685;
            int t___2689;
            int t___2691;
            G::IReadOnlyList<Point> t___2692;
            Point t___2693;
            int t___2695;
            int t___2696;
            G::IReadOnlyList<Point> t___2697;
            IDirection t___2698;
            Point t___2699;
            int t___2700;
            GameOver t___2701;
            int t___2702;
            int t___2707;
            int t___2709;
            G::IReadOnlyList<Point> t___2710;
            Point t___2711;
            int t___2716;
            int t___2717;
            int t___2718;
            int t___2720;
            int t___2721;
            IDirection t___2722;
            Point t___2723;
            Playing t___2724;
            int t___2725;
            int t___2727;
            int t___2728;
            IDirection t___2729;
            Point t___2730;
            int t___2731;
            IGameStatus t___2732;
            int t___2733;
            bool t___1559;
            bool t___1560;
            bool t___1561;
            {
                {
                    if (game__186.Status is GameOver)
                    {
                        return__63 = game__186;
                        goto fn__187;
                    }
                    Point delta__188 = DirectionDelta(game__186.Direction);
                    Point head__189 = C::Listed.GetOr(game__186.Snake, 0, new Point(0, 0));
                    Point newHead__190 = new Point(head__189.X + delta__188.X, head__189.Y + delta__188.Y);
                    if (newHead__190.X < 0)
                    {
                        t___1561 = true;
                    }
                    else
                    {
                        if (newHead__190.X >= game__186.Width)
                        {
                            t___1560 = true;
                        }
                        else
                        {
                            if (newHead__190.Y < 0)
                            {
                                t___1559 = true;
                            }
                            else
                            {
                                t___2676 = newHead__190.Y;
                                t___2677 = game__186.Height;
                                t___1559 = t___2676 >= t___2677;
                            }
                            t___1560 = t___1559;
                        }
                        t___1561 = t___1560;
                    }
                    if (t___1561)
                    {
                        t___2678 = game__186.Width;
                        t___2679 = game__186.Height;
                        t___2680 = game__186.Snake;
                        t___2681 = game__186.Direction;
                        t___2682 = game__186.Food;
                        t___2683 = game__186.Score;
                        t___2684 = new GameOver();
                        t___2685 = game__186.RngSeed;
                        return__63 = new SnakeGame(t___2678, t___2679, t___2680, t___2681, t___2682, t___2683, t___2684, t___2685);
                        goto fn__187;
                    }
                    bool eating__191 = PointEquals(newHead__190, game__186.Food);
                    int checkLength__192;
                    if (eating__191)
                    {
                        t___2689 = game__186.Snake.Count;
                        checkLength__192 = t___2689;
                    }
                    else
                    {
                        t___2691 = game__186.Snake.Count;
                        checkLength__192 = t___2691 - 1;
                    }
                    int i__193 = 0;
                    while (i__193 < checkLength__192)
                    {
                        t___2692 = game__186.Snake;
                        t___2693 = new Point(-1, -1);
                        if (PointEquals(newHead__190, C::Listed.GetOr(t___2692, i__193, t___2693)))
                        {
                            t___2695 = game__186.Width;
                            t___2696 = game__186.Height;
                            t___2697 = game__186.Snake;
                            t___2698 = game__186.Direction;
                            t___2699 = game__186.Food;
                            t___2700 = game__186.Score;
                            t___2701 = new GameOver();
                            t___2702 = game__186.RngSeed;
                            return__63 = new SnakeGame(t___2695, t___2696, t___2697, t___2698, t___2699, t___2700, t___2701, t___2702);
                            goto fn__187;
                        }
                        i__193 = i__193 + 1;
                    }
                    G::IList<Point> newSnakeBuilder__194 = new G::List<Point>();
                    C::Listed.Add(newSnakeBuilder__194, newHead__190);
                    int keepLength__195;
                    if (eating__191)
                    {
                        t___2707 = game__186.Snake.Count;
                        keepLength__195 = t___2707;
                    }
                    else
                    {
                        t___2709 = game__186.Snake.Count;
                        keepLength__195 = t___2709 - 1;
                    }
                    int i__196 = 0;
                    while (i__196 < keepLength__195)
                    {
                        t___2710 = game__186.Snake;
                        t___2711 = new Point(0, 0);
                        C::Listed.Add(newSnakeBuilder__194, C::Listed.GetOr(t___2710, i__196, t___2711));
                        i__196 = i__196 + 1;
                    }
                    G::IReadOnlyList<Point> newSnake__197 = C::Listed.ToReadOnlyList(newSnakeBuilder__194);
                    if (eating__191)
                    {
                        int newScore__198 = game__186.Score + 1;
                        t___2716 = game__186.Width;
                        t___2717 = game__186.Height;
                        t___2718 = game__186.RngSeed;
                        FoodPlacement foodResult__199 = placeFood__92(newSnake__197, t___2716, t___2717, t___2718);
                        t___2720 = game__186.Width;
                        t___2721 = game__186.Height;
                        t___2722 = game__186.Direction;
                        t___2723 = foodResult__199.Point;
                        t___2724 = new Playing();
                        t___2725 = foodResult__199.Seed;
                        return__63 = new SnakeGame(t___2720, t___2721, newSnake__197, t___2722, t___2723, newScore__198, t___2724, t___2725);
                    }
                    else
                    {
                        t___2727 = game__186.Width;
                        t___2728 = game__186.Height;
                        t___2729 = game__186.Direction;
                        t___2730 = game__186.Food;
                        t___2731 = game__186.Score;
                        t___2732 = game__186.Status;
                        t___2733 = game__186.RngSeed;
                        return__63 = new SnakeGame(t___2727, t___2728, newSnake__197, t___2729, t___2730, t___2731, t___2732, t___2733);
                    }
                }
                fn__187:
                {
                }
            }
            return return__63;
        }
        internal static string cellChar__93(SnakeGame game__209, Point p__210)
        {
            string return__65;
            int t___2655;
            G::IReadOnlyList<Point> t___2656;
            Point t___2657;
            Point t___2658;
            Point t___2659;
            {
                {
                    Point head__212 = C::Listed.GetOr(game__209.Snake, 0, new Point(-1, -1));
                    if (PointEquals(p__210, head__212))
                    {
                        return__65 = "@";
                        goto fn__211;
                    }
                    int i__213 = 1;
                    while (true)
                    {
                        t___2655 = game__209.Snake.Count;
                        if (!(i__213 < t___2655)) break;
                        t___2656 = game__209.Snake;
                        t___2657 = new Point(-1, -1);
                        t___2658 = C::Listed.GetOr(t___2656, i__213, t___2657);
                        if (PointEquals(p__210, t___2658))
                        {
                            return__65 = "o";
                            goto fn__211;
                        }
                        i__213 = i__213 + 1;
                    }
                    t___2659 = game__209.Food;
                    if (PointEquals(p__210, t___2659))
                    {
                        return__65 = "*";
                        goto fn__211;
                    }
                    return__65 = " ";
                }
                fn__211:
                {
                }
            }
            return return__65;
        }
        public static string Render(SnakeGame game__200)
        {
            int t___2630;
            int t___2633;
            int t___2635;
            int t___2641;
            T::StringBuilder sb__202 = new T::StringBuilder();
            sb__202.Append("\u001b[2J\u001b[H");
            sb__202.Append("#");
            int x__203 = 0;
            while (true)
            {
                t___2630 = game__200.Width;
                if (!(x__203 < t___2630)) break;
                sb__202.Append("#");
                x__203 = x__203 + 1;
            }
            sb__202.Append("#\r\n");
            int y__204 = 0;
            while (true)
            {
                t___2633 = game__200.Height;
                if (!(y__204 < t___2633)) break;
                sb__202.Append("#");
                int x__205 = 0;
                while (true)
                {
                    t___2635 = game__200.Width;
                    if (!(x__205 < t___2635)) break;
                    Point p__206 = new Point(x__205, y__204);
                    sb__202.Append(cellChar__93(game__200, p__206));
                    x__205 = x__205 + 1;
                }
                sb__202.Append("#\r\n");
                y__204 = y__204 + 1;
            }
            sb__202.Append("#");
            int x__207 = 0;
            while (true)
            {
                t___2641 = game__200.Width;
                if (!(x__207 < t___2641)) break;
                sb__202.Append("#");
                x__207 = x__207 + 1;
            }
            sb__202.Append("#\r\n");
            string statusText__208;
            IGameStatus t___2644 = game__200.Status;
            if (t___2644 is Playing)
            {
                statusText__208 = "Playing";
            }
            else if (t___2644 is GameOver)
            {
                statusText__208 = "GAME OVER";
            }
            else
            {
                statusText__208 = "";
            }
            sb__202.Append("Score: " + S::Convert.ToString(game__200.Score) + "  " + statusText__208 + "\r" + "\n");
            return sb__202.ToString();
        }
        internal static SpawnInfo spawnPosition__94(int width__261, int height__262, int index__263, int total__264)
        {
            SpawnInfo return__79;
            Point t___2615;
            Right t___2616;
            Point t___2618;
            Left t___2619;
            Point t___2621;
            Down t___2622;
            Point t___2624;
            Up t___2625;
            int t___1458;
            int t___1460;
            int t___1461;
            int t___1463;
            int t___1464;
            int t___1466;
            int t___1467;
            int t___1469;
            int t___1470;
            int t___1472;
            {
                {
                    int cx__266 = 0;
                    int cy__267 = 0;
                    if (width__261 > 0)
                    {
                        t___1458 = C::Core.DivSafe(width__261, 2);
                        t___1460 = t___1458;
                        cx__266 = t___1460;
                    }
                    if (height__262 > 0)
                    {
                        t___1461 = C::Core.DivSafe(height__262, 2);
                        t___1463 = t___1461;
                        cy__267 = t___1463;
                    }
                    int qx__268 = 0;
                    int qy__269 = 0;
                    if (width__261 > 0)
                    {
                        t___1464 = C::Core.DivSafe(width__261, 4);
                        t___1466 = t___1464;
                        qx__268 = t___1466;
                    }
                    if (height__262 > 0)
                    {
                        t___1467 = C::Core.DivSafe(height__262, 4);
                        t___1469 = t___1467;
                        qy__269 = t___1469;
                    }
                    int slot__270 = 0;
                    if (total__264 > 0)
                    {
                        t___1470 = C::Core.ModSafe(index__263, 4);
                        t___1472 = t___1470;
                        slot__270 = t___1472;
                    }
                    if (slot__270 == 0)
                    {
                        t___2615 = new Point(qx__268, cy__267);
                        t___2616 = new Right();
                        return__79 = new SpawnInfo(t___2615, t___2616);
                        goto fn__265;
                    }
                    if (slot__270 == 1)
                    {
                        t___2618 = new Point(width__261 - qx__268 - 1, cy__267);
                        t___2619 = new Left();
                        return__79 = new SpawnInfo(t___2618, t___2619);
                        goto fn__265;
                    }
                    if (slot__270 == 2)
                    {
                        t___2621 = new Point(cx__266, qy__269);
                        t___2622 = new Down();
                        return__79 = new SpawnInfo(t___2621, t___2622);
                        goto fn__265;
                    }
                    t___2624 = new Point(cx__266, height__262 - qy__269 - 1);
                    t___2625 = new Up();
                    return__79 = new SpawnInfo(t___2624, t___2625);
                }
                fn__265:
                {
                }
            }
            return return__79;
        }
        internal static G::IReadOnlyList<Point> collectAllSegments__95(G::IReadOnlyList<PlayerSnake> snakes__271)
        {
            int t___2602;
            PlayerSnake t___2606;
            int t___2609;
            G::IReadOnlyList<Point> t___2610;
            Point t___2611;
            G::IList<Point> builder__273 = new G::List<Point>();
            int i__274 = 0;
            while (true)
            {
                t___2602 = snakes__271.Count;
                if (!(i__274 < t___2602)) break;
                t___2606 = new PlayerSnake(0, C::Listed.CreateReadOnlyList<Point>(), new Right(), 0, new Dead());
                PlayerSnake snake__275 = C::Listed.GetOr(snakes__271, i__274, t___2606);
                int j__276 = 0;
                while (true)
                {
                    t___2609 = snake__275.Segments.Count;
                    if (!(j__276 < t___2609)) break;
                    t___2610 = snake__275.Segments;
                    t___2611 = new Point(0, 0);
                    C::Listed.Add(builder__273, C::Listed.GetOr(t___2610, j__276, t___2611));
                    j__276 = j__276 + 1;
                }
                i__274 = i__274 + 1;
            }
            return C::Listed.ToReadOnlyList(builder__273);
        }
        public static MultiSnakeGame NewMultiGame(int width__240, int height__241, int numPlayers__242, int seed__243)
        {
            Alive t___2591;
            G::IList<PlayerSnake> snakeBuilder__245 = new G::List<PlayerSnake>();
            int currentSeed__246 = seed__243;
            int i__247 = 0;
            while (i__247 < numPlayers__242)
            {
                SpawnInfo spawn__248 = spawnPosition__94(width__240, height__241, i__247, numPlayers__242);
                IDirection dir__249 = spawn__248.Direction;
                int startX__250 = spawn__248.Point.X;
                int startY__251 = spawn__248.Point.Y;
                Point delta__252 = DirectionDelta(dir__249);
                G::IReadOnlyList<Point> segments__253 = C::Listed.CreateReadOnlyList<Point>(new Point(startX__250, startY__251), new Point(startX__250 - delta__252.X, startY__251 - delta__252.Y), new Point(startX__250 - delta__252.X * 2, startY__251 - delta__252.Y * 2));
                t___2591 = new Alive();
                C::Listed.Add(snakeBuilder__245, new PlayerSnake(i__247, segments__253, dir__249, 0, t___2591));
                i__247 = i__247 + 1;
            }
            G::IReadOnlyList<PlayerSnake> t___2594 = C::Listed.ToReadOnlyList(snakeBuilder__245);
            G::IReadOnlyList<Point> allSegments__254 = collectAllSegments__95(t___2594);
            FoodPlacement foodResult__255 = placeFood__92(allSegments__254, width__240, height__241, currentSeed__246);
            G::IReadOnlyList<PlayerSnake> t___2597 = C::Listed.ToReadOnlyList(snakeBuilder__245);
            Point t___2598 = foodResult__255.Point;
            int t___2599 = foodResult__255.Seed;
            return new MultiSnakeGame(width__240, height__241, t___2597, t___2598, t___2599, 0);
        }
        public static MultiSnakeGame MultiTick(MultiSnakeGame game__277, G::IReadOnlyList<IDirection> directions__278)
        {
            int t___2420;
            G::IReadOnlyList<PlayerSnake> t___2421;
            PlayerSnake t___2425;
            IDirection t___2427;
            int t___2435;
            G::IReadOnlyList<PlayerSnake> t___2436;
            PlayerSnake t___2440;
            G::IReadOnlyList<IDirection> t___2444;
            Right t___2445;
            int t___2463;
            G::IReadOnlyList<PlayerSnake> t___2464;
            PlayerSnake t___2468;
            Point t___2473;
            int t___2479;
            int t___2480;
            int t___2482;
            G::IReadOnlyList<Point> t___2483;
            Point t___2484;
            int t___2487;
            G::IReadOnlyList<PlayerSnake> t___2488;
            PlayerSnake t___2492;
            int t___2497;
            G::IReadOnlyList<Point> t___2498;
            Point t___2499;
            int t___2502;
            G::IReadOnlyList<PlayerSnake> t___2503;
            PlayerSnake t___2507;
            Point t___2511;
            int t___2516;
            Point t___2518;
            int t___2523;
            G::IReadOnlyList<PlayerSnake> t___2524;
            PlayerSnake t___2528;
            Point t___2541;
            IDirection t___2543;
            int t___2546;
            int t___2548;
            G::IReadOnlyList<Point> t___2551;
            Point t___2552;
            int t___2555;
            int t___2556;
            int t___2566;
            int t___2567;
            int t___2568;
            Point t___2570;
            int t___2571;
            bool t___1320;
            bool t___1321;
            bool t___1322;
            int t___1392;
            int t___1400;
            G::IList<IDirection> newDirs__280 = new G::List<IDirection>();
            int i__281 = 0;
            while (true)
            {
                t___2420 = game__277.Snakes.Count;
                if (!(i__281 < t___2420)) break;
                t___2421 = game__277.Snakes;
                t___2425 = new PlayerSnake(0, C::Listed.CreateReadOnlyList<Point>(), new Right(), 0, new Dead());
                PlayerSnake snake__282 = C::Listed.GetOr(t___2421, i__281, t___2425);
                t___2427 = snake__282.Direction;
                IDirection inputDir__283 = C::Listed.GetOr(directions__278, i__281, t___2427);
                if (IsOpposite(snake__282.Direction, inputDir__283)) C::Listed.Add(newDirs__280, snake__282.Direction);
                else C::Listed.Add(newDirs__280, inputDir__283);
                i__281 = i__281 + 1;
            }
            G::IList<Point> newHeads__284 = new G::List<Point>();
            int i__285 = 0;
            while (true)
            {
                t___2435 = game__277.Snakes.Count;
                if (!(i__285 < t___2435)) break;
                t___2436 = game__277.Snakes;
                t___2440 = new PlayerSnake(0, C::Listed.CreateReadOnlyList<Point>(), new Right(), 0, new Dead());
                PlayerSnake snake__286 = C::Listed.GetOr(t___2436, i__285, t___2440);
                if (snake__286.Status is Alive)
                {
                    t___2444 = C::Listed.ToReadOnlyList(newDirs__280);
                    t___2445 = new Right();
                    IDirection dir__287 = C::Listed.GetOr(t___2444, i__285, t___2445);
                    Point delta__288 = DirectionDelta(dir__287);
                    Point head__289 = C::Listed.GetOr(snake__286.Segments, 0, new Point(0, 0));
                    C::Listed.Add(newHeads__284, new Point(head__289.X + delta__288.X, head__289.Y + delta__288.Y));
                }
                else C::Listed.Add(newHeads__284, new Point(-1, -1));
                i__285 = i__285 + 1;
            }
            G::IReadOnlyList<Point> headsList__290 = C::Listed.ToReadOnlyList(newHeads__284);
            G::IReadOnlyList<IDirection> dirsList__291 = C::Listed.ToReadOnlyList(newDirs__280);
            G::IList<bool> aliveBuilder__292 = new G::List<bool>();
            int i__293 = 0;
            while (true)
            {
                t___2463 = game__277.Snakes.Count;
                if (!(i__293 < t___2463)) break;
                t___2464 = game__277.Snakes;
                t___2468 = new PlayerSnake(0, C::Listed.CreateReadOnlyList<Point>(), new Right(), 0, new Dead());
                PlayerSnake snake__294 = C::Listed.GetOr(t___2464, i__293, t___2468);
                if (!(snake__294.Status is Alive)) C::Listed.Add(aliveBuilder__292, false);
                else
                {
                    t___2473 = new Point(-1, -1);
                    Point nh__295 = C::Listed.GetOr(headsList__290, i__293, t___2473);
                    bool dead__296 = false;
                    if (nh__295.X < 0)
                    {
                        t___1322 = true;
                    }
                    else
                    {
                        if (nh__295.X >= game__277.Width)
                        {
                            t___1321 = true;
                        }
                        else
                        {
                            if (nh__295.Y < 0)
                            {
                                t___1320 = true;
                            }
                            else
                            {
                                t___2479 = nh__295.Y;
                                t___2480 = game__277.Height;
                                t___1320 = t___2479 >= t___2480;
                            }
                            t___1321 = t___1320;
                        }
                        t___1322 = t___1321;
                    }
                    if (t___1322)
                    {
                        dead__296 = true;
                    }
                    if (!dead__296)
                    {
                        int s__297 = 0;
                        while (true)
                        {
                            t___2482 = snake__294.Segments.Count;
                            if (!(s__297 < t___2482 - 1)) break;
                            t___2483 = snake__294.Segments;
                            t___2484 = new Point(-2, -2);
                            if (PointEquals(nh__295, C::Listed.GetOr(t___2483, s__297, t___2484)))
                            {
                                dead__296 = true;
                            }
                            s__297 = s__297 + 1;
                        }
                    }
                    if (!dead__296)
                    {
                        int j__298 = 0;
                        while (true)
                        {
                            t___2487 = game__277.Snakes.Count;
                            if (!(j__298 < t___2487)) break;
                            if (j__298 != i__293)
                            {
                                t___2488 = game__277.Snakes;
                                t___2492 = new PlayerSnake(0, C::Listed.CreateReadOnlyList<Point>(), new Right(), 0, new Dead());
                                PlayerSnake other__299 = C::Listed.GetOr(t___2488, j__298, t___2492);
                                if (other__299.Status is Alive)
                                {
                                    int s__300 = 0;
                                    while (true)
                                    {
                                        t___2497 = other__299.Segments.Count;
                                        if (!(s__300 < t___2497 - 1)) break;
                                        t___2498 = other__299.Segments;
                                        t___2499 = new Point(-2, -2);
                                        if (PointEquals(nh__295, C::Listed.GetOr(t___2498, s__300, t___2499)))
                                        {
                                            dead__296 = true;
                                        }
                                        s__300 = s__300 + 1;
                                    }
                                }
                            }
                            j__298 = j__298 + 1;
                        }
                    }
                    if (!dead__296)
                    {
                        int j__301 = 0;
                        while (true)
                        {
                            t___2502 = game__277.Snakes.Count;
                            if (!(j__301 < t___2502)) break;
                            if (j__301 != i__293)
                            {
                                t___2503 = game__277.Snakes;
                                t___2507 = new PlayerSnake(0, C::Listed.CreateReadOnlyList<Point>(), new Right(), 0, new Dead());
                                PlayerSnake otherSnake__302 = C::Listed.GetOr(t___2503, j__301, t___2507);
                                if (otherSnake__302.Status is Alive)
                                {
                                    t___2511 = new Point(-3, -3);
                                    Point otherHead__303 = C::Listed.GetOr(headsList__290, j__301, t___2511);
                                    if (PointEquals(nh__295, otherHead__303))
                                    {
                                        dead__296 = true;
                                    }
                                }
                            }
                            j__301 = j__301 + 1;
                        }
                    }
                    C::Listed.Add(aliveBuilder__292, !dead__296);
                }
                i__293 = i__293 + 1;
            }
            G::IReadOnlyList<bool> aliveList__304 = C::Listed.ToReadOnlyList(aliveBuilder__292);
            int eaterIndex__305 = -1;
            int i__306 = 0;
            while (true)
            {
                t___2516 = game__277.Snakes.Count;
                if (!(i__306 < t___2516)) break;
                if (C::Listed.GetOr(aliveList__304, i__306, false))
                {
                    t___2518 = new Point(-1, -1);
                    Point nh__307 = C::Listed.GetOr(headsList__290, i__306, t___2518);
                    if (PointEquals(nh__307, game__277.Food))
                    {
                        eaterIndex__305 = i__306;
                    }
                }
                i__306 = i__306 + 1;
            }
            G::IList<PlayerSnake> resultSnakes__308 = new G::List<PlayerSnake>();
            int i__309 = 0;
            while (true)
            {
                t___2523 = game__277.Snakes.Count;
                if (!(i__309 < t___2523)) break;
                t___2524 = game__277.Snakes;
                t___2528 = new PlayerSnake(0, C::Listed.CreateReadOnlyList<Point>(), new Right(), 0, new Dead());
                PlayerSnake snake__310 = C::Listed.GetOr(t___2524, i__309, t___2528);
                if (!(snake__310.Status is Alive)) C::Listed.Add(resultSnakes__308, snake__310);
                else if (!C::Listed.GetOr(aliveList__304, i__309, false)) C::Listed.Add(resultSnakes__308, new PlayerSnake(snake__310.Id, snake__310.Segments, snake__310.Direction, snake__310.Score, new Dead()));
                else
                {
                    t___2541 = new Point(0, 0);
                    Point nh__311 = C::Listed.GetOr(headsList__290, i__309, t___2541);
                    t___2543 = snake__310.Direction;
                    IDirection dir__312 = C::Listed.GetOr(dirsList__291, i__309, t___2543);
                    bool isEating__313 = i__309 == eaterIndex__305;
                    if (isEating__313)
                    {
                        t___2546 = snake__310.Segments.Count;
                        t___1392 = t___2546;
                    }
                    else
                    {
                        t___2548 = snake__310.Segments.Count;
                        t___1392 = t___2548 - 1;
                    }
                    int keepLen__314 = t___1392;
                    G::IList<Point> newSegs__315 = new G::List<Point>();
                    C::Listed.Add(newSegs__315, nh__311);
                    int s__316 = 0;
                    while (s__316 < keepLen__314)
                    {
                        t___2551 = snake__310.Segments;
                        t___2552 = new Point(0, 0);
                        C::Listed.Add(newSegs__315, C::Listed.GetOr(t___2551, s__316, t___2552));
                        s__316 = s__316 + 1;
                    }
                    if (isEating__313)
                    {
                        t___2555 = snake__310.Score;
                        t___1400 = t___2555 + 1;
                    }
                    else
                    {
                        t___2556 = snake__310.Score;
                        t___1400 = t___2556;
                    }
                    int newScore__317 = t___1400;
                    C::Listed.Add(resultSnakes__308, new PlayerSnake(snake__310.Id, C::Listed.ToReadOnlyList(newSegs__315), dir__312, newScore__317, new Alive()));
                }
                i__309 = i__309 + 1;
            }
            G::IReadOnlyList<PlayerSnake> resultSnakesList__318 = C::Listed.ToReadOnlyList(resultSnakes__308);
            Point t___2563 = game__277.Food;
            Point newFood__319 = t___2563;
            int t___2564 = game__277.RngSeed;
            int newSeed__320 = t___2564;
            if (eaterIndex__305 >= 0)
            {
                G::IReadOnlyList<Point> allSegs__321 = collectAllSegments__95(resultSnakesList__318);
                t___2566 = game__277.Width;
                t___2567 = game__277.Height;
                t___2568 = game__277.RngSeed;
                FoodPlacement foodResult__322 = placeFood__92(allSegs__321, t___2566, t___2567, t___2568);
                t___2570 = foodResult__322.Point;
                newFood__319 = t___2570;
                t___2571 = foodResult__322.Seed;
                newSeed__320 = t___2571;
            }
            int t___2572 = game__277.Width;
            int t___2573 = game__277.Height;
            int t___2574 = game__277.TickCount;
            return new MultiSnakeGame(t___2572, t___2573, resultSnakesList__318, newFood__319, newSeed__320, t___2574 + 1);
        }
        public static MultiSnakeGame ChangePlayerDirection(MultiSnakeGame game__323, int playerId__324, IDirection dir__325)
        {
            int t___2393;
            G::IReadOnlyList<PlayerSnake> t___2394;
            PlayerSnake t___2398;
            IDirection t___2403;
            int t___2404;
            G::IReadOnlyList<Point> t___2405;
            int t___2406;
            IPlayerStatus t___2407;
            bool t___1245;
            bool t___1246;
            G::IList<PlayerSnake> newSnakes__327 = new G::List<PlayerSnake>();
            int i__328 = 0;
            while (true)
            {
                t___2393 = game__323.Snakes.Count;
                if (!(i__328 < t___2393)) break;
                t___2394 = game__323.Snakes;
                t___2398 = new PlayerSnake(0, C::Listed.CreateReadOnlyList<Point>(), new Right(), 0, new Dead());
                PlayerSnake snake__329 = C::Listed.GetOr(t___2394, i__328, t___2398);
                if (snake__329.Id == playerId__324)
                {
                    if (snake__329.Status is Alive)
                    {
                        t___2403 = snake__329.Direction;
                        t___1245 = !IsOpposite(t___2403, dir__325);
                    }
                    else
                    {
                        t___1245 = false;
                    }
                    t___1246 = t___1245;
                }
                else
                {
                    t___1246 = false;
                }
                if (t___1246)
                {
                    t___2404 = snake__329.Id;
                    t___2405 = snake__329.Segments;
                    t___2406 = snake__329.Score;
                    t___2407 = snake__329.Status;
                    C::Listed.Add(newSnakes__327, new PlayerSnake(t___2404, t___2405, dir__325, t___2406, t___2407));
                }
                else C::Listed.Add(newSnakes__327, snake__329);
                i__328 = i__328 + 1;
            }
            return new MultiSnakeGame(game__323.Width, game__323.Height, C::Listed.ToReadOnlyList(newSnakes__327), game__323.Food, game__323.RngSeed, game__323.TickCount);
        }
        public static bool IsMultiGameOver(MultiSnakeGame game__330)
        {
            bool return__83;
            int t___2378;
            G::IReadOnlyList<PlayerSnake> t___2379;
            PlayerSnake t___2383;
            int aliveCount__332 = 0;
            int i__333 = 0;
            while (true)
            {
                t___2378 = game__330.Snakes.Count;
                if (!(i__333 < t___2378)) break;
                t___2379 = game__330.Snakes;
                t___2383 = new PlayerSnake(0, C::Listed.CreateReadOnlyList<Point>(), new Right(), 0, new Dead());
                PlayerSnake snake__334 = C::Listed.GetOr(t___2379, i__333, t___2383);
                if (snake__334.Status is Alive)
                {
                    aliveCount__332 = aliveCount__332 + 1;
                }
                i__333 = i__333 + 1;
            }
            if (game__330.Snakes.Count == 0)
            {
                return__83 = false;
            }
            else if (game__330.Snakes.Count == 1)
            {
                return__83 = aliveCount__332 == 0;
            }
            else
            {
                return__83 = aliveCount__332 <= 1;
            }
            return return__83;
        }
        public static MultiSnakeGame AddPlayer(MultiSnakeGame game__335, int seed__336)
        {
            int t___2356;
            G::IReadOnlyList<PlayerSnake> t___2357;
            PlayerSnake t___2361;
            int newId__338 = game__335.Snakes.Count;
            SpawnInfo spawn__339 = spawnPosition__94(game__335.Width, game__335.Height, newId__338, newId__338 + 1);
            IDirection dir__340 = spawn__339.Direction;
            Point delta__341 = DirectionDelta(dir__340);
            int startX__342 = spawn__339.Point.X;
            int startY__343 = spawn__339.Point.Y;
            G::IReadOnlyList<Point> segments__344 = C::Listed.CreateReadOnlyList<Point>(new Point(startX__342, startY__343), new Point(startX__342 - delta__341.X, startY__343 - delta__341.Y), new Point(startX__342 - delta__341.X * 2, startY__343 - delta__341.Y * 2));
            PlayerSnake newSnake__345 = new PlayerSnake(newId__338, segments__344, dir__340, 0, new Alive());
            G::IList<PlayerSnake> builder__346 = new G::List<PlayerSnake>();
            int i__347 = 0;
            while (true)
            {
                t___2356 = game__335.Snakes.Count;
                if (!(i__347 < t___2356)) break;
                t___2357 = game__335.Snakes;
                t___2361 = new PlayerSnake(0, C::Listed.CreateReadOnlyList<Point>(), new Right(), 0, new Dead());
                C::Listed.Add(builder__346, C::Listed.GetOr(t___2357, i__347, t___2361));
                i__347 = i__347 + 1;
            }
            C::Listed.Add(builder__346, newSnake__345);
            G::IReadOnlyList<PlayerSnake> t___2365 = C::Listed.ToReadOnlyList(builder__346);
            G::IReadOnlyList<Point> allSegs__348 = collectAllSegments__95(t___2365);
            int t___2367 = game__335.Width;
            int t___2368 = game__335.Height;
            FoodPlacement foodResult__349 = placeFood__92(allSegs__348, t___2367, t___2368, seed__336);
            return new MultiSnakeGame(game__335.Width, game__335.Height, C::Listed.ToReadOnlyList(builder__346), foodResult__349.Point, foodResult__349.Seed, game__335.TickCount);
        }
        public static MultiSnakeGame RemovePlayer(MultiSnakeGame game__350, int playerId__351)
        {
            int t___2318;
            G::IReadOnlyList<PlayerSnake> t___2319;
            PlayerSnake t___2323;
            G::IList<PlayerSnake> builder__353 = new G::List<PlayerSnake>();
            int i__354 = 0;
            while (true)
            {
                t___2318 = game__350.Snakes.Count;
                if (!(i__354 < t___2318)) break;
                t___2319 = game__350.Snakes;
                t___2323 = new PlayerSnake(0, C::Listed.CreateReadOnlyList<Point>(), new Right(), 0, new Dead());
                PlayerSnake snake__355 = C::Listed.GetOr(t___2319, i__354, t___2323);
                if (snake__355.Id != playerId__351) C::Listed.Add(builder__353, snake__355);
                i__354 = i__354 + 1;
            }
            return new MultiSnakeGame(game__350.Width, game__350.Height, C::Listed.ToReadOnlyList(builder__353), game__350.Food, game__350.RngSeed, game__350.TickCount);
        }
        public static string PlayerHeadChar(int id__368)
        {
            string return__87;
            if (id__368 == 0)
            {
                return__87 = "@";
            }
            else if (id__368 == 1)
            {
                return__87 = "#";
            }
            else if (id__368 == 2)
            {
                return__87 = "\u0024";
            }
            else if (id__368 == 3)
            {
                return__87 = "%";
            }
            else
            {
                return__87 = "&";
            }
            return return__87;
        }
        public static string PlayerBodyChar(int id__370)
        {
            string return__88;
            if (id__370 == 0)
            {
                return__88 = "o";
            }
            else if (id__370 == 1)
            {
                return__88 = "+";
            }
            else if (id__370 == 2)
            {
                return__88 = "~";
            }
            else if (id__370 == 3)
            {
                return__88 = "=";
            }
            else
            {
                return__88 = ".";
            }
            return return__88;
        }
        internal static string multiCellChar__96(MultiSnakeGame game__372, Point p__373)
        {
            string return__89;
            int t___2288;
            G::IReadOnlyList<PlayerSnake> t___2289;
            PlayerSnake t___2293;
            int t___2300;
            int t___2302;
            G::IReadOnlyList<PlayerSnake> t___2303;
            PlayerSnake t___2307;
            int t___2310;
            G::IReadOnlyList<Point> t___2311;
            Point t___2312;
            Point t___2313;
            int t___2314;
            Point t___2315;
            {
                {
                    int i__375 = 0;
                    while (true)
                    {
                        t___2288 = game__372.Snakes.Count;
                        if (!(i__375 < t___2288)) break;
                        t___2289 = game__372.Snakes;
                        t___2293 = new PlayerSnake(0, C::Listed.CreateReadOnlyList<Point>(), new Right(), 0, new Dead());
                        PlayerSnake snake__376 = C::Listed.GetOr(t___2289, i__375, t___2293);
                        if (snake__376.Segments.Count > 0)
                        {
                            Point head__377 = C::Listed.GetOr(snake__376.Segments, 0, new Point(-1, -1));
                            if (PointEquals(p__373, head__377))
                            {
                                t___2300 = snake__376.Id;
                                return__89 = PlayerHeadChar(t___2300);
                                goto fn__374;
                            }
                        }
                        i__375 = i__375 + 1;
                    }
                    int i__378 = 0;
                    while (true)
                    {
                        t___2302 = game__372.Snakes.Count;
                        if (!(i__378 < t___2302)) break;
                        t___2303 = game__372.Snakes;
                        t___2307 = new PlayerSnake(0, C::Listed.CreateReadOnlyList<Point>(), new Right(), 0, new Dead());
                        PlayerSnake snake__379 = C::Listed.GetOr(t___2303, i__378, t___2307);
                        int j__380 = 1;
                        while (true)
                        {
                            t___2310 = snake__379.Segments.Count;
                            if (!(j__380 < t___2310)) break;
                            t___2311 = snake__379.Segments;
                            t___2312 = new Point(-1, -1);
                            t___2313 = C::Listed.GetOr(t___2311, j__380, t___2312);
                            if (PointEquals(p__373, t___2313))
                            {
                                t___2314 = snake__379.Id;
                                return__89 = PlayerBodyChar(t___2314);
                                goto fn__374;
                            }
                            j__380 = j__380 + 1;
                        }
                        i__378 = i__378 + 1;
                    }
                    t___2315 = game__372.Food;
                    if (PointEquals(p__373, t___2315))
                    {
                        return__89 = "*";
                        goto fn__374;
                    }
                    return__89 = " ";
                }
                fn__374:
                {
                }
            }
            return return__89;
        }
        public static string MultiRender(MultiSnakeGame game__356)
        {
            int t___2255;
            int t___2258;
            int t___2260;
            int t___2266;
            int t___2270;
            G::IReadOnlyList<PlayerSnake> t___2271;
            PlayerSnake t___2275;
            IPlayerStatus t___2277;
            string t___1116;
            T::StringBuilder sb__358 = new T::StringBuilder();
            sb__358.Append("\u001b[2J\u001b[H");
            sb__358.Append("#");
            int x__359 = 0;
            while (true)
            {
                t___2255 = game__356.Width;
                if (!(x__359 < t___2255)) break;
                sb__358.Append("#");
                x__359 = x__359 + 1;
            }
            sb__358.Append("#\r\n");
            int y__360 = 0;
            while (true)
            {
                t___2258 = game__356.Height;
                if (!(y__360 < t___2258)) break;
                sb__358.Append("#");
                int x__361 = 0;
                while (true)
                {
                    t___2260 = game__356.Width;
                    if (!(x__361 < t___2260)) break;
                    Point p__362 = new Point(x__361, y__360);
                    sb__358.Append(multiCellChar__96(game__356, p__362));
                    x__361 = x__361 + 1;
                }
                sb__358.Append("#\r\n");
                y__360 = y__360 + 1;
            }
            sb__358.Append("#");
            int x__363 = 0;
            while (true)
            {
                t___2266 = game__356.Width;
                if (!(x__363 < t___2266)) break;
                sb__358.Append("#");
                x__363 = x__363 + 1;
            }
            sb__358.Append("#\r\n");
            int i__364 = 0;
            while (true)
            {
                t___2270 = game__356.Snakes.Count;
                if (!(i__364 < t___2270)) break;
                t___2271 = game__356.Snakes;
                t___2275 = new PlayerSnake(0, C::Listed.CreateReadOnlyList<Point>(), new Right(), 0, new Dead());
                PlayerSnake snake__365 = C::Listed.GetOr(t___2271, i__364, t___2275);
                t___2277 = snake__365.Status;
                if (t___2277 is Alive)
                {
                    t___1116 = "Playing";
                }
                else if (t___2277 is Dead)
                {
                    t___1116 = "DEAD";
                }
                else
                {
                    t___1116 = "";
                }
                string statusText__366 = t___1116;
                string symbol__367 = PlayerHeadChar(snake__365.Id);
                sb__358.Append("P" + S::Convert.ToString(snake__365.Id) + " " + symbol__367 + ": " + S::Convert.ToString(snake__365.Score) + "  " + statusText__366 + "\r" + "\n");
                i__364 = i__364 + 1;
            }
            return sb__358.ToString();
        }
        public static string DirectionToString(IDirection dir__381)
        {
            string return__90;
            if (dir__381 is Up)
            {
                return__90 = "up";
            }
            else if (dir__381 is Down)
            {
                return__90 = "down";
            }
            else if (dir__381 is Left)
            {
                return__90 = "left";
            }
            else if (dir__381 is Right)
            {
                return__90 = "right";
            }
            else
            {
                return__90 = "right";
            }
            return return__90;
        }
        public static IDirection ? StringToDirection(string s__383)
        {
            IDirection ? return__91;
            {
                {
                    if (s__383 == "up")
                    {
                        return__91 = new Up();
                        goto fn__384;
                    }
                    if (s__383 == "down")
                    {
                        return__91 = new Down();
                        goto fn__384;
                    }
                    if (s__383 == "left")
                    {
                        return__91 = new Left();
                        goto fn__384;
                    }
                    if (s__383 == "right")
                    {
                        return__91 = new Right();
                        goto fn__384;
                    }
                    return__91 = null;
                }
                fn__384:
                {
                }
            }
            return return__91;
        }
    }
}
