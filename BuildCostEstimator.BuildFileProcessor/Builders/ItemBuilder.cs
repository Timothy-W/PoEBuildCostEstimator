using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BuildCostEstimator.Models;

namespace BuildCostEstimator.BuildFileProcessor.Builders
{
    public abstract class Builder<T> where T : class
    {
        //protected abstract T newObj;
        protected abstract T obj { get; set; }
    }



    public class ItemBuilder : Builder<Item>
    {
        // Object to build        
        protected override Item obj { get; set; } = new Item();

        public ItemNameBuilder Called => new ItemNameBuilder(obj);
        public ItemMetaDataBuilder WithMetaData => new ItemMetaDataBuilder(obj);
        public ItemCostDataBuilder WithCost => new ItemCostDataBuilder(obj);

        






        /*
         Implicit conversion operator from ItemBuilder to Item
         Allows us to write the following code without compile error.
        
            var itemBuilder = new ItemBuilder();
            Item newitem = itemBuilder.Called...
        
         Alt solution can be another api call ".GetItem()" to get the Item 
            object internal to ItemBuilder.
        */
        public static implicit operator Item(ItemBuilder itemBuilder)
        {
            return itemBuilder.obj;
        }

    }

    public class ItemNameBuilder : ItemBuilder
    {
        public ItemNameBuilder(Item item)
        {
            this.obj = item;
        }

        public ItemNameBuilder Name(string name)
        {
            obj.Name = name;
            return this;
        }

        public ItemNameBuilder BaseType(string baseType)
        {
            obj.BaseType = baseType;
            return this;
        }
    }

    public class ItemMetaDataBuilder : ItemBuilder
    {
        public ItemMetaDataBuilder(Item item)
        {
            this.obj = item;
        }

        public ItemMetaDataBuilder PoBItemId(int pobItemId)
        {
            obj.PobItemId = pobItemId;
            return this;
        }

        public ItemMetaDataBuilder Rarity(string rarity)
        {
            obj.Rarity = rarity;
            return this;
        }

        public ItemMetaDataBuilder ILevel(int itemLevel) 
        {
            obj.ItemLevel = itemLevel;
            return this;
        }
        public ItemMetaDataBuilder LevelReq(int levelReq)
        {
            obj.LevelReq = levelReq;
            return this;
        }

    }

    public class ItemCostDataBuilder : ItemBuilder
    {
        public ItemCostDataBuilder(Item item)
        {
            this.obj = item;
        }

        public ItemCostDataBuilder InChaos(int cost)
        {
            obj.CostInChaos = cost;
            return this;
        }

    }
}
