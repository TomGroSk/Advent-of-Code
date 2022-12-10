using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022;

public static class Day_06
{
    public static void part01(string data)
    {
        for (int i = 0; i < data.Length; i++)
        {
            if (!CheckIfThereIsDuplicate(new char[] { data[i], data[i + 1], data[i + 2], data[i + 3] }))
            {
                Console.WriteLine(i + 4);
                return;
            }
        }
    }

    public static void part02(string data)
    {
        for (int i = 0; i < data.Length; i++)
        {
            char[] messageChars = new char[14];

            for(int j=0; j < 14; j++)
            {
                messageChars[j] = data[i+j];
            }

            if (!CheckIfThereIsDuplicate(messageChars))
            {
                Console.WriteLine(i + 14);
                return;
            }
        }
    }

    public static bool CheckIfThereIsDuplicate(char[] data)
    {
        for (int i = 0; i < data.Length; i++)
        {
            for (int j = 0; j < data.Length; j++)
            {
                if (j == i) continue;

                if (data[i] == data[j])
                {
                    return true;
                }
            }
        }
        return false;
    }
}
