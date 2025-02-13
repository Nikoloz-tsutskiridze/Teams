using System.Security.Cryptography;

var teamNames = new string[]
{
  "Manchester United",
  "Real Madrid",
  "Barcelona",
  "Liverpool",
  "Paris Saint-Germain",
  "Bayern Munich",
  "Chelsea",
  "Juventus",
  "Manchester City",
  "AC Milan",
  "Arsenal",
  "Tottenham Hotspur",
  "Inter Milan",
  "Atlético Madrid",
  "Borussia Dortmund",
  "Napoli",
};

var Teams = teamNames.Select(x => new Team(x)).ToList();

var tournament = new Tournament("Uefa Champions League", Teams);
tournament.GetWinners();

Console.ReadKey();

/*
var teamNames = new string[]
{
    "Real Madrid", "Barcelona", "Liverpool", "Bayern Munich",
    "AC Milan", "Chelsea", "Juventus", "Manchester United",
    "Inter Milan", "Atlético Madrid", "Borussia Dortmund",
    "Napoli", "Paris Saint-Germain", "Arsenal", "Tottenham Hotspur"
};

var winCounter = new WinCounter();

int startYear = 1956;
int currentYear = DateTime.Now.Year;
Random random = new();

for (int i = startYear; i <= currentYear; i++)
{
    string winner = teamNames[random.Next(teamNames.Length)];
    winCounter.AddWin(winner);
    Console.WriteLine($"{i}: {winner}");
}
 */

//winCounter.PrintTopTeams();

//Console.ReadKey();
