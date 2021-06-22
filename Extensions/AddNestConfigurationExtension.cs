using System;
using Nest;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAdvert.SearchApi.Models;

namespace WebAdvert.SearchApi.Extensions
{
    public static class AddNestConfigurationExtension
    {
        public static void AddElasticSearch(this IServiceCollection services, IConfiguration config)
        {
            var elasticSearchurl = config.GetSection("ES").GetValue<string>("url");

            var connectionSettings = new ConnectionSettings(new Uri(elasticSearchurl))
                .DefaultIndex("adverts")
                //.DefaultTypeName("advert")
                .DefaultMappingFor<AdvertType>(advert => advert.IdProperty(p => p.Id));

                var client = new ElasticClient(connectionSettings);

                services.AddSingleton<IElasticClient>(client);
        }
    }
}