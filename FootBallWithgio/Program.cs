var FootballTeamNames = new string[]
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

var BasketballTeamNames = new string[]
{
  "Los Angeles Lakers",
  "Golden State Warriors",
  "Chicago Bulls",
  "Boston Celtics",
  "Miami Heat",
  "Brooklyn Nets",
  "Milwaukee Bucks",
  "Philadelphia 76ers",
  "Phoenix Suns",
  "Dallas Mavericks",
  "Denver Nuggets",
  "San Antonio Spurs",
  "New York Knicks",
  "Toronto Raptors",
  "Houston Rockets",
  "Memphis Grizzlies",
};



//var match = new BasketballMatch(new BasketballTeam("Warriors"), new BasketballTeam("Lakers"));
//match.Start(50, 150);

//var match2 = new FootballMatch(new FootballTeam("Real"), new FootballTeam("barca"));
//match2.Start(1, 6);

//Console.WriteLine($"{match.Home.Name} {match.HomeGoals} - {match.AwayGoals} {match.Away.Name}");
//Console.WriteLine($"{match2.Home.Name} {match2.HomeGoals} - {match2.AwayGoals} {match2.Away.Name}");

//Console.ReadKey();
//return;

var basketballTeams = BasketballTeamNames.Select(name => new BasketballTeam(name)).ToList();
new List<int>();

var tournament = new Tournament<BasketballTeam>("NBA", basketballTeams);
tournament.GetWinners();



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

winCounter.PrintTopTeams();

Console.ReadKey();
 */
