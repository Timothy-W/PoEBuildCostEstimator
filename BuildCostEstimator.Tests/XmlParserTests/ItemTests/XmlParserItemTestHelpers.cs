using System.Xml.Linq;
using BuildCostEstimator.Models;

namespace BuildCostEstimator.Tests.XmlParser.ItemTests
{
    public class ItemXmlHelper
    {
        public ItemXmlHelper(Item item, XElement xml)
        {
            Item = item;
            Xml = xml;
        }

        public Item Item;
        public XElement Xml;
    }


 
}
