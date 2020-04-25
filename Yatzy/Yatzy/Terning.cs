using System;
using System.Collections.Generic;
using System.Text;

namespace Yatzy
{
    public class Terning
    {
        public int Current;
        public Random rand = new Random();



        public Terning()
        {
            Roll();
        }

        public override string ToString()
        {
            return "You rolled " + Current;
        }

        public virtual int Roll()
        {
            Current = rand.Next(1, 7);

            return Current;
        }

        public class SnydeTerning : Terning
        {
            public bool _IsPositiveBiased => Settings.bias;
            public int _threshold => Settings.snydeGrad;

            public override int Roll()
            {
                base.Roll();
                var probability = rand.Next(0, 100);

                if (_IsPositiveBiased == true)
                    Current = positiveRoll(probability);
                else
                    Current = negativeRoll(probability);
                return Current;
            }

            private int positiveRoll(int probability)
            {
                int value = Current;
                if (probability <= _threshold && value != 6)
                    value += 1;

                return value;
            }

            private int negativeRoll(int probability)
            {
                int value = Current;

                if (probability <= _threshold && value != 1)
                    value -= 1;
                return value;
            }
        }

    }
}
