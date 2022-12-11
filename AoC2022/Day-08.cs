namespace AoC2022;

public static class Day_08
{
    public static void part01(string data)
    {
        var forest = data.Split('\n', StringSplitOptions.TrimEntries);
        int visibleForestCounter = 0;
        for (int y = 0; y < forest.Length; y++)
        {
            for (int x = 0; x < forest[0].Length; x++)
            {
                if (x == 0 || y == 0 || x == forest[0].Length - 1 || y == forest.Length - 1)
                {
                    visibleForestCounter++;
                    continue;
                }

                bool isVisible = true;

                int tempCoordinate = x - 1;
                while (tempCoordinate >= 0)
                {
                    if (int.Parse(forest[x][y].ToString()) <= int.Parse(forest[tempCoordinate][y].ToString()))
                    {
                        isVisible = false;
                    }
                    tempCoordinate--;
                }
                if (isVisible)
                {
                    visibleForestCounter++;
                    continue;
                }

                isVisible = true;
                tempCoordinate = x + 1;
                while (tempCoordinate <= forest[0].Length - 1)
                {
                    if (int.Parse(forest[x][y].ToString()) <= int.Parse(forest[tempCoordinate][y].ToString()))
                    {
                        isVisible = false;
                    }
                    tempCoordinate++;
                }
                if (isVisible)
                {
                    visibleForestCounter++;
                    continue;
                }

                isVisible = true;
                tempCoordinate = y - 1;
                while (tempCoordinate >= 0)
                {
                    if (int.Parse(forest[x][y].ToString()) <= int.Parse(forest[x][tempCoordinate].ToString()))
                    {
                        isVisible = false;
                    }
                    tempCoordinate--;
                }
                if (isVisible)
                {
                    visibleForestCounter++;
                    continue;
                }

                isVisible = true;
                tempCoordinate = y + 1;
                while (tempCoordinate <= forest.Length - 1)
                {
                    if (int.Parse(forest[x][y].ToString()) <= int.Parse(forest[x][tempCoordinate].ToString()))
                    {
                        isVisible = false;
                    }
                    tempCoordinate++;
                }
                if (isVisible)
                {
                    visibleForestCounter++;
                    continue;
                }
            }
        }

        Console.WriteLine(visibleForestCounter);
    }

    public static void part02(string data)
    {
        var forest = data.Split('\n', StringSplitOptions.TrimEntries);
        List<int> scenicScore = new();

        for (int y = 0; y < forest.Length; y++)
        {
            for (int x = 0; x < forest[0].Length; x++)
            {
                if (x == 0 || y == 0 || x == forest[0].Length - 1 || y == forest.Length - 1)
                {
                    continue;
                }

                int tempScenicScore = 0;
                int score = 1;
                int tempCoordinate = x - 1;
                while (tempCoordinate >= 0)
                {
                    tempScenicScore++;
                    if (int.Parse(forest[x][y].ToString()) <= int.Parse(forest[tempCoordinate][y].ToString()))
                    {
                        break;
                    }
                    tempCoordinate--;
                }

                score *= tempScenicScore;
                tempScenicScore = 0;
                tempCoordinate = x + 1;
                while (tempCoordinate <= forest[0].Length - 1)
                {
                    tempScenicScore++;
                    if (int.Parse(forest[x][y].ToString()) <= int.Parse(forest[tempCoordinate][y].ToString()))
                    {
                        break;
                    }
                    tempCoordinate++;
                }

                score *= tempScenicScore;
                tempScenicScore = 0;
                tempCoordinate = y - 1;
                while (tempCoordinate >= 0)
                {
                    tempScenicScore++;
                    if (int.Parse(forest[x][y].ToString()) <= int.Parse(forest[x][tempCoordinate].ToString()))
                    {
                        break;
                    }
                    tempCoordinate--;
                }

                score *= tempScenicScore;
                tempScenicScore = 0;
                tempCoordinate = y + 1;
                while (tempCoordinate <= forest.Length - 1)
                {
                    tempScenicScore++;
                    if (int.Parse(forest[x][y].ToString()) <= int.Parse(forest[x][tempCoordinate].ToString()))
                    {
                        break;
                    }
                    tempCoordinate++;
                }
                score *= tempScenicScore;

                scenicScore.Add(score);
            }
        }

        Console.WriteLine(scenicScore.Max());
    }
}
