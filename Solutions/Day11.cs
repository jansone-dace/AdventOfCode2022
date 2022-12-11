using System.Text.RegularExpressions;

namespace Advent_of_Code_2022.Solutions
{
    public class Day11
    {
        private class Monkey
        {
            public List<int> Items { get; set; } = new List<int>();
            public string Operation { get; set; } = "";
            public int TestDivisibleBy { get; set; }
            public int TestTrueMonkey { get; set; }
            public int TestFalseMonkey { get; set; }
            public int InspectionCount { get; set; }
        }

        public static int Part1()
        {
            List<Monkey> monkeys = new List<Monkey>();
            int monkeyNumber = 0, newValue, val1, val2, active1, active2;
            string pattern, value;
            Match match;

            foreach (string line in System.IO.File.ReadLines(@"Inputs/day11.txt"))
            {  
                if (line.Contains("Monkey"))
                {
                    pattern = @"Monkey ([0-9]+):";
                    match = Regex.Match(line, pattern);
                    monkeyNumber = Int32.Parse(match.Groups[1].Value);

                    if (monkeys.Count <= monkeyNumber)
                        monkeys.Add(new Monkey());

                    continue;
                }

                if (line.Contains("Starting items"))
                {
                    pattern = @"Starting items: (.*)";
                    match = Regex.Match(line, pattern);
                    value = match.Groups[1].Value;
                    monkeys[monkeyNumber].Items = value.Split(',').Select(int.Parse).ToList();
                    continue;
                }

                if (line.Contains("Operation"))
                {
                    pattern = @"Operation: (.*)";
                    match = Regex.Match(line, pattern);
                    monkeys[monkeyNumber].Operation = match.Groups[1].Value;
                    continue;
                }

                if (line.Contains("Test:"))
                {
                    pattern = @"Test: divisible by ([0-9]+)";
                    match = Regex.Match(line, pattern);
                    monkeys[monkeyNumber].TestDivisibleBy = Int32.Parse(match.Groups[1].Value);
                    continue;
                }

                if (line.Contains("If true"))
                {
                    pattern = @"If true: throw to monkey ([0-9]+)";
                    match = Regex.Match(line, pattern);
                    monkeys[monkeyNumber].TestTrueMonkey = Int32.Parse(match.Groups[1].Value);
                    continue;
                }

                if (line.Contains("If false"))
                {
                    pattern = @"If false: throw to monkey ([0-9]+)";
                    match = Regex.Match(line, pattern);
                    monkeys[monkeyNumber].TestFalseMonkey = Int32.Parse(match.Groups[1].Value);
                    continue;
                }
            }

            for (int round = 0; round < 20; round++)
            {
                foreach (var monkey in monkeys)
                {
                    foreach (var item in monkey.Items)
                    {
                        pattern = @"new = ([a-z0-9]+) ([/+/*]) ([a-z0-9]+)";
                        match = Regex.Match(monkey.Operation, pattern);
                        val1 = match.Groups[1].Value == "old" ? item : Int32.Parse(match.Groups[1].Value);
                        val2 = match.Groups[3].Value == "old" ? item : Int32.Parse(match.Groups[3].Value);
                        newValue = match.Groups[2].Value switch
                        {
                            "*" => val1 * val2,
                            "+" => val1 + val2,
                            _ => item
                        };

                        // Monkey gets bored with item
                        newValue = (int)Math.Floor((decimal)(newValue/3));

                        if (newValue % monkey.TestDivisibleBy == 0)
                            monkeys[monkey.TestTrueMonkey].Items.Add(newValue);
                        else
                            monkeys[monkey.TestFalseMonkey].Items.Add(newValue);

                        monkey.InspectionCount++;
                    }

                    monkey.Items.Clear();
                }
            }

            // Find 2 most active monkeys
            active1 = active2 = 0;
            foreach (var monkey in monkeys)
            {
                if (monkey.InspectionCount > active1)
                {
                    active2 = active1;
                    active1 = monkey.InspectionCount;
                }
                else if (monkey.InspectionCount > active2)
                    active2 = monkey.InspectionCount;
            }

            return active1 * active2;
        }
    }
}