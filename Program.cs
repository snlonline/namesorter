namespace namesorter;

class Program
{
    static void Main(string[] args)
    {
        string unsortedNamesFilePath = GetRelativeFilePath("unsorted-names-list.txt");
        string[] names = ReadFileLines(unsortedNamesFilePath);
        
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
}
