using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BuildCostEstimator.BuildFileProcessor.Parsers.Interfaces
{
    public interface IParser<T>
    {
        T Parse(XElement element);
    }

}
