namespace Advent_of_Code_2022.Solutions
{
    public static class Day4
    {
        public static int Part1()
        {
            int overlappingAreas = 0;
            string firstPair, secondPair;
            int firstPairFrom, firstPairTo, secondPairFrom, secondPairTo;

            foreach (string line in System.IO.File.ReadLines(@"Inputs/day4.txt"))
            {
                firstPair = line.Split(',')[0];
                secondPair = line.Split(',')[1];
                firstPairFrom = Int32.Parse(firstPair.Split('-')[0]);
                firstPairTo = Int32.Parse(firstPair.Split('-')[1]);
                secondPairFrom = Int32.Parse(secondPair.Split('-')[0]);
                secondPairTo = Int32.Parse(secondPair.Split('-')[1]);

                if ((firstPairFrom >= secondPairFrom && firstPairTo <= secondPairTo)
                || (secondPairFrom >= firstPairFrom && secondPairTo <= firstPairTo))
                    overlappingAreas++;
            }

            return overlappingAreas;
        }

        public static int Part2()
        {
            int overlappingAreas = 0;
            string firstPair, secondPair;
            int firstPairFrom, firstPairTo, secondPairFrom, secondPairTo;

            foreach (string line in System.IO.File.ReadLines(@"Inputs/day4.txt"))
            {
                firstPair = line.Split(',')[0];
                secondPair = line.Split(',')[1];
                firstPairFrom = Int32.Parse(firstPair.Split('-')[0]);
                firstPairTo = Int32.Parse(firstPair.Split('-')[1]);
                secondPairFrom = Int32.Parse(secondPair.Split('-')[0]);
                secondPairTo = Int32.Parse(secondPair.Split('-')[1]);

                if ((firstPairFrom <= secondPairFrom && firstPairTo >= secondPairFrom)
                || (secondPairFrom <= firstPairFrom && secondPairTo >= firstPairFrom))
                    overlappingAreas++;
            }

            return overlappingAreas;
        }
    }
}