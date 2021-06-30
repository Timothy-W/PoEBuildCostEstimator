using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BuildCostEstimator.Models;
using BuildCostEstimator.Models.PoeNinjaModels;
using BuildCostEstimator.PriceCheck.Interfaces;
using BuildCostEstimator.Utilities;
using Microsoft.Extensions.Caching.Memory;


namespace BuildCostEstimator.PriceCheck
{
    class UniquePriceChecker : PriceChecker
    {
        // Poe Ninja unique item endpoints
        private HashSet<string> _uniqueItemTypeEndpoints = new()
        {
            StaticDetails.EndpointUniqueJewel,
            StaticDetails.EndpointUniqueFlask,
            StaticDetails.EndpointUniqueWeapon,
            StaticDetails.EndpointUniqueArmour,
            StaticDetails.EndpointUniqueAccessory
        };

        public UniquePriceChecker(IHttpClientFactory clientFactory, IMemoryCache memoryCache) : 
            base(clientFactory, memoryCache)
        {
        }

        public override async Task<Item> CheckPriceAsync(Item item)
        {
            //Set default value
            item.CostInChaos = 0;

            var itemCategory = item.PoeNinjaCategory();

            var poeNinjaEndpoint = _uniqueItemTypeEndpoints.Intersect(new HashSet<string>() {"Unique" + itemCategory})
                .FirstOrDefault();

            if (itemCategory != "Unknown" && poeNinjaEndpoint != null)
            {
                ItemOverviewModel itemOverview;
                if (!_memoryCache.TryGetValue(poeNinjaEndpoint, out itemOverview))
                {
                    var client = _clientFactory.CreateClient("PoeNinjaItemOverview");

                    var request = new HttpRequestMessage(HttpMethod.Get,
                        client.BaseAddress + $"league={StaticDetails.League}&type={poeNinjaEndpoint}");

                    HttpResponseMessage response = await client.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        itemOverview =
                            await response.Content
                                .ReadFromJsonAsync<
                                    ItemOverviewModel>(); //Will this be null if it fails or just throw exception?

                        var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(1));

                        _memoryCache.Set(poeNinjaEndpoint, itemOverview, cacheOptions);
                    }
                    else
                    {
                        itemOverview = null;
                    }
                }

                if (itemOverview != null)
                {
                    // Do stuff
                    var match = itemOverview.Items.ToList()
                        .FindAll(x => x.name == item.Name)
                        .OrderByDescending(x => x.links).FirstOrDefault();

                    item.CostInChaos = match != null ? Math.Round(match.chaosValue, 2) : 0;
                    
                }
            }

            return item;
        }
    }
}
