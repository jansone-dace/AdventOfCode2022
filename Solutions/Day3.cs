namespace Advent_of_Code_2022.Solutions
{
    public static class Day3
    {
        public static int Part1()
        {
            int itemCount, totalValue = 0;
            string firstCompartment, secondCompartment;
            char commonElement;

            foreach (string line in System.IO.File.ReadLines(@"Inputs/day3.txt"))
            {
                itemCount = line.Length / 2;
                firstCompartment = line.Substring(0, itemCount);
                secondCompartment = line.Substring(itemCount, itemCount);

                commonElement = ' ';
                foreach (var letter1 in firstCompartment)
                {
                    foreach (var letter2 in secondCompartment)
                    {
                        if (letter1 == letter2)
                        {
                            commonElement = letter1;
                            break;
                        }
                    }
                }

                totalValue += GetItemValue(commonElement);
            }

            return totalValue;
        }

        public static int Part2()
        {
            string line1 = "", line2 = "", line3 = "";
            List<char> commonLetters = new List<char>();
            int totalValue = 0;
            char commonElement = ' ';

            foreach (string line in System.IO.File.ReadLines(@"Inputs/day3.txt"))
            {
                if (string.IsNullOrEmpty(line1))
                    line1 = line;
                else if (string.IsNullOrEmpty(line2))
                    line2 = line;
                else
                {
                    line3 = line;

                    foreach (var letter1 in line1)
                    {
                        foreach (var letter2 in line2)
                        {
                            if (letter1 == letter2)
                                commonLetters.Add(letter1);
                        }
                    }
                    
                    foreach (var letter1 in commonLetters)
                    {
                        foreach (var letter2 in line3)
                        {
                            if (letter1 == letter2)
                            {
                                commonElement = letter1;
                                break;
                            }
                        }
                    }

                    totalValue += GetItemValue(commonElement);
                    line1 = line2 = line3 = "";
                    commonLetters.Clear();
                }
            }

            return totalValue;
        }

        private static int GetItemValue(char letter)
        {
            if (Char.IsLower(letter))
                return (int)letter - 96;
            return (int)letter - 38;
        }
    }
}