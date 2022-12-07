using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022;

public class Day_02
{
    public static void part01(string data)
    {
        var rounds = data.Split("\n", StringSplitOptions.TrimEntries);
        var finalScore = 0;
        foreach (var round in rounds)
        {
            string opponentShape = round.Split(" ")[0];
            string myShape = round.Split(" ")[1];
            finalScore += RoundCalculator(opponentShape, myShape);
        }
        Console.WriteLine(finalScore);
    }

    public static void part02(string data)
    {
        var rounds = data.Split("\n", StringSplitOptions.TrimEntries);
        var finalScore = 0;
        foreach (var round in rounds)
        {
            string opponentShape = round.Split(" ")[0];
            string myShape = round.Split(" ")[1];
            myShape = ShapeChanger(opponentShape,myShape);
            finalScore += RoundCalculator(opponentShape, myShape);
        }
        Console.WriteLine(finalScore);
    }

    private static int RoundCalculator(string opponentShape, string myShape)
    {
        var score = 0;

        score += ShapeScoreAdditor(myShape);
        score += JudgeScoreCalculator(opponentShape, myShape);

        return score;
    }

    private static int JudgeScoreCalculator(string opponentShape, string myShape)
    {
        return (opponentShape, myShape) switch
        {
            ("A", "X") => 3,
            ("A", "Y") => 6,
            ("A", "Z") => 0,
            ("B", "X") => 0,
            ("B", "Y") => 3,
            ("B", "Z") => 6,
            ("C", "X") => 6,
            ("C", "Y") => 0,
            ("C", "Z") => 3,
            _ => 0
        };
    }

    private static int ShapeScoreAdditor(string shape)
    {
        switch (shape)
        {
            case "X":
                return 1;
            case "Y":
                return 2;
            case "Z":
                return 3;
        }
        return 0;
    }

    private static string ShapeChanger(string opponentShape, string myShape)
    {
        return (opponentShape, myShape) switch
        {
            ("A", "X") => "Z", //lose
            ("A", "Y") => "X", //draw
            ("A", "Z") => "Y", //win
            ("B", "X") => "X", //lose
            ("B", "Y") => "Y", //draw
            ("B", "Z") => "Z", //win
            ("C", "X") => "Y", //lose
            ("C", "Y") => "Z", //draw
            ("C", "Z") => "X", //win
            _ => ""
        };
    }
}
