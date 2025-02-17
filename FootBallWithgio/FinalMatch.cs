class FinalMatch : Match
{
    public FinalMatch(Team home, Team away) : base(home, away)
    {
    }
    public FinalMatch(string home, string away) : base(home, away)
    {
    }

    public PenaltySeries PenaltySeries;

    public override void Start()
    {
        base.Start();
        if (HomeGoals == AwayGoals)
        {
            PenaltySeries = new PenaltySeries(Home, Away);
            PenaltySeries.Start(1, 6);
        }
    }
}
