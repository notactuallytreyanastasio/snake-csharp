namespace Snake
{
    class SpawnInfo
    {
        readonly Point point__257;
        readonly IDirection direction__258;
        public SpawnInfo(Point point__260, IDirection direction__261)
        {
            this.point__257 = point__260;
            this.direction__258 = direction__261;
        }
        public Point Point
        {
            get
            {
                return this.point__257;
            }
        }
        public IDirection Direction
        {
            get
            {
                return this.direction__258;
            }
        }
    }
}
