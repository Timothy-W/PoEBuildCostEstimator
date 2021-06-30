using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using BuildCostEstimator.Models;
using BuildCostEstimator.Models.PoePricesModels;
using BuildCostEstimator.PriceCheck.Interfaces;
using BuildCostEstimator.Utilities;
using Microsoft.Extensions.Caching.Memory;

namespace BuildCostEstimator.PriceCheck
{
    public class PriceChecker : IPriceChecker
    {
        protected IHttpClientFactory _clientFactory;
        protected IMemoryCache _memoryCache;

        

        public PriceChecker(IHttpClientFactory clientFactory, IMemoryCache memoryCache)
        {
            _clientFactory = clientFactory;
            _memoryCache = memoryCache;
        }

        public virtual async Task<Item> CheckPriceAsync(Item item)
        {
            await Task.Delay(100);
            item.CostInChaos = 2.0;
            return item;
        }


    }
}

