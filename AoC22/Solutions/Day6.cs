namespace Solutions;

public static class Day6
{
    public static (string, string) GetAnswers(string inputFilePath)
    {
        var data = File.ReadAllText(inputFilePath);

        var marker = new Marker(4);
        var part1 = 0;
        for (int i = 0; i < data.Length; i++)
        {
            marker.Push(data[i]);

            if (marker.IsValid)
            {
                part1 = i + 1;
                break;
            }
        }

        return (part1.ToString(), String.Empty);
    }

    private class Marker
    {
        private int _length;
        private Queue<char> _data = new Queue<char>();

        public Marker(int length)
        {
            _length = length;
        }

        public bool IsValid => _data.Count == _length && _data.ToHashSet().Count == _length;

        internal void Push(char value)
        {
            if (_data.Count == _length)
            {
                _data.Dequeue();
            }
            _data.Enqueue(value);
        }
    }
}