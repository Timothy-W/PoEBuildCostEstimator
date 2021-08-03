using BuildCostEstimator.BuildFileProcessor.Parsers.Interfaces;
using BuildCostEstimator.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BuildCostEstimator.BuildFileProcessor.Factories
{
    public class BuildFactory : Factory<Build>, IFactory<Build>
    {

        
        // What is using this item factory? The controller? Anther class used by the controller?
        public BuildFactory()
        {
            
            // Make more dynamic, maybe with reflection
            StringParsers = new List<IParser<string>>() { };
            IntParsers = new List<IParser<int>>() { };    
        }

        public override async Task<Build> CreateObjAsync(XElement buildElement)
        {
            return await Task.Run(() => CreateObj(buildElement));
        }


        public override Build CreateObj(XElement buildElement)
        {
            var newBuild = new Build()
            {
                Class = buildElement.Attribute("className").Value,
                Ascendancy = buildElement.Attribute("ascendClassName").Value
            };

            return newBuild;
        }

  
    }
}
