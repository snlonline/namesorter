namespace namesorter;

class Program
{
    static void Main(string[] args)
    {
        
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
}
