using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022;

public static class Day_04
{
    public static void part01(string data)
    {
        var pairs = data.Split("\n", StringSplitOptions.TrimEntries);
        int counter = 0;
        foreach(var pair in pairs)
        {
            int begin1 = int.Parse(pair.Split(",")[0].Split("-")[0]);
            int end1 = int.Parse(pair.Split(",")[0].Split("-")[1]);
            int begin2 = int.Parse(pair.Split(",")[1].Split("-")[0]);    
            int end2 = int.Parse(pair.Split(",")[1].Split("-")[1]);

            if ((begin1 >= begin2 && end1 <= end2) || (begin1 <= begin2 && end1 >= end2))
            {
                counter++;
            }
        }
        Console.WriteLine(counter);
    }

    public static void part02(string data)
    {
        var pairs = data.Split("\n", StringSplitOptions.TrimEntries);
        int counter = 0;

        foreach (var pair in pairs)
        {
            int begin1 = int.Parse(pair.Split(",")[0].Split("-")[0]);
            int end1 = int.Parse(pair.Split(",")[0].Split("-")[1]);
            int begin2 = int.Parse(pair.Split(",")[1].Split("-")[0]);
            int end2 = int.Parse(pair.Split(",")[1].Split("-")[1]);

            if (begin1 <= begin2 && end1 >= begin2)
            {
                counter++;
            }
            else if(begin2 <= begin1 && end2 >= begin1)
            {
                counter++;
            }
        }
        Console.WriteLine(counter);
    }
}
