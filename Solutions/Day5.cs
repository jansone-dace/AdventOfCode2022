using System.Linq;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2022.Solutions
{
    public static class Day5
    {
        public static string Part1()
        {
            List<List<char>> stacks = new List<List<char>>();
            int prevIndex, curIndex, stackIndex;
            char letter;
            int moveCount, stackFrom, stackTo;
            string movePattern = @"move ([0-9]+) from ([0-9]+) to ([0-9]+)";
            Match match;
            List<char> itemsToMove;

            foreach (string line in System.IO.File.ReadLines(@"Inputs/day5.txt"))
            {
                if (line.Contains("move"))
                {
                    itemsToMove = new List<char>();
                    match = Regex.Match(line, movePattern);
                    moveCount = Int32.Parse(match.Groups[1].Value);
                    stackFrom = Int32.Parse(match.Groups[2].Value);
                    stackTo = Int32.Parse(match.Groups[3].Value);

                    for (int i = 0; i < moveCount; i++)
                    {
                        itemsToMove.Add(stacks[stackFrom-1].Last());
                        stacks[stackFrom-1].RemoveAt(stacks[stackFrom-1].Count - 1);
                    }

                    stacks[stackTo-1].AddRange(itemsToMove.ToArray());
                }
                else
                {
                    prevIndex = -1;
                    while (true)
                    {
                        curIndex = line.IndexOf('[', prevIndex+1);
                        prevIndex = curIndex;
                        if (curIndex == -1)
                            break;

                        letter = line.Substring(curIndex+1, 1)[0]; // get char from single letter string
                        stackIndex = curIndex / 4;
                        while (stacks.Count < stackIndex+1)
                            stacks.Add(new List<char>(){});
                        stacks[stackIndex].Insert(0, letter);
                    }
                }
            }

            return new string(stacks.Select(stack => stack.Last()).ToArray());
        }
    }
}