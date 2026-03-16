using G = System.Collections.Generic;
namespace Snake
{
    public class PlayerSnake
    {
        readonly int id__217;
        readonly G::IReadOnlyList<Point> segments__218;
        readonly IDirection direction__219;
        readonly int score__220;
        readonly IPlayerStatus status__221;
        public PlayerSnake(int id__223, G::IReadOnlyList<Point> segments__224, IDirection direction__225, int score__226, IPlayerStatus status__227)
        {
            this.id__217 = id__223;
            this.segments__218 = segments__224;
            this.direction__219 = direction__225;
            this.score__220 = score__226;
            this.status__221 = status__227;
        }
        public int Id
        {
            get
            {
                return this.id__217;
            }
        }
        public G::IReadOnlyList<Point> Segments
        {
            get
            {
                return this.segments__218;
            }
        }
        public IDirection Direction
        {
            get
            {
                return this.direction__219;
            }
        }
        public int Score
        {
            get
            {
                return this.score__220;
            }
        }
        public IPlayerStatus Status
        {
            get
            {
                return this.status__221;
            }
        }
    }
}
