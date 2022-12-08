namespace Advent_of_Code_2022.Solutions
{
    public class Day8
    {
        /// <summary>
        /// Returns number of trees that are visible from outside
        /// </summary>
        /// <returns></returns>
        public static int Part1()
        {
            List<List<int>> input = new List<List<int>>();
            int counter = 0, visibleTreeCount = 0;
            int value;
            bool hasHigher;

            foreach (string line in System.IO.File.ReadLines(@"Inputs/day8.txt"))
            {  
                input.Add(new List<int>());
                foreach (var character in line)
                {
                    value = Int32.Parse(character.ToString());
                    input[counter].Add(value);
                }
                counter++;
            }

            for (int row = 0; row < input.Count; row++)
            {
                for (int column = 0; column < input[row].Count; column++)
                {
                    // Everything from outside is visible
                    if (column == 0 || row == 0 || column == input.Count-1 || row == input[column].Count-1)
                    {
                        visibleTreeCount++;
                        continue;
                    }

                    // Left
                    hasHigher = false;
                    for (int i = 0; i < column; i++)
                    {
                        if (input[row][i] >= input[row][column])
                        {
                            hasHigher = true;
                            break;
                        }
                    }
                    if (!hasHigher)
                    {
                        visibleTreeCount++;
                        continue;
                    }

                    // Right
                    hasHigher = false;
                    for (int i = column+1; i < input[row].Count;i++)
                    {
                        if (input[row][i] >= input[row][column])
                        {
                            hasHigher = true;
                            break;
                        }
                    }
                    if (!hasHigher)
                    {
                        visibleTreeCount++;
                        continue;
                    }

                    // Up
                    hasHigher = false;
                    for (int i = 0; i < row; i++)
                    {
                        if (input[i][column] >= input[row][column])
                        {
                            hasHigher = true;
                            break;
                        }
                    }
                    if (!hasHigher)
                    {
                        visibleTreeCount++;
                        continue;
                    }

                    // Down
                    hasHigher = false;
                    for (int i = row+1; i < input[row].Count; i++)
                    {
                        if (input[i][column] >= input[row][column])
                        {
                            hasHigher = true;
                            break;
                        }
                    }
                    if (!hasHigher)
                    {
                        visibleTreeCount++;
                        continue;
                    }
                }
            }

            return visibleTreeCount;
        }
    }
}