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
                    "Ürün: "+prod.ProductName+
                    " | Ücret: "+prod.UnitPrice+
                    " | Stoktaki Ürün Sayısı: " + prod.UnitsInStock
                    );
            }

            Console.WriteLine("Tebrikler");
        }
    }
}
