using DeveloperTest2020.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperTest2020.Services
{
    public class WordService : IWordService
    {
        private readonly WordContext _wordContext;

        public WordService(WordContext wordContext)
        {
            _wordContext = wordContext;
        }

        public Task<IEnumerable<string>> GetDistinctWords(string sentence)
        {
            return Task.FromResult(sentence.Split().Distinct(StringComparer.InvariantCultureIgnoreCase));
        }

        public async Task<IEnumerable<string>> GetWatchedWords(IEnumerable<string> words)
        {
            return await _wordContext.WordWatchlists
                .Where(watchedWord => words.Contains(watchedWord.Word))
                .Select(watchedWord => watchedWord.Word)
                .ToListAsync();
        }

        public async Task<int> RecordWords(IEnumerable<string> words)
        {
            var alreadyKnownWords = await _wordContext.SeenWords.Where(seenWord => words.Contains(seenWord.Word)).Select(seenWord => seenWord.Word).ToListAsync();
            words = words.Where(word => !alreadyKnownWords.Contains(word));

            await _wordContext.SeenWords.AddRangeAsync(words.Select(word => new SeenWord { Word = word }));
            
            return await _wordContext.SaveChangesAsync();
        }
    }
}
