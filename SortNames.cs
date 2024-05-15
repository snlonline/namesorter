using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace namesorter
{
    public class SortNames
    {
        /// <summary>
        /// Gets the full path of a file given its name relative to the current directory.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <returns>The full path of the file.</returns>
        public static string GetRelativeFilePath(string fileName)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var relativePath = Path.Combine("..", "..", "..", fileName);
            return Path.GetFullPath(Path.Combine(currentDirectory, relativePath));
        }

        /// <summary>
        /// Reads all lines from a file.
        /// </summary>
        /// <param name="filePath">The path of the file to read.</param>
        /// <returns>An array containing all lines from the file.</returns>
        public static string[] ReadFileLines(string filePath)
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

        /// <summary>
        /// Writes an array of lines to a file.
        /// </summary>
        /// <param name="filePath">The path of the file to write to.</param>
        /// <param name="lines">The array of lines to write to the file.</param>
        public static void WriteFileLines(string filePath, string[] lines)
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

        /// <summary>
        /// Compares two names for sorting purposes.
        /// </summary>
        /// <param name="x">The first name to compare.</param>
        /// <param name="y">The second name to compare.</param>
        /// <returns>An integer that indicates the relative order of the names.</returns>
        public static int CompareNames(string x, string y)
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
}
