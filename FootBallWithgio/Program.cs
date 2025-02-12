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


List<Team> teams = new List<Team>();

foreach (var teamName in teamNames)
{
    var team = new Team(teamName);
    teams.Add(team);
}


var tournament = new Tournament("Uefa Champions League");
var winners = tournament.GetWinners(teams);


Console.ReadKey();