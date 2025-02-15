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



    public List<Playoff> Draw()
    {
        var playoffs = new List<Playoff>();
        var matchGenerator = new GenerateRandomMatch(); 

        while (Teams.Count > 0)
        {
            var match = matchGenerator.GenerateMatch(Teams);
            var playoff = new Playoff(match.Home, match.Away);
            playoffs.Add(playoff);
        }
        return playoffs;
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

        var playoffs = Draw();

        foreach (var playoff in playoffs)
        {
            playoff.Start();
        }

        Teams = playoffs.Select(x => x.GetWinner()).ToList();

        return GetWinners();
    }
}