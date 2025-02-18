using Sports.Matches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class GenerateRandomMatch<TTeam> where TTeam : Team
{
    public TTeam GetOpponent(List<TTeam> teams)
    {
        var index = GenerateRandomNumber.Generate(0, teams.Count - 1);
        var randomElement = teams[index];
        teams.RemoveAt(index);
        return randomElement;
    }

    public Match<TTeam> GenerateMatch(List<TTeam> teams)
    {
        var home = GetOpponent(teams);
        var away = GetOpponent(teams);

        home.IsHome = true;
        away.IsAway = true;

        return new Match<TTeam>(home, away);
    }
}