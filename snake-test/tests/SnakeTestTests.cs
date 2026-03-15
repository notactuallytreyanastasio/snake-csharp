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
        public void initialStateHasSnakeNearCenter__86()
        {
            T::Test test___0 = new T::Test();
            try
            {
                S0::SnakeGame game__38 = S0::SnakeGlobal.NewGame(10, 10, 42);
                S0::Point head__39 = C::Listed.GetOr(game__38.Snake, 0, new S0::Point(-1, -1));
                bool t___766 = head__39.X == 5;
                string fn__759()
                {
                    return "head x should be 5, got " + S1::Convert.ToString(head__39.X);
                }
                test___0.Assert(t___766, (S1::Func<string>) fn__759);
                bool t___770 = head__39.Y == 5;
                string fn__758()
                {
                    return "head y should be 5, got " + S1::Convert.ToString(head__39.Y);
                }
                test___0.Assert(t___770, (S1::Func<string>) fn__758);
                bool t___775 = game__38.Snake.Count == 3;
                string fn__757()
                {
                    return "snake should start with 3 segments";
                }
                test___0.Assert(t___775, (S1::Func<string>) fn__757);
            }
            finally
            {
                test___0.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void initialStatusIsPlaying__87()
        {
            T::Test test___1 = new T::Test();
            try
            {
                S0::SnakeGame game__41 = S0::SnakeGlobal.NewGame(10, 10, 42);
                bool t___750 = game__41.Status is S0::Playing;
                string fn__747()
                {
                    return "initial status should be Playing";
                }
                test___1.Assert(t___750, (S1::Func<string>) fn__747);
            }
            finally
            {
                test___1.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void initialDirectionIsRight__88()
        {
            T::Test test___2 = new T::Test();
            try
            {
                S0::SnakeGame game__43 = S0::SnakeGlobal.NewGame(10, 10, 42);
                bool t___744 = game__43.Direction is S0::Right;
                string fn__741()
                {
                    return "initial direction should be Right";
                }
                test___2.Assert(t___744, (S1::Func<string>) fn__741);
            }
            finally
            {
                test___2.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void initialScoreIs0__89()
        {
            T::Test test___3 = new T::Test();
            try
            {
                S0::SnakeGame game__45 = S0::SnakeGlobal.NewGame(10, 10, 42);
                bool t___739 = game__45.Score == 0;
                string fn__735()
                {
                    return "initial score should be 0";
                }
                test___3.Assert(t___739, (S1::Func<string>) fn__735);
            }
            finally
            {
                test___3.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void snakeMovesRight__90()
        {
            T::Test test___4 = new T::Test();
            try
            {
                S0::SnakeGame game__47 = S0::SnakeGlobal.NewGame(10, 10, 42);
                S0::SnakeGame moved__48 = S0::SnakeGlobal.Tick(game__47);
                S0::Point head__49 = C::Listed.GetOr(moved__48.Snake, 0, new S0::Point(-1, -1));
                bool t___729 = head__49.X == 6;
                string fn__721()
                {
                    return "head should move right to x=6, got " + S1::Convert.ToString(head__49.X);
                }
                test___4.Assert(t___729, (S1::Func<string>) fn__721);
                bool t___733 = head__49.Y == 5;
                string fn__720()
                {
                    return "head y should stay 5, got " + S1::Convert.ToString(head__49.Y);
                }
                test___4.Assert(t___733, (S1::Func<string>) fn__720);
            }
            finally
            {
                test___4.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void snakeMovesDown__91()
        {
            T::Test test___5 = new T::Test();
            try
            {
                S0::SnakeGame game__51 = S0::SnakeGlobal.ChangeDirection(S0::SnakeGlobal.NewGame(10, 10, 42), new S0::Down());
                S0::SnakeGame moved__52 = S0::SnakeGlobal.Tick(game__51);
                S0::Point head__53 = C::Listed.GetOr(moved__52.Snake, 0, new S0::Point(-1, -1));
                bool t___710 = head__53.X == 5;
                string fn__701()
                {
                    return "head x should stay 5, got " + S1::Convert.ToString(head__53.X);
                }
                test___5.Assert(t___710, (S1::Func<string>) fn__701);
                bool t___714 = head__53.Y == 6;
                string fn__700()
                {
                    return "head should move down to y=6, got " + S1::Convert.ToString(head__53.Y);
                }
                test___5.Assert(t___714, (S1::Func<string>) fn__700);
            }
            finally
            {
                test___5.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void snakeMovesUp__92()
        {
            T::Test test___6 = new T::Test();
            try
            {
                S0::SnakeGame game__55 = S0::SnakeGlobal.ChangeDirection(S0::SnakeGlobal.NewGame(10, 10, 42), new S0::Up());
                S0::SnakeGame moved__56 = S0::SnakeGlobal.Tick(game__55);
                S0::Point head__57 = C::Listed.GetOr(moved__56.Snake, 0, new S0::Point(-1, -1));
                bool t___694 = head__57.Y == 4;
                string fn__685()
                {
                    return "head should move up to y=4, got " + S1::Convert.ToString(head__57.Y);
                }
                test___6.Assert(t___694, (S1::Func<string>) fn__685);
            }
            finally
            {
                test___6.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void oppositeDirectionIsRejected__93()
        {
            T::Test test___7 = new T::Test();
            try
            {
                S0::SnakeGame game__59 = S0::SnakeGlobal.NewGame(10, 10, 42);
                S0::SnakeGame changed__60 = S0::SnakeGlobal.ChangeDirection(game__59, new S0::Left());
                bool t___680 = changed__60.Direction is S0::Right;
                string fn__676()
                {
                    return "should still be Right after trying Left";
                }
                test___7.Assert(t___680, (S1::Func<string>) fn__676);
            }
            finally
            {
                test___7.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void nonOppositeDirectionIsAccepted__94()
        {
            T::Test test___8 = new T::Test();
            try
            {
                S0::SnakeGame game__62 = S0::SnakeGlobal.NewGame(10, 10, 42);
                S0::SnakeGame changed__63 = S0::SnakeGlobal.ChangeDirection(game__62, new S0::Up());
                bool t___673 = changed__63.Direction is S0::Up;
                string fn__669()
                {
                    return "should change to Up";
                }
                test___8.Assert(t___673, (S1::Func<string>) fn__669);
            }
            finally
            {
                test___8.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void wallCollisionCausesGameOver__95()
        {
            T::Test test___9 = new T::Test();
            try
            {
                S0::SnakeGame t___664;
                S0::SnakeGame t___663 = S0::SnakeGlobal.NewGame(10, 10, 42);
                S0::SnakeGame game__65 = t___663;
                int i__66 = 0;
                while (i__66 < 10)
                {
                    t___664 = S0::SnakeGlobal.Tick(game__65);
                    game__65 = t___664;
                    i__66 = i__66 + 1;
                }
                bool t___666 = game__65.Status is S0::GameOver;
                string fn__662()
                {
                    return "should be GameOver after hitting wall";
                }
                test___9.Assert(t___666, (S1::Func<string>) fn__662);
            }
            finally
            {
                test___9.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void selfCollisionCausesGameOver__96()
        {
            T::Test test___10 = new T::Test();
            try
            {
                G::IReadOnlyList<S0::Point> snake__68 = C::Listed.CreateReadOnlyList<S0::Point>(new S0::Point(5, 5), new S0::Point(6, 5), new S0::Point(6, 4), new S0::Point(5, 4), new S0::Point(4, 4), new S0::Point(4, 5), new S0::Point(4, 6));
                S0::SnakeGame t___656 = new S0::SnakeGame(10, 10, snake__68, new S0::Left(), new S0::Point(0, 0), 0, new S0::Playing(), 42);
                S0::SnakeGame game__69 = t___656;
                S0::SnakeGame t___657 = S0::SnakeGlobal.Tick(game__69);
                game__69 = t___657;
                bool t___659 = game__69.Status is S0::GameOver;
                string fn__645()
                {
                    return "should be GameOver after self collision";
                }
                test___10.Assert(t___659, (S1::Func<string>) fn__645);
            }
            finally
            {
                test___10.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void pointEqualsWorksForSamePoints__97()
        {
            T::Test test___11 = new T::Test();
            try
            {
                bool t___643 = S0::SnakeGlobal.PointEquals(new S0::Point(3, 4), new S0::Point(3, 4));
                string fn__639()
                {
                    return "same points should be equal";
                }
                test___11.Assert(t___643, (S1::Func<string>) fn__639);
            }
            finally
            {
                test___11.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void pointEqualsWorksForDifferentPoints__98()
        {
            T::Test test___12 = new T::Test();
            try
            {
                bool t___637 = !S0::SnakeGlobal.PointEquals(new S0::Point(3, 4), new S0::Point(5, 6));
                string fn__633()
                {
                    return "different points should not be equal";
                }
                test___12.Assert(t___637, (S1::Func<string>) fn__633);
            }
            finally
            {
                test___12.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void isOppositeDetectsOppositeDirections__99()
        {
            T::Test test___13 = new T::Test();
            try
            {
                bool t___621 = S0::SnakeGlobal.IsOpposite(new S0::Up(), new S0::Down());
                string fn__617()
                {
                    return "Up/Down are opposite";
                }
                test___13.Assert(t___621, (S1::Func<string>) fn__617);
                bool t___626 = S0::SnakeGlobal.IsOpposite(new S0::Left(), new S0::Right());
                string fn__616()
                {
                    return "Left/Right are opposite";
                }
                test___13.Assert(t___626, (S1::Func<string>) fn__616);
                bool t___631 = !S0::SnakeGlobal.IsOpposite(new S0::Up(), new S0::Left());
                string fn__615()
                {
                    return "Up/Left are not opposite";
                }
                test___13.Assert(t___631, (S1::Func<string>) fn__615);
            }
            finally
            {
                test___13.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void directionDeltaReturnsCorrectDeltas__100()
        {
            T::Test test___14 = new T::Test();
            try
            {
                int t___607;
                int t___612;
                bool t___279;
                bool t___284;
                S0::Point up__74 = S0::SnakeGlobal.DirectionDelta(new S0::Up());
                if (up__74.X == 0)
                {
                    t___607 = up__74.Y;
                    t___279 = t___607 == -1;
                }
                else
                {
                    t___279 = false;
                }
                string fn__604()
                {
                    return "Up should be (0, -1)";
                }
                test___14.Assert(t___279, (S1::Func<string>) fn__604);
                S0::Point right__75 = S0::SnakeGlobal.DirectionDelta(new S0::Right());
                if (right__75.X == 1)
                {
                    t___612 = right__75.Y;
                    t___284 = t___612 == 0;
                }
                else
                {
                    t___284 = false;
                }
                string fn__603()
                {
                    return "Right should be (1, 0)";
                }
                test___14.Assert(t___284, (S1::Func<string>) fn__603);
            }
            finally
            {
                test___14.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void prngIsDeterministic__101()
        {
            T::Test test___17 = new T::Test();
            try
            {
                S0::RandomResult r1__77 = S0::SnakeGlobal.NextRandom(42, 100);
                S0::RandomResult r2__78 = S0::SnakeGlobal.NextRandom(42, 100);
                bool t___596 = r1__77.Value == r2__78.Value;
                string fn__592()
                {
                    return "same seed should produce same value";
                }
                test___17.Assert(t___596, (S1::Func<string>) fn__592);
                bool t___601 = r1__77.NextSeed == r2__78.NextSeed;
                string fn__591()
                {
                    return "same seed should produce same next seed";
                }
                test___17.Assert(t___601, (S1::Func<string>) fn__591);
            }
            finally
            {
                test___17.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void prngProducesValuesInRange__102()
        {
            T::Test test___18 = new T::Test();
            try
            {
                int t___588;
                bool t___269;
                S0::RandomResult r__80 = S0::SnakeGlobal.NextRandom(42, 10);
                if (r__80.Value >= 0)
                {
                    t___588 = r__80.Value;
                    t___269 = t___588 < 10;
                }
                else
                {
                    t___269 = false;
                }
                string fn__586()
                {
                    return "value should be in [0, 10), got " + S1::Convert.ToString(r__80.Value);
                }
                test___18.Assert(t___269, (S1::Func<string>) fn__586);
            }
            finally
            {
                test___18.SoftFailToHard();
            }
        }
        [U::TestMethod]
        public void tickDoesNothingWhenGameIsOver__103()
        {
            T::Test test___20 = new T::Test();
            try
            {
                S0::SnakeGame t___569;
                S0::SnakeGame t___568 = S0::SnakeGlobal.NewGame(10, 10, 42);
                S0::SnakeGame game__82 = t___568;
                int i__83 = 0;
                while (i__83 < 10)
                {
                    t___569 = S0::SnakeGlobal.Tick(game__82);
                    game__82 = t___569;
                    i__83 = i__83 + 1;
                }
                bool t___571 = game__82.Status is S0::GameOver;
                string fn__567()
                {
                    return "should be GameOver";
                }
                test___20.Assert(t___571, (S1::Func<string>) fn__567);
                S0::Point head1__84 = C::Listed.GetOr(game__82.Snake, 0, new S0::Point(-1, -1));
                S0::SnakeGame t___577 = S0::SnakeGlobal.Tick(game__82);
                game__82 = t___577;
                S0::Point head2__85 = C::Listed.GetOr(game__82.Snake, 0, new S0::Point(-1, -1));
                bool t___582 = S0::SnakeGlobal.PointEquals(head1__84, head2__85);
                string fn__566()
                {
                    return "snake should not move after game over";
                }
                test___20.Assert(t___582, (S1::Func<string>) fn__566);
            }
            finally
            {
                test___20.SoftFailToHard();
            }
        }
    }
}
