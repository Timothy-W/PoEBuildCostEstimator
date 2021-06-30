using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using BuildCostEstimator.BuildFileProcessor.Builders;
using BuildCostEstimator.BuildFileProcessor.Factories;
using BuildCostEstimator.Models;



namespace BuildCostEstimator.BuildFileProcessor
{
    

    public class XmlParser
    {

        private readonly XDocument _xmlXDoc;
        //private readonly XElement _itemsXElement;
        //private readonly XElement _buildInfoXElement;

        private readonly IFactory<Item> _itemFactory; // Find some way to remove dependecy on concrete implementation
        private readonly IFactory<ItemSet> _setFactory; // Find some way to remove dependecy on concrete implementation
        private readonly IFactory<Build> _buildFactory; // Find some way to remove dependecy on concrete implementation

        public XmlParser(XDocument xmlXDoc, IFactory<Item> itemFactory, IFactory<ItemSet> setFactory, IFactory<Build> buildFactory)
        {
            _xmlXDoc = xmlXDoc;
            //_buildInfoXElement =  _xmlXDoc.Element("PathOfBuilding").Element("Build"); //Change to be more dynamic
            //_itemsXElement = _xmlXDoc.Element("PathOfBuilding").Element("Items");                      //Change to be more dynamic
            _itemFactory = itemFactory;
            _setFactory = setFactory;
            _buildFactory = buildFactory;

            //TODO Add some check to make sure we have the right tags, throw exception if so.

        }

        public Item ParseItemElement(XElement itemElement){ 
            return _itemFactory.CreateObj(itemElement);
        }
        

        public Dictionary<int,Item> ParseItemElementsToList(){ 
            
            var _itemsXElement = _xmlXDoc.Element("PathOfBuilding").Element("Items");
            Dictionary<int,Item> dict = new Dictionary<int,Item>();

            foreach (var itemXEle in _itemsXElement.Elements("Item"))
            {
                Item item = ParseItemElement(itemXEle);
                dict[item.PobItemId] = item;
            }

            return dict;
        }


        public ItemSet ParseItemSetElement(XElement itemElement){ 
            return _setFactory.CreateObj(itemElement);
        }
        

        public List<ItemSet> ParseItemSetElementsToList(){ 

            var _itemSetElements = _xmlXDoc.Element("PathOfBuilding").Element("Items").Elements("ItemSet");
            List<ItemSet> list = new List<ItemSet>();

            foreach (var ele in _itemSetElements)
            {
                list.Add(ParseItemSetElement(ele));
            }

            return list;
        }

        public Build ParseBuildInfo(){ 

            var buildInfoXElement = _xmlXDoc.Element("PathOfBuilding").Element("Build");

            return _buildFactory.CreateObj(buildInfoXElement);

        }











        /// <summary>
        /// //////////////////////////////////////////////////////////////
        /// 
        /// 
        ///			OLD IMPLIMENTATION
        /// 
        /// 
        /// </summary>
        /// <returns></returns>



        //public Build ParseBuildInfo()
        //{
        //    var buildTag = _xmlXDoc.Element("PathOfBuilding").Element("Build");

        //    var className = buildTag.Attribute("className").Value;
        //    var ascendancy = buildTag.Attribute("ascendClassName").Value;

        //    return new Build() { Class = className, Ascendancy = ascendancy };

        //}

        //// Entry into process of parsing all items into sets
        //public async Task<IEnumerable<ItemSet>> ParseItemSetsAsync()
        //{
        //    var result = new List<ItemSet>();

        //    // Maps the id take from indivisual item such as..		
        //    // <Item id="12">
        //    //    Rarity: UNIQUE
        //    //
        //    //  and maps it to the actual Item object that has been created.
        //    var taskOne = MapPobItemIdToItemObj();

        //    var taskTwo = MapItemSetIdToItemSetName();

        //    // Gets the set id of the tag taken from <ItemSet useSecondWeaponSet="false" title="Budget Gear" id="2">
        //    //      and maps them to a list containing ids of items in the set.
        //    var taskThree = MapPobItemIdToItemSetXmlId();

        //    Task.WaitAll(taskOne, taskTwo, taskThree);	

        //    Dictionary<int, Item> pobItemIdToItemObjMapping = await taskOne; 
        //    Dictionary<int, string> itemSetIdToItemSetNameMapping = await taskTwo; //Correct
            
            
        //    Dictionary<int, int> itemSetIdToListOfPobItemIdMapping = await taskThree; // Seems correct
                


        //    foreach(var pair in pobItemIdToItemObjMapping){ 
                
        //        var pobItemId = pair.Key;
        //        var item = pair.Value;
                
        //        var xmlId = itemSetIdToListOfPobItemIdMapping[pobItemId];
        //        var itemSetTitle = itemSetIdToItemSetNameMapping[xmlId];
        //        var newItemSet = new ItemSet() { ItemSetTitle = itemSetTitle, ItemSetXmlId = xmlId };

        //        var newRelation = new ItemSetRelationship() { Item = item, ItemSet = newItemSet};

        //        item.itemSetRelationships.Add(newRelation);
        //        newItemSet.ItemSetRelationships.Add(newRelation);
                
        //        result.Add(newItemSet);
        //    }

        //    return result;
        //}
        //public async Task<List<Item>> ParseItemsFromXmlAsync() //TODO Need to refactor
        //{
        //    if (_xmlXDoc == null)
        //    {
        //        return new List<Item>();
        //    }

        //    //Grab all the <Item></Item> elements
        //    var itemElements = _xmlXDoc.Element("PathOfBuilding").Element("Items").Descendants("Item");


        //    // Convert them into a dictionary
        //    List<Dictionary<string, string>> processedItemXElements = new List<Dictionary<string, string>>();

        //    foreach (var xElement in itemElements)
        //    {
        //        processedItemXElements.Add(XElementToDictionary(xElement));
        //    }

        //    // We might be doign this often, can we make it a generic method?
        //    IEnumerable<Task<Item>> allTasks = processedItemXElements.Select(x => BuildItemFromDictionaryAsync(x));

        //    Item[] allResults = await Task.WhenAll(allTasks);

        //    return allResults.Select(x => x).ToList();
        //}

        ////Maybe this can be done in a generic way so we dont have to keep editing this when we add new properties
        //private async Task<Item> BuildItemFromDictionaryAsync(Dictionary<string, string> itemDict)
        //{

        //    //Process Name

        //    if (itemDict["Name"].Contains("Flask"))
        //    {
        //        itemDict["BaseType"] = "Flask";
        //    }

        //    // Process PoB Item ID
        //    int pobItemId = int.TryParse(itemDict["PobItemId"], out pobItemId) ? pobItemId : -1;

        //    //Process Item Level
        //    int? itemLevel = null;
        //    if (itemDict["ItemLevel"] != null)
        //    {
        //        int itemLevelOut;
        //        string ItemLevel = itemDict["ItemLevel"].Split(" ").ElementAt(2);

        //        if (int.TryParse(ItemLevel, out itemLevelOut))
        //        {
        //            itemLevel = itemLevelOut;
        //        }

        //    }

        //    // Process Level Requirement
        //    int levelReq = 0;
        //    if (itemDict["LevelReq"] != null)
        //    {
        //        string LevelReq = itemDict["LevelReq"].Split(" ").ElementAt(1);
        //        levelReq = int.TryParse(LevelReq, out levelReq) ? levelReq : 0;
        //    }

        //    var itemBuilder = new ItemBuilder();
        //    Item newitem = itemBuilder
        //        .Called.Name(itemDict["Name"]).BaseType(itemDict["BaseType"])
        //        .WithMetaData.LevelReq(levelReq).ILevel(itemLevel).PoBItemId(pobItemId).Rarity("Rare")
        //        .WithCost.InChaos(-1);

        //    newitem.itemSetRelationships = new HashSet<ItemSetRelationship>();


        //    return newitem;

        //}

        //private async Task<Dictionary<int, string>> MapItemSetIdToItemSetName()
        //{
        //    var itemSetXElements = _xmlXDoc.Element("PathOfBuilding").Element("Items").Descendants("ItemSet");
        //    var result = new Dictionary<int, string>();

        //    foreach (var xEle in itemSetXElements){ 

        //        var id = int.Parse(xEle.Attribute("id").Value);

        //        result[id] = xEle.Attribute("title").Value;
        //    }

        //    return result;
        //}

        //private async Task<Dictionary<int, Item>> MapPobItemIdToItemObj()
        //{
        //    var itemList = await ParseItemsFromXmlAsync();
        //    var result = new Dictionary<int, Item>();

        //    foreach (var item in itemList)
        //    {

        //        result[item.PobItemId] = item;


        //    }

        //    return result;
        //}

        //private async Task<Dictionary<int, int>> MapPobItemIdToItemSetXmlId()
        //{
        //    var itemSetXElements = _xmlXDoc.Element("PathOfBuilding").Element("Items").Descendants("ItemSet");
        //    var result = new Dictionary<int, int>();


        //    foreach (var itemSet in itemSetXElements){ 
                
        //        var id = int.Parse(itemSet.Attribute("id").Value);

        //        var pobItemIdList = itemSet.Descendants("Slot")
        //            .Where( x => x.Attribute("itemId").Value != "0")
        //            .Select(x => int.Parse(x.Attribute("itemId").Value))
        //            .ToList();;

        //        foreach(var pobItemId in pobItemIdList){ 
                    
        //            result[pobItemId] = id;
                    
        //        }

        //    }

        //    return result;
        //}
        ///*
        // * TODO
        // * Currently we convert ALL XElements to a dictionary BEFORE we start to convert them to items.
        // * It might better to create a chain of async calls that go from an XElement -> Dictionary -> Item individually then group together at the end
        // *
        // */
        //private Dictionary<string, string> XElementToDictionary(XElement xElement) // TODO Need to switch to XElementToDictionaryAsync
        //{

        //    Dictionary<string, string> dict = new Dictionary<string, string>();


        //    // Move all this crap into its own method
        //    var elementStrings = xElement.Value.Trim();
        //    var eleSplitByLine = elementStrings.Split("\n").Select(x => x.Trim()).ToArray();

        //    dict.Add("PobItemId", xElement.Attribute("id").Value);
        //    dict.Add("Rarity", eleSplitByLine.ElementAt(0).Split(" ").ElementAt(1));
        //    dict.Add("Name", eleSplitByLine.ElementAt(1));
        //    dict.Add("BaseType", eleSplitByLine.ElementAt(2));
        //    dict.Add("ItemLevel", eleSplitByLine.FirstOrDefault(x => x.Contains("Item Level")));
        //    dict.Add("LevelReq", eleSplitByLine.FirstOrDefault(x => x.Contains("LevelReq")));

        //    return dict;
            
        //}

    }


}
