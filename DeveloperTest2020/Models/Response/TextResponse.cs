using System.Collections.Generic;

namespace DeveloperTest2020.Models.Response
{
    public class TextResponse
    {
        public int DistinctUniqueWords { get; set; }
        public IEnumerable<string> WatchlistWords { get; set; }
        public int NewWords { get; set; }
    }
}
