namespace Snake
{
    class FoodPlacement
    {
        readonly Point point__98;
        readonly int seed__99;
        public FoodPlacement(Point point__101, int seed__102)
        {
            this.point__98 = point__101;
            this.seed__99 = seed__102;
        }
        public Point Point
        {
            get
            {
                return this.point__98;
            }
        }
        public int Seed
        {
            get
            {
                return this.seed__99;
            }
        }
    }
}
