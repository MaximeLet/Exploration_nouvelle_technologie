using System.Collections.Generic;
using SQLite;
using TP2.Core.Repositories.Entities;
using System.Collections.ObjectModel;

namespace TP2.Core.Repositories
{
    public class SqLiteRepository<T> : IRepository<Product> where T : Product, new()
    {
        private readonly SQLiteConnection _database;

        public SqLiteRepository(SQLiteConnection sqLiteConnection)
        {
            _database = sqLiteConnection;
            _database.CreateTable<Product>(); 
        }
        public IEnumerable<Product> GetAll()
        {
            return _database.Table<Product>().ToList();
        }

        public Product GetById(int id)
        {
            return _database.Find<Product>(id);
        }

        public void Delete(Product entity)
        {
            _database.Delete(entity);
        }

        public void Add(Product entity)
        {
            _database.Insert(entity);
        }

        public void Update(Product entity)
        {
            _database.Update(entity);
        }

        public bool IsProductAlreadyInInventory(Product product)
        {
            var isExist = _database.Table<Product>().Where(V => V.SerialNumber == product.SerialNumber).ToList().Count;
            if (isExist == 0)
            {
                _database.Insert(product);
            }
            Product inventoryProduct = _database.Table<Product>().Where(V => V.SerialNumber == product.SerialNumber).First();
            return inventoryProduct.IsInInventory;
        }

        public ObservableCollection<Product> GetAllInventoryProduct()
        {
            ObservableCollection<Product> _inventoryProduct = new ObservableCollection<Product>();
            foreach (Product product in _database.Table<Product>())
            {
                if (product.IsInInventory) _inventoryProduct.Add(product);
            }
            return _inventoryProduct;
        }

        public void AddProductIntoInventory(Product product)
        {
            Product inventoryProduct = _database.Table<Product>().Where(V => V.SerialNumber == product.SerialNumber).First();
            inventoryProduct.IsInInventory = true;
            Update(inventoryProduct);

        }
    }
}