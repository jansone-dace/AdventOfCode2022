namespace Advent_of_Code_2022.Solutions
{
    public class Day13
    {
        public static int Part1()
        {
            string left = "", right = "";
            int pairIndex = 1;

            foreach (string line in System.IO.File.ReadLines(@"Inputs/day13.txt"))
            {  
                if (string.IsNullOrWhiteSpace(line))
                {
                    

                    left = "";
                    right = "";
                    pairIndex++;
                }
                else if (string.IsNullOrEmpty(left))
                    left = line;
                else
                    right = line;
            }
        }    
    }
}