using System;
using System.Collections;
using BuildCostEstimator.BuildFileProcessor.Builders;
using BuildCostEstimator.BuildFileProcessor.Parsers;
using BuildCostEstimator.BuildFileProcessor.Parsers.Interfaces;
using BuildCostEstimator.Models;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace BuildCostEstimator.BuildFileProcessor.Factories
{
    public class BuildFactory : Factory<Build> 
    {

        
        // What is using this item factory? The controller? Anther class used by the controller?
        public BuildFactory()
        {
            
            // Make more dynamic, maybe with reflection
            stringParsers = new List<IParser<string>>() { };
            intParsers = new List<IParser<int>>() { };    
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
