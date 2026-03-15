using S = System;
using G = System.Collections.Generic;
using T = System.Text;
using C = TemperLang.Core;
namespace Snake
{
    public static class SnakeGlobal
    {
        public static IDirection Move(Point head__44, G::IReadOnlyList<Point> body__45, Point food__46, int width__47, int height__48)
        {
            return new Right();
        }
        public static bool PointEquals(Point a__61, Point b__62)
        {
            bool return__25;
            int t___944;
            int t___945;
            if (a__61.X == b__62.X)
            {
                t___944 = a__61.Y;
                t___945 = b__62.Y;
                return__25 = t___944 == t___945;
            }
            else
            {
                return__25 = false;
            }
            return return__25;
        }
        public static bool IsOpposite(IDirection a__64, IDirection b__65)
        {
            bool return__26;
            if (a__64 is Up)
            {
                return__26 = b__65 is Down;
            }
            else if (a__64 is Down)
            {
                return__26 = b__65 is Up;
            }
            else if (a__64 is Left)
            {
                return__26 = b__65 is Right;
            }
            else if (a__64 is Right)
            {
                return__26 = b__65 is Left;
            }
            else
            {
                return__26 = false;
            }
            return return__26;
        }
        public static Point DirectionDelta(IDirection dir__67)
        {
            Point return__27;
            if (dir__67 is Up)
            {
                return__27 = new Point(0, -1);
            }
            else if (dir__67 is Down)
            {
                return__27 = new Point(0, 1);
            }
            else if (dir__67 is Left)
            {
                return__27 = new Point(-1, 0);
            }
            else if (dir__67 is Right)
            {
                return__27 = new Point(1, 0);
            }
            else
            {
                return__27 = new Point(0, 0);
            }
            return return__27;
        }
        public static RandomResult NextRandom(int seed__74, int max__75)
        {
            int t___587;
            int t___589;
            int raw__77 = seed__74 * 1664525 + 1013904223;
            int masked__78 = raw__77 & 2147483647;
            int posVal__79;
            if (masked__78 < 0)
            {
                posVal__79 = -masked__78;
            }
            else
            {
                posVal__79 = masked__78;
            }
            int value__80 = 0;
            if (max__75 > 0)
            {
                try
                {
                    t___587 = C::Core.Mod(posVal__79, max__75);
                    t___589 = t___587;
                }
                catch
                {
                    t___589 = 0;
                }
                value__80 = t___589;
            }
            return new RandomResult(value__80, masked__78);
        }
        internal static FoodPlacement placeFood__42(G::IReadOnlyList<Point> snake__103, int width__104, int height__105, int seed__106)
        {
            FoodPlacement return__36;
            int t___911;
            Point t___922;
            int t___552;
            int t___554;
            int t___556;
            int t___558;
            {
                {
                    int totalCells__108 = width__104 * height__105;
                    int currentSeed__109 = seed__106;
                    int attempt__110 = 0;
                    while (attempt__110 < totalCells__108)
                    {
                        RandomResult result__111 = NextRandom(currentSeed__109, totalCells__108);
                        t___911 = result__111.NextSeed;
                        currentSeed__109 = t___911;
                        int px__112 = 0;
                        int py__113 = 0;
                        if (width__104 > 0)
                        {
                            try
                            {
                                t___552 = C::Core.Mod(result__111.Value, width__104);
                                t___554 = t___552;
                            }
                            catch
                            {
                                t___554 = 0;
                            }
                            px__112 = t___554;
                            try
                            {
                                t___556 = C::Core.Div(result__111.Value, width__104);
                                t___558 = t___556;
                            }
                            catch
                            {
                                t___558 = 0;
                            }
                            py__113 = t___558;
                        }
                        Point candidate__114 = new Point(px__112, py__113);
                        bool occupied__115 = false;
                        void fn__910(Point seg__116)
                        {
                            if (PointEquals(seg__116, candidate__114))
                            {
                                occupied__115 = true;
                            }
                        }
                        C::Listed.ForEach(snake__103, (S::Action<Point>) fn__910);
                        if (!occupied__115)
                        {
                            return__36 = new FoodPlacement(candidate__114, currentSeed__109);
                            goto fn__107;
                        }
                        attempt__110 = attempt__110 + 1;
                    }
                    int y__117 = 0;
                    while (y__117 < height__105)
                    {
                        int x__118 = 0;
                        while (x__118 < width__104)
                        {
                            Point candidate__119 = new Point(x__118, y__117);
                            bool free__120 = true;
                            void fn__909(Point seg__121)
                            {
                                if (PointEquals(seg__121, candidate__119))
                                {
                                    free__120 = false;
                                }
                            }
                            C::Listed.ForEach(snake__103, (S::Action<Point>) fn__909);
                            if (free__120)
                            {
                                return__36 = new FoodPlacement(candidate__119, currentSeed__109);
                                goto fn__107;
                            }
                            x__118 = x__118 + 1;
                        }
                        y__117 = y__117 + 1;
                    }
                    t___922 = new Point(0, 0);
                    return__36 = new FoodPlacement(t___922, currentSeed__109);
                }
                fn__107:
                {
                }
            }
            return return__36;
        }
        public static SnakeGame NewGame(int width__122, int height__123, int seed__124)
        {
            int t___535;
            int t___537;
            int t___538;
            int t___540;
            int centerX__126 = 0;
            int centerY__127 = 0;
            if (width__122 > 0)
            {
                t___535 = C::Core.DivSafe(width__122, 2);
                t___537 = t___535;
                centerX__126 = t___537;
            }
            if (height__123 > 0)
            {
                t___538 = C::Core.DivSafe(height__123, 2);
                t___540 = t___538;
                centerY__127 = t___540;
            }
            G::IReadOnlyList<Point> snake__128 = C::Listed.CreateReadOnlyList<Point>(new Point(centerX__126, centerY__127), new Point(centerX__126 - 1, centerY__127), new Point(centerX__126 - 2, centerY__127));
            FoodPlacement foodResult__129 = placeFood__42(snake__128, width__122, height__123, seed__124);
            Right t___904 = new Right();
            Point t___905 = foodResult__129.Point;
            Playing t___906 = new Playing();
            int t___907 = foodResult__129.Seed;
            return new SnakeGame(width__122, height__123, snake__128, t___904, t___905, 0, t___906, t___907);
        }
        public static SnakeGame ChangeDirection(SnakeGame game__130, IDirection dir__131)
        {
            SnakeGame return__38;
            int t___892;
            int t___893;
            G::IReadOnlyList<Point> t___894;
            Point t___895;
            int t___896;
            IGameStatus t___897;
            int t___898;
            if (IsOpposite(game__130.Direction, dir__131))
            {
                return__38 = game__130;
            }
            else
            {
                t___892 = game__130.Width;
                t___893 = game__130.Height;
                t___894 = game__130.Snake;
                t___895 = game__130.Food;
                t___896 = game__130.Score;
                t___897 = game__130.Status;
                t___898 = game__130.RngSeed;
                return__38 = new SnakeGame(t___892, t___893, t___894, dir__131, t___895, t___896, t___897, t___898);
            }
            return return__38;
        }
        public static SnakeGame Tick(SnakeGame game__133)
        {
            SnakeGame return__39;
            int t___832;
            int t___833;
            int t___834;
            int t___835;
            G::IReadOnlyList<Point> t___836;
            IDirection t___837;
            Point t___838;
            int t___839;
            GameOver t___840;
            int t___841;
            int t___845;
            int t___847;
            G::IReadOnlyList<Point> t___848;
            Point t___849;
            int t___851;
            int t___852;
            G::IReadOnlyList<Point> t___853;
            IDirection t___854;
            Point t___855;
            int t___856;
            GameOver t___857;
            int t___858;
            int t___863;
            int t___865;
            G::IReadOnlyList<Point> t___866;
            Point t___867;
            int t___872;
            int t___873;
            int t___874;
            int t___876;
            int t___877;
            IDirection t___878;
            Point t___879;
            Playing t___880;
            int t___881;
            int t___883;
            int t___884;
            IDirection t___885;
            Point t___886;
            int t___887;
            IGameStatus t___888;
            int t___889;
            bool t___462;
            bool t___463;
            bool t___464;
            {
                {
                    if (game__133.Status is GameOver)
                    {
                        return__39 = game__133;
                        goto fn__134;
                    }
                    Point delta__135 = DirectionDelta(game__133.Direction);
                    Point head__136 = C::Listed.GetOr(game__133.Snake, 0, new Point(0, 0));
                    Point newHead__137 = new Point(head__136.X + delta__135.X, head__136.Y + delta__135.Y);
                    if (newHead__137.X < 0)
                    {
                        t___464 = true;
                    }
                    else
                    {
                        if (newHead__137.X >= game__133.Width)
                        {
                            t___463 = true;
                        }
                        else
                        {
                            if (newHead__137.Y < 0)
                            {
                                t___462 = true;
                            }
                            else
                            {
                                t___832 = newHead__137.Y;
                                t___833 = game__133.Height;
                                t___462 = t___832 >= t___833;
                            }
                            t___463 = t___462;
                        }
                        t___464 = t___463;
                    }
                    if (t___464)
                    {
                        t___834 = game__133.Width;
                        t___835 = game__133.Height;
                        t___836 = game__133.Snake;
                        t___837 = game__133.Direction;
                        t___838 = game__133.Food;
                        t___839 = game__133.Score;
                        t___840 = new GameOver();
                        t___841 = game__133.RngSeed;
                        return__39 = new SnakeGame(t___834, t___835, t___836, t___837, t___838, t___839, t___840, t___841);
                        goto fn__134;
                    }
                    bool eating__138 = PointEquals(newHead__137, game__133.Food);
                    int checkLength__139;
                    if (eating__138)
                    {
                        t___845 = game__133.Snake.Count;
                        checkLength__139 = t___845;
                    }
                    else
                    {
                        t___847 = game__133.Snake.Count;
                        checkLength__139 = t___847 - 1;
                    }
                    int i__140 = 0;
                    while (i__140 < checkLength__139)
                    {
                        t___848 = game__133.Snake;
                        t___849 = new Point(-1, -1);
                        if (PointEquals(newHead__137, C::Listed.GetOr(t___848, i__140, t___849)))
                        {
                            t___851 = game__133.Width;
                            t___852 = game__133.Height;
                            t___853 = game__133.Snake;
                            t___854 = game__133.Direction;
                            t___855 = game__133.Food;
                            t___856 = game__133.Score;
                            t___857 = new GameOver();
                            t___858 = game__133.RngSeed;
                            return__39 = new SnakeGame(t___851, t___852, t___853, t___854, t___855, t___856, t___857, t___858);
                            goto fn__134;
                        }
                        i__140 = i__140 + 1;
                    }
                    G::IList<Point> newSnakeBuilder__141 = new G::List<Point>();
                    C::Listed.Add(newSnakeBuilder__141, newHead__137);
                    int keepLength__142;
                    if (eating__138)
                    {
                        t___863 = game__133.Snake.Count;
                        keepLength__142 = t___863;
                    }
                    else
                    {
                        t___865 = game__133.Snake.Count;
                        keepLength__142 = t___865 - 1;
                    }
                    int i__143 = 0;
                    while (i__143 < keepLength__142)
                    {
                        t___866 = game__133.Snake;
                        t___867 = new Point(0, 0);
                        C::Listed.Add(newSnakeBuilder__141, C::Listed.GetOr(t___866, i__143, t___867));
                        i__143 = i__143 + 1;
                    }
                    G::IReadOnlyList<Point> newSnake__144 = C::Listed.ToReadOnlyList(newSnakeBuilder__141);
                    if (eating__138)
                    {
                        int newScore__145 = game__133.Score + 1;
                        t___872 = game__133.Width;
                        t___873 = game__133.Height;
                        t___874 = game__133.RngSeed;
                        FoodPlacement foodResult__146 = placeFood__42(newSnake__144, t___872, t___873, t___874);
                        t___876 = game__133.Width;
                        t___877 = game__133.Height;
                        t___878 = game__133.Direction;
                        t___879 = foodResult__146.Point;
                        t___880 = new Playing();
                        t___881 = foodResult__146.Seed;
                        return__39 = new SnakeGame(t___876, t___877, newSnake__144, t___878, t___879, newScore__145, t___880, t___881);
                    }
                    else
                    {
                        t___883 = game__133.Width;
                        t___884 = game__133.Height;
                        t___885 = game__133.Direction;
                        t___886 = game__133.Food;
                        t___887 = game__133.Score;
                        t___888 = game__133.Status;
                        t___889 = game__133.RngSeed;
                        return__39 = new SnakeGame(t___883, t___884, newSnake__144, t___885, t___886, t___887, t___888, t___889);
                    }
                }
                fn__134:
                {
                }
            }
            return return__39;
        }
        internal static string cellChar__43(SnakeGame game__156, Point p__157)
        {
            string return__41;
            int t___811;
            G::IReadOnlyList<Point> t___812;
            Point t___813;
            Point t___814;
            Point t___815;
            {
                {
                    Point head__159 = C::Listed.GetOr(game__156.Snake, 0, new Point(-1, -1));
                    if (PointEquals(p__157, head__159))
                    {
                        return__41 = "@";
                        goto fn__158;
                    }
                    int i__160 = 1;
                    while (true)
                    {
                        t___811 = game__156.Snake.Count;
                        if (!(i__160 < t___811)) break;
                        t___812 = game__156.Snake;
                        t___813 = new Point(-1, -1);
                        t___814 = C::Listed.GetOr(t___812, i__160, t___813);
                        if (PointEquals(p__157, t___814))
                        {
                            return__41 = "o";
                            goto fn__158;
                        }
                        i__160 = i__160 + 1;
                    }
                    t___815 = game__156.Food;
                    if (PointEquals(p__157, t___815))
                    {
                        return__41 = "*";
                        goto fn__158;
                    }
                    return__41 = " ";
                }
                fn__158:
                {
                }
            }
            return return__41;
        }
        public static string Render(SnakeGame game__147)
        {
            int t___786;
            int t___789;
            int t___791;
            int t___797;
            T::StringBuilder sb__149 = new T::StringBuilder();
            sb__149.Append("\u001b[2J\u001b[H");
            sb__149.Append("#");
            int x__150 = 0;
            while (true)
            {
                t___786 = game__147.Width;
                if (!(x__150 < t___786)) break;
                sb__149.Append("#");
                x__150 = x__150 + 1;
            }
            sb__149.Append("#\n");
            int y__151 = 0;
            while (true)
            {
                t___789 = game__147.Height;
                if (!(y__151 < t___789)) break;
                sb__149.Append("#");
                int x__152 = 0;
                while (true)
                {
                    t___791 = game__147.Width;
                    if (!(x__152 < t___791)) break;
                    Point p__153 = new Point(x__152, y__151);
                    sb__149.Append(cellChar__43(game__147, p__153));
                    x__152 = x__152 + 1;
                }
                sb__149.Append("#\n");
                y__151 = y__151 + 1;
            }
            sb__149.Append("#");
            int x__154 = 0;
            while (true)
            {
                t___797 = game__147.Width;
                if (!(x__154 < t___797)) break;
                sb__149.Append("#");
                x__154 = x__154 + 1;
            }
            sb__149.Append("#\n");
            string statusText__155;
            IGameStatus t___800 = game__147.Status;
            if (t___800 is Playing)
            {
                statusText__155 = "Playing";
            }
            else if (t___800 is GameOver)
            {
                statusText__155 = "GAME OVER";
            }
            else
            {
                statusText__155 = "";
            }
            sb__149.Append("Score: " + S::Convert.ToString(game__147.Score) + "  " + statusText__155 + "\n");
            return sb__149.ToString();
        }
    }
}
