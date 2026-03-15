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
        public void initialStateHasSnakeNearCenter__168()
        {
            T::Test test___0 = new T::Test();
            try
            {
                S0::SnakeGame game__65 = S0::SnakeGlobal.NewGame(10, 10, 42);
                S0::Point head__66 = C::Listed.GetOr(game__65.Snake, 0, new S0::Point(-1, -1));
                bool t___1567 = head__66.X == 5;
                string fn__1560()
                {
                    return "head x should be 5, got " + S1::Convert.ToString(head__66.X);
                }
                test___0.Assert(t___1567, (S1::Func<string>) fn__1560);
                bool t___1571 = head__66.Y == 5;
                string fn__1559()
                {
                    return "head y should be 5, got " + S1::Convert.ToString(head__66.Y);
                }
                test___0.Assert(t___1571, (S1::Func<string>) fn__1559);
                bool t___1576 = game__65.Snake.Count == 3;
                string fn__1558()
                {
                    return "snake should start with 3 segments";
                }
                test___0.Assert(t___1576, (S1::Func<string>) fn__1558);
            }
            finally
            {
                test___0.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void initialStatusIsPlaying__169()
        {
            T::Test test___1 = new T::Test();
            try
            {
                S0::SnakeGame game__68 = S0::SnakeGlobal.NewGame(10, 10, 42);
                bool t___1551 = game__68.Status is S0::Playing;
                string fn__1548()
                {
                    return "initial status should be Playing";
                }
                test___1.Assert(t___1551, (S1::Func<string>) fn__1548);
            }
            finally
            {
                test___1.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void initialDirectionIsRight__170()
        {
            T::Test test___2 = new T::Test();
            try
            {
                S0::SnakeGame game__70 = S0::SnakeGlobal.NewGame(10, 10, 42);
                bool t___1545 = game__70.Direction is S0::Right;
                string fn__1542()
                {
                    return "initial direction should be Right";
                }
                test___2.Assert(t___1545, (S1::Func<string>) fn__1542);
            }
            finally
            {
                test___2.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void initialScoreIs0__171()
        {
            T::Test test___3 = new T::Test();
            try
            {
                S0::SnakeGame game__72 = S0::SnakeGlobal.NewGame(10, 10, 42);
                bool t___1540 = game__72.Score == 0;
                string fn__1536()
                {
                    return "initial score should be 0";
                }
                test___3.Assert(t___1540, (S1::Func<string>) fn__1536);
            }
            finally
            {
                test___3.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void snakeMovesRight__172()
        {
            T::Test test___4 = new T::Test();
            try
            {
                S0::SnakeGame game__74 = S0::SnakeGlobal.NewGame(10, 10, 42);
                S0::SnakeGame moved__75 = S0::SnakeGlobal.Tick(game__74);
                S0::Point head__76 = C::Listed.GetOr(moved__75.Snake, 0, new S0::Point(-1, -1));
                bool t___1530 = head__76.X == 6;
                string fn__1522()
                {
                    return "head should move right to x=6, got " + S1::Convert.ToString(head__76.X);
                }
                test___4.Assert(t___1530, (S1::Func<string>) fn__1522);
                bool t___1534 = head__76.Y == 5;
                string fn__1521()
                {
                    return "head y should stay 5, got " + S1::Convert.ToString(head__76.Y);
                }
                test___4.Assert(t___1534, (S1::Func<string>) fn__1521);
            }
            finally
            {
                test___4.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void snakeMovesDown__173()
        {
            T::Test test___5 = new T::Test();
            try
            {
                S0::SnakeGame game__78 = S0::SnakeGlobal.ChangeDirection(S0::SnakeGlobal.NewGame(10, 10, 42), new S0::Down());
                S0::SnakeGame moved__79 = S0::SnakeGlobal.Tick(game__78);
                S0::Point head__80 = C::Listed.GetOr(moved__79.Snake, 0, new S0::Point(-1, -1));
                bool t___1511 = head__80.X == 5;
                string fn__1502()
                {
                    return "head x should stay 5, got " + S1::Convert.ToString(head__80.X);
                }
                test___5.Assert(t___1511, (S1::Func<string>) fn__1502);
                bool t___1515 = head__80.Y == 6;
                string fn__1501()
                {
                    return "head should move down to y=6, got " + S1::Convert.ToString(head__80.Y);
                }
                test___5.Assert(t___1515, (S1::Func<string>) fn__1501);
            }
            finally
            {
                test___5.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void snakeMovesUp__174()
        {
            T::Test test___6 = new T::Test();
            try
            {
                S0::SnakeGame game__82 = S0::SnakeGlobal.ChangeDirection(S0::SnakeGlobal.NewGame(10, 10, 42), new S0::Up());
                S0::SnakeGame moved__83 = S0::SnakeGlobal.Tick(game__82);
                S0::Point head__84 = C::Listed.GetOr(moved__83.Snake, 0, new S0::Point(-1, -1));
                bool t___1495 = head__84.Y == 4;
                string fn__1486()
                {
                    return "head should move up to y=4, got " + S1::Convert.ToString(head__84.Y);
                }
                test___6.Assert(t___1495, (S1::Func<string>) fn__1486);
            }
            finally
            {
                test___6.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void oppositeDirectionIsRejected__175()
        {
            T::Test test___7 = new T::Test();
            try
            {
                S0::SnakeGame game__86 = S0::SnakeGlobal.NewGame(10, 10, 42);
                S0::SnakeGame changed__87 = S0::SnakeGlobal.ChangeDirection(game__86, new S0::Left());
                bool t___1481 = changed__87.Direction is S0::Right;
                string fn__1477()
                {
                    return "should still be Right after trying Left";
                }
                test___7.Assert(t___1481, (S1::Func<string>) fn__1477);
            }
            finally
            {
                test___7.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void nonOppositeDirectionIsAccepted__176()
        {
            T::Test test___8 = new T::Test();
            try
            {
                S0::SnakeGame game__89 = S0::SnakeGlobal.NewGame(10, 10, 42);
                S0::SnakeGame changed__90 = S0::SnakeGlobal.ChangeDirection(game__89, new S0::Up());
                bool t___1474 = changed__90.Direction is S0::Up;
                string fn__1470()
                {
                    return "should change to Up";
                }
                test___8.Assert(t___1474, (S1::Func<string>) fn__1470);
            }
            finally
            {
                test___8.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void wallCollisionCausesGameOver__177()
        {
            T::Test test___9 = new T::Test();
            try
            {
                S0::SnakeGame t___1465;
                S0::SnakeGame t___1464 = S0::SnakeGlobal.NewGame(10, 10, 42);
                S0::SnakeGame game__92 = t___1464;
                int i__93 = 0;
                while (i__93 < 10)
                {
                    t___1465 = S0::SnakeGlobal.Tick(game__92);
                    game__92 = t___1465;
                    i__93 = i__93 + 1;
                }
                bool t___1467 = game__92.Status is S0::GameOver;
                string fn__1463()
                {
                    return "should be GameOver after hitting wall";
                }
                test___9.Assert(t___1467, (S1::Func<string>) fn__1463);
            }
            finally
            {
                test___9.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void selfCollisionCausesGameOver__178()
        {
            T::Test test___10 = new T::Test();
            try
            {
                G::IReadOnlyList<S0::Point> snake__95 = C::Listed.CreateReadOnlyList<S0::Point>(new S0::Point(5, 5), new S0::Point(6, 5), new S0::Point(6, 4), new S0::Point(5, 4), new S0::Point(4, 4), new S0::Point(4, 5), new S0::Point(4, 6));
                S0::SnakeGame t___1457 = new S0::SnakeGame(10, 10, snake__95, new S0::Left(), new S0::Point(0, 0), 0, new S0::Playing(), 42);
                S0::SnakeGame game__96 = t___1457;
                S0::SnakeGame t___1458 = S0::SnakeGlobal.Tick(game__96);
                game__96 = t___1458;
                bool t___1460 = game__96.Status is S0::GameOver;
                string fn__1446()
                {
                    return "should be GameOver after self collision";
                }
                test___10.Assert(t___1460, (S1::Func<string>) fn__1446);
            }
            finally
            {
                test___10.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void pointEqualsWorksForSamePoints__179()
        {
            T::Test test___11 = new T::Test();
            try
            {
                bool t___1444 = S0::SnakeGlobal.PointEquals(new S0::Point(3, 4), new S0::Point(3, 4));
                string fn__1440()
                {
                    return "same points should be equal";
                }
                test___11.Assert(t___1444, (S1::Func<string>) fn__1440);
            }
            finally
            {
                test___11.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void pointEqualsWorksForDifferentPoints__180()
        {
            T::Test test___12 = new T::Test();
            try
            {
                bool t___1438 = !S0::SnakeGlobal.PointEquals(new S0::Point(3, 4), new S0::Point(5, 6));
                string fn__1434()
                {
                    return "different points should not be equal";
                }
                test___12.Assert(t___1438, (S1::Func<string>) fn__1434);
            }
            finally
            {
                test___12.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void isOppositeDetectsOppositeDirections__181()
        {
            T::Test test___13 = new T::Test();
            try
            {
                bool t___1422 = S0::SnakeGlobal.IsOpposite(new S0::Up(), new S0::Down());
                string fn__1418()
                {
                    return "Up/Down are opposite";
                }
                test___13.Assert(t___1422, (S1::Func<string>) fn__1418);
                bool t___1427 = S0::SnakeGlobal.IsOpposite(new S0::Left(), new S0::Right());
                string fn__1417()
                {
                    return "Left/Right are opposite";
                }
                test___13.Assert(t___1427, (S1::Func<string>) fn__1417);
                bool t___1432 = !S0::SnakeGlobal.IsOpposite(new S0::Up(), new S0::Left());
                string fn__1416()
                {
                    return "Up/Left are not opposite";
                }
                test___13.Assert(t___1432, (S1::Func<string>) fn__1416);
            }
            finally
            {
                test___13.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void directionDeltaReturnsCorrectDeltas__182()
        {
            T::Test test___14 = new T::Test();
            try
            {
                int t___1408;
                int t___1413;
                bool t___701;
                bool t___706;
                S0::Point up__101 = S0::SnakeGlobal.DirectionDelta(new S0::Up());
                if (up__101.X == 0)
                {
                    t___1408 = up__101.Y;
                    t___701 = t___1408 == -1;
                }
                else
                {
                    t___701 = false;
                }
                string fn__1405()
                {
                    return "Up should be (0, -1)";
                }
                test___14.Assert(t___701, (S1::Func<string>) fn__1405);
                S0::Point right__102 = S0::SnakeGlobal.DirectionDelta(new S0::Right());
                if (right__102.X == 1)
                {
                    t___1413 = right__102.Y;
                    t___706 = t___1413 == 0;
                }
                else
                {
                    t___706 = false;
                }
                string fn__1404()
                {
                    return "Right should be (1, 0)";
                }
                test___14.Assert(t___706, (S1::Func<string>) fn__1404);
            }
            finally
            {
                test___14.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void prngIsDeterministic__183()
        {
            T::Test test___17 = new T::Test();
            try
            {
                S0::RandomResult r1__104 = S0::SnakeGlobal.NextRandom(42, 100);
                S0::RandomResult r2__105 = S0::SnakeGlobal.NextRandom(42, 100);
                bool t___1397 = r1__104.Value == r2__105.Value;
                string fn__1393()
                {
                    return "same seed should produce same value";
                }
                test___17.Assert(t___1397, (S1::Func<string>) fn__1393);
                bool t___1402 = r1__104.NextSeed == r2__105.NextSeed;
                string fn__1392()
                {
                    return "same seed should produce same next seed";
                }
                test___17.Assert(t___1402, (S1::Func<string>) fn__1392);
            }
            finally
            {
                test___17.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void prngProducesValuesInRange__184()
        {
            T::Test test___18 = new T::Test();
            try
            {
                int t___1389;
                bool t___691;
                S0::RandomResult r__107 = S0::SnakeGlobal.NextRandom(42, 10);
                if (r__107.Value >= 0)
                {
                    t___1389 = r__107.Value;
                    t___691 = t___1389 < 10;
                }
                else
                {
                    t___691 = false;
                }
                string fn__1387()
                {
                    return "value should be in [0, 10), got " + S1::Convert.ToString(r__107.Value);
                }
                test___18.Assert(t___691, (S1::Func<string>) fn__1387);
            }
            finally
            {
                test___18.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void tickDoesNothingWhenGameIsOver__185()
        {
            T::Test test___20 = new T::Test();
            try
            {
                S0::SnakeGame t___1370;
                S0::SnakeGame t___1369 = S0::SnakeGlobal.NewGame(10, 10, 42);
                S0::SnakeGame game__109 = t___1369;
                int i__110 = 0;
                while (i__110 < 10)
                {
                    t___1370 = S0::SnakeGlobal.Tick(game__109);
                    game__109 = t___1370;
                    i__110 = i__110 + 1;
                }
                bool t___1372 = game__109.Status is S0::GameOver;
                string fn__1368()
                {
                    return "should be GameOver";
                }
                test___20.Assert(t___1372, (S1::Func<string>) fn__1368);
                S0::Point head1__111 = C::Listed.GetOr(game__109.Snake, 0, new S0::Point(-1, -1));
                S0::SnakeGame t___1378 = S0::SnakeGlobal.Tick(game__109);
                game__109 = t___1378;
                S0::Point head2__112 = C::Listed.GetOr(game__109.Snake, 0, new S0::Point(-1, -1));
                bool t___1383 = S0::SnakeGlobal.PointEquals(head1__111, head2__112);
                string fn__1367()
                {
                    return "snake should not move after game over";
                }
                test___20.Assert(t___1383, (S1::Func<string>) fn__1367);
            }
            finally
            {
                test___20.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void multiGameCreatesCorrectNumberOfSnakes__186()
        {
            T::Test test___21 = new T::Test();
            try
            {
                S0::MultiSnakeGame game__114 = S0::SnakeGlobal.NewMultiGame(20, 10, 2, 42);
                bool t___1365 = game__114.Snakes.Count == 2;
                string fn__1360()
                {
                    return "should have 2 snakes";
                }
                test___21.Assert(t___1365, (S1::Func<string>) fn__1360);
            }
            finally
            {
                test___21.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void multiGameSnakesStartAlive__187()
        {
            T::Test test___22 = new T::Test();
            try
            {
                S0::MultiSnakeGame game__116 = S0::SnakeGlobal.NewMultiGame(20, 10, 2, 42);
                S0::PlayerSnake s0__117 = C::Listed.GetOr(game__116.Snakes, 0, new S0::PlayerSnake(0, C::Listed.CreateReadOnlyList<S0::Point>(), new S0::Right(), 0, new S0::Dead()));
                S0::PlayerSnake s1__118 = C::Listed.GetOr(game__116.Snakes, 1, new S0::PlayerSnake(0, C::Listed.CreateReadOnlyList<S0::Point>(), new S0::Right(), 0, new S0::Dead()));
                bool t___1353 = s0__117.Status is S0::Alive;
                string fn__1338()
                {
                    return "player 0 should be alive";
                }
                test___22.Assert(t___1353, (S1::Func<string>) fn__1338);
                bool t___1357 = s1__118.Status is S0::Alive;
                string fn__1337()
                {
                    return "player 1 should be alive";
                }
                test___22.Assert(t___1357, (S1::Func<string>) fn__1337);
            }
            finally
            {
                test___22.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void multiGameSnakesStartAtDifferentPositions__188()
        {
            T::Test test___23 = new T::Test();
            try
            {
                S0::MultiSnakeGame game__120 = S0::SnakeGlobal.NewMultiGame(20, 10, 2, 42);
                S0::PlayerSnake s0__121 = C::Listed.GetOr(game__120.Snakes, 0, new S0::PlayerSnake(0, C::Listed.CreateReadOnlyList<S0::Point>(), new S0::Right(), 0, new S0::Dead()));
                S0::PlayerSnake s1__122 = C::Listed.GetOr(game__120.Snakes, 1, new S0::PlayerSnake(0, C::Listed.CreateReadOnlyList<S0::Point>(), new S0::Right(), 0, new S0::Dead()));
                S0::Point h0__123 = C::Listed.GetOr(s0__121.Segments, 0, new S0::Point(-1, -1));
                S0::Point h1__124 = C::Listed.GetOr(s1__122.Segments, 0, new S0::Point(-1, -1));
                bool t___1335 = !S0::SnakeGlobal.PointEquals(h0__123, h1__124);
                string fn__1314()
                {
                    return "snakes should start at different positions";
                }
                test___23.Assert(t___1335, (S1::Func<string>) fn__1314);
            }
            finally
            {
                test___23.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void multiGameSnakesHave3_segmentsEach__189()
        {
            T::Test test___24 = new T::Test();
            try
            {
                S0::MultiSnakeGame game__126 = S0::SnakeGlobal.NewMultiGame(20, 10, 2, 42);
                S0::PlayerSnake s0__127 = C::Listed.GetOr(game__126.Snakes, 0, new S0::PlayerSnake(0, C::Listed.CreateReadOnlyList<S0::Point>(), new S0::Right(), 0, new S0::Dead()));
                S0::PlayerSnake s1__128 = C::Listed.GetOr(game__126.Snakes, 1, new S0::PlayerSnake(0, C::Listed.CreateReadOnlyList<S0::Point>(), new S0::Right(), 0, new S0::Dead()));
                bool t___1307 = s0__127.Segments.Count == 3;
                string fn__1290()
                {
                    return "player 0 should have 3 segments";
                }
                test___24.Assert(t___1307, (S1::Func<string>) fn__1290);
                bool t___1312 = s1__128.Segments.Count == 3;
                string fn__1289()
                {
                    return "player 1 should have 3 segments";
                }
                test___24.Assert(t___1312, (S1::Func<string>) fn__1289);
            }
            finally
            {
                test___24.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void multiTickMovesBothSnakes__190()
        {
            T::Test test___25 = new T::Test();
            try
            {
                S0::MultiSnakeGame game__130 = S0::SnakeGlobal.NewMultiGame(20, 10, 2, 42);
                S0::Point h0Before__131 = C::Listed.GetOr(C::Listed.GetOr(game__130.Snakes, 0, new S0::PlayerSnake(0, C::Listed.CreateReadOnlyList<S0::Point>(), new S0::Right(), 0, new S0::Dead())).Segments, 0, new S0::Point(0, 0));
                S0::Point h1Before__132 = C::Listed.GetOr(C::Listed.GetOr(game__130.Snakes, 1, new S0::PlayerSnake(0, C::Listed.CreateReadOnlyList<S0::Point>(), new S0::Right(), 0, new S0::Dead())).Segments, 0, new S0::Point(0, 0));
                G::IReadOnlyList<S0::IDirection> dirs__133 = C::Listed.CreateReadOnlyList<S0::IDirection>(new S0::Right(), new S0::Left());
                S0::MultiSnakeGame after__134 = S0::SnakeGlobal.MultiTick(game__130, dirs__133);
                S0::Point h0After__135 = C::Listed.GetOr(C::Listed.GetOr(after__134.Snakes, 0, new S0::PlayerSnake(0, C::Listed.CreateReadOnlyList<S0::Point>(), new S0::Right(), 0, new S0::Dead())).Segments, 0, new S0::Point(0, 0));
                S0::Point h1After__136 = C::Listed.GetOr(C::Listed.GetOr(after__134.Snakes, 1, new S0::PlayerSnake(0, C::Listed.CreateReadOnlyList<S0::Point>(), new S0::Right(), 0, new S0::Dead())).Segments, 0, new S0::Point(0, 0));
                bool t___1284 = !S0::SnakeGlobal.PointEquals(h0Before__131, h0After__135);
                string fn__1242()
                {
                    return "snake 0 should have moved";
                }
                test___25.Assert(t___1284, (S1::Func<string>) fn__1242);
                bool t___1287 = !S0::SnakeGlobal.PointEquals(h1Before__132, h1After__136);
                string fn__1241()
                {
                    return "snake 1 should have moved";
                }
                test___25.Assert(t___1287, (S1::Func<string>) fn__1241);
            }
            finally
            {
                test___25.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void multiWallCollisionKillsOneSnake__191()
        {
            T::Test test___26 = new T::Test();
            try
            {
                S0::MultiSnakeGame t___1227;
                int t___1229;
                G::IReadOnlyList<S0::PlayerSnake> t___1230;
                S0::PlayerSnake t___1234;
                S0::MultiSnakeGame t___1224 = S0::SnakeGlobal.NewMultiGame(20, 10, 2, 42);
                S0::MultiSnakeGame game__138 = t___1224;
                G::IReadOnlyList<S0::IDirection> dirs__139 = C::Listed.CreateReadOnlyList<S0::IDirection>(new S0::Right(), new S0::Left());
                int i__140 = 0;
                while (i__140 < 20)
                {
                    t___1227 = S0::SnakeGlobal.MultiTick(game__138, dirs__139);
                    game__138 = t___1227;
                    i__140 = i__140 + 1;
                }
                int deadCount__141 = 0;
                int i__142 = 0;
                while (true)
                {
                    t___1229 = game__138.Snakes.Count;
                    if (!(i__142 < t___1229)) break;
                    t___1230 = game__138.Snakes;
                    t___1234 = new S0::PlayerSnake(0, C::Listed.CreateReadOnlyList<S0::Point>(), new S0::Right(), 0, new S0::Dead());
                    S0::PlayerSnake snake__143 = C::Listed.GetOr(t___1230, i__142, t___1234);
                    if (snake__143.Status is S0::Dead)
                    {
                        deadCount__141 = deadCount__141 + 1;
                    }
                    i__142 = i__142 + 1;
                }
                bool t___1239 = deadCount__141 > 0;
                string fn__1223()
                {
                    return "at least one snake should be dead after 20 ticks toward walls";
                }
                test___26.Assert(t___1239, (S1::Func<string>) fn__1223);
            }
            finally
            {
                test___26.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void multiGameOverWhenOnePlayerLeft__192()
        {
            T::Test test___27 = new T::Test();
            try
            {
                S0::MultiSnakeGame t___1219;
                S0::MultiSnakeGame t___1216 = S0::SnakeGlobal.NewMultiGame(20, 10, 2, 42);
                S0::MultiSnakeGame game__145 = t___1216;
                G::IReadOnlyList<S0::IDirection> dirs__146 = C::Listed.CreateReadOnlyList<S0::IDirection>(new S0::Right(), new S0::Left());
                int i__147 = 0;
                while (i__147 < 30)
                {
                    t___1219 = S0::SnakeGlobal.MultiTick(game__145, dirs__146);
                    game__145 = t___1219;
                    i__147 = i__147 + 1;
                }
                bool t___1220 = S0::SnakeGlobal.IsMultiGameOver(game__145);
                string fn__1215()
                {
                    return "game should be over after enough ticks";
                }
                test___27.Assert(t___1220, (S1::Func<string>) fn__1215);
            }
            finally
            {
                test___27.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void changePlayerDirectionWorks__193()
        {
            T::Test test___28 = new T::Test();
            try
            {
                S0::MultiSnakeGame game__149 = S0::SnakeGlobal.NewMultiGame(20, 10, 2, 42);
                S0::Up t___1203 = new S0::Up();
                S0::MultiSnakeGame changed__150 = S0::SnakeGlobal.ChangePlayerDirection(game__149, 0, t___1203);
                S0::PlayerSnake s0__151 = C::Listed.GetOr(changed__150.Snakes, 0, new S0::PlayerSnake(0, C::Listed.CreateReadOnlyList<S0::Point>(), new S0::Right(), 0, new S0::Dead()));
                bool t___1212 = s0__151.Direction is S0::Up;
                string fn__1201()
                {
                    return "player 0 direction should be Up";
                }
                test___28.Assert(t___1212, (S1::Func<string>) fn__1201);
            }
            finally
            {
                test___28.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void changePlayerDirectionRejectsOpposite__194()
        {
            T::Test test___29 = new T::Test();
            try
            {
                S0::MultiSnakeGame game__153 = S0::SnakeGlobal.NewMultiGame(20, 10, 2, 42);
                S0::Left t___1189 = new S0::Left();
                S0::MultiSnakeGame changed__154 = S0::SnakeGlobal.ChangePlayerDirection(game__153, 0, t___1189);
                S0::PlayerSnake s0__155 = C::Listed.GetOr(changed__154.Snakes, 0, new S0::PlayerSnake(0, C::Listed.CreateReadOnlyList<S0::Point>(), new S0::Right(), 0, new S0::Dead()));
                bool t___1198 = s0__155.Direction is S0::Right;
                string fn__1187()
                {
                    return "should reject opposite direction";
                }
                test___29.Assert(t___1198, (S1::Func<string>) fn__1187);
            }
            finally
            {
                test___29.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void addPlayerAddsANewSnake__195()
        {
            T::Test test___30 = new T::Test();
            try
            {
                S0::MultiSnakeGame game__157 = S0::SnakeGlobal.NewMultiGame(20, 10, 2, 42);
                S0::MultiSnakeGame bigger__158 = S0::SnakeGlobal.AddPlayer(game__157, 99);
                bool t___1185 = bigger__158.Snakes.Count == 3;
                string fn__1179()
                {
                    return "should have 3 snakes after adding";
                }
                test___30.Assert(t___1185, (S1::Func<string>) fn__1179);
            }
            finally
            {
                test___30.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void removePlayerRemovesASnake__196()
        {
            T::Test test___31 = new T::Test();
            try
            {
                S0::MultiSnakeGame game__160 = S0::SnakeGlobal.NewMultiGame(20, 10, 3, 42);
                S0::MultiSnakeGame smaller__161 = S0::SnakeGlobal.RemovePlayer(game__160, 1);
                bool t___1177 = smaller__161.Snakes.Count == 2;
                string fn__1171()
                {
                    return "should have 2 snakes after removing";
                }
                test___31.Assert(t___1177, (S1::Func<string>) fn__1171);
            }
            finally
            {
                test___31.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void multiRenderProducesOutput__197()
        {
            T::Test test___32 = new T::Test();
            try
            {
                S0::MultiSnakeGame game__163 = S0::SnakeGlobal.NewMultiGame(20, 10, 2, 42);
                string rendered__164 = S0::SnakeGlobal.MultiRender(game__163);
                bool t___1169 = rendered__164 != "";
                string fn__1165()
                {
                    return "render should produce output";
                }
                test___32.Assert(t___1169, (S1::Func<string>) fn__1165);
            }
            finally
            {
                test___32.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void directionToStringAndStringToDirectionRoundTrip__198()
        {
            T::Test test___33 = new T::Test();
            try
            {
                string d__166 = S0::SnakeGlobal.DirectionToString(new S0::Up());
                bool t___1161 = d__166 == "up";
                string fn__1158()
                {
                    return "Up should serialize to 'up'";
                }
                test___33.Assert(t___1161, (S1::Func<string>) fn__1158);
                S0::IDirection ? parsed__167 = S0::SnakeGlobal.StringToDirection("down");
                string fn__1157()
                {
                    return "'down' should parse to Down";
                }
                test___33.Assert(true, (S1::Func<string>) fn__1157);
            }
            finally
            {
                test___33.SoftFailToHard();
            }
        }
    }
}
