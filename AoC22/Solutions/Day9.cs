namespace Solutions;

public static class Day9
{
    public static (string, string) GetAnswers(string inputFilePath)
    {
        var rope = new Rope();

        RunMovesFromFile(rope, inputFilePath);

        var part1 = rope.TailVisitedNodes.Count;

        return (part1.ToString(), string.Empty);
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
    public Rope()
    {
        TailVisitedNodes = new HashSet<(int, int)>();
        TailVisitedNodes.Add((0, 0));
    }

    public ISet<(int, int)> TailVisitedNodes { get; internal set; }
    public (int, int) Head { get; set; } = (0, 0);
    public (int, int) Tail { get; set; } = (0, 0);

    public void Move(string line)
    {
        var move = line.Split(' ');
        var length = int.Parse(move[1]);

        for (int i = 0; i < length; i++)
        {
            MoveHead(move[0]);
            MoveTail(move[0]);
            TailVisitedNodes.Add(Tail);
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
        var (headX, headY) = Head;
        var (tailX, tailY) = Tail;

        if (Math.Abs(headX - tailX) < 2 && Math.Abs(headY - tailY) < 2)
        {
            return;
        }

        switch (direction)
        {
            case "R":
                tailY += headY - tailY;
                tailX++;
                break;
            case "L":
                tailY += headY - tailY;
                tailX--;
                break;
            case "U":
                tailX += headX - tailX;
                tailY++;
                break;
            case "D":
                tailX += headX - tailX;
                tailY--;
                break;
        }

        Tail = (tailX, tailY);
    }
}