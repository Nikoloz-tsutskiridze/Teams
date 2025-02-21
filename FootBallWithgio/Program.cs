using Sports.Teams;

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

var TennisPlayers = new string[]
{
    "Roger Federer",
    "Rafael Nadal",
    "Novak Djokovic",
    "Andy Murray",
    "Pete Sampras",
    "Andre Agassi",
    "Björn Borg",
    "Rod Laver",
    "John McEnroe",
    "Stefan Edberg",
    "Ivan Lendl",
    "Jimmy Connors",
    "Mats Wilander",
    "Boris Becker",
    "Stan Wawrinka",
    "Carlos Alcaraz",
};



//var footballTeams = FootballTeamNames.Select(name => new FootballTeam(name)).ToList();
//var basketballTeams = BasketballTeamNames.Select(name => new BasketballTeam(name)).ToList();
var tennisTeams = TennisPlayers.Select(name => new TennisTeam(name)).ToList();

//var footballTournament = new Tournament<FootballTeam>("Champions League", footballTeams);
//footballTournament.GetWinners();

//var basketballTournament = new Tournament<BasketballTeam>("NBA Finals", basketballTeams);
//basketballTournament.GetWinners();

var tennisTournament = new Tournament<TennisTeam>("NBA Finals", tennisTeams);
tennisTournament.GetWinners();



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

 */
Console.ReadKey();
