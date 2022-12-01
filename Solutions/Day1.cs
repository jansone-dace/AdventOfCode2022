using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advent_of_Code_2022
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
    }
}