using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yatzy
{
    public abstract class Scoreboard
    {
        public List<Rule> Rules { get; set; } = new List<Rule>();

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
