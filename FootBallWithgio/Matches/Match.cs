
namespace Sports.Matches
{
    public class Match<TTeam> where TTeam : Team
    {
        public TTeam Home;
        public TTeam Away;
        public int HomeGoals;
        public int AwayGoals;

        public Match(TTeam home, TTeam away)
        {
            Home = home;
            Away = away;
        }

        public Match<TTeam> Reverse()
        {
            return new Match<TTeam>(Away, Home);
        }

        public virtual void Start(int start, int end)
        {
            HomeGoals = GenerateRandomNumber.Generate(start, end);
            AwayGoals = GenerateRandomNumber.Generate(start, end);

            Statistics.TotalGoals += HomeGoals + AwayGoals;
            Statistics.MatchesPlayed++;

            ApplyHomeAdvantage();
        }

        private void ApplyHomeAdvantage()
        {
            var homeBoostChance = GenerateRandomNumber.Generate(1, 100);

            if (homeBoostChance <= 20)
            {
                HomeGoals++;
            }
        }

        public bool IsHomeTeam(TTeam team) => team == Home;
        public bool IsAwayTeam(TTeam team) => team == Away;

        public TTeam GetWinner()
        {
            TTeam matchWinner = HomeGoals > AwayGoals ? Home : Away;

            Console.WriteLine($" Winner: {matchWinner.Name} ({(matchWinner == Home ? "Home" : "Away")})");

            return matchWinner;
        }
    }
}
