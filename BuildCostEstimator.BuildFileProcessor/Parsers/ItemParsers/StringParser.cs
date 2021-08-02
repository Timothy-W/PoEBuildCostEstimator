using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BuildCostEstimator.BuildFileProcessor.Parsers.Interfaces;

namespace BuildCostEstimator.BuildFileProcessor.Parsers.ItemParsers
{
    public class StringParser : IParser<string>
    {
        public async Task<string> ParseAsync(XElement element)
        {
            return await Task.Run(() => Parse(element));
        }

        public virtual string Parse(XElement element)
        {
            return string.Empty;
        }
    }
}
