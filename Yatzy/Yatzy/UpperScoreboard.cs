using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yatzy
{
    class UpperScoreboard
    {
        public List<Rule> Rules { get; set; } = new List<Rule>();

        public UpperScoreboard()
        {
            Rules.Add(new AcesCount());
            Rules.Add(new TwosCount());
            Rules.Add(new ThreesCount());
            Rules.Add(new FoursCount());
            Rules.Add(new FivesCount());
            Rules.Add(new SixesCount());
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
