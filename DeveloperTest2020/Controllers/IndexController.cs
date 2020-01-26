using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeveloperTest2020.Models.Request;
using DeveloperTest2020.Models.Response;
using DeveloperTest2020.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperTest2020.Controllers
{
    [ApiController]
    [Route("/")]
    public class IndexController : ControllerBase
    {        
        private readonly IWordService _wordService;

        public IndexController(IWordService wordService)
        {
            _wordService = wordService;
        }

        [HttpPost]
        public async Task<TextResponse> Post([FromBody] TextRequest textRequest)
        {
            var distinctWords = await _wordService.GetDistinctWords(textRequest.Text);
            var watchedWords = await _wordService.GetWatchedWords(distinctWords);
            var newWords  = await _wordService.RecordWords(distinctWords);

            return new TextResponse
            {
                DistinctUniqueWords = distinctWords.Count(),
                WatchlistWords = watchedWords,
                NewWords = newWords
            };
        }
    }
}
