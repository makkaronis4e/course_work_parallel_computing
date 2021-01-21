using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvertedIndex
{
    public class FoldersParser
    {
        private readonly ConcurrentQueue<string> _filesToParse;
        public FoldersParser(IEnumerable<string> folders)
        {
            _filesToParse = new ConcurrentQueue<string>(folders.SelectMany(Directory.GetFiles));
        }
    }
}
