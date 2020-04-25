using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Yatzy
{
    public abstract class Rule
    {
        public bool Used { get; set; }

        public int Points { get; set; }

        // Every type of rule should have a name
        public abstract string GetName();

        // Every type of rule can have multiple scores depending on the dice
        public abstract List<int> GetScores(List<int> diceList);
    }

    public class ChanceRule : Rule
    {
        public override string GetName()
        {
            return "Chance";
        }

        public override List<int> GetScores(List<int> diceList)
        {
            return new List<int> { diceList.Sum() };
        }
    }

    public abstract class NOfAKindCheck : Rule
    {
        public int N { get; }

        public NOfAKindCheck(int n)
        {
            N = n;
        }

        public override List<int> GetScores(List<int> diceList)
        {
            var scores = new List<int>();

            for (int i = 1; i <= 6; i++)
            {
                int count = 0;

                for (int j = 0; j < 6; j++)
                {
                    if (diceList[j] == i)
                        count++;
                }

                if (count >= N)
                    scores.Add(N * i);
            }

            return scores;
        }

        public override string GetName()
        {
            return $"{N} of a kind";
        }
    }

    public class ThreeOfAKindCheck : NOfAKindCheck
    {
        public ThreeOfAKindCheck() : base(3)
        {
        }
    }

    public class FourOfAKindCheck : NOfAKindCheck
    {
        public FourOfAKindCheck() : base(4)
        {
        }
    }


    public class YatzyCheck : NOfAKindCheck
    {
        public YatzyCheck() : base(6)
        {
        }

        public override string GetName()
        {
            return "Yatzy";
        }

        public override List<int> GetScores(List<int> diceList)
        {
            var scores = base.GetScores(diceList);
            if (scores.Count > 0)
            {
                return new List<int> { 100 };
            }

            return scores;
        }
    }



    public class AcesCount : Rule
    {
        public override string GetName()
        {
            return "Aces";
        }

        public override List<int> GetScores(List<int> diceList)
        {
            var scores = new List<int>();


            for (int i = 1; i <= 6; i++)
            {
                diceList.Count(i => i == 1);
                scores.Add(i * 1);


            }
            return scores;
        }
    }
    public class TwosCount : Rule
    {
        public override string GetName()
        {
            return "Twos";
        }

        public override List<int> GetScores(List<int> diceList)
        {
            var scores = new List<int>();


            for (int i = 1; i <= 6; i++)
            {
                diceList.Count(i => i == 2);
                scores.Add(i * 2);


            }
            return scores;
        }
    }
    public class ThreesCount : Rule
    {
        public override string GetName()
        {
            return "Threes";
        }

        public override List<int> GetScores(List<int> diceList)
        {
            var scores = new List<int>();


            for (int i = 1; i <= 6; i++)
            {
                diceList.Count(i => i == 3);
                scores.Add(i * 3);


            }
            return scores;
        }
    }
    public class FoursCount : Rule
    {
        public override string GetName()
        {
            return "Fours";
        }

        public override List<int> GetScores(List<int> diceList)
        {
            var scores = new List<int>();


            for (int i = 1; i <= 6; i++)
            {
                diceList.Count(i => i == 4);
                scores.Add(i * 4);


            }
            return scores;
        }
    }
    public class FivesCount : Rule
    {
        public override string GetName()
        {
            return "Fives";
        }

        public override List<int> GetScores(List<int> diceList)
        {
            var scores = new List<int>();


            for (int i = 1; i <= 6; i++)
            {
                diceList.Count(i => i == 5);
                scores.Add(i * 5);


            }
            return scores;
        }
    }
    public class SixesCount : Rule
    {
        public override string GetName()
        {
            return "Sixes";
        }

        public override List<int> GetScores(List<int> diceList)
        {
            var scores = new List<int>();


            for (int i = 1; i <= 6; i++)
            {
                diceList.Count(i => i == 6);
                scores.Add(i * 6);


            }
            return scores;
        }


    }
    public class PairCheck : Rule
    {
        public override string GetName()
        {
            return "1 Pair";
        }

        public override List<int> GetScores(List<int> diceList)
        {
            var scores = new List<int>();

            for (int i = 1; i <= 6; i++)
            {
                int count = 0;

                for (int j = 0; j < 6; j++)
                {
                    if (diceList[j] == i)
                        count++;
                    if (count == 2)
                        scores.Add(2 * i);
                }

            }
            return scores;
        }
    }
    public class TwoPairsCheck : Rule
    {
        public override string GetName()
        {
            return "2 Pairs";
        }

        public override List<int> GetScores(List<int> diceList)
        {
            var scores = new List<int>();
            for (int i = 1; i <= 6; i++)
            {
                for (int k = 1; k <= 6; k++)
                {
                    if (i == k)
                        continue;


                    int count1 = 0;
                    int count2 = 0;
                    for (int j = 0; j < 6; j++)
                    {
                        if (diceList[j] == i)
                            count1++;
                    }
                    for (int l = 0; l < 6; l++)
                    {
                        if (diceList[l] == k)
                            count2++;
                    }
                    if (count1 == 2 && count2 == 2) ;
                    scores.Add(2 * i + 2 * k);
                }
            }
            return scores;
        }
    }
    public class FullHouseCheck : Rule
    {
        public override string GetName()
        {
            return "Full House";
        }

        public override List<int> GetScores(List<int> diceList)
        {
            var scores = new List<int>();


            for (int i = 1; i <= 6; i++)
            {
                for (int k = 1; k <= 6; k++)
                {
                    if (i == k)
                        continue;


                    int count1 = 0;
                    int count2 = 0;
                    for (int j = 0; j < 6; j++)
                    {
                        if (diceList[j] == i)
                            count1++;
                    }
                    for (int l = 0; l < 6; l++)
                    {
                        if (diceList[l] == k)
                            count2++;
                    }
                    if (count1 == 2 && count2 == 3) ;
                    scores.Add(2 * i + 3 * k);
                }
            }
            return scores;
        }
    }

    public class SmallStraightCheck : Rule
    {
        public override string GetName()
        {
            return "Small Straight";
        }

        public override List<int> GetScores(List<int> diceList)
        {
            var scores = new List<int>();
            for (int i = 1; i <= 6; i++)
            {
                for (int k = 1; k <= 6; k++)
                {
                    if (i == k)
                        continue;


                    int count1 = 0;
                    int count2 = 0;
                    for (int j = 0; j < 6; j++)
                    {
                        if (diceList[j] == i)
                            count1++;
                    }
                    for (int l = 0; l < 6; l++)
                    {
                        if (diceList[l] == k)
                            count2++;
                    }
                    if (count1 == 2 && count2 == 3) ;
                    scores.Add(2 * i + 3 * k);
                }
            }
            return scores;
        }
    }

}
