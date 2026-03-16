namespace Snake
{
    class FoodPlacement
    {
        readonly Point point__152;
        readonly int seed__153;
        public FoodPlacement(Point point__155, int seed__156)
        {
            this.point__152 = point__155;
            this.seed__153 = seed__156;
        }
        public Point Point
        {
            get
            {
                return this.point__152;
            }
        }
        public int Seed
        {
            get
            {
                return this.seed__153;
            }
        }
    }
}
