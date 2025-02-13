using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Tournament
{
    public string Name;
    public List<Team> Teams;

    public Tournament(string name, List<Team> teams)
    {
        Name = name;
        Teams = teams;
    }

    public List<Match> Draw()
    {
        var matches = new List<Match>();
        var matchGenerator = new GenerateRandomMatch(); 

        while (Teams.Count > 0)
        {
            var match = matchGenerator.GenerateMatch(Teams); 
            matches.Add(match);
        }

        return matches;
    }


    public Team GetWinners()
    {

        if (Teams.Count == 1)
        {
            Console.WriteLine($"\nWinner is: {Teams.First().Name}");
            Statistics.Display();
            return Teams.First();
        }

        string roundName;
        switch (Teams.Count)
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


        foreach (var team in Teams)
        {
            team.IsHome = false;
            team.IsAway = false;
        }

        var matches = Draw();

        foreach (var match in matches)
        {
            match.Start();
        }

        Teams = matches.Select(x => x.GetWinner()).ToList();

        return GetWinners();
    }
}