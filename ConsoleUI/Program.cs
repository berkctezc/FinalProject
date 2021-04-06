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
            //DTO: Data Transformation Object 

            ProductTest();
            //IoC
            //CategoryTest();
        
        }



        //Tests
        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            //ProductManager productManager = new ProductManager(new InMemoryProductDal());
            ProductManager productManager = new ProductManager(new EfProductDal());

            Console.WriteLine("-----GetAll-----");

            foreach (var prod in productManager.GetAll().Data)
            {
                Console.WriteLine(
                    "Ürün: {0} | Ücret: {1} | Stoktaki Ürün Sayısı: {2}"
                    , prod.ProductName, prod.UnitPrice, prod.UnitsInStock);
            }

            Console.WriteLine("-----GetAllByCategoryId-----");

            foreach (var prod in productManager.GetAllByCategoryId(2).Data)
            {
                Console.WriteLine(
                    "Ürün: {0} | Ücret: {1} | Stoktaki Ürün Sayısı: {2}"
                    , prod.ProductName, prod.UnitPrice, prod.UnitsInStock);
            }

            Console.WriteLine("-----GetByUnitPrice-----");

            foreach (var prod in productManager.GetByUnitPrice(50, 100).Data)
            {
                Console.WriteLine(
                    "Ürün: {0} | Ücret: {1} | Stoktaki Ürün Sayısı: {2}"
                    , prod.ProductName, prod.UnitPrice, prod.UnitsInStock);
            }

            Console.WriteLine("-----Details with DTO-----");

            foreach (var prod in productManager.GetProductDetails().Data)
            {
                Console.WriteLine(
                    "Ürün: {0} / {1}"
                    , prod.ProductName, prod.CategoryName);
            }

            Console.WriteLine("----Result Sonrası---");

            var result = productManager.GetProductDetails();

            if (result.Success == true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName+"/"+product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
