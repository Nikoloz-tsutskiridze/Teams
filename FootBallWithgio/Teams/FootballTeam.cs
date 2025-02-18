using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FootballTeam : Team
{
    public FootballTeam(string name) : base(name)
    {
    }

    public override int ScoreStart => 1;
    public override int ScoreEnd => 6;
}
