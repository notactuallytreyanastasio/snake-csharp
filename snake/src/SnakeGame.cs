using G = System.Collections.Generic;
namespace Snake
{
    public class SnakeGame
    {
        readonly int width__81;
        readonly int height__82;
        readonly G::IReadOnlyList<Point> snake__83;
        readonly IDirection direction__84;
        readonly Point food__85;
        readonly int score__86;
        readonly IGameStatus status__87;
        readonly int rngSeed__88;
        public SnakeGame(int width__90, int height__91, G::IReadOnlyList<Point> snake__92, IDirection direction__93, Point food__94, int score__95, IGameStatus status__96, int rngSeed__97)
        {
            this.width__81 = width__90;
            this.height__82 = height__91;
            this.snake__83 = snake__92;
            this.direction__84 = direction__93;
            this.food__85 = food__94;
            this.score__86 = score__95;
            this.status__87 = status__96;
            this.rngSeed__88 = rngSeed__97;
        }
        public int Width
        {
            get
            {
                return this.width__81;
            }
        }
        public int Height
        {
            get
            {
                return this.height__82;
            }
        }
        public G::IReadOnlyList<Point> Snake
        {
            get
            {
                return this.snake__83;
            }
        }
        public IDirection Direction
        {
            get
            {
                return this.direction__84;
            }
        }
        public Point Food
        {
            get
            {
                return this.food__85;
            }
        }
        public int Score
        {
            get
            {
                return this.score__86;
            }
        }
        public IGameStatus Status
        {
            get
            {
                return this.status__87;
            }
        }
        public int RngSeed
        {
            get
            {
                return this.rngSeed__88;
            }
        }
    }
}
