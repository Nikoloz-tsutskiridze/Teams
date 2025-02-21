using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Tournament<TTeam> where TTeam : Team
{
    public string Name;
    public List<TTeam> Teams;
    

    public Tournament(string name, List<TTeam> teams)
    {
        Name = name;
        Teams = teams;
    }
    public List<Playoff<TTeam>> Draw()
    {
        var playoffs = new List<Playoff<TTeam>>();
        var matchGenerator = new GenerateRandomMatch<TTeam>(); 

        while (Teams.Count > 1)
        {
            var match = matchGenerator.GenerateMatch(Teams);
            var playoff = new Playoff<TTeam>(match.Home, match.Away);
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