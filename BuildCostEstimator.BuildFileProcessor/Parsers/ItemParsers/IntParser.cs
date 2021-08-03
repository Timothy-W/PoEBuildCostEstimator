using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BuildCostEstimator.BuildFileProcessor.Parsers.Interfaces;

namespace BuildCostEstimator.BuildFileProcessor.Parsers.ItemParsers
{
    public class IntParser : IParser<int>
    {
        public async Task<int> ParseAsync(XElement element)
        {
            return await Task.Run(() => Parse(element));
        }

        public virtual int Parse(XElement element)
        {
            return -1;
        }
    }
}
