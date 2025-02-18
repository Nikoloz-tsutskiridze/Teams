using Sports.Matches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FootballMatch : Match<FootballTeam>
{
    public FootballMatch(FootballTeam home, FootballTeam away) : base(home, away)
    {
    }
}
