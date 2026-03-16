using G = System.Collections.Generic;
namespace Snake
{
    public class SnakeGame
    {
        readonly int width__135;
        readonly int height__136;
        readonly G::IReadOnlyList<Point> snake__137;
        readonly IDirection direction__138;
        readonly Point food__139;
        readonly int score__140;
        readonly IGameStatus status__141;
        readonly int rngSeed__142;
        public SnakeGame(int width__144, int height__145, G::IReadOnlyList<Point> snake__146, IDirection direction__147, Point food__148, int score__149, IGameStatus status__150, int rngSeed__151)
        {
            this.width__135 = width__144;
            this.height__136 = height__145;
            this.snake__137 = snake__146;
            this.direction__138 = direction__147;
            this.food__139 = food__148;
            this.score__140 = score__149;
            this.status__141 = status__150;
            this.rngSeed__142 = rngSeed__151;
        }
        public int Width
        {
            get
            {
                return this.width__135;
            }
        }
        public int Height
        {
            get
            {
                return this.height__136;
            }
        }
        public G::IReadOnlyList<Point> Snake
        {
            get
            {
                return this.snake__137;
            }
        }
        public IDirection Direction
        {
            get
            {
                return this.direction__138;
            }
        }
        public Point Food
        {
            get
            {
                return this.food__139;
            }
        }
        public int Score
        {
            get
            {
                return this.score__140;
            }
        }
        public IGameStatus Status
        {
            get
            {
                return this.status__141;
            }
        }
        public int RngSeed
        {
            get
            {
                return this.rngSeed__142;
            }
        }
    }
}
