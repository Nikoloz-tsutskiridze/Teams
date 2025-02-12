using System.Security.Cryptography;

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

    public void Start()
    {
        HomeGoals = GenerateRandomNumber.Generate(1, 6);
        AwayGoals = GenerateRandomNumber.Generate(1, 6);

        Statistics.TotalGoals += HomeGoals + AwayGoals;
        Statistics.MatchesPlayed++;

        ApplyHomeAdvantage();

        if (HomeGoals == AwayGoals)
        {
            ShootPenalties();
        }
        Console.WriteLine($"{Home.Name} {HomeGoals} - {AwayGoals} {Away.Name}");
    }

    private void ApplyHomeAdvantage()
    {
        var homeBoostChance = GenerateRandomNumber.Generate(1, 100);

        if (homeBoostChance <= 20)
        {
            HomeGoals++;
            Console.WriteLine($"Home advantage! {Home.Name} scores an extra goal!");
        }
    }

    public void ShootPenalties()
    {
        Statistics.PenaltyShootouts++;

        var homePenalties = GenerateRandomNumber.Generate(1, 6);
        var awayPenalties = GenerateRandomNumber.Generate(1, 6);

        while (homePenalties == awayPenalties)
        {
            Console.WriteLine("Tie in penalties, reshooting...");
            homePenalties = GenerateRandomNumber.Generate(1, 6);
            awayPenalties = GenerateRandomNumber.Generate(1, 6);
        }

        if (homePenalties > awayPenalties)
        {
            Console.WriteLine("Home wins on penalties!");
        }
        else
        {
            Console.WriteLine("Away wins on penalties!");
        }
    }


    public Team GetWinner()
    {
        Team matchWinner = HomeGoals > AwayGoals ? Home : Away;

        Console.WriteLine($" Winner: {matchWinner.Name} ({(matchWinner == Home ? "Home" : "Away")})");

        return matchWinner;
    }
}