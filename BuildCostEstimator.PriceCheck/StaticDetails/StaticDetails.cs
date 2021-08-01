using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BuildCostEstimator.PriceCheck
{
    public static class StaticDetails
    {
        public const string Normal = "Normal";
        public const string Magic = "Magic";
        public const string Rare = "Rare";
        public const string Unique = "Unique";

        public const string League = "Expedition";
        //public const string League = "Standard";

        // Poe Ninja url
        public const string PoeNinjaUrl = "https://poe.ninja/api/data/itemoverview?";
        public static readonly TimeSpan PoeNinjaRefreshRate = new(6, 0, 0);

        // PoE Ninja unique item endpoints
        public const string EndpointUniqueJewel = "UniqueJewel";
        public const string EndpointUniqueFlask = "UniqueFlask";
        public const string EndpointUniqueWeapon = "UniqueWeapon";
        public const string EndpointUniqueArmour = "UniqueArmour";
        public const string EndpointUniqueAccessory = "UniqueAccessory";
    }
}
