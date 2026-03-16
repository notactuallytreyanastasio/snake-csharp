using U = Microsoft.VisualStudio.TestTools.UnitTesting;
using S0 = Snake;
using S1 = System;
using G = System.Collections.Generic;
using C = TemperLang.Core;
using T = TemperLang.Std.Testing;
namespace SnakeTest
{
    [U::TestClass]
    public class SnakeTestTests
    {
        [U::TestMethod]
        public void initialStateHasSnakeNearCenter__170()
        {
            T::Test test___0 = new T::Test();
            try
            {
                S0::SnakeGame game__65 = S0::SnakeGlobal.NewGame(10, 10, 42);
                S0::Point head__66 = C::Listed.GetOr(game__65.Snake, 0, new S0::Point(-1, -1));
                bool t___1569 = head__66.X == 5;
                string fn__1562()
                {
                    return "head x should be 5, got " + S1::Convert.ToString(head__66.X);
                }
                test___0.Assert(t___1569, (S1::Func<string>) fn__1562);
                bool t___1573 = head__66.Y == 5;
                string fn__1561()
                {
                    return "head y should be 5, got " + S1::Convert.ToString(head__66.Y);
                }
                test___0.Assert(t___1573, (S1::Func<string>) fn__1561);
                bool t___1578 = game__65.Snake.Count == 3;
                string fn__1560()
                {
                    return "snake should start with 3 segments";
                }
                test___0.Assert(t___1578, (S1::Func<string>) fn__1560);
            }
            finally
            {
                test___0.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void initialStatusIsPlaying__171()
        {
            T::Test test___1 = new T::Test();
            try
            {
                S0::SnakeGame game__68 = S0::SnakeGlobal.NewGame(10, 10, 42);
                bool t___1553 = game__68.Status is S0::Playing;
                string fn__1550()
                {
                    return "initial status should be Playing";
                }
                test___1.Assert(t___1553, (S1::Func<string>) fn__1550);
            }
            finally
            {
                test___1.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void initialDirectionIsRight__172()
        {
            T::Test test___2 = new T::Test();
            try
            {
                S0::SnakeGame game__70 = S0::SnakeGlobal.NewGame(10, 10, 42);
                bool t___1547 = game__70.Direction is S0::Right;
                string fn__1544()
                {
                    return "initial direction should be Right";
                }
                test___2.Assert(t___1547, (S1::Func<string>) fn__1544);
            }
            finally
            {
                test___2.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void initialScoreIs0__173()
        {
            T::Test test___3 = new T::Test();
            try
            {
                S0::SnakeGame game__72 = S0::SnakeGlobal.NewGame(10, 10, 42);
                bool t___1542 = game__72.Score == 0;
                string fn__1538()
                {
                    return "initial score should be 0";
                }
                test___3.Assert(t___1542, (S1::Func<string>) fn__1538);
            }
            finally
            {
                test___3.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void snakeMovesRight__174()
        {
            T::Test test___4 = new T::Test();
            try
            {
                S0::SnakeGame game__74 = S0::SnakeGlobal.NewGame(10, 10, 42);
                S0::SnakeGame moved__75 = S0::SnakeGlobal.Tick(game__74);
                S0::Point head__76 = C::Listed.GetOr(moved__75.Snake, 0, new S0::Point(-1, -1));
                bool t___1532 = head__76.X == 6;
                string fn__1524()
                {
                    return "head should move right to x=6, got " + S1::Convert.ToString(head__76.X);
                }
                test___4.Assert(t___1532, (S1::Func<string>) fn__1524);
                bool t___1536 = head__76.Y == 5;
                string fn__1523()
                {
                    return "head y should stay 5, got " + S1::Convert.ToString(head__76.Y);
                }
                test___4.Assert(t___1536, (S1::Func<string>) fn__1523);
            }
            finally
            {
                test___4.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void snakeMovesDown__175()
        {
            T::Test test___5 = new T::Test();
            try
            {
                S0::SnakeGame game__78 = S0::SnakeGlobal.ChangeDirection(S0::SnakeGlobal.NewGame(10, 10, 42), new S0::Down());
                S0::SnakeGame moved__79 = S0::SnakeGlobal.Tick(game__78);
                S0::Point head__80 = C::Listed.GetOr(moved__79.Snake, 0, new S0::Point(-1, -1));
                bool t___1513 = head__80.X == 5;
                string fn__1504()
                {
                    return "head x should stay 5, got " + S1::Convert.ToString(head__80.X);
                }
                test___5.Assert(t___1513, (S1::Func<string>) fn__1504);
                bool t___1517 = head__80.Y == 6;
                string fn__1503()
                {
                    return "head should move down to y=6, got " + S1::Convert.ToString(head__80.Y);
                }
                test___5.Assert(t___1517, (S1::Func<string>) fn__1503);
            }
            finally
            {
                test___5.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void snakeMovesUp__176()
        {
            T::Test test___6 = new T::Test();
            try
            {
                S0::SnakeGame game__82 = S0::SnakeGlobal.ChangeDirection(S0::SnakeGlobal.NewGame(10, 10, 42), new S0::Up());
                S0::SnakeGame moved__83 = S0::SnakeGlobal.Tick(game__82);
                S0::Point head__84 = C::Listed.GetOr(moved__83.Snake, 0, new S0::Point(-1, -1));
                bool t___1497 = head__84.Y == 4;
                string fn__1488()
                {
                    return "head should move up to y=4, got " + S1::Convert.ToString(head__84.Y);
                }
                test___6.Assert(t___1497, (S1::Func<string>) fn__1488);
            }
            finally
            {
                test___6.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void oppositeDirectionIsRejected__177()
        {
            T::Test test___7 = new T::Test();
            try
            {
                S0::SnakeGame game__86 = S0::SnakeGlobal.NewGame(10, 10, 42);
                S0::SnakeGame changed__87 = S0::SnakeGlobal.ChangeDirection(game__86, new S0::Left());
                bool t___1483 = changed__87.Direction is S0::Right;
                string fn__1479()
                {
                    return "should still be Right after trying Left";
                }
                test___7.Assert(t___1483, (S1::Func<string>) fn__1479);
            }
            finally
            {
                test___7.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void nonOppositeDirectionIsAccepted__178()
        {
            T::Test test___8 = new T::Test();
            try
            {
                S0::SnakeGame game__89 = S0::SnakeGlobal.NewGame(10, 10, 42);
                S0::SnakeGame changed__90 = S0::SnakeGlobal.ChangeDirection(game__89, new S0::Up());
                bool t___1476 = changed__90.Direction is S0::Up;
                string fn__1472()
                {
                    return "should change to Up";
                }
                test___8.Assert(t___1476, (S1::Func<string>) fn__1472);
            }
            finally
            {
                test___8.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void wallCollisionCausesGameOver__179()
        {
            T::Test test___9 = new T::Test();
            try
            {
                S0::SnakeGame t___1467;
                S0::SnakeGame t___1466 = S0::SnakeGlobal.NewGame(10, 10, 42);
                S0::SnakeGame game__92 = t___1466;
                int i__93 = 0;
                while (i__93 < 10)
                {
                    t___1467 = S0::SnakeGlobal.Tick(game__92);
                    game__92 = t___1467;
                    i__93 = i__93 + 1;
                }
                bool t___1469 = game__92.Status is S0::GameOver;
                string fn__1465()
                {
                    return "should be GameOver after hitting wall";
                }
                test___9.Assert(t___1469, (S1::Func<string>) fn__1465);
            }
            finally
            {
                test___9.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void selfCollisionCausesGameOver__180()
        {
            T::Test test___10 = new T::Test();
            try
            {
                G::IReadOnlyList<S0::Point> snake__95 = C::Listed.CreateReadOnlyList<S0::Point>(new S0::Point(5, 5), new S0::Point(6, 5), new S0::Point(6, 4), new S0::Point(5, 4), new S0::Point(4, 4), new S0::Point(4, 5), new S0::Point(4, 6));
                S0::SnakeGame t___1459 = new S0::SnakeGame(10, 10, snake__95, new S0::Left(), new S0::Point(0, 0), 0, new S0::Playing(), 42);
                S0::SnakeGame game__96 = t___1459;
                S0::SnakeGame t___1460 = S0::SnakeGlobal.Tick(game__96);
                game__96 = t___1460;
                bool t___1462 = game__96.Status is S0::GameOver;
                string fn__1448()
                {
                    return "should be GameOver after self collision";
                }
                test___10.Assert(t___1462, (S1::Func<string>) fn__1448);
            }
            finally
            {
                test___10.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void pointEqualsWorksForSamePoints__181()
        {
            T::Test test___11 = new T::Test();
            try
            {
                bool t___1446 = S0::SnakeGlobal.PointEquals(new S0::Point(3, 4), new S0::Point(3, 4));
                string fn__1442()
                {
                    return "same points should be equal";
                }
                test___11.Assert(t___1446, (S1::Func<string>) fn__1442);
            }
            finally
            {
                test___11.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void pointEqualsWorksForDifferentPoints__182()
        {
            T::Test test___12 = new T::Test();
            try
            {
                bool t___1440 = !S0::SnakeGlobal.PointEquals(new S0::Point(3, 4), new S0::Point(5, 6));
                string fn__1436()
                {
                    return "different points should not be equal";
                }
                test___12.Assert(t___1440, (S1::Func<string>) fn__1436);
            }
            finally
            {
                test___12.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void isOppositeDetectsOppositeDirections__183()
        {
            T::Test test___13 = new T::Test();
            try
            {
                bool t___1424 = S0::SnakeGlobal.IsOpposite(new S0::Up(), new S0::Down());
                string fn__1420()
                {
                    return "Up/Down are opposite";
                }
                test___13.Assert(t___1424, (S1::Func<string>) fn__1420);
                bool t___1429 = S0::SnakeGlobal.IsOpposite(new S0::Left(), new S0::Right());
                string fn__1419()
                {
                    return "Left/Right are opposite";
                }
                test___13.Assert(t___1429, (S1::Func<string>) fn__1419);
                bool t___1434 = !S0::SnakeGlobal.IsOpposite(new S0::Up(), new S0::Left());
                string fn__1418()
                {
                    return "Up/Left are not opposite";
                }
                test___13.Assert(t___1434, (S1::Func<string>) fn__1418);
            }
            finally
            {
                test___13.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void directionDeltaReturnsCorrectDeltas__184()
        {
            T::Test test___14 = new T::Test();
            try
            {
                int t___1410;
                int t___1415;
                bool t___703;
                bool t___708;
                S0::Point up__101 = S0::SnakeGlobal.DirectionDelta(new S0::Up());
                if (up__101.X == 0)
                {
                    t___1410 = up__101.Y;
                    t___703 = t___1410 == -1;
                }
                else
                {
                    t___703 = false;
                }
                string fn__1407()
                {
                    return "Up should be (0, -1)";
                }
                test___14.Assert(t___703, (S1::Func<string>) fn__1407);
                S0::Point right__102 = S0::SnakeGlobal.DirectionDelta(new S0::Right());
                if (right__102.X == 1)
                {
                    t___1415 = right__102.Y;
                    t___708 = t___1415 == 0;
                }
                else
                {
                    t___708 = false;
                }
                string fn__1406()
                {
                    return "Right should be (1, 0)";
                }
                test___14.Assert(t___708, (S1::Func<string>) fn__1406);
            }
            finally
            {
                test___14.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void prngIsDeterministic__185()
        {
            T::Test test___17 = new T::Test();
            try
            {
                S0::RandomResult r1__104 = S0::SnakeGlobal.NextRandom(42, 100);
                S0::RandomResult r2__105 = S0::SnakeGlobal.NextRandom(42, 100);
                bool t___1399 = r1__104.Value == r2__105.Value;
                string fn__1395()
                {
                    return "same seed should produce same value";
                }
                test___17.Assert(t___1399, (S1::Func<string>) fn__1395);
                bool t___1404 = r1__104.NextSeed == r2__105.NextSeed;
                string fn__1394()
                {
                    return "same seed should produce same next seed";
                }
                test___17.Assert(t___1404, (S1::Func<string>) fn__1394);
            }
            finally
            {
                test___17.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void prngProducesValuesInRange__186()
        {
            T::Test test___18 = new T::Test();
            try
            {
                int t___1391;
                bool t___693;
                S0::RandomResult r__107 = S0::SnakeGlobal.NextRandom(42, 10);
                if (r__107.Value >= 0)
                {
                    t___1391 = r__107.Value;
                    t___693 = t___1391 < 10;
                }
                else
                {
                    t___693 = false;
                }
                string fn__1389()
                {
                    return "value should be in [0, 10), got " + S1::Convert.ToString(r__107.Value);
                }
                test___18.Assert(t___693, (S1::Func<string>) fn__1389);
            }
            finally
            {
                test___18.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void tickDoesNothingWhenGameIsOver__187()
        {
            T::Test test___20 = new T::Test();
            try
            {
                S0::SnakeGame t___1372;
                S0::SnakeGame t___1371 = S0::SnakeGlobal.NewGame(10, 10, 42);
                S0::SnakeGame game__109 = t___1371;
                int i__110 = 0;
                while (i__110 < 10)
                {
                    t___1372 = S0::SnakeGlobal.Tick(game__109);
                    game__109 = t___1372;
                    i__110 = i__110 + 1;
                }
                bool t___1374 = game__109.Status is S0::GameOver;
                string fn__1370()
                {
                    return "should be GameOver";
                }
                test___20.Assert(t___1374, (S1::Func<string>) fn__1370);
                S0::Point head1__111 = C::Listed.GetOr(game__109.Snake, 0, new S0::Point(-1, -1));
                S0::SnakeGame t___1380 = S0::SnakeGlobal.Tick(game__109);
                game__109 = t___1380;
                S0::Point head2__112 = C::Listed.GetOr(game__109.Snake, 0, new S0::Point(-1, -1));
                bool t___1385 = S0::SnakeGlobal.PointEquals(head1__111, head2__112);
                string fn__1369()
                {
                    return "snake should not move after game over";
                }
                test___20.Assert(t___1385, (S1::Func<string>) fn__1369);
            }
            finally
            {
                test___20.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void multiGameCreatesCorrectNumberOfSnakes__188()
        {
            T::Test test___21 = new T::Test();
            try
            {
                S0::MultiSnakeGame game__114 = S0::SnakeGlobal.NewMultiGame(20, 10, 2, 42);
                bool t___1367 = game__114.Snakes.Count == 2;
                string fn__1362()
                {
                    return "should have 2 snakes";
                }
                test___21.Assert(t___1367, (S1::Func<string>) fn__1362);
            }
            finally
            {
                test___21.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void multiGameSnakesStartAlive__189()
        {
            T::Test test___22 = new T::Test();
            try
            {
                S0::MultiSnakeGame game__116 = S0::SnakeGlobal.NewMultiGame(20, 10, 2, 42);
                S0::PlayerSnake s0__117 = C::Listed.GetOr(game__116.Snakes, 0, new S0::PlayerSnake(0, C::Listed.CreateReadOnlyList<S0::Point>(), new S0::Right(), 0, new S0::Dead()));
                S0::PlayerSnake s1__118 = C::Listed.GetOr(game__116.Snakes, 1, new S0::PlayerSnake(0, C::Listed.CreateReadOnlyList<S0::Point>(), new S0::Right(), 0, new S0::Dead()));
                bool t___1355 = s0__117.Status is S0::Alive;
                string fn__1340()
                {
                    return "player 0 should be alive";
                }
                test___22.Assert(t___1355, (S1::Func<string>) fn__1340);
                bool t___1359 = s1__118.Status is S0::Alive;
                string fn__1339()
                {
                    return "player 1 should be alive";
                }
                test___22.Assert(t___1359, (S1::Func<string>) fn__1339);
            }
            finally
            {
                test___22.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void multiGameSnakesStartAtDifferentPositions__190()
        {
            T::Test test___23 = new T::Test();
            try
            {
                S0::MultiSnakeGame game__120 = S0::SnakeGlobal.NewMultiGame(60, 30, 2, 42);
                S0::PlayerSnake s0__121 = C::Listed.GetOr(game__120.Snakes, 0, new S0::PlayerSnake(0, C::Listed.CreateReadOnlyList<S0::Point>(), new S0::Right(), 0, new S0::Dead()));
                S0::PlayerSnake s1__122 = C::Listed.GetOr(game__120.Snakes, 1, new S0::PlayerSnake(0, C::Listed.CreateReadOnlyList<S0::Point>(), new S0::Right(), 0, new S0::Dead()));
                S0::Point h0__123 = C::Listed.GetOr(s0__121.Segments, 0, new S0::Point(-1, -1));
                S0::Point h1__124 = C::Listed.GetOr(s1__122.Segments, 0, new S0::Point(-1, -1));
                bool t___1337 = !S0::SnakeGlobal.PointEquals(h0__123, h1__124);
                string fn__1316()
                {
                    return "snakes should start at different positions";
                }
                test___23.Assert(t___1337, (S1::Func<string>) fn__1316);
            }
            finally
            {
                test___23.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void multiGameSnakesHave3_segmentsEach__191()
        {
            T::Test test___24 = new T::Test();
            try
            {
                S0::MultiSnakeGame game__126 = S0::SnakeGlobal.NewMultiGame(20, 10, 2, 42);
                S0::PlayerSnake s0__127 = C::Listed.GetOr(game__126.Snakes, 0, new S0::PlayerSnake(0, C::Listed.CreateReadOnlyList<S0::Point>(), new S0::Right(), 0, new S0::Dead()));
                S0::PlayerSnake s1__128 = C::Listed.GetOr(game__126.Snakes, 1, new S0::PlayerSnake(0, C::Listed.CreateReadOnlyList<S0::Point>(), new S0::Right(), 0, new S0::Dead()));
                bool t___1309 = s0__127.Segments.Count == 3;
                string fn__1292()
                {
                    return "player 0 should have 3 segments";
                }
                test___24.Assert(t___1309, (S1::Func<string>) fn__1292);
                bool t___1314 = s1__128.Segments.Count == 3;
                string fn__1291()
                {
                    return "player 1 should have 3 segments";
                }
                test___24.Assert(t___1314, (S1::Func<string>) fn__1291);
            }
            finally
            {
                test___24.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void multiTickMovesBothSnakes__192()
        {
            T::Test test___25 = new T::Test();
            try
            {
                S0::MultiSnakeGame game__130 = S0::SnakeGlobal.NewMultiGame(60, 30, 2, 42);
                S0::PlayerSnake s0__131 = C::Listed.GetOr(game__130.Snakes, 0, new S0::PlayerSnake(0, C::Listed.CreateReadOnlyList<S0::Point>(), new S0::Right(), 0, new S0::Dead()));
                S0::PlayerSnake s1__132 = C::Listed.GetOr(game__130.Snakes, 1, new S0::PlayerSnake(0, C::Listed.CreateReadOnlyList<S0::Point>(), new S0::Right(), 0, new S0::Dead()));
                S0::Point h0Before__133 = C::Listed.GetOr(s0__131.Segments, 0, new S0::Point(0, 0));
                S0::Point h1Before__134 = C::Listed.GetOr(s1__132.Segments, 0, new S0::Point(0, 0));
                G::IReadOnlyList<S0::IDirection> dirs__135 = C::Listed.CreateReadOnlyList<S0::IDirection>(s0__131.Direction, s1__132.Direction);
                S0::MultiSnakeGame after__136 = S0::SnakeGlobal.MultiTick(game__130, dirs__135);
                S0::Point h0After__137 = C::Listed.GetOr(C::Listed.GetOr(after__136.Snakes, 0, new S0::PlayerSnake(0, C::Listed.CreateReadOnlyList<S0::Point>(), new S0::Right(), 0, new S0::Dead())).Segments, 0, new S0::Point(0, 0));
                S0::Point h1After__138 = C::Listed.GetOr(C::Listed.GetOr(after__136.Snakes, 1, new S0::PlayerSnake(0, C::Listed.CreateReadOnlyList<S0::Point>(), new S0::Right(), 0, new S0::Dead())).Segments, 0, new S0::Point(0, 0));
                bool t___1286 = !S0::SnakeGlobal.PointEquals(h0Before__133, h0After__137);
                string fn__1244()
                {
                    return "snake 0 should have moved";
                }
                test___25.Assert(t___1286, (S1::Func<string>) fn__1244);
                bool t___1289 = !S0::SnakeGlobal.PointEquals(h1Before__134, h1After__138);
                string fn__1243()
                {
                    return "snake 1 should have moved";
                }
                test___25.Assert(t___1289, (S1::Func<string>) fn__1243);
            }
            finally
            {
                test___25.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void multiWallCollisionKillsOneSnake__193()
        {
            T::Test test___26 = new T::Test();
            try
            {
                S0::MultiSnakeGame t___1229;
                int t___1231;
                G::IReadOnlyList<S0::PlayerSnake> t___1232;
                S0::PlayerSnake t___1236;
                S0::MultiSnakeGame t___1226 = S0::SnakeGlobal.NewMultiGame(20, 10, 2, 42);
                S0::MultiSnakeGame game__140 = t___1226;
                G::IReadOnlyList<S0::IDirection> dirs__141 = C::Listed.CreateReadOnlyList<S0::IDirection>(new S0::Right(), new S0::Left());
                int i__142 = 0;
                while (i__142 < 20)
                {
                    t___1229 = S0::SnakeGlobal.MultiTick(game__140, dirs__141);
                    game__140 = t___1229;
                    i__142 = i__142 + 1;
                }
                int deadCount__143 = 0;
                int i__144 = 0;
                while (true)
                {
                    t___1231 = game__140.Snakes.Count;
                    if (!(i__144 < t___1231)) break;
                    t___1232 = game__140.Snakes;
                    t___1236 = new S0::PlayerSnake(0, C::Listed.CreateReadOnlyList<S0::Point>(), new S0::Right(), 0, new S0::Dead());
                    S0::PlayerSnake snake__145 = C::Listed.GetOr(t___1232, i__144, t___1236);
                    if (snake__145.Status is S0::Dead)
                    {
                        deadCount__143 = deadCount__143 + 1;
                    }
                    i__144 = i__144 + 1;
                }
                bool t___1241 = deadCount__143 > 0;
                string fn__1225()
                {
                    return "at least one snake should be dead after 20 ticks toward walls";
                }
                test___26.Assert(t___1241, (S1::Func<string>) fn__1225);
            }
            finally
            {
                test___26.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void multiGameOverWhenOnePlayerLeft__194()
        {
            T::Test test___27 = new T::Test();
            try
            {
                S0::MultiSnakeGame t___1221;
                S0::MultiSnakeGame t___1218 = S0::SnakeGlobal.NewMultiGame(20, 10, 2, 42);
                S0::MultiSnakeGame game__147 = t___1218;
                G::IReadOnlyList<S0::IDirection> dirs__148 = C::Listed.CreateReadOnlyList<S0::IDirection>(new S0::Right(), new S0::Left());
                int i__149 = 0;
                while (i__149 < 30)
                {
                    t___1221 = S0::SnakeGlobal.MultiTick(game__147, dirs__148);
                    game__147 = t___1221;
                    i__149 = i__149 + 1;
                }
                bool t___1222 = S0::SnakeGlobal.IsMultiGameOver(game__147);
                string fn__1217()
                {
                    return "game should be over after enough ticks";
                }
                test___27.Assert(t___1222, (S1::Func<string>) fn__1217);
            }
            finally
            {
                test___27.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void changePlayerDirectionWorks__195()
        {
            T::Test test___28 = new T::Test();
            try
            {
                S0::MultiSnakeGame game__151 = S0::SnakeGlobal.NewMultiGame(20, 10, 2, 42);
                S0::Up t___1205 = new S0::Up();
                S0::MultiSnakeGame changed__152 = S0::SnakeGlobal.ChangePlayerDirection(game__151, 0, t___1205);
                S0::PlayerSnake s0__153 = C::Listed.GetOr(changed__152.Snakes, 0, new S0::PlayerSnake(0, C::Listed.CreateReadOnlyList<S0::Point>(), new S0::Right(), 0, new S0::Dead()));
                bool t___1214 = s0__153.Direction is S0::Up;
                string fn__1203()
                {
                    return "player 0 direction should be Up";
                }
                test___28.Assert(t___1214, (S1::Func<string>) fn__1203);
            }
            finally
            {
                test___28.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void changePlayerDirectionRejectsOpposite__196()
        {
            T::Test test___29 = new T::Test();
            try
            {
                S0::MultiSnakeGame game__155 = S0::SnakeGlobal.NewMultiGame(20, 10, 2, 42);
                S0::Left t___1191 = new S0::Left();
                S0::MultiSnakeGame changed__156 = S0::SnakeGlobal.ChangePlayerDirection(game__155, 0, t___1191);
                S0::PlayerSnake s0__157 = C::Listed.GetOr(changed__156.Snakes, 0, new S0::PlayerSnake(0, C::Listed.CreateReadOnlyList<S0::Point>(), new S0::Right(), 0, new S0::Dead()));
                bool t___1200 = s0__157.Direction is S0::Right;
                string fn__1189()
                {
                    return "should reject opposite direction";
                }
                test___29.Assert(t___1200, (S1::Func<string>) fn__1189);
            }
            finally
            {
                test___29.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void addPlayerAddsANewSnake__197()
        {
            T::Test test___30 = new T::Test();
            try
            {
                S0::MultiSnakeGame game__159 = S0::SnakeGlobal.NewMultiGame(20, 10, 2, 42);
                S0::MultiSnakeGame bigger__160 = S0::SnakeGlobal.AddPlayer(game__159, 99);
                bool t___1187 = bigger__160.Snakes.Count == 3;
                string fn__1181()
                {
                    return "should have 3 snakes after adding";
                }
                test___30.Assert(t___1187, (S1::Func<string>) fn__1181);
            }
            finally
            {
                test___30.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void removePlayerRemovesASnake__198()
        {
            T::Test test___31 = new T::Test();
            try
            {
                S0::MultiSnakeGame game__162 = S0::SnakeGlobal.NewMultiGame(20, 10, 3, 42);
                S0::MultiSnakeGame smaller__163 = S0::SnakeGlobal.RemovePlayer(game__162, 1);
                bool t___1179 = smaller__163.Snakes.Count == 2;
                string fn__1173()
                {
                    return "should have 2 snakes after removing";
                }
                test___31.Assert(t___1179, (S1::Func<string>) fn__1173);
            }
            finally
            {
                test___31.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void multiRenderProducesOutput__199()
        {
            T::Test test___32 = new T::Test();
            try
            {
                S0::MultiSnakeGame game__165 = S0::SnakeGlobal.NewMultiGame(20, 10, 2, 42);
                string rendered__166 = S0::SnakeGlobal.MultiRender(game__165);
                bool t___1171 = rendered__166 != "";
                string fn__1167()
                {
                    return "render should produce output";
                }
                test___32.Assert(t___1171, (S1::Func<string>) fn__1167);
            }
            finally
            {
                test___32.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void directionToStringAndStringToDirectionRoundTrip__200()
        {
            T::Test test___33 = new T::Test();
            try
            {
                string d__168 = S0::SnakeGlobal.DirectionToString(new S0::Up());
                bool t___1163 = d__168 == "up";
                string fn__1160()
                {
                    return "Up should serialize to 'up'";
                }
                test___33.Assert(t___1163, (S1::Func<string>) fn__1160);
                S0::IDirection ? parsed__169 = S0::SnakeGlobal.StringToDirection("down");
                string fn__1159()
                {
                    return "'down' should parse to Down";
                }
                test___33.Assert(true, (S1::Func<string>) fn__1159);
            }
            finally
            {
                test___33.SoftFailToHard();
            }
        }
    }
}
