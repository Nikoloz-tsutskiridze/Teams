using FirstLesson;
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

var matches = new List<Match>();
while (teams.Count > 0)
{
    var indexForFirstTeam = GenerateRandomNumber.Generate(0, teams.Count);
    var teamFirst = teams[indexForFirstTeam];

    teams.Remove(teamFirst);

    var indexForSecondTeam = GenerateRandomNumber.Generate(0, teams.Count);
    var teamSecond = teams[indexForSecondTeam];
    teams.Remove(teamSecond);

    var match = new Match(teamFirst, teamSecond);
    matches.Add(match);
}

foreach (var item in matches)
{
    item.Start();
    item.Start();
    item.GetWinner();
}


Console.ReadKey();