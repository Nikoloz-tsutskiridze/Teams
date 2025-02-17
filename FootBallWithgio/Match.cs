class Match
{
    public Team Home;
    public Team Away;
    public int HomeGoals;
    public int AwayGoals;

    public Match(Team home, Team away)
    {
        Home = home;
        Away = away;
    }

    public Match(string home, string away)
    {
        Home = new Team(home);
        Away = new Team(away);
    }

    public Match Reverse()
    {
        var NewReversedMatch = new Match(Away, Home);

        return NewReversedMatch;
    }

    public virtual void Start()
    {
        HomeGoals = GenerateRandomNumber.Generate(1, 3);
        AwayGoals = GenerateRandomNumber.Generate(1, 3);

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

    public Team GetWinner()
    {
        Team matchWinner = HomeGoals > AwayGoals ? Home : Away;

        Console.WriteLine($" Winner: {matchWinner.Name} ({(matchWinner == Home ? "Home" : "Away")})");

        return matchWinner;
    }
}