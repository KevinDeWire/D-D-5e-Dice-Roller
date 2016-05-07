using System;

namespace Dungeons_and_Dragons_5e_Dice_Roller
{
    public class DieClass
    {
        private int sides;
        private int value;
        private Random generator;

        //  The constructor that accepts a number of sides and the seed for the random number generator
        public DieClass(int numOfSides, int seed)
        {
            Sides(numOfSides);
            Generator(seed);
        }

        //  Initialize the number of sides on the die
        public void Sides (int numOfSides)
        {
            sides = numOfSides;
        }

        //  Initialize the random number generator
        public void Generator (int seed)
        {
            generator = new Random(seed);
        }

        // Generate a number between 1 and the number of sides
        public int RollDie()
        {
            value = generator.Next(sides) + 1;
            return value;
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}