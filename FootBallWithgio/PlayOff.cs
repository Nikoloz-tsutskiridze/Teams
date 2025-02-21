using Sports.Matches;
using Sports.Teams;

internal class Playoff<TTeam> where TTeam : Team
{
    public TTeam FirstTeam;
    public TTeam SecondTeam;
    private List<Match<TTeam>> Matches = new();
    private List<(int homeScore, int awayScore)> ScoreHistory = new();
    private PenaltySeries? PenaltySeries;

    public int FirstTeamWins = 0;
    public int SecondTeamWins = 0;

    public Playoff(TTeam firstTeam, TTeam secondTeam)
    {
        FirstTeam = firstTeam;
        SecondTeam = secondTeam;
    }

    public void Start()
    {
        Console.WriteLine($"\nMatchup: {FirstTeam.Name} vs {SecondTeam.Name}");

        if (typeof(TTeam) == typeof(BasketballTeam))
        {
            SimulateBasketballSeries();
        }
        else if (typeof(TTeam) == typeof(TennisTeam))
        {
            SimulateTennisSeries();
        }
        else
        {
            SimulateFootballSeries();
        }

        Console.WriteLine($"Series Winner: {GetWinner().Name}\n");
    }

    private void SimulateBasketballSeries()
    {
        while (FirstTeamWins < 4 && SecondTeamWins < 4)
        {
            var match = (Match<TTeam>)(object)new BasketballMatch(
                (BasketballTeam)(object)FirstTeam,
                (BasketballTeam)(object)SecondTeam);

            match.Start(50, 150);
            Matches.Add(match);

            Statistics.MatchesPlayed++;
            Statistics.TotalGoals += match.HomeGoals + match.AwayGoals;

            Console.WriteLine($"Match Result: {match.Home.Name} {match.HomeGoals} - {match.AwayGoals} {match.Away.Name}");

            if (match.HomeGoals > match.AwayGoals)
                FirstTeamWins++;
            else
                SecondTeamWins++;
        }
    }


    private void SimulateTennisSeries()
    {
        while (FirstTeamWins < 3 && SecondTeamWins < 3) 
        {
            var match = new TennisMatch((TennisTeam)(object)FirstTeam, (TennisTeam)(object)SecondTeam);
            Matches.Add((Match<TTeam>)(object)match);

            (int homeSets, int awaySets) = match.StartSetBasedMatch(); 

            Statistics.MatchesPlayed++;
            Statistics.TotalGoals += homeSets + awaySets;

            Console.WriteLine($"Match Result: {match.Home.Name} {homeSets} - {awaySets} {match.Away.Name}");

            if (homeSets > awaySets)
                FirstTeamWins++;
            else
                SecondTeamWins++;
        }
    }


    private void SimulateFootballSeries()
    {
        Matches.Add(new Match<TTeam>(FirstTeam, SecondTeam));
        Matches.Add(Matches[0].Reverse());

        foreach (var match in Matches)
        {
            int minScore = (typeof(TTeam) == typeof(FootballTeam)) ? 1 : 50;
            int maxScore = (typeof(TTeam) == typeof(FootballTeam)) ? 6 : 150;

            match.Start(minScore, maxScore);
            ScoreHistory.Add((match.HomeGoals, match.AwayGoals));

            Statistics.MatchesPlayed++;
            Statistics.TotalGoals += match.HomeGoals + match.AwayGoals;

            Console.WriteLine($"Match Result: {match.Home.Name} {match.HomeGoals} - {match.AwayGoals} {match.Away.Name}");

            if (match.HomeGoals > match.AwayGoals)
                FirstTeamWins++;
            else if (match.HomeGoals < match.AwayGoals)
                SecondTeamWins++;
        }

        if (typeof(TTeam) == typeof(FootballTeam) && FirstTeamWins == SecondTeamWins)
        {
            ShootPenalties();
        }
    }


    private void ShootPenalties()
    {
        Statistics.PenaltyShootouts++;
        PenaltySeries = new PenaltySeries(FirstTeam, SecondTeam);
        PenaltySeries.Start(1, 6);

        Console.WriteLine($"Penalty Shootout: {PenaltySeries.GetScore()}");

        if (PenaltySeries.FirstGoals > PenaltySeries.SecondGoals)
            FirstTeamWins++;
        else
            SecondTeamWins++;
    }

    public TTeam GetWinner()
    {
        return FirstTeamWins > SecondTeamWins ? FirstTeam : SecondTeam;
    }
}
