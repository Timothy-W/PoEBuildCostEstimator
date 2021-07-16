using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using BuildCostEstimator.Models;
using BuildCostEstimator.Models.PoePricesModels;
using BuildCostEstimator.PriceCheck.Interfaces;
using BuildCostEstimator.Utilities.Extensions;
using Microsoft.Extensions.Caching.Memory;

namespace BuildCostEstimator.PriceCheck
{
    public class RarePriceChecker : IPriceChecker
    {
        protected IHttpClientFactory _clientFactory;
        protected IMemoryCache _memoryCache;

        

        public RarePriceChecker(IHttpClientFactory clientFactory, IMemoryCache memoryCache)
        {
            _clientFactory = clientFactory;
            _memoryCache = memoryCache;
        }

        public virtual async Task<Item> CheckPriceAsync(Item item)
        {
            return await CheckPriceFromPoePricesAsync(item);

            //await Task.Delay(100);
            //item.CostInChaos = 20.0;
            //return item;
        }

        public async Task<Item> CheckPriceFromPoePricesAsync(Item item)
        {
 
            item.CostInChaos = 0;
            StringBuilder sb = new StringBuilder();
            
            var itemRawText = item.RawText();
            var rawTextBytes = Encoding.UTF8.GetBytes(itemRawText);
            var base64Encoding = Convert.ToBase64String(rawTextBytes);
            
            PoePricesModel priceInfo;
            if (!_memoryCache.TryGetValue(base64Encoding, out priceInfo))
            {
                // Build request uri
                sb.Append("https://www.poeprices.info/api?");
                sb.Append($"l={StaticDetails.League}");
                sb.Append($"&i={base64Encoding}");
                sb.Append("&s=awakened-poe-trade");

                var client = _clientFactory.CreateClient();

                var request = new HttpRequestMessage(HttpMethod.Get, sb.ToString());

                HttpResponseMessage response = await client.SendAsync(request);
                
                if (response.IsSuccessStatusCode)
                {
                    priceInfo = await response.Content.ReadFromJsonAsync<PoePricesModel>(); //Will this be null if it fails or just throw exception?

                    // Todo Need error checking here. We can recieve and ok response but json data will say error
                    // Log Error info 

                    var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(1));

                    _memoryCache.Set(base64Encoding, priceInfo, cacheOptions);
                }
            }

            
            if (priceInfo != null && priceInfo.currency != null)
            {
                var results = Math.Round(new[] { priceInfo.max, priceInfo.min }.Average(), 2);
                item.CostInChaos = results;
            }
           
            return item;
            
        }

    }
}



/*
 
https://www.poeprices.info/api?l=Standard&i=SXRlbSBDbGFzczogQm9keSBBcm1vdXJzClJhcml0eTogUmFyZQpTa3VsbCBHdWFyZGlhbgpDcnlwdCBBcm1vdXIKLS0tLS0tLS0KRXZhc2lvbiBSYXRpbmc6IDMzOSAoYXVnbWVudGVkKQpFbmVyZ3kgU2hpZWxkOiA2NiAoYXVnbWVudGVkKQotLS0tLS0tLQpSZXF1aXJlbWVudHM6CkxldmVsOiA3MAotLS0tLS0tLQpTb2NrZXRzOiBHLVItQi1CLVItQiAKLS0tLS0tLS0KSXRlbSBMZXZlbDogNTcKLS0tLS0tLS0KeyBQcmVmaXggTW9kaWZpZXIgIk9wYWxlc2NlbnQiIChUaWVyOiA2KSDigJQgTWFuYSB9Cis0OSg0NS00OSkgdG8gbWF4aW11bSBNYW5hCnsgUHJlZml4IE1vZGlmaWVyICJTdGFsd2FydCIgKFRpZXI6IDEwKSDigJQgTGlmZSB9CiszOCgzMC0zOSkgdG8gbWF4aW11bSBMaWZlCnsgUHJlZml4IE1vZGlmaWVyICJNb3NxdWl0bydzIiAoVGllcjogNikg4oCUIERlZmVuY2VzIH0KMTAoNi0xMyklIGluY3JlYXNlZCBFdmFzaW9uIGFuZCBFbmVyZ3kgU2hpZWxkCjYoNi03KSUgaW5jcmVhc2VkIFN0dW4gYW5kIEJsb2NrIFJlY292ZXJ5CnsgU3VmZml4IE1vZGlmaWVyICJvZiB0aGUgU2FnZSIgKFRpZXI6IDQpIOKAlCBBdHRyaWJ1dGUgfQorMzYoMzMtMzcpIHRvIEludGVsbGlnZW5jZQp7IFN1ZmZpeCBNb2RpZmllciAib2YgdGhlIFlldGkiIChUaWVyOiA1KSDigJQgRWxlbWVudGFsLCBDb2xkLCBSZXNpc3RhbmNlIH0KKzI2KDI0LTI5KSUgdG8gQ29sZCBSZXNpc3RhbmNlCnsgU3VmZml4IE1vZGlmaWVyICJvZiBBZGFtYW50aXRlIFNraW4iIChUaWVyOiAyKSB9CjIzKDIzLTI1KSUgaW5jcmVhc2VkIFN0dW4gYW5kIEJsb2NrIFJlY292ZXJ5Ci0tLS0tLS0tCkNvcnJ1cHRlZA==&w=1




Item Class: Body Armours
Rarity: Rare
Skull Guardian
Crypt Armour
--------
Evasion Rating: 339 (augmented)
Energy Shield: 66 (augmented)
--------
Requirements:
Level: 70
--------
Sockets: G-R-B-B-R-B 
--------
Item Level: 57
--------
{ Prefix Modifier "Opalescent" (Tier: 6) — Mana }
+49(45-49) to maximum Mana
{ Prefix Modifier "Stalwart" (Tier: 10) — Life }
+38(30-39) to maximum Life
{ Prefix Modifier "Mosquito's" (Tier: 6) — Defences }
10(6-13)% increased Evasion and Energy Shield
6(6-7)% increased Stun and Block Recovery
{ Suffix Modifier "of the Sage" (Tier: 4) — Attribute }
+36(33-37) to Intelligence
{ Suffix Modifier "of the Yeti" (Tier: 5) — Elemental, Cold, Resistance }
+26(24-29)% to Cold Resistance
{ Suffix Modifier "of Adamantite Skin" (Tier: 2) }
23(23-25)% increased Stun and Block Recovery
--------
Corrupted




Item Class: Body Armours
Rarity: Rare
Chimeric Carapace
Sentinel Jacket
--------
Evasion Rating: 419 (augmented)
Energy Shield: 91 (augmented)
--------
Requirements:
Level: 59
Dex: 86
Int: 86
--------
Sockets: G-G-B-B B-R 
--------
Item Level: 67
--------
You take 50% reduced Extra Damage from Critical Strikes (implicit)
--------
+32 to Dexterity
+16 to Evasion Rating
21% increased Evasion and Energy Shield
+11 to maximum Energy Shield
+33 to maximum Mana
10% increased Stun and Block Recovery
--------
Corrupted












Query:


https://www.poeprices.info/api?myshops=&league=Ultimatum&auto=auto&myaccounts=&itemtext=Item+Class%3A+Body+Armours%0D%0ARarity%3A+Rare%0D%0AChimeric+Carapace%0D%0ASentinel+Jacket%0D%0A--------%0D%0AEvasion+Rating%3A+419+%28augmented%29%0D%0AEnergy+Shield%3A+91+%28augmented%29%0D%0A--------%0D%0ARequirements%3A%0D%0ALevel%3A+59%0D%0ADex%3A+86%0D%0AInt%3A+86%0D%0A--------%0D%0ASockets%3A+G-G-B-B+B-R+%0D%0A--------%0D%0AItem+Level%3A+67%0D%0A--------%0D%0AYou+take+50%25+reduced+Extra+Damage+from+Critical+Strikes+%28implicit%29%0D%0A--------%0D%0A%2B32+to+Dexterity%0D%0A%2B16+to+Evasion+Rating%0D%0A21%25+increased+Evasion+and+Energy+Shield%0D%0A%2B11+to+maximum+Energy+Shield%0D%0A%2B33+to+maximum+Mana%0D%0A10%25+increased+Stun+and+Block+Recovery%0D%0A--------%0D%0ACorrupted















 */
