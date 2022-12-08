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

        /// <summary>
        /// Returns position of first message marker (previous 14 characters are all different)
        /// </summary>
        /// <returns></returns>
        public static int Part2()
        {
            string characterStream = File.ReadAllText(@"Inputs/day6.txt");
            bool hasCommonLetter;
            
            for (int i = 13; i < characterStream.Length; i++)
            {
                hasCommonLetter = false;
                for (int m1 = i; m1 >= i-13; m1--)
                {
                    for (int m2 = m1-1; m2 >= i-13; m2--)
                    {
                        if (characterStream[m1] == characterStream[m2])
                        {
                            hasCommonLetter = true;
                            break;
                        }
                    }

                    if (hasCommonLetter)
                        break;
                }

                if (!hasCommonLetter)
                    return i+1;
            }

            return -1;
        }
    }
}