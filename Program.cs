namespace namesorter;

class Program
{
    static void Main(string[] args)
    {
        string unsortedNamesFilePath = GetRelativeFilePath("unsorted-names-list.txt");
        string[] names = ReadFileLines(unsortedNamesFilePath);
        
        Array.Sort(names, CompareNames);
        
        foreach (string name in names)
        {
            Console.WriteLine(name);
        }

        string sortedNamesFilePath = GetRelativeFilePath("sorted-names-list.txt");
        WriteFileLines(sortedNamesFilePath, names);
    }
    static string GetRelativeFilePath(string fileName)
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string relativePath = Path.Combine("..", "..", "..", fileName);
        return Path.GetFullPath(Path.Combine(currentDirectory, relativePath));
    }
    static string[] ReadFileLines(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                return File.ReadAllLines(filePath);
            }

            Console.WriteLine($"File not found: {filePath}");
            return Array.Empty<string>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
            return Array.Empty<string>();
        }
    }
    static void WriteFileLines(string filePath, string[] lines)
    {
        try
        {
            File.WriteAllLines(filePath, lines);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while writing to the file: {ex.Message}");
        }
    }
    static int CompareNames(string x, string y)
    {
        string[] xParts = x.Split(' ');
        string[] yParts = y.Split(' ');

        int lastNameComparison = String.Compare(xParts.Last(), yParts.Last(), StringComparison.Ordinal);
        if (lastNameComparison != 0)
        {
            return lastNameComparison;
        }

        int minNamesCount = Math.Min(xParts.Length - 1, yParts.Length - 1);
        for (int i = 0; i < minNamesCount; i++)
        {
            int nameComparison = String.Compare(xParts[i], yParts[i], StringComparison.Ordinal);
            if (nameComparison != 0)
            {
                return nameComparison;
            }
        }

        return xParts.Length.CompareTo(yParts.Length);
    }
}
