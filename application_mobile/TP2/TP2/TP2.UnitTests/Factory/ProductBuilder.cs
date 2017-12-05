using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using TP2.Core.Repositories.Entities;

namespace TP2.UnitTests.Factory
{
    public class ProductBuilder
    {
        private Faker<Product> _productFaker;

        public ProductBuilder()
        {
            InitializeProductBuilder();
        }

        private void InitializeProductBuilder()
        {
            _productFaker = new Faker<Product>(locale: "fr")
                            .RuleFor(x => x.Id, p => p.IndexVariable++)
                            .RuleFor(x => x.SerialNumber, p => p.Commerce.ProductName())
                            .RuleFor(x => x.Modal, p => p.Commerce.Product())
                            .RuleFor(x => x.DateProduction, p => p.Date.Past())
                            .RuleFor(x => x.Description, p => p.Commerce.ProductMaterial())
                            .RuleFor(x => x.RadioId, p => p.Finance.BitcoinAddress())
                            .RuleFor(x => x.IsInInventory, p =>false);
        }

        public Product GenerateProduct()
        {
            return _productFaker;
        }
        
        public List<Product> GenerateProducts(int number)
        {
            return _productFaker.Generate(number).ToList();
        }
        
    }
}