using System;

namespace AgarioServer
{
    public class RandomVector3
    {
        public float x { get; }
        public float y { get; }
        public float z { get; }

        public RandomVector3(int range)
        {
            var random = new Random();

            x = random.Next(range * -1, range);
            y = random.Next(range * -1, range);
            z = 0;
        }
    }
}