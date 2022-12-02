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
            int choicePoints, roundScore, tournamentScore = 0;

            foreach (string line in System.IO.File.ReadLines(@"Inputs/day2.txt"))
            {
                opponent = GetRockPaperScissorsType(line.Split(' ')[0]);
                myChoice = GetRockPaperScissorsType(line.Split(' ')[1]);

                choicePoints = myChoice switch
                {
                    RockPaperScissors.Rock => 1,
                    RockPaperScissors.Paper => 2,
                    RockPaperScissors.Scissors => 3,
                    _ => 0
                };

                roundScore = choicePoints + DetermineResult(opponent, myChoice);
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
    }
}