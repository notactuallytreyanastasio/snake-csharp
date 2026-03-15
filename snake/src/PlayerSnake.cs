using G = System.Collections.Generic;
namespace Snake
{
    public class PlayerSnake
    {
        readonly int id__216;
        readonly G::IReadOnlyList<Point> segments__217;
        readonly IDirection direction__218;
        readonly int score__219;
        readonly IPlayerStatus status__220;
        public PlayerSnake(int id__222, G::IReadOnlyList<Point> segments__223, IDirection direction__224, int score__225, IPlayerStatus status__226)
        {
            this.id__216 = id__222;
            this.segments__217 = segments__223;
            this.direction__218 = direction__224;
            this.score__219 = score__225;
            this.status__220 = status__226;
        }
        public int Id
        {
            get
            {
                return this.id__216;
            }
        }
        public G::IReadOnlyList<Point> Segments
        {
            get
            {
                return this.segments__217;
            }
        }
        public IDirection Direction
        {
            get
            {
                return this.direction__218;
            }
        }
        public int Score
        {
            get
            {
                return this.score__219;
            }
        }
        public IPlayerStatus Status
        {
            get
            {
                return this.status__220;
            }
        }
    }
}
