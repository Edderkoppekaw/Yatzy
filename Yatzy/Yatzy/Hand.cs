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
        public List<Terning> Terninger { get; set; } = new List<Terning>();

        public Hand()
        {
            CreateDice();
        }

        public void CreateDice()
        {
            Terninger.Clear();

            for (int i = 0; i < 6; i++)
            {
                Terninger.Add(Settings.snyd ? new Terning.SnydeTerning() : new Terning());
            }
        }

        // Now comes the tricky part, I need a new method where the user chooses a set number of dices which then I have to keep and reroll the others. 

        public void RerollDices(int[] toReroll)
        {
            for (var i = 0; i < Terninger.Count; i++)
            {
                if (toReroll.Contains(i))
                    Terninger[i].Roll();
            }

            ShowDices();
        }

        public void ShowDices()
        {
            Console.WriteLine();
            foreach (Terning terning in Terninger)
            {
                Console.Write("[{0}] ", terning.Current);
                FirstRound = false;
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        public void RerollAll()
        {
            foreach (Terning terning in Terninger)
            {
                terning.Roll();
            }

            // display all dices after the are rerolled
            ShowDices();
        }
    }
}