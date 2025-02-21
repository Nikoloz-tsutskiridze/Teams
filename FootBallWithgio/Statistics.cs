using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Statistics
{
    public static int TotalGoals { get; set; }
    public static int MatchesPlayed { get; set; }
    public static int PenaltyShootouts { get; set; }

    public static void Reset()
    {
        MatchesPlayed = 0;  
        TotalGoals = 0;
        PenaltyShootouts = 0;
    }

    public static void Display()
    {
        Console.WriteLine("\n=== Tournament Statistics ===");
        Console.WriteLine($"Total Matches Played: {MatchesPlayed}");
        Console.WriteLine($"Total Points Scored: {TotalGoals}");
        Console.WriteLine($"Penalty Shootouts: {PenaltyShootouts}");
    }
}

