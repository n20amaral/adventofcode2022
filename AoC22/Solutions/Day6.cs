namespace Solutions;

public static class Day6
{
    public static (string, string) GetAnswers(string inputFilePath)
    {
        var data = File.ReadAllText(inputFilePath);

        var marker1 = CreateMarker(data, 4);
        var marker2 = CreateMarker(data, 14);

        return (marker1.Start.ToString(), marker2.Start.ToString());
    }

    private static Marker CreateMarker(string data, int markerLength)
    {
        var marker = new Marker(markerLength);

        for (int i = 0; i < data.Length; i++)
        {
            marker.Push(data[i]);

            if (marker.IsValid)
            {
                break;
            }
        }

        return marker;
    }

    private class Marker
    {
        private int _length;
        private Queue<char> _data = new Queue<char>();

        public Marker(int length)
        {
            _length = length;
            Start = 0;
        }

        public int Start { get; private set; }
        public bool IsValid => _data.Count == _length && _data.ToHashSet().Count == _length;

        internal void Push(char value)
        {
            if (_data.Count == _length)
            {
                _data.Dequeue();
            }

            _data.Enqueue(value);
            Start++;
        }
    }
}