using System.Numerics;

namespace AoC2022;

public static class Day_07
{
    public static void part01(string data)
    {
        int totalSize = 100000;
        var instructions = data.Split("\n", StringSplitOptions.TrimEntries);
        Tree tree = new();
        TreeNode currentNode = new();

        for (int i = 0; i < instructions.Length - 1; i++)
        {
            var instruction = instructions[i];
            if (instruction[0] == '$')
            {
                var instructionParts = instruction.Split(' ');

                switch (instructionParts[1])
                {
                    case "cd":
                        var directory = instructionParts[2];
                        var temp = tree.SearchForDir(directory, currentNode);


                        if (directory == ".." && currentNode._parent is not null)
                        {
                            currentNode = currentNode._parent;
                        }
                        else if (temp is not null)
                        {
                            currentNode = temp;
                        }
                        else if (temp is null)
                        {
                            currentNode = tree.Add(new TreeNode()
                            {
                                _parent = null,
                                _name = directory,
                                _childrens = new(),
                                _size = 0
                            });
                        }
                        break;

                    case "ls":
                        string op = "";
                        while (true)
                        {
                            i++;
                            if (i == instructions.Length) break;

                            var nextInstruction = instructions[i];
                            var nextInstructionParts = nextInstruction.Split(" ");

                            op = nextInstructionParts[0];
                            if (op == "$")
                            {
                                i--;
                                break;
                            }
                            else if (op == "dir")
                            {
                                currentNode._childrens.Add(tree.Add(new TreeNode()
                                {
                                    _parent = currentNode,
                                    _name = nextInstructionParts[1],
                                    _childrens = new(),
                                    _size = 0
                                }));
                            }
                            else
                            {
                                currentNode._childrens.Add(tree.Add(new TreeNode()
                                {
                                    _parent = currentNode,
                                    _name = nextInstructionParts[1],
                                    _childrens = null,
                                    _size = int.Parse(op)
                                }));
                            }

                        }
                        break;
                }
            }
        }

        List<int> folderSums = new();

        foreach (var dir in tree._nodes.Where(p => p._size == 0).ToList())
        {
            folderSums.Add(tree.CalculateDirectorySizeSum(dir));
        }

        var sum = folderSums.Where(p => p <= totalSize).Sum();
        Console.WriteLine(sum);
    }

    public static void part02(string data)
    {
        int computerSpace = 70000000;
        int neededSpace = 30000000;
        var instructions = data.Split("\n", StringSplitOptions.TrimEntries);
        Tree tree = new();
        TreeNode currentNode = new();

        for (int i = 0; i < instructions.Length - 1; i++)
        {
            var instruction = instructions[i];
            if (instruction[0] == '$')
            {
                var instructionParts = instruction.Split(' ');

                switch (instructionParts[1])
                {
                    case "cd":
                        var directory = instructionParts[2];
                        var temp = tree.SearchForDir(directory, currentNode);


                        if (directory == ".." && currentNode._parent is not null)
                        {
                            currentNode = currentNode._parent;
                        }
                        else if (temp is not null)
                        {
                            currentNode = temp;
                        }
                        else if (temp is null)
                        {
                            currentNode = tree.Add(new TreeNode()
                            {
                                _parent = null,
                                _name = directory,
                                _childrens = new(),
                                _size = 0
                            });
                        }
                        break;

                    case "ls":
                        string op = "";
                        while (true)
                        {
                            i++;
                            if (i == instructions.Length) break;

                            var nextInstruction = instructions[i];
                            var nextInstructionParts = nextInstruction.Split(" ");

                            op = nextInstructionParts[0];
                            if (op == "$")
                            {
                                i--;
                                break;
                            }
                            else if (op == "dir")
                            {
                                currentNode._childrens.Add(tree.Add(new TreeNode()
                                {
                                    _parent = currentNode,
                                    _name = nextInstructionParts[1],
                                    _childrens = new(),
                                    _size = 0
                                }));
                            }
                            else
                            {
                                currentNode._childrens.Add(tree.Add(new TreeNode()
                                {
                                    _parent = currentNode,
                                    _name = nextInstructionParts[1],
                                    _childrens = null,
                                    _size = int.Parse(op)
                                }));
                            }

                        }
                        break;
                }
            }
        }

        List<int> folderSums = tree._nodes.Where(p => p._size == 0).Select(p => tree.CalculateDirectorySizeSum(p)).ToList();

        int currentAvailableSpace = computerSpace - tree.CalculateDirectorySizeSum(tree._root);

        Console.WriteLine(folderSums.Where(p => currentAvailableSpace + p >= neededSpace).Order().First());
    }

    class Tree
    {
        public TreeNode _root { get; set; }
        public List<TreeNode> _nodes { get; set; }

        public Tree()
        {
            _nodes = new List<TreeNode>();
        }

        public TreeNode SearchForDir(string name, TreeNode currentNode)
        {
            if (currentNode._childrens == null) return null;

            return currentNode._childrens.Where(p => p._name == name)
                .FirstOrDefault();
        }

        public TreeNode Add(TreeNode file)
        {
            _nodes.Add(file);

            if (_root == null)
            {
                _root = file;
            }
            return file;
        }

        public int CalculateDirectorySizeSum(TreeNode node)
        {
            if (node._childrens is null)
            {
                return node._size;
            }

            int sum = 0;
            foreach (var child in node._childrens)
            {
                sum += CalculateDirectorySizeSum(child);
            }
            return sum;
        }

        public int FindMaxValue(List<int> sums, int targetSum, int iteration, int sum)
        {
            if (sum > targetSum) return 0;
            if (iteration == sums.Count) return sum;

            var pick = FindMaxValue(sums, targetSum, iteration + 1, sum + sums[iteration]);
            var leave = FindMaxValue(sums, targetSum, iteration + 1, sum);
            return Math.Max(pick, leave);
        }
    }

    class TreeNode
    {
        public TreeNode _parent { get; set; }
        public List<TreeNode> _childrens { get; set; }
        public string _name { get; set; }
        public int _size { get; set; }
    }
}
