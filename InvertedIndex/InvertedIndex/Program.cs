using System;

namespace InvertedIndex
{
    class Program
    {
        static void Main(string[] args)
        {
            var FoldersParser = new FoldersParser(new[]
            {
                "..\\..\\..\\1",
                "..\\..\\..\\2",
                "..\\..\\..\\3",
                "..\\..\\..\\4",
                "..\\..\\..\\5",
            });
        }
    }
}
