using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yatzy
{
    class LowerScoreboard : Scoreboard
    {

        public LowerScoreboard()
        {
            Rules.Add(new YatzyCheck());
            Rules.Add(new ThreeOfAKindCheck());
            Rules.Add(new FourOfAKindCheck());
            Rules.Add(new ChanceRule());
            Rules.Add(new PairCheck());
            Rules.Add(new TwoPairsCheck());
            Rules.Add(new FullHouseCheck());
            Rules.Add(new SmallStraightCheck());
            Rules.Add(new LargeStraightCheck());
        }
        public void kasper()
        { }
    }
}
