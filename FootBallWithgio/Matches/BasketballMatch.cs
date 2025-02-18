using Sports.Matches;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BasketballMatch : Match<BasketballTeam>
{
    public BasketballMatch(BasketballTeam home, BasketballTeam away) : base(home, away)
    {
    }

    public override void Start(int start, int end) 
    {
        base.Start(start, end);
    }
}
