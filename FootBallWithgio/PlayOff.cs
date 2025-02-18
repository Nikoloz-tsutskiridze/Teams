
using Sports.Matches;

internal class Playoff<TTeam> where TTeam : Team
{
    public TTeam FirstTeam;
    public TTeam SecondTeam;

    public Match<TTeam> FirstRound;
    public Match<TTeam> SecondRound;

    public int FirstTeamTotalGoals;
    public int SecondTeamTotalGoals;

    private PenaltySeries PenaltySeries;

    public Playoff(TTeam firstTeam, TTeam secondTeam)
    {
        FirstTeam = firstTeam;
        SecondTeam = secondTeam;

        FirstRound = new Match<TTeam>(firstTeam, secondTeam);
        SecondRound = FirstRound.Reverse();

        PenaltySeries = new PenaltySeries(firstTeam, secondTeam);
    }

    public void ShootPenalties()
    {
        Statistics.PenaltyShootouts++;
        PenaltySeries.Start(1, 6);

        Console.WriteLine(PenaltySeries.GetScore());

        if (PenaltySeries.FirstGoals > PenaltySeries.SecondGoals)
        {
            FirstTeamTotalGoals++;
        }
        else if (PenaltySeries.FirstGoals < PenaltySeries.SecondGoals)
        {
            SecondTeamTotalGoals++;
        }
    }

    public void Start()
    {
        var start = FirstRound.Home.ScoreStart;
        var end = FirstRound.Home.ScoreEnd;
        FirstRound.Start(start, end);
        SecondRound.Start(start, end);

        var firstTeamTotalGoals = FirstRound.HomeGoals + SecondRound.AwayGoals;
        var secondTeamTotalGoals = SecondRound.HomeGoals + FirstRound.AwayGoals;

        FirstTeamTotalGoals = firstTeamTotalGoals;
        SecondTeamTotalGoals = secondTeamTotalGoals;

        if (firstTeamTotalGoals == secondTeamTotalGoals)
        {
            ShootPenalties();
        }

        var winner = GetWinner();
        var potentialPenalties = PenaltySeries.FirstGoals != 0 && PenaltySeries.SecondGoals != 0
            ? $"({PenaltySeries.FirstGoals} : {PenaltySeries.SecondGoals})"
            : string.Empty;

        Console.WriteLine($"==== {FirstTeam.Name} {firstTeamTotalGoals} - {secondTeamTotalGoals} {SecondTeam.Name} ==== {potentialPenalties} ({winner.Name})\n");
    }

    public TTeam GetWinner()
    {
        return FirstTeamTotalGoals > SecondTeamTotalGoals ? FirstTeam : SecondTeam;
    }
}
