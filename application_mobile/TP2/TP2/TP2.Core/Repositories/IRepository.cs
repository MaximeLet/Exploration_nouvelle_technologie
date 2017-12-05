using System.Collections.Generic;
using System.Collections.ObjectModel;
using TP2.Core.Repositories.Entities;

namespace TP2.Core.Repositories
{
    public interface IRepository<Product>
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        bool IsProductAlreadyInInventory(Product product);
        void AddProductIntoInventory(Product product);
        ObservableCollection<Product> GetAllInventoryProduct();
        void Delete(Product entity);
        void Add(Product entity);
        void Update(Product entity);
    }
}
