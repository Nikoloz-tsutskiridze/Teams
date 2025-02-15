internal class Playoff
{
    public Team FirstTeam;
    public Team SecondTeam;

    public Match FirstRound;
    public Match SecondRound;

    public int FirstTeamTotalGoals;
    public int SecondTeamTotalGoals;

    public Playoff(Team firsteam, Team secondteam)
    {
        FirstTeam = firsteam;
        SecondTeam = secondteam;

        FirstRound = new Match(firsteam, secondteam);
        SecondRound = FirstRound.Reverse();
    }

    public void ShootPenalties(out int firstTeamPenalties, out int secondTeamPenalties)
    {
        Statistics.PenaltyShootouts++;

        firstTeamPenalties = GenerateRandomNumber.Generate(1, 6);
        secondTeamPenalties = GenerateRandomNumber.Generate(1, 6);

        while (firstTeamPenalties == secondTeamPenalties)
        {
            Console.WriteLine("Tie in penalties, reshooting...");
            firstTeamPenalties = GenerateRandomNumber.Generate(1, 6);
            secondTeamPenalties = GenerateRandomNumber.Generate(1, 6);
        }

        if (firstTeamPenalties > secondTeamPenalties)
        {
            FirstTeamTotalGoals = FirstTeamTotalGoals++;
            Console.WriteLine("Home wins on penalties!");
        }
        else
        {
            SecondTeamTotalGoals = SecondTeamTotalGoals++;
            Console.WriteLine("Away wins on penalties!");
        }
    }

    public void Start()
    {
        FirstRound.Start();
        SecondRound.Start();

        FirstTeamTotalGoals = FirstRound.HomeGoals + SecondRound.AwayGoals;
        SecondTeamTotalGoals = SecondRound.HomeGoals + FirstRound.AwayGoals;

        //Console.WriteLine($"\nAggregate Score: {FirstTeam.Name} {FirstTeamTotalGoals} - {SecondTeamTotalGoals} {SecondTeam.Name}");
        int firstTeamPenalties = 0;
        int secondTeamPenalties = 0;

        if (FirstTeamTotalGoals == SecondTeamTotalGoals)
        {
            ShootPenalties(out firstTeamPenalties, out secondTeamPenalties);
        }

        var winner = GetWinner();
        var potentialPenalties = firstTeamPenalties != 0 && secondTeamPenalties != 0 ? $"({firstTeamPenalties} : {secondTeamPenalties})" : string.Empty;

        Console.WriteLine($"==== {FirstTeam.Name} {FirstTeamTotalGoals} - {SecondTeamTotalGoals} {SecondTeam.Name} ==== {potentialPenalties} ({winner.Name})\n");
    }

    public Team GetWinner()
    {
        return FirstTeamTotalGoals > SecondTeamTotalGoals ? FirstTeam : SecondTeam;
    }
}
