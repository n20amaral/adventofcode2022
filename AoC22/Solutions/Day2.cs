namespace Solutions;

public static class Day2
{
    public static (string, string) GetAnswers(string inputFilePath)
    {
        var games = LoadGames(inputFilePath);

        var scoreTotal = games.Sum(g => g.Score);
        var strategyScoreTotal = games.Sum(g => g.StrategyScore);

        return (scoreTotal.ToString(), strategyScoreTotal.ToString());
    }

    private static IEnumerable<Game> LoadGames(string filePath)
    {
        var games = new List<Game>();

        foreach (string line in System.IO.File.ReadLines(filePath))
        {
            games.Add(new Game(line.Split(' ')));
        }

        return games;
    }

    private class Game
    {
        public Game(string[] registry)
        {
            Opponent = new Play(registry[0]);
            Player = new Play(registry[1]);
            Strategy = GetStrategyPlay(registry[1], Opponent);
        }

        public Play Strategy { get; set; }
        public Play Opponent { get; set; }
        public Play Player { get; set; }
        public int Score => CalculateScore(Player, Opponent);
        public int StrategyScore => CalculateScore(Strategy, Opponent);

        private int CalculateScore(Play a, Play b)
        {
            var score = a.Score;

            if (a < b)
            {
                return score;
            }

            score += a > b ? 6 : 3;

            return score;
        }
        private Play GetStrategyPlay(string choice, Play opponent)
        {
            switch (choice)
            {
                case "X":
                    return Play.CreateWeakerPlay(opponent);
                case "Y":
                    return opponent;
                case "Z":
                    return Play.CreateStrongerPlay(opponent);
                default:
                    throw new ArgumentException("Unexpected Hand Value");
            }
        }
    }

    private class Play
    {
        private Hand _hand;

        public Play(string choice)
        {
            switch (choice)
            {
                case "A":
                case "X":
                    _hand = Hand.Rock;
                    break;
                case "B":
                case "Y":
                    _hand = Hand.Paper;
                    break;
                case "C":
                case "Z":
                    _hand = Hand.Scissors;
                    break;
                default:
                    throw new ArgumentException("Unexpected Hand Value");
            }
        }

        public int Score => _hand switch
        {
            Hand.Rock => 1,
            Hand.Paper => 2,
            Hand.Scissors => 3,
            _ => throw new ArgumentException("Unexpected Hand Value")
        };

        public static Play CreateWeakerPlay(Play play) => play._hand switch
        {
            Hand.Rock => new Play("C"),
            Hand.Paper => new Play("A"),
            Hand.Scissors => new Play("B"),
            _ => throw new ArgumentException("Unexpected Hand Value")
        };
        public static Play CreateStrongerPlay(Play play) => play._hand switch
        {
            Hand.Rock => new Play("B"),
            Hand.Paper => new Play("C"),
            Hand.Scissors => new Play("A"),
            _ => throw new ArgumentException("Unexpected Hand Value")
        };
        public static bool operator >(Play a, Play b)
        {
            if (a._hand == b._hand)
            {
                return false;
            }

            return a._hand switch
            {
                Hand.Rock => b._hand == Hand.Scissors,
                Hand.Paper => b._hand == Hand.Rock,
                Hand.Scissors => b._hand == Hand.Paper,
                _ => throw new ArgumentException("Unexpected Hand Value")
            };
        }
        public static bool operator <(Play a, Play b)
        {
            if (a._hand == b._hand)
            {
                return false;
            }

            return !(a > b);
        }
        public static bool operator >=(Play a, Play b)
        {
            if (a._hand == b._hand)
            {
                return true;
            }

            return a > b;
        }
        public static bool operator <=(Play a, Play b)
        {
            if (a._hand == b._hand)
            {
                return true;
            }

            return a < b;
        }

        private enum Hand
        {
            Rock,
            Paper,
            Scissors
        }
    }
}