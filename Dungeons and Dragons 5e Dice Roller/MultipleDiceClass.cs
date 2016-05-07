using System;

namespace Dungeons_and_Dragons_5e_Dice_Roller
{
    class MultipleDiceClass
    {
        private int sides;
        private int number;
        private int totalValue;

        public String dieRolls;

        private Random generator;

        DieClass[] diceBag;

        //  Constructor to create the array and initialize each die with number of sides and generator seed
        public MultipleDiceClass(int numOfSides, int numOfDice, int seed)
        {
            sides = numOfSides;
            number = numOfDice;
            totalValue = 0;
            dieRolls = "";
            generator = new Random(seed);

            diceBag = new DieClass[number];

            for (int i=0; i<number; i++)
            {
                diceBag[i] = new DieClass(sides, generator.Next());
            }

            foreach (DieClass die in diceBag)
            {
                totalValue = totalValue + die.RollDie();
            }                
        }

        //  Returns the total value of all dice rolled
        public int Total()
        {
            return totalValue;
        }

        //  Returns a string with the value of each die rolled
        public override string ToString()
        {
            dieRolls = "Dice Rolled: "; 
            foreach (DieClass die in diceBag)
            {
                dieRolls = dieRolls + die.ToString() + "  ";
            }
            return dieRolls;
        }
    }
}