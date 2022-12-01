
Console.WriteLine($"Day 1 : {Day1()}");


static int Day1()
{
    var current = 0;
    var max = 0;
    foreach (string line in System.IO.File.ReadLines(@"inputs/1.txt"))
    {
        if (String.IsNullOrWhiteSpace(line))
        {
            max = max > current ? max : current;
            current = 0;
            continue;
        }
        var value = 0;
        Int32.TryParse(line, out value);
        current += value;
    }

    return max > current ? max : current;
}