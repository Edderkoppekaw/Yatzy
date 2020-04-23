using System;
using System.Collections.Generic;
using System.Text;

namespace Yatzy
{
    interface IRule
    {
        bool IsFulfilled(List<int> diceList);
    }

    public class ThreeOfAKindCheck : IRule
    {
        public bool IsFulfilled(List<int> diceList)
        {
            int Sum = 0;
            bool ThreeOfAKind = false;

            for (int i = 1; i <= 6; i++)
            {
                int count = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (diceList[j] == i)
                        count++;
                }
                if (count == 3)
                    return true;
            }
            return false;
        }
    }
    public class FourOfAKindCheck : IRule
    {
        public bool IsFulfilled(List<int> diceList)
        {
            int Sum = 0;
            bool FourOfAKind = false;

            for (int i = 1; i <= 6; i++)
            {
                int count = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (diceList[j] == i)
                        count++;
                }
                if (count == 4)
                    return true;
            }
            return false;
        }
    }
    public class YatzyCheck : IRule
    {
        public bool IsFulfilled(List<int> diceList)
        {
            int Sum = 0;
            bool Yatzy = false;

            for (int i = 1; i <= 6; i++)
            {
                int count = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (diceList[j] == i)
                        count++;
                }
                if (count == 5)
                    return true;
            }
            return false;
        }
    }
    public class AcesCount : IRule
    {
        public bool IsFulfilled(List<int> diceList)
        {
            int Count = 0;
            bool Aces = false;

            for (int i = 1; i <= 6; i++)
            {
                diceList.Count(d => d == 1);
                Count = diceList.Count;

                return true;
            }
            return false;
        }
    }
    public class TwosCount : IRule
    {
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
    public class ThreesCount : IRule
    {
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
    public class FoursCount : IRule
    {
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
    public class FivesCount : IRule
    {
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
    public class SixesCount : IRule
    {
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
    public class PairsCheck : IRule
    {
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
    public class TwoPairsCheck : IRule
    {
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
    public class FullHouseCheck : IRule
    {
        public bool IsFulfilled(List<int> diceList)
        {
            int Sum = 0;
            bool FullHouse = false;
            List<Die> twoAlike = new List<Die>();
            List<Die> threeAlike = new List<Die>();
            var Die = new Die();

            for (int i = 1; i <= 6; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (diceList[j] == i)
                        threeAlike.Add(Die);
                }
                for (int k = 0; k < 5; k++)
                {
                    if (diceList[k] == i)
                        twoAlike.Add(Die);
                }
                if (twoAlike.Count == 2 && (threeAlike.Count == 3))
                    return true;
            }
            return false;
        }
    }
}
