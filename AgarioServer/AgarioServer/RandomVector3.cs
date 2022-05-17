using System;

namespace AgarioServer
{
    public class RandomVector3
    {
        public float X { get; }
        public float Y { get; }
        public float Z { get; }

        public RandomVector3(int range)
        {
            var random = new Random();

            X = random.Next(range * -1, range);
            Y = random.Next(range * -1, range);
            Z = random.Next(range * -1, range);
        }
    }
}