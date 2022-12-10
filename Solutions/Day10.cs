namespace Advent_of_Code_2022.Solutions
{
    public class Day10
    {
        /// <summary>
        /// Returns sum of signals strengths during the 20th, 60th, 100th, 140th, 180th, and 220th cycles
        /// </summary>
        /// <returns></returns>
        public static int Part1()
        {
            int x = 1, currentCycle = 0, addx, signalSum = 0;

            foreach (string line in System.IO.File.ReadLines(@"Inputs/day10.txt"))
            {  
                addx = 0;
                if (line == "noop")
                {
                    currentCycle++;
                    signalSum += checkSignalStrength(currentCycle, x);
                    continue;
                }

                addx = Int32.Parse(line.Split("addx ")[1]);
                currentCycle++;
                signalSum += checkSignalStrength(currentCycle, x);
                currentCycle++;
                signalSum += checkSignalStrength(currentCycle, x);
                x += addx;
            }

            return signalSum;
        }

        public static string Part2()
        {
            string result = "";
            int x = 1, currentCycle = 0, addx;

            foreach (string line in System.IO.File.ReadLines(@"Inputs/day10.txt"))
            {  
                addx = 0;
                if (line == "noop")
                {
                    result += draw(currentCycle, x);
                    currentCycle++;
                    continue;
                }

                addx = Int32.Parse(line.Split("addx ")[1]);
                result += draw(currentCycle, x);
                currentCycle++;
                result += draw(currentCycle, x);
                currentCycle++;
                x += addx;
            }

            return result;
        }

        private static int checkSignalStrength(int currentCycle, int x)
        {
            if (new[] {20,60,100,140,180,220}.Contains(currentCycle))
                return currentCycle * x;
            return 0;
        }

        private static string draw(int currentCycle, int x)
        {
            string result;
            int offset = currentCycle % 40;
            if (offset == x || offset == x-1 || offset == x+1)
                result = "#";
            else
                result = ".";
            
            if (offset == 0)
                result += "\n";

            return result;
        }
    }
}