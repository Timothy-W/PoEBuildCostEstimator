using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BuildCostEstimator.Models.PoeNinjaModels
{

    public class ItemOverviewModel
    {
        [JsonPropertyName("lines")]

        public PoeNinjaItem[] Items { get; set; }
    }



   


 

    public class PoeNinjaItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int levelRequired { get; set; }
        public string baseType { get; set; }
        public int links { get; set; }
        public int itemClass { get; set; }
        public Implicitmodifier[] implicitModifiers { get; set; }
        public Explicitmodifier[] explicitModifiers { get; set; }
        public string flavourText { get; set; }
        public string itemType { get; set; }
        public float chaosValue { get; set; }
        public float exaltedValue { get; set; }
        public int count { get; set; }
        public string detailsId { get; set; }
        public int listingCount { get; set; }
    }
    
    public class Implicitmodifier
    {
        public string text { get; set; }
        public bool optional { get; set; }
    }

    public class Explicitmodifier
    {
        public string text { get; set; }
        public bool optional { get; set; }
    }
    

}
