using BuildCostEstimator.BuildFileProcessor.Builders;
using BuildCostEstimator.BuildFileProcessor.Parsers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BuildCostEstimator.BuildFileProcessor.Factories
{
    public interface IFactory<out T> where T : class
    {
        public T CreateObj(XElement itemElement);
    }

    public class Factory<T> : IFactory<T> where T : class, new() //Item obj
    {
        public Builder<T> objBuilder { get; set; }
        public IList<IParser<string>> stringParsers { get; set; }
        public IList<IParser<int>> intParsers { get; set; }

        public virtual T CreateObj(XElement itemElement)
        {
            return new T();
        }
    }
}
