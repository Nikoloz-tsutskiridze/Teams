internal class Playoff
{
    public Team FirstTeam;
    public Team SecondTeam;

    public Match FirstRound;
    public Match SecondRound;

    public int FirstTeamTotalGoals;
    public int SecondTeamTotalGoals;

    private PenaltySeries PenaltySeries;

    public Playoff(Team firstTeam, Team secondTeam)
    {
        FirstTeam = firstTeam;
        SecondTeam = secondTeam;

        FirstRound = new Match(firstTeam, secondTeam);
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
        FirstRound.Start();
        SecondRound.Start();

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

    public Team GetWinner()
    {
        return FirstTeamTotalGoals > SecondTeamTotalGoals ? FirstTeam : SecondTeam;
    }
}
