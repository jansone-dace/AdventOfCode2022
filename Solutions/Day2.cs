namespace Advent_of_Code_2022.Solutions
{
    public static class Day2
    {
        private enum RockPaperScissors
        {
            Rock,
            Paper,
            Scissors,
            None
        }

        /// <summary>
        /// Calculates total score of rock paper scissors tournament
        /// </summary>
        /// <returns></returns>
        public static int Part1()
        {
            RockPaperScissors opponent, myChoice;
            int roundScore, tournamentScore = 0;

            foreach (string line in System.IO.File.ReadLines(@"Inputs/day2.txt"))
            {
                opponent = GetRockPaperScissorsType(line.Split(' ')[0]);
                myChoice = GetRockPaperScissorsType(line.Split(' ')[1]);

                roundScore = CalculateChoicePoints(myChoice) + DetermineResult(opponent, myChoice);
                tournamentScore += roundScore;
            }

            return tournamentScore;
        }

        /// <summary>
        /// Calculates total score of rock paper scissors tournamnet
        /// </summary>
        /// <returns></returns>
        public static int Part2()
        {
            RockPaperScissors opponent, myChoice;
            int roundScore, tournamentScore = 0;

            foreach (string line in System.IO.File.ReadLines(@"Inputs/day2.txt"))
            {
                opponent = GetRockPaperScissorsType(line.Split(' ')[0]);
                myChoice = DetermineAction(opponent, line.Split(' ')[1]);

                roundScore = CalculateChoicePoints(myChoice) + DetermineResult(opponent, myChoice);
                tournamentScore += roundScore;
            }

            return tournamentScore;
        }

        private static RockPaperScissors GetRockPaperScissorsType(string typeLetter)
        {
            return typeLetter switch
            {
                "A" => RockPaperScissors.Rock,
                "B" => RockPaperScissors.Paper,
                "C" => RockPaperScissors.Scissors,
                "X" => RockPaperScissors.Rock,
                "Y" => RockPaperScissors.Paper,
                "Z" => RockPaperScissors.Scissors,
                _ => RockPaperScissors.None
            };
        }

        private static int CalculateChoicePoints(RockPaperScissors choice)
        {
            return choice switch
            {
                RockPaperScissors.Rock => 1,
                RockPaperScissors.Paper => 2,
                RockPaperScissors.Scissors => 3,
                _ => 0
            };
        }

        private static int DetermineResult(RockPaperScissors opponent, RockPaperScissors me)
        {
            if (opponent == me)
                return 3; // draw
            if (me == RockPaperScissors.Rock && opponent == RockPaperScissors.Scissors
            || me == RockPaperScissors.Scissors && opponent == RockPaperScissors.Paper
            || me == RockPaperScissors.Paper && opponent == RockPaperScissors.Rock)
                return 6; // me win

            return 0; // opponent wins
        }

        private static RockPaperScissors DetermineAction(RockPaperScissors opponent, string result)
        {
            // I need to loose
            if (result == "X")
            {
                return opponent switch
                {
                    RockPaperScissors.Rock => RockPaperScissors.Scissors,
                    RockPaperScissors.Paper => RockPaperScissors.Rock,
                    RockPaperScissors.Scissors => RockPaperScissors.Paper,
                    _ => RockPaperScissors.None
                };
            }
            
            // Needs to be draw
            if (result == "Y")
            {
                return opponent;
            }

            // I need to win
            if (result == "Z")
            {
                return opponent switch
                {
                    RockPaperScissors.Rock => RockPaperScissors.Paper,
                    RockPaperScissors.Paper => RockPaperScissors.Scissors,
                    RockPaperScissors.Scissors => RockPaperScissors.Rock,
                    _ => RockPaperScissors.None
                };
            }

            return RockPaperScissors.None;
        }
    }
}