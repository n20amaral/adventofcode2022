namespace Solutions;

public static class Day9
{
    public static (string, string) GetAnswers(string inputFilePath)
    {
        var rope = new Rope();

        RunMovesFromFile(rope, inputFilePath);

        var part1 = rope.TailVisitedNodes.Count;
        var part2 = rope.KnotVisitedNodes.Count;

        return (part1.ToString(), part2.ToString());
    }

    private static void RunMovesFromFile(Rope rope, string filePath)
    {
        foreach (var line in File.ReadLines(filePath))
        {
            rope.Move(line);
        }
    }
}

internal class Rope
{
    public Rope(int knots = 9)
    {
        TailVisitedNodes.Add((0, 0));
        KnotVisitedNodes.Add((0, 0));
        for (int i = 0; i < knots; i++)
        {
            Knots.Add((0, 0));
        }
    }

    public ISet<(int, int)> TailVisitedNodes { get; internal set; } = new HashSet<(int, int)>();
    public ISet<(int, int)> KnotVisitedNodes { get; internal set; } = new HashSet<(int, int)>();
    public (int, int) Head { get; set; } = (0, 0);
    public (int, int) Tail { get; set; } = (0, 0);
    public IList<(int, int)> Knots = new List<(int, int)>();

    public void Move(string line)
    {
        var move = line.Split(' ');
        var length = int.Parse(move[1]);

        for (int i = 0; i < length; i++)
        {
            MoveHead(move[0]);
            MoveTail(move[0]);
            MoveKnots(move[0]);
        }
    }

    private void MoveHead(string direction)
    {
        var (x, y) = Head;

        switch (direction)
        {
            case "R":
                x++;
                break;
            case "L":
                x--;
                break;
            case "U":
                y++;
                break;
            case "D":
                y--;
                break;
        }

        Head = (x, y);
    }

    private void MoveTail(string direction)
    {
        Tail = FollowMove(direction, Head, Tail);
        TailVisitedNodes.Add(Tail);
    }

    private void MoveKnots(string direction)
    {
        var currentLeader = Head;
        var nextDirection = direction;

        for (int i = 0; i < Knots.Count; i++)
        {
            Knots[i] = FollowMove(nextDirection, currentLeader, Knots[i]);
            currentLeader = Knots[i];
        }

        KnotVisitedNodes.Add(Knots.Last());
    }

    private (int, int) FollowMove(string direction, (int, int) Leader, (int, int) Follower)
    {
        var (headX, headY) = Leader;
        var (tailX, tailY) = Follower;

        if (Math.Abs(headX - tailX) < 2 && Math.Abs(headY - tailY) < 2)
        {
            return (tailX, tailY);
        }

        switch (direction)
        {
            case "L":
            case "R":
                if (tailY != headY)
                {
                    tailY += headY > tailY ? 1 : -1;
                }

                if (tailX != headX)
                {
                    tailX += headX > tailX ? 1 : -1;
                }
                break;
            case "U":
            case "D":
                if (tailX != headX)
                {
                    tailX += headX > tailX ? 1 : -1;
                }

                if (tailY != headY)
                {
                    tailY += headY > tailY ? 1 : -1;
                }
                break;
        }

        return (tailX, tailY);
    }
}