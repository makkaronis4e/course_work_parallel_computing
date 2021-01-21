using System;
using System.Collections.Concurrent;

namespace InvertedIndex
{
    class Program
    {
        private static int _numberOfTasks = 4;
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var FoldersParser = new FoldersParser(new[]
            {
                "D:\\Univer\\parallel\\course\\1",
                "D:\\Univer\\parallel\\course\\2",
                "D:\\Univer\\parallel\\course\\3",
                "D:\\Univer\\parallel\\course\\4",
                "D:\\Univer\\parallel\\course\\5",
            });
            ConcurrentDictionary<string, ConcurrentBag<string>> index = await FoldersParser.ProcessFiles(_numberOfTasks);
        }
    }
}
