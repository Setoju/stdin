using System;

namespace stdin
{
    class Program
    {
        static void Main(string[] args)
        {
            // dotnet build в папці
            // dotnet run -- -filter lorem --ignore-case < text.txt
            if (args.Length < 2 || args[0] != "-filter")
            {
                Console.WriteLine("Usage: -filter <word> [--ignore-case]");
                return;
            }

            string filterWord = args[1];
            bool ignoreCase = args.Length > 2 && args[2] == "--ignore-case";

            // Використання StreamReader для читання всього вхідного потоку
            using var reader = new StreamReader(Console.OpenStandardInput()); // openstandardinput відкриває стандартний вхідний потік
            string? input = reader.ReadToEnd();

            string[] lines = input.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None); //\r\n — стандартний кінець рядка для Windows. \n — стандартний кінець рядка для Unix / Linux.

            foreach (var line in lines)
            {
                if ((ignoreCase && line.IndexOf(filterWord, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (!ignoreCase && line.Contains(filterWord)))
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}