using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using AppUI.Models;

namespace AppUI.Services
{
    public class StoreService
    {
        private readonly IStoreDatabaseSettings _settings;
        private readonly IMongoCollection<Product> _products;

        public StoreService(IStoreDatabaseSettings settings)
        {
            _settings = settings;

            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);

            _products = database.GetCollection<Product>(_settings.ProductsCollectionName);
        }

        public List<Product> Get() =>
            _products.Find(product => true).ToList();

        public Product Get(string productId) =>
            _products.Find<Product>(product => product.ProductId == productId).FirstOrDefault();

        public Product Create(Product product)
        {
            var p = _products.Find(x => x.SKU == product.SKU).FirstOrDefault();
            if (p == null)
            {
                _products.InsertOne(product);
                return product;
            }

            return null;
        }

        public void Update(string productId, Product productIn) =>
            _products.ReplaceOne(product => product.ProductId == productId, productIn);

        public void Remove(Product productIn) =>
            _products.DeleteOne(product => product.ProductId == productIn.ProductId);

        public void Remove(string productId) =>
            _products.DeleteOne(product => product.ProductId == productId);
    }
}
