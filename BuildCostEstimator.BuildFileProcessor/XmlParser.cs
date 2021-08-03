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

        //private readonly ItemFactory _concreteItemFactory = new ItemFactory(); //for testing

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

        
        public async Task<Dictionary<int, Item>> ParseItemElementsToDictAsync()
        {
            var listOfItemXElements = _xmlXDoc.Element("PathOfBuilding").Element("Items").Elements("Item");

            List<Task<Item>> itemCreationTasks = listOfItemXElements.Select(element => _itemFactory.CreateObjAsync(element)).ToList();

            var results = await Task.WhenAll(itemCreationTasks);
            
            return results.ToDictionary(x => x.PobItemId);
        }

        
        public async Task<List<ItemSet>> ParseItemSetElementsToListAsync()
        {

            var itemSetElements = _xmlXDoc.Element("PathOfBuilding").Element("Items").Elements("ItemSet");

            List<Task<ItemSet>> itemSetCreationTasks =
                itemSetElements.Select(element => _setFactory.CreateObjAsync(element)).ToList();
            
            var results = await Task.WhenAll(itemSetCreationTasks);
            
           return results.ToList();
        }

        public async Task<Build> ParseBuildInfoAsync()
        {
            var buildInfoXElement = _xmlXDoc.Element("PathOfBuilding").Element("Build");

            return await _buildFactory.CreateObjAsync(buildInfoXElement);
        }










        public Dictionary<int, Item> ParseItemElementsToDict()
        {

            var _itemsXElement = _xmlXDoc.Element("PathOfBuilding").Element("Items");
            Dictionary<int, Item> dict = new Dictionary<int, Item>();

            foreach (var itemXEle in _itemsXElement.Elements("Item"))
            {
                Item item = ParseItemElement(itemXEle);
                dict[item.PobItemId] = item;
            }

            return dict;
        }


        public List<ItemSet> ParseItemSetElementsToList()
        {

            var itemSetElements = _xmlXDoc.Element("PathOfBuilding").Element("Items").Elements("ItemSet");
            List<ItemSet> list = new List<ItemSet>();

            foreach (var ele in itemSetElements)
            {
                list.Add(ParseItemSetElement(ele));
            }

            return list;
        }


        public Build ParseBuildInfo()
        {

            var buildInfoXElement = _xmlXDoc.Element("PathOfBuilding").Element("Build");

            return _buildFactory.CreateObj(buildInfoXElement);

        }


        private Item ParseItemElement(XElement itemElement)
        {
            return _itemFactory.CreateObj(itemElement);
        }


        private ItemSet ParseItemSetElement(XElement itemElement)
        {
            return _setFactory.CreateObj(itemElement);
        }




    }


}
