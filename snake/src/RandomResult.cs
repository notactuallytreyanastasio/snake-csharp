namespace Snake
{
    public class RandomResult
    {
        readonly int value__123;
        readonly int nextSeed__124;
        public RandomResult(int value__126, int nextSeed__127)
        {
            this.value__123 = value__126;
            this.nextSeed__124 = nextSeed__127;
        }
        public int Value
        {
            get
            {
                return this.value__123;
            }
        }
        public int NextSeed
        {
            get
            {
                return this.nextSeed__124;
            }
        }
    }
}
