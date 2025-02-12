using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class GenerateRandomMatch
{
    public Team GetOpponent(List<Team> teams)
    {
        var index = GenerateRandomNumber.Generate(0, teams.Count - 1);
        var randomElement = teams[index];
        teams.RemoveAt(index);
        return randomElement;
    }

    public Match GenerateMatch(List<Team> teams)
    {
        var home = GetOpponent(teams);
        var away = GetOpponent(teams);

        home.IsHome = true;
        away.IsAway = true;

        return new Match(home, away);
    }
}