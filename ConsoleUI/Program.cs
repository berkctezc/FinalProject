using System;
using System.Linq;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;


namespace ConsoleUI
{
    //SOLID
    //***Open Closed Principle: Yeni bir özellik ekliyorsan hiç bir özelliğe dokunmassın
    class Program
    {
        static void Main(string[] args)
        {
            //ProductTest();

            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach(var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            //ProductManager productManager = new ProductManager(new InMemoryProductDal());
            ProductManager productManager = new ProductManager(new EfProductDal());

            Console.WriteLine("-----GetAll-----");

            foreach (var prod in productManager.GetAll())
            {
                Console.WriteLine(
                    "Ürün: {0} | Ücret: {1} | Stoktaki Ürün Sayısı: {2}"
                    , prod.ProductName, prod.UnitPrice, prod.UnitsInStock);
            }

            Console.WriteLine("-----GetAllByCategoryId-----");

            foreach (var prod in productManager.GetAllByCategoryId(2))
            {
                Console.WriteLine(
                    "Ürün: {0} | Ücret: {1} | Stoktaki Ürün Sayısı: {2}"
                    , prod.ProductName, prod.UnitPrice, prod.UnitsInStock);
            }

            Console.WriteLine("-----GetByUnitPrice-----");

            foreach (var prod in productManager.GetByUnitPrice(50, 100))
            {
                Console.WriteLine(
                    "Ürün: {0} | Ücret: {1} | Stoktaki Ürün Sayısı: {2}"
                    , prod.ProductName, prod.UnitPrice, prod.UnitsInStock);
            }
        }
    }
}
