using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

/*    public abstract class NCount : Rule
    {
        public int N { get; }
        public int M { get; }

        public NCount(int n, int m)
        {
            N = n;
            M = m;
        }
        public bool IsFulfilled(List<int> diceList)
        {
            return diceList.Where(d => d == M).Count() == N;
        }

        public List<int> GetScores(List<int> diceList)
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            throw new NotImplementedException();
        }
    }*/

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

    public class FiveOfAKindCheck : NOfAKindCheck
    {
        public FiveOfAKindCheck() : base(5)
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

    public class FullHouseRule : Rule
    {
        public override string GetName()
        {
            return "Full House";
        }

        public override List<int> GetScores(List<int> diceList)
        {
            throw new NotImplementedException();
        }
    }

    /*    public class AcesCount : NCount
        {
            public AcesCount() : base (1, 1)
            {
            }
        }
        public class TwosCount : Rule
        {
            public string GetName()
            {
                throw new NotImplementedException();
            }

            public List<int> GetScores(List<int> diceList)
            {
                throw new NotImplementedException();
            }

            public bool IsFulfilled(List<int> diceList)
            {
                int Count = 0;
                bool Twos = false;

                for (int i = 1; i <= 6; i++)
                {
                    diceList.Count(d => d == 2);
                    Count = diceList.Count;

                    return true;
                }
                return false;
            }
        }
        public class ThreesCount : Rule
        {
            public string GetName()
            {
                throw new NotImplementedException();
            }

            public List<int> GetScores(List<int> diceList)
            {
                throw new NotImplementedException();
            }

            public bool IsFulfilled(List<int> diceList)
            {
                int Count = 0;
                bool Threes = false;

                for (int i = 1; i <= 6; i++)
                {
                    diceList.Count(d => d == 3);
                    Count = diceList.Count;

                    return true;
                }
                return false;
            }
        }
        public class FoursCount : Rule
        {
            public string GetName()
            {
                throw new NotImplementedException();
            }

            public List<int> GetScores(List<int> diceList)
            {
                throw new NotImplementedException();
            }

            public bool IsFulfilled(List<int> diceList)
            {
                int Count = 0;
                bool Fours = false;

                for (int i = 1; i <= 6; i++)
                {
                    diceList.Count(d => d == 4);
                    Count = diceList.Count;

                    return true;
                }
                return false;
            }
        }
        public class FivesCount : Rule
        {
            public string GetName()
            {
                throw new NotImplementedException();
            }

            public List<int> GetScores(List<int> diceList)
            {
                throw new NotImplementedException();
            }

            public bool IsFulfilled(List<int> diceList)
            {
                int Count = 0;
                bool Fives = false;

                for (int i = 1; i <= 6; i++)
                {
                    diceList.Count(d => d == 5);
                    Count = diceList.Count;

                    return true;
                }
                return false;
            }
        }
        public class SixesCount : Rule
        {
            public string GetName()
            {
                throw new NotImplementedException();
            }

            public List<int> GetScores(List<int> diceList)
            {
                throw new NotImplementedException();
            }

            public bool IsFulfilled(List<int> diceList)
            {
                int Count = 0;
                bool Sixes = false;

                for (int i = 1; i <= 6; i++)
                {
                    diceList.Count(d => d == 6);
                    Count = diceList.Count;

                    return true;
                }
                return false;
            }
        }
        public class PairsCheck : Rule
        {
            public string GetName()
            {
                throw new NotImplementedException();
            }

            public List<int> GetScores(List<int> diceList)
            {
                throw new NotImplementedException();
            }

            public bool IsFulfilled(List<int> diceList)
            {
                int Sum = 0;
                bool Pairs = false;

                for (int i = 1; i <= 6; i++)
                {
                    int count = 0;
                    for (int j = 0; j < 5; j++)
                    {
                        if (diceList[j] == i)
                            count++;
                    }
                    if (count == 2)
                        return true;
                }
                return false;
            }
        }
        public class TwoPairsCheck : Rule
        {
            public string GetName()
            {
                throw new NotImplementedException();
            }

            public List<int> GetScores(List<int> diceList)
            {
                throw new NotImplementedException();
            }

            public bool IsFulfilled(List<int> diceList)
            {
                int Sum = 0;
                bool TwoPairs = false;

                for (int i = 1; i <= 6; i++)
                {
                    int count1 = 0;
                    int count2 = 0;
                    for (int j = 0; j < 5; j++)
                    {
                        if (diceList[j] == i)
                            count1++;
                    }
                    for (int j = 0; j < 5; j++)
                    {
                        if (diceList[j] == i)
                            count2++;
                    }
                    if (count1 == 2 && count2 == 2) ;
                    return true;
                }
                return false;
            }
        }
        public class FullHouseCheck : Rule
        {
            public string GetName()
            {
                throw new NotImplementedException();
            }

            public List<int> GetScores(List<int> diceList)
            {
                throw new NotImplementedException();
            }

            public bool IsFulfilled(List<int> diceList)
            {
                int Sum = 0;
                bool FullHouse = false;
                List<Terning> twoAlike = new List<Terning>();
                List<Terning> threeAlike = new List<Terning>();
                var Terning = new Terning();

                for (int i = 1; i <= 6; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (diceList[j] == i)
                            threeAlike.Add(Terning);
                    }
                    for (int k = 0; k < 5; k++)
                    {
                        if (diceList[k] == i)
                            twoAlike.Add(Terning);
                    }
                    if (twoAlike.Count == 2 && (threeAlike.Count == 3))
                        return true;
                }
                return false;
            }
        }*/
}
