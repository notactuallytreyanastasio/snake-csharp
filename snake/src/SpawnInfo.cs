namespace Snake
{
    class SpawnInfo
    {
        readonly Point point__256;
        readonly IDirection direction__257;
        public SpawnInfo(Point point__259, IDirection direction__260)
        {
            this.point__256 = point__259;
            this.direction__257 = direction__260;
        }
        public Point Point
        {
            get
            {
                return this.point__256;
            }
        }
        public IDirection Direction
        {
            get
            {
                return this.direction__257;
            }
        }
    }
}
