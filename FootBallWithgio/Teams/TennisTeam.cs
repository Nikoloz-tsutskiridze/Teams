using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Teams
{
    class TennisTeam : Team
    {
        public TennisTeam(string name) : base(name)
        {
        }

        public override int ScoreStart => 1;
        public override int ScoreEnd => 6;
    }
}
