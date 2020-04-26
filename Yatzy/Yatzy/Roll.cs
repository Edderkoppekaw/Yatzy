using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yatzy
{
    class Roll
    {
        public List<Outcome> Outcomes { get; set; } = new List<Outcome>();

        public Roll(LowerScoreboard scoreboard, List<Die> dice)
        {
            // Convert terninger to their int value
            var diceList = dice.Select(d => d.Current).ToList();

            foreach (var rule in scoreboard.Rules)
            {
                if (!rule.Used)
                {
                    var ruleScores = rule.GetScores(diceList);
                    foreach (var score in ruleScores)
                    {
                        Outcomes.Add(new Outcome(rule, score));
                    }

                    // If no outcomes from rule, add zero score option
                    if (ruleScores.Count == 0)
                    {
                        Outcomes.Add(new Outcome(rule, 0));
                    }
                }
            }


            Outcomes = Outcomes.OrderByDescending(o => o.Points).ToList();
        }

        public Roll(UpperScoreboard scoreboardUpper, List<Die> dice)
        {
            // Convert terninger to their int value
            var diceList = dice.Select(d => d.Current).ToList();

            foreach (var rule in scoreboardUpper.Rules)
            {
                if (!rule.Used)
                {
                    var ruleScores = rule.GetScores(diceList);
                    foreach (var score in ruleScores)
                    {
                        Outcomes.Add(new Outcome(rule, score));
                    }

                    // If no outcomes from rule, add zero score option
                    if (ruleScores.Count == 0)
                    {
                        Outcomes.Add(new Outcome(rule, 0));
                    }
                }
            }


            Outcomes = Outcomes.OrderByDescending(o => o.Points).ToList();
        }
        public void Print()
        {
            for (var i = 0; i < Outcomes.Count; i++)
            {
                Console.WriteLine($"{(char)('a' + i)}. {Outcomes[i]}");
            }
        }

        public void UseOutcome(int index)
        {
            var outcome = Outcomes[index];
            outcome.Rule.Used = true;
            outcome.Rule.Points = outcome.Points;
        }
    }

    class Outcome
    {
        public Rule Rule { get; set; }
        public int Points { get; set; }

        public Outcome(Rule usedRule, int points)
        {
            Rule = usedRule;
            Points = points;
        }

        public override string ToString()
        {
            return $"{Rule.GetName()}, {Points} pts";
        }
    }
}
