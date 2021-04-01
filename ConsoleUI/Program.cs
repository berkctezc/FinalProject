using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;


namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProductManager productManager = new ProductManager(new InMemoryProductDal());
            ProductManager productManager = new ProductManager(new EfProductDal());


            foreach (var prod in productManager.GetAll())
            {
                Console.WriteLine(
                    "Ürün: {0} | Ücret: {1} | Stoktaki Ürün Sayısı: {2}"
                    , prod.ProductName, prod.UnitPrice, prod.UnitsInStock);
            }

            Console.WriteLine("Tebrikler");
        }
    }
}
