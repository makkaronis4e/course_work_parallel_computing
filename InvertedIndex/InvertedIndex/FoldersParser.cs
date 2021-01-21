using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace InvertedIndex
{
    public class FoldersParser
    {
        private readonly ConcurrentQueue<string> _filesToParse;
		private readonly IndexBuilder _builder = new();

		public FoldersParser(IEnumerable<string> folders)
        {
            _filesToParse = new ConcurrentQueue<string>(folders.SelectMany(Directory.GetFiles));
        }

		public async Task<ConcurrentDictionary<string, ConcurrentBag<string>>> ProcessFiles(int tasksNumber)
		{
			Console.WriteLine($"{_filesToParse.Count} files to process");
			var tasks = new List<Task>();
			for (var i = 0; i < tasksNumber; i++)
			{
				tasks.Add(ParseTask(i));
			}

			await Task.WhenAll(tasks);

			Console.WriteLine("All files processed");
			return _builder.Build();
		}

		private async Task ParseTask(int id)
		{
			while (!_filesToParse.IsEmpty)
			{
				_filesToParse.TryDequeue(out string fileToParse);
				Console.WriteLine($"TASK {id}: I took {fileToParse}");
				await _builder.ParseFile(fileToParse);
			}
			Console.WriteLine($"{id}: Finished");
		}
	}
}
