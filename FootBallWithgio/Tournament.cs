using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Tournament
{
    public string Name;
    public Tournament(string name)
    {
        Name = name;
    }

    public Team GetWinners(List<Team> teams)
    {

        if (teams.Count == 1)
        {
            Console.WriteLine($"\nWinner is: {teams.First().Name} 🎉");
            Statistics.Display();
            return teams.First();
        }

        string roundName;
        switch (teams.Count)
        {
            case 16:
                roundName = "Eight-Finals";
                break;
            case 8:
                roundName = "Quarter-Finals";
                break;
            case 4:
                roundName = "Semi-Finals";
                break;
            case 2:
                roundName = "Final";
                break;
            default:
                roundName = "";
                break;
        }


        Console.WriteLine("╔═════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine($"                               {roundName}                                 ");
        Console.WriteLine("╚═════════════════════════════════════════════════════════════════════════╝");


        foreach (var team in teams)
        {
            team.IsHome = false;
            team.IsAway = false;
        }

        var matches = new List<Match>();
        var matchGenerator = new GenerateRandomMatch();

        while (teams.Count > 0)
        {
            var match = matchGenerator.GenerateMatch(teams);
            matches.Add(match);
        }

        foreach (var match in matches)
        {
            match.Start();
        }

        var winners = matches.Select(x => x.GetWinner()).ToList();

        return GetWinners(winners);
    }
}