using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy
{
    class Hand
    {
        public bool FirstRound { get; private set; } = true; // set this to false when the user has made the first move
        // this class has a hand of all the dices in the game (o)
        private readonly Terning[] Terninger = 
        {
            new Terning(),
            new Terning(),
            new Terning(),
            new Terning(),
            new Terning(),
            new Terning()
        };

        // Now comes the tricky part, I need a new method where the user chooses a set number of dices which then I have to keep and reroll the others. 

        public void KeepDices(int[] toReroll)
        {

            // now we need to go through every dice in the toReroll array and check if it's in Dices array. If it's in the array do nothing with it. If we find a value that is not equal to the toReroll number we have to reroll it



            for (int i = 0; i < Terninger.Length; i++)
            {
               

                foreach (int roll in toReroll)
                {
                    if (roll == 1)
                    {

                        Terninger[0].Reroll();

                    }

                    if (roll == 2)
                    {

                        Terninger[1].Reroll();

                    }

                    if (roll == 3)
                    {

                        Terninger[2].Reroll();

                    }

                    if (roll == 4)
                    {

                        Terninger[3].Reroll();

                    }

                    if (roll == 5)
                    {

                        Terninger[4].Reroll();

                    }

                    if (roll == 6)
                    {

                        Terninger[5].Reroll();

                    }
                }

              


            }

            ShowDices();



        }



        public void ShowDices()
        {
            Console.WriteLine();
            foreach (Terning terning in Terninger)
            {
                Console.Write("[{0}] ", terning.current);
                FirstRound = false;
            }
            Console.WriteLine();
            Console.WriteLine();

        }

        public void RerollAll()
        {
            foreach (Terning terning in Terninger)
            {
                terning.Reroll();
            }

            // display all dices after the are rerolled
            ShowDices();

        }


    }
}