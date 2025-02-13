using System;
using System.Collections.Generic;
using System.Linq;

internal class WinCounter
{
    private Dictionary<string, int> teamWinCount = new();

    public void AddWin(string teamName)
    {
        teamWinCount[teamName] = teamWinCount.GetValueOrDefault(teamName, 0) + 1;
    }

    public void PrintTopTeams(int TopTeams = 10)
    {
        var topTeams = teamWinCount.OrderByDescending(i => i.Value)
                                   .Take(TopTeams)
                                   .ToList();

        Console.WriteLine("\n Top Winning Teams:");
        foreach (var (team, wins) in topTeams)
        {
            Console.WriteLine($"{team}: {wins} titles");
        }
    }
}
