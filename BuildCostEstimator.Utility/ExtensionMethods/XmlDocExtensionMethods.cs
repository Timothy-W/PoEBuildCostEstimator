using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BuildCostEstimator.Models;

namespace BuildCostEstimator.Utilities
{
    public static class XmlDocExtensionMethods
    { 
        public static void ValidatePobXmlDoc(this XDocument xmlXDoc)
        {
            
            //TODO Needs testing. What happens when a empty xmlDoc is passed
            if (xmlXDoc == null || xmlXDoc.Root == null)
            {
                throw new InvalidDataException("Decoded xml from pastebin url is empty");
            }

            StringBuilder sb = new StringBuilder();
            
            var root = xmlXDoc.Root;

            // Check for <PathOfBuilding tag> exists
            if (root.Name == "PathOfBuilding")
            {
                // check for build tag exists with required attributes
                var buildEle = root.Element("Build");
                
                if (buildEle != null)
                {
                    if (buildEle.Attribute("className") == null)
                    {
                        sb.Append(" <Build> tag attribute 'className' missing.");
                    }
                    
                    if (buildEle.Attribute("ascendClassName") == null)
                    {
                        sb.Append(" <Build> tag attribute 'ascendClassName' missing.");
                    }
                  
                } 
                else {
                    sb.Append(" <Build> tag missing.");
                }


                //check for Items tag
                var itemsEle = root.Element("Items");
                
                if (itemsEle != null)
                {
                    if (itemsEle.Element("Item") == null)
                    {
                        sb.Append(" <Items> tag has no item data.");
                    }

                    if (itemsEle.Element("ItemSet") == null)
                    {
                        sb.Append(" <Items> tag has no item set data.");
                    }
                }
                else
                {
                    sb.Append(" <Items> tag missing.");
                }

            }
            else
            {
                sb.Append(" <PathOfBuilding> root tag missing.");
            }

            if (sb.Length != 0)
            {
                throw new InvalidDataException("Invalid xml decoded from pastebin url." + sb);
            }

            
        }


    }
}

