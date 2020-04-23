using System;
using System.Collections.Generic;
using System.Text;

namespace Yatzy
{
    class BægerPos
    {
        public bool FirstRound { get; private set; } = true; // set this to false when the user has made the first move
        // this class has a hand of all the dices in the game (o)
        private readonly Terning.snydeTerning[] snydeTerninger =
        {
            new Terning.snydeTerning(Settings.snydeGrad, Settings.bias),
            new Terning.snydeTerning(Settings.snydeGrad, Settings.bias),
            new Terning.snydeTerning(Settings.snydeGrad, Settings.bias),
            new Terning.snydeTerning(Settings.snydeGrad, Settings.bias),
            new Terning.snydeTerning(Settings.snydeGrad, Settings.bias),
            new Terning.snydeTerning(Settings.snydeGrad, Settings.bias)
        };

        // Now comes the tricky part, I need a new method where the user chooses a set number of dices which then I have to keep and reroll the others. 

        public void KeepDices(int[] toReroll)
        {

            // now we need to go through every dice in the toReroll array and check if it's in Dices array. If it's in the array do nothing with it. If we find a value that is not equal to the toReroll number we have to reroll it



            for (int i = 0; i < snydeTerninger.Length; i++)
            {


                foreach (int roll in toReroll)
                {
                    if (roll == 1)
                    {

                        snydeTerninger[0].Reroll();

                    }

                    if (roll == 2)
                    {

                        snydeTerninger[1].Reroll();

                    }

                    if (roll == 3)
                    {

                        snydeTerninger[2].Reroll();

                    }

                    if (roll == 4)
                    {

                        snydeTerninger[3].Reroll();

                    }

                    if (roll == 5)
                    {

                        snydeTerninger[4].Reroll();

                    }

                    if (roll == 6)
                    {

                        snydeTerninger[5].Reroll();

                    }
                }




            }

            ShowDices();



        }



        public void ShowDices()
        {
            Console.WriteLine();
            foreach (Terning.snydeTerning snydeterning in snydeTerninger)
            {
                Console.Write("[{0}] ", snydeterning.current);
                FirstRound = false;
            }
            Console.WriteLine();
            Console.WriteLine();

        }

        public void RerollAll()
        {
            foreach (Terning.snydeTerning snydeterning in snydeTerninger)
            {
                snydeterning.Reroll();
            }

            // display all dices after the are rerolled
            ShowDices();

        }


    }
}
