using Sports.Matches;

public class FinalMatch<TTeam> : Match<TTeam> where TTeam : Team
{
    public FinalMatch(TTeam home, TTeam away) : base(home, away) { }

    public PenaltySeries PenaltySeries;

    public override void Start(int start, int end)
    {
        base.Start(start, end);
        if (HomeGoals == AwayGoals)
        {
            PenaltySeries = new PenaltySeries(Home, Away);
            PenaltySeries.Start(1, 6);
        }
    }
}
