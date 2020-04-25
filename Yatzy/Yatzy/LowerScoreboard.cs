using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yatzy
{
    class LowerScoreboard
    {
        public List<Rule> Rules { get; set; } = new List<Rule>();

        public LowerScoreboard()
        {
            Rules.Add(new YatzyCheck());
            Rules.Add(new ThreeOfAKindCheck());
            Rules.Add(new FourOfAKindCheck());
            Rules.Add(new ChanceRule());
            Rules.Add(new PairCheck());
            Rules.Add(new TwoPairsCheck());
            Rules.Add(new FullHouseCheck());
        }

        public void Print()
        {
            var sum = 0;
            foreach (var rule in Rules)
            {
                if (rule.Used)
                {
                    Console.WriteLine($"{rule.GetName()}: {rule.Points}");
                    sum += rule.Points;
                }
            }

            Console.WriteLine($"Sum of points: {sum}");
        }

        public int Sum()
        {
            return Rules.Where(r => r.Used).Select(r => r.Points).Sum();
        }
    }
}
