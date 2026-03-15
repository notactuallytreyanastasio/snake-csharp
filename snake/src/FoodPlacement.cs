namespace Snake
{
    class FoodPlacement
    {
        readonly Point point__151;
        readonly int seed__152;
        public FoodPlacement(Point point__154, int seed__155)
        {
            this.point__151 = point__154;
            this.seed__152 = seed__155;
        }
        public Point Point
        {
            get
            {
                return this.point__151;
            }
        }
        public int Seed
        {
            get
            {
                return this.seed__152;
            }
        }
    }
}
