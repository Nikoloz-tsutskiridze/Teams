internal class Playoff
{
    public Team Home;
    public Team Away;
    public int HomeTotalGoals;
    public int AwayTotalGoals;

    public Playoff(Team home, Team away)
    {
        Home = home;
        Away = away;
    }

    public void Start()
    {
        var firstMatch = new Match(Home, Away);
        firstMatch.Start();
        HomeTotalGoals += firstMatch.HomeGoals;
        AwayTotalGoals += firstMatch.AwayGoals;

        var secondMatch = new Match(Away, Home);
        secondMatch.Start();
        HomeTotalGoals += secondMatch.AwayGoals;
        AwayTotalGoals += secondMatch.HomeGoals;

        Console.WriteLine($"\nAggregate Score: {Home.Name} {HomeTotalGoals} - {AwayTotalGoals} {Away.Name}");

        if (HomeTotalGoals == AwayTotalGoals)
        {
            Console.WriteLine("Tie on aggregate! Proceeding to penalties...");
            firstMatch.ShootPenalties();
        }
        else
        {
            var winner = GetWinner();
            Console.WriteLine($"\nWinner on aggregate: {winner.Name}");
        }

        Console.WriteLine($"==== {Home.Name} VS {Away.Name}");
    }

    public Team GetWinner()
    {
        return HomeTotalGoals > AwayTotalGoals ? Home : Away;
    }
}
