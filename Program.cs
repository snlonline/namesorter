namespace namesorter;

internal class Program
{
    private static void Main(string[] args)
    {
        var unsortedNamesFilePath = GetRelativeFilePath("unsorted-names-list.txt");
        var names = ReadFileLines(unsortedNamesFilePath);

        Array.Sort(names, CompareNames);

        foreach (var name in names) Console.WriteLine(name);

        var sortedNamesFilePath = GetRelativeFilePath("sorted-names-list.txt");
        WriteFileLines(sortedNamesFilePath, names);
    }

    private static string GetRelativeFilePath(string fileName)
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        var relativePath = Path.Combine("..", "..", "..", fileName);
        return Path.GetFullPath(Path.Combine(currentDirectory, relativePath));
    }

    private static string[] ReadFileLines(string filePath)
    {
        try
        {
            if (File.Exists(filePath)) return File.ReadAllLines(filePath);

            Console.WriteLine($"File not found: {filePath}");
            return Array.Empty<string>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
            return Array.Empty<string>();
        }
    }

    private static void WriteFileLines(string filePath, string[] lines)
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

    private static int CompareNames(string x, string y)
    {
        var xParts = x.Split(' ');
        var yParts = y.Split(' ');

        var lastNameComparison = string.Compare(xParts.Last(), yParts.Last(), StringComparison.Ordinal);
        if (lastNameComparison != 0) return lastNameComparison;

        var minNamesCount = Math.Min(xParts.Length - 1, yParts.Length - 1);
        for (var i = 0; i < minNamesCount; i++)
        {
            var nameComparison = string.Compare(xParts[i], yParts[i], StringComparison.Ordinal);
            if (nameComparison != 0) return nameComparison;
        }

        return xParts.Length.CompareTo(yParts.Length);
    }
}