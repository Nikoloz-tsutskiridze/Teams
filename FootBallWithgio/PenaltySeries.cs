public class PenaltySeries
{
    private Team FirstTeam;
    private Team SecondTeam;

    public int FirstGoals { get; private set; }
    public int SecondGoals { get; private set; }
    public int SuddenDeathRounds { get; private set; } = 0; 

    public PenaltySeries(Team firstTeam, Team secondTeam)
    {
        FirstTeam = firstTeam;
        SecondTeam = secondTeam;
    }

    public string GetScore()
    {
        return $"Pen: {FirstGoals} - {SecondGoals}";
    }

    public void Start(int start, int end)
    {
        FirstGoals = GenerateRandomNumber.Generate(start, end);
        SecondGoals = GenerateRandomNumber.Generate(start, end);

        if (FirstGoals == SecondGoals)
        {
            while (true)
            {
                int suddenDeathFirst = GenerateRandomNumber.Generate(0, 2);
                int suddenDeathSecond = GenerateRandomNumber.Generate(0, 2);

                SuddenDeathRounds++; 

                Console.WriteLine($"Sudden Death Round {SuddenDeathRounds}: {FirstTeam.Name} {suddenDeathFirst} - {suddenDeathSecond} {SecondTeam.Name}");

                if (suddenDeathFirst != suddenDeathSecond)
                {
                    if (suddenDeathFirst > suddenDeathSecond)
                    {
                        FirstGoals++;
                        Console.WriteLine($"{FirstTeam.Name} wins on sudden death penalties!");
                    }
                    else
                    {
                        SecondGoals++;
                        Console.WriteLine($"{SecondTeam.Name} wins on sudden death penalties!");
                    }
                    break; 
                }
            }
        }
    }
}
