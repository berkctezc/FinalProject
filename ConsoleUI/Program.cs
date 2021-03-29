using System;
using Business.Concrete;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new InMemoryProductDal());

            foreach (var prod in productManager.GetAll())
            {
                Console.WriteLine(
                    "Ürün: "+prod.ProductName+
                    " | Ücret: "+prod.UnitPrice+
                    " | Stoktaki Ürün Sayısı: " + prod.UnitsInStock
                    );
            }

            Console.WriteLine("Tebrikler");
        }
    }
}
