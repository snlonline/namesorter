using System;
using System.IO;
using namesorter; // Make sure to include the namespace where SortNames class is defined

namespace namesorter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var unsortedNamesFilePath = SortNames.GetRelativeFilePath("unsorted-names-list.txt");
            var names = SortNames.ReadFileLines(unsortedNamesFilePath);

            Array.Sort(names, SortNames.CompareNames);

            foreach (var name in names) Console.WriteLine(name);

            var sortedNamesFilePath = SortNames.GetRelativeFilePath("sorted-names-list.txt");
            SortNames.WriteFileLines(sortedNamesFilePath, names);
        }
    }
}
