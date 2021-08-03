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
    public interface IFactory<T> where T : class
    {
        public T CreateObj(XElement itemElement);
        public Task<T> CreateObjAsync(XElement itemElement);
    }

    public abstract class Factory<T> : IFactory<T> where T : class, new() //Item obj
    {
        public Builder<T> ObjBuilder { get; set; }
        public IList<IParser<string>> StringParsers { get; set; }
        public IList<IParser<int>> IntParsers { get; set; }

        public abstract T CreateObj(XElement itemElement);

        public abstract Task<T> CreateObjAsync(XElement itemElement);
    
    }
}
