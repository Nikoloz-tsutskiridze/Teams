using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BasketballTeam : Team
{
    public BasketballTeam(string name) : base(name)
    {
    }

    public override int ScoreStart => 50;
    public override int ScoreEnd => 150;
}
