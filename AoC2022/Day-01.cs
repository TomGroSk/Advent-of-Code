namespace AoC2022;

public static class Day_01
{
    public static void part01(string data)
    {
        var elfCaloriesPackages = data.Split("\n\r\n");
        var maxSum = int.MinValue;
        foreach(var pack in elfCaloriesPackages)
        {
            var t = pack.Split("\n");
            var sum = 0;

            foreach(var calories in t)
            {
                var cals = int.Parse(calories);
                sum += cals;
            }

            if(maxSum < sum)
            {
                maxSum = sum;
            }
        }

        Console.WriteLine(maxSum);
    }

    public static void part02(string data)
    {
        var elfCaloriesPackages = data.Split("\n\r\n");
        List<int> elfCaloriesSums = new();
        foreach (var pack in elfCaloriesPackages)
        {
            var t = pack.Split("\n");
            var sum = 0;

            foreach (var calories in t)
            {
                var cals = int.Parse(calories);
                sum += cals;
            }

            elfCaloriesSums.Add(sum);
        }

        Console.WriteLine(elfCaloriesSums.OrderByDescending(x => x).Take(3).Sum());
    }
}
