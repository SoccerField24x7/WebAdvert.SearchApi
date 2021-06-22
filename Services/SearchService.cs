using System.Linq;
using System.Threading.Tasks;
using Nest;
using WebAdvert.SearchApi.Models;

namespace WebAdvert.SearchApi.Services
{
    public class SearchService : ISearchService
    {
        private readonly IElasticClient _client;
        public SearchService(IElasticClient client)
        {
            _client = client;

        }
        public async Task<System.Collections.Generic.List<AdvertType>> Search(string keyword)
        {
            var searchResponse = await _client.SearchAsync<AdvertType>(search => search.Query(query => query.Term(field => field.Title, keyword.ToLower())));

            return searchResponse.Hits.Select(hit => hit.Source).ToList();
        }
    }
}