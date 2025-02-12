using System.Security.Cryptography;

//while (true)
//{
//    Thread.Sleep(300);
//    Console.WriteLine(GenerateRandomNumber.Generate(0, 2));
//}

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

var teams = teamNames.Select(x => new Team(x)).ToList();

var tournament = new Tournament("Uefa Champions League");
tournament.GetWinners(teams);

Console.ReadKey();
