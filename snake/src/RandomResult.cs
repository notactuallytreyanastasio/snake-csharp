namespace Snake
{
    public class RandomResult
    {
        readonly int value__122;
        readonly int nextSeed__123;
        public RandomResult(int value__125, int nextSeed__126)
        {
            this.value__122 = value__125;
            this.nextSeed__123 = nextSeed__126;
        }
        public int Value
        {
            get
            {
                return this.value__122;
            }
        }
        public int NextSeed
        {
            get
            {
                return this.nextSeed__123;
            }
        }
    }
}
