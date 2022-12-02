namespace Advent_of_Code_2022.Solutions
{
    public static class Day1
    {
        /// <summary>
        /// Finds how many calories carries elf with most calories
        /// </summary>
        /// <returns></returns>
        public static int Part1()
        {
            int currentCalories = 0, maxCalories = 0;

            foreach (string line in System.IO.File.ReadLines(@"Inputs/day1.txt"))
            {  
                if (String.IsNullOrWhiteSpace(line))
                {
                    if (currentCalories > maxCalories)
                        maxCalories = currentCalories;
                    currentCalories = 0;
                } 
                else
                    currentCalories += Int32.Parse(line);
            }

            if (currentCalories > maxCalories)
                maxCalories = currentCalories;

            return maxCalories;
        }

        /// <summary>
        /// Find sum of total calories carried by top 3 elfs
        /// </summary>
        /// <returns></returns>
        public static int Part2()
        {
            int currentCalories = 0;
            int[] topCalories = new int[3];

            foreach (string line in System.IO.File.ReadLines(@"Inputs/day1.txt"))
            {  
                if (String.IsNullOrWhiteSpace(line))
                {
                    switchCalories(topCalories, currentCalories);
                    currentCalories = 0;
                } 
                else
                    currentCalories += Int32.Parse(line);
            }

            switchCalories(topCalories, currentCalories);

            return topCalories[0] + topCalories[1] + topCalories[2];
        }

        private static void switchCalories(int[] topCalories, int currentCalories)
        {
            if (currentCalories > topCalories[0])
            {
                topCalories[2] = topCalories[1];
                topCalories[1] = topCalories[0];
                topCalories[0] = currentCalories;
            }
            else if (currentCalories > topCalories[1])
            {
                topCalories[2] = topCalories[1];
                topCalories[1] = currentCalories;
            }
            else if (currentCalories > topCalories[2])
                topCalories[2] = currentCalories;
        }
    }
}