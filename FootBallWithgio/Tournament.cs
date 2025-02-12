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

    public List<Team> GetWinners(List<Team> teams)
    {
        if (teams.Count % 2 != 0)
            throw new ArgumentException("Number of teams must be even.");

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

        return matches.Select(x => x.GetWinner()).ToList();
    }
}