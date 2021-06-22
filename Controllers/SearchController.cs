using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.Runtime.Internal.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAdvert.SearchApi.Models;
using WebAdvert.SearchApi.Services;

namespace WebAdvert.SearchApi.Controllers
{
    [Route("search/v1")]
    [ApiController]
    [Produces("application/json")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;
        private readonly ILogger<SearchController> _logger;

        public SearchController(ISearchService searchService, ILogger<SearchController> logger)
        {
            _logger = logger;
            _searchService = searchService;
        }

        [HttpGet]
        [Route("{keyword}")]
        public async Task<List<AdvertType>> Get(string keyword)
        {
            _logger.LogInformation("Search method was called");
            return await _searchService.Search(keyword);
        }
    }
}