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

            List<int> AcesList = new List<int>();

            for (int j = 0; j < 6; j++)
            {
                if (diceList[j] == 1)
                {
                    AcesList.Add(1);
                }
            }
            scores.Add(AcesList.Count * 1);
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


            List<int> twosList = new List<int>();

            for (int j = 0; j < 6; j++)
            {
                if (diceList[j] == 2)
                {
                    twosList.Add(1);
                }
            }
            scores.Add(twosList.Count * 2);
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

            List<int> threesList = new List<int>();

            for (int j = 0; j < 6; j++)
            {
                if (diceList[j] == 3)
                {
                    threesList.Add(1);
                }
            }
            scores.Add(threesList.Count * 3);
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


            List<int> foursList = new List<int>();

            for (int j = 0; j < 6; j++)
            {
                if (diceList[j] == 4)
                {
                    foursList.Add(1);
                }
            }
            scores.Add(foursList.Count * 4);
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


            List<int> fivesList = new List<int>();

            for (int j = 0; j < 6; j++)
            {
                if (diceList[j] == 5)
                {
                    fivesList.Add(1);
                }
            }
            scores.Add(fivesList.Count * 5);
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

            List<int> sixesList = new List<int>();

            for (int j = 0; j < 6; j++)
            {
                if (diceList[j] == 6)
                {
                    sixesList.Add(1);
                }
            }
            scores.Add(sixesList.Count * 6);
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
                
            List<int> pairList = new List<int>();

            for (int i = 1; i <= 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (diceList[j] == i)
                        pairList.Add(1);
                }
                if (pairList.Count == 2)
                {
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
            List<int> pair1List = new List<int>();
            List<int> pair2List = new List<int>();
            for (int i = 1; i <= 6; i++)
            {
                for (int k = 1; k <= 6; k++)
                {
                    if (i == k)
                        continue;

                    for (int j = 0; j < 6; j++)
                    {
                        if (diceList[j] == i)
                            pair1List.Add(1);
                    }
                    for (int l = 0; l < 6; l++)
                    {
                        if (diceList[l] == k)
                            pair2List.Add(1);
                    }
                    if (pair1List.Count == 2 && pair2List.Count == 2)
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
                    if (count1 == 2 && count2 == 3)
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
                int count1 = 0;
                int count2 = 0;
                int count3 = 0;
                int count4 = 0;
                int count5 = 0;
                for (int j = 0; j < 6; j++)
                {
                    if (diceList[j] == 1)
                        count1++;
                }
                for (int k = 0; k < 6; k++)
                {
                    if (diceList[k] == 2)
                        count2++;
                }
                for (int l = 0; l < 6; l++)
                {
                    if (diceList[l] == 3)
                        count3++;
                }
                for (int m = 0; m < 6; m++)
                {
                    if (diceList[m] == 4)
                        count4++;
                }
                for (int n = 0; n < 6; n++)
                {
                    if (diceList[n] == 5)
                        count5++;
                }
                if (count1 >= 1 && count2 >= 1 && count3 >= 1 && count4 >= 1 && count5 >= 1)
                    scores.Add(15);
            }
            return scores;
        }
    }

    public class LargeStraightCheck : Rule
    {
        public override string GetName()
        {
            return "Large Straight";
        }

        public override List<int> GetScores(List<int> diceList)
        {
            var scores = new List<int>();

            for (int i = 1; i <= 6; i++)
            {
                int count1 = 0;
                int count2 = 0;
                int count3 = 0;
                int count4 = 0;
                int count5 = 0;
                for (int j = 0; j < 6; j++)
                {
                    if (diceList[j] == 2)
                        count1++;
                }
                for (int k = 0; k < 6; k++)
                {
                    if (diceList[k] == 3)
                        count2++;
                }
                for (int l = 0; l < 6; l++)
                {
                    if (diceList[l] == 4)
                        count3++;
                }
                for (int m = 0; m < 6; m++)
                {
                    if (diceList[m] == 5)
                        count4++;
                }
                for (int n = 0; n < 6; n++)
                {
                    if (diceList[n] == 6)
                        count5++;
                }
                if (count1 >= 1 && count2 >= 1 && count3 >= 1 && count4 >= 1 && count5 >= 1)
                    scores.Add(20);
            }
            return scores;
        }
    }

}
