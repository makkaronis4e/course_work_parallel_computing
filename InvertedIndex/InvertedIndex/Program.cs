using System;
using System.Collections.Concurrent;

namespace InvertedIndex
{
    class Program
    {
        private static int _numberOfTasks = 4;
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var foldersParser = new FoldersParser(new[]
            {
                "D:\\Univer\\parallel\\course\\1",
                "D:\\Univer\\parallel\\course\\2",
                "D:\\Univer\\parallel\\course\\3",
                "D:\\Univer\\parallel\\course\\4",
                "D:\\Univer\\parallel\\course\\5",
            });
            ConcurrentDictionary<string, ConcurrentBag<string>> index = await foldersParser.ProcessFiles(_numberOfTasks);

			while (true)
			{
				Console.WriteLine("Enter word to search for (type <exit> to exit):");
				string searchWord = Console.ReadLine();
				if (searchWord == "<exit>")
				{
					Console.WriteLine("Exiting");
					return;
				}

				if (index.ContainsKey(searchWord))
				{
					Console.WriteLine($"Word {searchWord} is used in following {index[searchWord].Count} files:");
					foreach (string file in index[searchWord])
					{
						Console.WriteLine(file);
					}
				}
				else
				{
					Console.WriteLine($"Word {searchWord} is not used in any file");
				}

				Console.Write("Press any key for another search...");
				Console.ReadLine();
				Console.Clear();
			}
		}
	}
}
