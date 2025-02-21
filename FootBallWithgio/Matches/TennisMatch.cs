using Sports.Matches;
using Sports.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Matches
{
    class TennisMatch:Match<TennisTeam>
    {
        public TennisMatch(TennisTeam home, TennisTeam away) : base(home,away)
        {
            
        }
        public (int homeSets, int awaySets) StartSetBasedMatch()
        {
            Random random = new Random();
            int homeSets = 0, awaySets = 0;

            while (homeSets < 3 && awaySets < 3) 
            {
                int homeGames = 0, awayGames = 0;

                while (true)
                {
                    int homeGameScore = random.Next(0, 2);
                    int awayGameScore = 1 - homeGameScore;

                    homeGames += homeGameScore;
                    awayGames += awayGameScore;

                    if ((homeGames >= 6 || awayGames >= 6) && Math.Abs(homeGames - awayGames) >= 2)
                        break;
                }

                if (homeGames > awayGames)
                    homeSets++;
                else
                    awaySets++;
            }

            return (homeSets, awaySets);
        }

    }
}

