using G = System.Collections.Generic;
namespace Snake
{
    public class MultiSnakeGame
    {
        readonly int width__227;
        readonly int height__228;
        readonly G::IReadOnlyList<PlayerSnake> snakes__229;
        readonly Point food__230;
        readonly int rngSeed__231;
        readonly int tickCount__232;
        public MultiSnakeGame(int width__234, int height__235, G::IReadOnlyList<PlayerSnake> snakes__236, Point food__237, int rngSeed__238, int tickCount__239)
        {
            this.width__227 = width__234;
            this.height__228 = height__235;
            this.snakes__229 = snakes__236;
            this.food__230 = food__237;
            this.rngSeed__231 = rngSeed__238;
            this.tickCount__232 = tickCount__239;
        }
        public int Width
        {
            get
            {
                return this.width__227;
            }
        }
        public int Height
        {
            get
            {
                return this.height__228;
            }
        }
        public G::IReadOnlyList<PlayerSnake> Snakes
        {
            get
            {
                return this.snakes__229;
            }
        }
        public Point Food
        {
            get
            {
                return this.food__230;
            }
        }
        public int RngSeed
        {
            get
            {
                return this.rngSeed__231;
            }
        }
        public int TickCount
        {
            get
            {
                return this.tickCount__232;
            }
        }
    }
}
