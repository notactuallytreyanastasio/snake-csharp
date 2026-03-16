using G = System.Collections.Generic;
namespace Snake
{
    public class MultiSnakeGame
    {
        readonly int width__228;
        readonly int height__229;
        readonly G::IReadOnlyList<PlayerSnake> snakes__230;
        readonly Point food__231;
        readonly int rngSeed__232;
        readonly int tickCount__233;
        public MultiSnakeGame(int width__235, int height__236, G::IReadOnlyList<PlayerSnake> snakes__237, Point food__238, int rngSeed__239, int tickCount__240)
        {
            this.width__228 = width__235;
            this.height__229 = height__236;
            this.snakes__230 = snakes__237;
            this.food__231 = food__238;
            this.rngSeed__232 = rngSeed__239;
            this.tickCount__233 = tickCount__240;
        }
        public int Width
        {
            get
            {
                return this.width__228;
            }
        }
        public int Height
        {
            get
            {
                return this.height__229;
            }
        }
        public G::IReadOnlyList<PlayerSnake> Snakes
        {
            get
            {
                return this.snakes__230;
            }
        }
        public Point Food
        {
            get
            {
                return this.food__231;
            }
        }
        public int RngSeed
        {
            get
            {
                return this.rngSeed__232;
            }
        }
        public int TickCount
        {
            get
            {
                return this.tickCount__233;
            }
        }
    }
}
