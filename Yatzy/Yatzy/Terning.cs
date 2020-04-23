using System;
using System.Collections.Generic;
using System.Text;

namespace Yatzy
{
    public class Terning
    {
        public int current;
        public Random rand = new Random();



        public Terning()
        {

            Roll();

        }

        public override string ToString()
        {
            return "You rolled " + current;
        }

        public virtual int Roll()
        {
            current = rand.Next(1, 7);
            return current;

        }
        public virtual int Reroll()
        {

            current = rand.Next(1, 7);
            return current;

        }



        public class snydeTerning : Terning
        {
            private int probability;

            public bool _IsPositiveBiased { get; set; }
            public int _threshold { get; set; }


            public snydeTerning(int threshold, bool IsPositiveBiased)
            {
                _threshold = threshold;
                _IsPositiveBiased = IsPositiveBiased;
            }

            public snydeTerning(int probability)
            {
                this.probability = probability;
            }

            public override int Roll()
            {
                base.Roll();
                var probability = rand.Next(0, 100);

                if (_IsPositiveBiased == true)
                    current = positiveRoll(probability);
                else
                    current = negativeRoll(probability);
                return current;
            }

            public override int Reroll()
            {
                base.Reroll();
                var probability = rand.Next(0, 100);

                if (_IsPositiveBiased == true)
                    current = positiveRoll(probability);
                else
                    current = negativeRoll(probability);
                return current;


            }

            private int positiveRoll(int probability)
            {
                int value = current;
                if (probability <= _threshold && value != 6)
                    value += 1;
                return value;

            }

            private int negativeRoll(int probability)
            {
                int value = current;

                if (probability <= _threshold && value != 1)
                    value -= 1;
                return value;


            }









        }

    }
}
