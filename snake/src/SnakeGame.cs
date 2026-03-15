using G = System.Collections.Generic;
namespace Snake
{
    public class SnakeGame
    {
        readonly int width__134;
        readonly int height__135;
        readonly G::IReadOnlyList<Point> snake__136;
        readonly IDirection direction__137;
        readonly Point food__138;
        readonly int score__139;
        readonly IGameStatus status__140;
        readonly int rngSeed__141;
        public SnakeGame(int width__143, int height__144, G::IReadOnlyList<Point> snake__145, IDirection direction__146, Point food__147, int score__148, IGameStatus status__149, int rngSeed__150)
        {
            this.width__134 = width__143;
            this.height__135 = height__144;
            this.snake__136 = snake__145;
            this.direction__137 = direction__146;
            this.food__138 = food__147;
            this.score__139 = score__148;
            this.status__140 = status__149;
            this.rngSeed__141 = rngSeed__150;
        }
        public int Width
        {
            get
            {
                return this.width__134;
            }
        }
        public int Height
        {
            get
            {
                return this.height__135;
            }
        }
        public G::IReadOnlyList<Point> Snake
        {
            get
            {
                return this.snake__136;
            }
        }
        public IDirection Direction
        {
            get
            {
                return this.direction__137;
            }
        }
        public Point Food
        {
            get
            {
                return this.food__138;
            }
        }
        public int Score
        {
            get
            {
                return this.score__139;
            }
        }
        public IGameStatus Status
        {
            get
            {
                return this.status__140;
            }
        }
        public int RngSeed
        {
            get
            {
                return this.rngSeed__141;
            }
        }
    }
}
