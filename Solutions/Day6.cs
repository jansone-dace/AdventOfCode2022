namespace Advent_of_Code_2022.Solutions
{
    public class Day6
    {
        /// <summary>
        /// Returns position of first marker (previous 4 characters are all different)
        /// </summary>
        /// <returns></returns>
        public static int Part1()
        {
            string characterStream = File.ReadAllText(@"Inputs/day6.txt");
            
            for (int i = 3; i < characterStream.Length; i++)
            {
                if (characterStream[i] != characterStream[i-1] && characterStream[i] != characterStream[i-2] && characterStream[i] != characterStream[i-3]
                && characterStream[i-1] != characterStream[i-2] && characterStream[i-1] != characterStream[i-3]
                && characterStream[i-2] != characterStream[i-3])
                    return i+1; // return +1 because positions need to start with 1, not 0
            }

            return -1;
        }
    }
}