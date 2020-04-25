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
        public static void CurrentDice()
        {
            var diceList = new List<Terning>();

            for (int i = 0; i < 6; i++)
            {
                diceList.Add(new Terning());
            }

        }


        // Now comes the tricky part, I need a new method where the user chooses a set number of dices which then I have to keep and reroll the others. 

        public void KeepDices(List<Terning> diceList)
            {

                // now we need to go through every dice in the toReroll array and check if it's in Dices array. If it's in the array do nothing with it. If we find a value that is not equal to the toReroll number we have to reroll it



                for (int i = 0; i < diceList.Count; i++)
                {


                    foreach (int roll in diceList)
                    {
                        if (roll == 1)
                        {

                            diceList[0].Reroll();

                        }

                        if (roll == 2)
                        {

                            diceList[1].Reroll();

                        }

                        if (roll == 3)
                        {

                            diceList[2].Reroll();

                        }

                        if (roll == 4)
                        {

                            diceList[3].Reroll();

                        }

                        if (roll == 5)
                        {

                            diceList[4].Reroll();

                        }

                        if (roll == 6)
                        {

                            diceList[5].Reroll();

                        }
                    }




                

                ShowDices();



            }
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