using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022;

public static class Day_03
{
    public static void part01(string data)
    {
        var rucksacks = data.Split("\n", StringSplitOptions.TrimEntries);
        int sum = 0;
        foreach (var rucksack in rucksacks)
        {
            var compartments = rucksack.ToCharArray().Chunk(rucksack.Length / 2).ToList();
            var firstCompartment = compartments[0];
            var secondCompartment = compartments[1];
            var similarChar = GetSimilarity(firstCompartment, secondCompartment);
            foreach(var c in similarChar)
            {
                var value = CalculateCharValue(c);
                sum += value;
            }
        }
        Console.WriteLine(sum);
    }

    public static void part02(string data)
    {
        var rucksacks = data.Split("\n", StringSplitOptions.TrimEntries);
        int sum = 0;

        for(int i=0; i < rucksacks.Length - 1; i += 3)
        {
            var compartments1 = rucksacks[i].ToCharArray();
            var compartments2 = rucksacks[i+1].ToCharArray();
            var compartments3 = rucksacks[i+2].ToCharArray();

            var similarChar = GetSimilarity(compartments1, compartments2, compartments3);
            foreach (var c in similarChar)
            {
                var value = CalculateCharValue(c);
                sum += value;
            }
        }
        Console.WriteLine(sum);
    }

    private static int CalculateCharValue(char c)
    {
        if (c == char.ToUpper(c))
        {
            return char.ToUpper(c) - 38;
        }
        return (int)c % 32;
    }

    private static List<char> GetSimilarity(char[] firstCompartment, char[] secondCompartment)
    {
        List<char> result = new();
        foreach(char f in firstCompartment)
        {
            foreach(char s in secondCompartment)
            {
                if (f == s && !result.Any(p => p == f))
                {
                    result.Add(s);
                }
            }
        }
        return result;
    }

    private static List<char> GetSimilarity(char[] firstCompartment, char[] secondCompartment, char[] thirdCompartment)
    {
        List<char> result = new();
        foreach (char f in firstCompartment)
        {
            foreach (char s in secondCompartment)
            {
                foreach (char t in thirdCompartment)
                {
                    if (f == s && s == t && !result.Any(p => p == f))
                    {
                        result.Add(s);
                    }
                }
            }
        }
        return result;
    }
}
