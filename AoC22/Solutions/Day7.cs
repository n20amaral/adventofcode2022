namespace Solutions;

public static class Day7
{
    public static (string, string) GetAnswers(string inputFilePath)
    {
        List<Folder> allFolders = LoadFolderFromFile(inputFilePath);

        var part1 = allFolders.Where(f => f.Size < 100000).Sum(f => f.Size);

        const int DISK_SIZE = 70000000;
        const int UPDATE_SIZE = 30000000;
        var occupied = allFolders.First(f => f.Name == "/").Size;
        var requiredSpace = UPDATE_SIZE - (DISK_SIZE - occupied);

        var smallestFolder = allFolders
            .Where(f => f.Size > requiredSpace)
            .MinBy(f => f.Size);

        var part2 = smallestFolder?.Size ?? 0;

        return (part1.ToString(), part2.ToString());
    }

    private static List<Folder> LoadFolderFromFile(string filePath)
    {
        var folders = new List<Folder>();
        var currentFolder = new Folder("/");
        folders.Add(currentFolder);

        foreach (var line in System.IO.File.ReadLines(filePath))
        {
            var argv = line.Split(' ');

            if (argv[0] == "$")
            {
                if (argv[1] == "ls" || argv[2] == "/")
                {
                    continue;
                }

                if (argv[2] == "..")
                {
                    if (currentFolder.Parent == null)
                    {
                        throw new Exception("Folder without a parent");
                    }

                    currentFolder = currentFolder.Parent;
                    continue;
                }

                var newFolder = new Folder(argv[2]);
                newFolder.Parent = currentFolder;
                folders.Add(newFolder);

                currentFolder.AddSubFolder(newFolder);
                currentFolder = newFolder;
                continue;
            }

            if (argv[0] == "dir")
            {
                continue;
            }

            currentFolder.AddFile(new File(argv[1], int.Parse(argv[0])));
        }

        return folders;
    }

    private class Folder
    {
        private List<File> _files = new List<File>();
        private List<Folder> _subFolders = new List<Folder>();

        public Folder(string name)
        {
            Name = name;
        }

        public string Name { get; internal set; }
        public Folder? Parent { get; internal set; }
        public int Size => _files.Sum(f => f.Size) + _subFolders.Sum(f => f.Size);

        internal void AddFile(File file)
        {
            _files.Add(file);
        }

        internal void AddSubFolder(Folder folder)
        {
            _subFolders.Add(folder);
        }
    }

    private class File
    {
        public File(string name, int size)
        {
            Name = name;
            Size = size;
        }

        public string Name { get; }
        public int Size { get; }
    }
}