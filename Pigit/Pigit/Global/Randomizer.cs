using System;

namespace Pigit.Global
{
    class Randomizer
    {
        public static int GetRandomInt(int min, int max)
        {
            return new Random().Next(min, max + 1);
        }
        public static float GetRandomFloat(int min, int max)
        {
            return (float) new Random().NextDouble() * (max - min) + min;
        }
    }
}
