using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022;

public static class Day_05
{
    public static void part01(string data)
    {
        var main = data.Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries);
        var stackMap = ParseInputStackData(main[0]);
        string instructions = main[1];

        foreach (string instruction in instructions.Split('\n', StringSplitOptions.RemoveEmptyEntries))
        {
            var splittedInstruction = instruction.Split(' ');
            int iterations = int.Parse(splittedInstruction[1]);
            int from = int.Parse(splittedInstruction[3]);
            int to = int.Parse(splittedInstruction[5]);

            for (int i = 0; i < iterations; i++)
            {
                char value = stackMap[from].Pop();
                stackMap[to].Push(value);
            }
        }
        foreach (var stack in stackMap)
        {
            Console.Write(stack.Value.Peek());
        }
    }

    public static void part02(string data)
    {
        var main = data.Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries);
        var stackMap = ParseInputStackData(main[0]);
        string instructions = main[1];

        foreach (string instruction in instructions.Split('\n', StringSplitOptions.RemoveEmptyEntries))
        {
            var splittedInstruction = instruction.Split(' ');
            int iterations = int.Parse(splittedInstruction[1]);
            int from = int.Parse(splittedInstruction[3]);
            int to = int.Parse(splittedInstruction[5]);

            Stack<char> crateMover9001 = new();

            for (int i = 0; i < iterations; i++)
            {
                char value = stackMap[from].Pop();
                crateMover9001.Push(value);
            }

            while (crateMover9001.Count != 0)
            {
                char value = crateMover9001.Pop();
                stackMap[to].Push(value);
            }

        }
        foreach (var stack in stackMap)
        {
            Console.Write(stack.Value.Peek());
        }
    }

    private static Dictionary<int, Stack<char>> ParseInputStackData(string stackAsString)
    {
        var stackMap = new Dictionary<int, Stack<char>>();

        var stackLines = stackAsString.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        for (int i = stackLines.Length - 2; i >= 0; i--)
        {
            var iterator = 0;
            foreach (char c in stackLines[i].ToCharArray())
            {
                iterator++;
                if (c == '[')
                {
                    var value = stackLines[i][iterator];
                    int stackNumber = int.Parse(stackLines[^1][iterator].ToString());

                    if (!stackMap.ContainsKey(stackNumber)) stackMap[stackNumber] = new();
                    stackMap[stackNumber].Push(value);
                }
            }
        }
        return stackMap;
    }

}
