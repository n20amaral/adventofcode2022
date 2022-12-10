using System.Text;

namespace Solutions;

public static class Day10
{
    public static (string, string) GetAnswers(string inputFilePath)
    {
        var signalsStrength = new List<int>();
        var counter = 1;
        var x = 1;
        var nextSignalUpgrade = 20;
        var crt = new char[240];

        foreach (var line in File.ReadAllLines(inputFilePath))
        {
            if (line == "noop")
            {
                PrintCrt(ref crt, counter, x);
                UpdateSignalStrength(ref counter, ref nextSignalUpgrade, x, signalsStrength);
                continue;
            }

            var addxValue = int.Parse(line.Split(' ')[1]);

            PrintCrt(ref crt, counter, x);
            UpdateSignalStrength(ref counter, ref nextSignalUpgrade, x, signalsStrength);
            PrintCrt(ref crt, counter, x);
            x += addxValue;
            UpdateSignalStrength(ref counter, ref nextSignalUpgrade, x, signalsStrength);
        }

        var crtLines = crt.Chunk(40).Select(x => new String(x));
        var strBuilder = new StringBuilder();
        strBuilder.AppendLine();
        foreach (var line in crtLines)
        {
            strBuilder.AppendLine(line);
        }

        return (signalsStrength.Sum().ToString(), strBuilder.ToString().TrimEnd());
    }

    private static void UpdateSignalStrength(ref int counter, ref int nextSignalUpgrade, int x, IList<int> signalsStrength)
    {
        counter++;
        if (counter != nextSignalUpgrade || counter > 220)
        {
            return;
        }

        nextSignalUpgrade += 40;
        signalsStrength.Add(counter * x);
    }

    private static void PrintCrt(ref char[] crt, int counter, int x)
    {
        var index = counter - 1;

        if (index % 40 == x - 1 || index % 40 == x || index % 40 == x + 1)
        {
            crt[index] = '#';
        }
        else
        {
            crt[index] = '.';
        }
    }
}