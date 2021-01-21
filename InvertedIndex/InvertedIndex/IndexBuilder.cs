using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace InvertedIndex
{
    public class IndexBuilder
    {
		private readonly ConcurrentDictionary<string, ConcurrentBag<string>> _index = new();
		public async Task ParseFile(string fileName)
		{
			string text = await File.ReadAllTextAsync(fileName);

			string[] words = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);

			foreach (string word in words)
			{
				if (!_index.ContainsKey(word))
				{
					_index[word] = new ConcurrentBag<string> { fileName };
				}
				else
				{
					if (!_index[word].Contains(fileName))
					{
						_index[word].Add(fileName);
					}
				}
			}
		}

		public ConcurrentDictionary<string, ConcurrentBag<string>> Build()
		{
			return _index;
		}
	}
}
