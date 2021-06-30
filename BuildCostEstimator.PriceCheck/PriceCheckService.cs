using BuildCostEstimator.Models;
using BuildCostEstimator.PriceCheck.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BuildCostEstimator.PriceCheck.IPriceCheck;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Http;

namespace BuildCostEstimator.PriceCheck
{

    //Maybe have different price checkers for Uniques, Jewels, Rares? If So then we cant use a static class
    public class PriceCheckService : IPriceCheckService
    {
        private IPriceChecker PriceChecker { get; }
        private IPriceChecker UniquePriceChecker { get; }
        private IPriceChecker RarePriceChecker { get; }

        

        
        public PriceCheckService(IHttpClientFactory clientFactory, IMemoryCache memoryCache)
        {
            PriceChecker = new PriceChecker(clientFactory, memoryCache);
            UniquePriceChecker = new UniquePriceChecker(clientFactory, memoryCache);
            RarePriceChecker = new RarePriceChecker(clientFactory, memoryCache);
            
        }


        public async Task<Item> SinglePriceCheckAsync(Item item)
        {
            if (item.Rarity == StaticDetails.Rare)
            {
                return await RarePriceChecker.CheckPriceAsync(item);
            }

            if (item.Rarity == StaticDetails.Unique)
            {
                return await UniquePriceChecker.CheckPriceAsync(item);
            }
            
            return await PriceChecker.CheckPriceAsync(item);
        }

        public async Task<IEnumerable<Item>> MultiplePriceCheckAsync(IEnumerable<Item> items)
        {
            return await SpawnMultiAsyncTasks(items, SinglePriceCheckAsync);
        }

        private async Task<IEnumerable<TIn>> SpawnMultiAsyncTasks<TIn>(IEnumerable<TIn> items, Func<TIn,Task<TIn>> function) // How can I constrain this properly?
        {
            IEnumerable<Task<TIn>> allTasks = items.Select(function);
           
            TIn[] allResults = await Task.WhenAll(allTasks);
            
            return allResults.Select(x => x).ToList();
        }


    }
    


    // Current Solution is poor, find another, simplier solution


    //Option 1: https://www.c-sharpcorner.com/article/switch-statement-a-code-smell/

    //Option 2: Some kind of factory




















}




