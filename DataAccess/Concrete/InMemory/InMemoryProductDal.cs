using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        private readonly List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product> {
                new() {ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15 },
                new() {ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3 },
                new() {ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2 },
                new() {ProductId=4,CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65 },
                new() {ProductId=5,CategoryId=2,ProductName="Fare",UnitPrice=85,UnitsInStock=1 }
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = null;
            //LINQ olmadan
            //foreach (var p in _products){ if (product.ProductId == p.ProductId)      productToDelete = p;}

            //LINQ ile
            //=>lambda: her p için p.productid gönderilen productid ile eşit midir? sorgusu
            productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            _products.Remove(product);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            //////////////////////////////_products: bütün productların bulundugu listemiz (memory)
            //////////////////////////////SingleOrDefault: LINQ metodumuz
            //////////////////////////////p: _productsun takma ismi (alias)
            //////////////////////////////p.ProductId: dizimizdeki elemanlar içinde ara
            //////////////////////////////product.ProductId: metoda gönderilen parametrenin productidsi
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            if (productToUpdate == null) return;
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            //koşula uyan elemanlarla yeni bir liste oluşturup döndürür
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}