using HechoaMano.Domain.Entities;
using HechoaMano.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HechoaMano.Domain.Products
{
    public sealed class Product : AggregateRoot
    {
        public Product(ProductId id,string name, Family family, SubFamily subFamily, Size size, Region region, decimal sellPrice, decimal buyPrice)
        {
            Id = id;
            Name = name;
            Family = family;
            SubFamily = subFamily;
            Size = size;
            Region = region;
            SellPrice = sellPrice;
            BuyPrice = buyPrice;

            //Name = $"{family.Name} {subFamily.Name} {FamilyType?.Name ?? string.Empty}  {size.Name} {region.Name}";
        }

        private Product() { }

        public ProductId Id { get; private set; }
        public string Name { get; private set; }
        public FamilyType FamilyType { get; set; }
        public Family Family { get; private set; }
        public SubFamily SubFamily { get; private set; }
        public Size Size { get; private set; }  
        public Region Region { get; private set; }

        public decimal SellPrice { get; set; }
        public decimal BuyPrice { get; set; }
    }
}
