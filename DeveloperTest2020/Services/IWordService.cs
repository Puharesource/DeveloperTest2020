using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeveloperTest2020.Services
{
    public interface IWordService
    {
        Task<IEnumerable<string>> GetDistinctWords(string sentence);

        Task<IEnumerable<string>> GetWatchedWords(IEnumerable<string> words);

        Task<int> RecordWords(IEnumerable<string> words);
    }
}
