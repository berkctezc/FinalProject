using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{

    //Context: Db tabloları ile proje classlarını bağlamak icin yapılır
    class NorthwindContext : DbContext //EF'den geliyor
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Veritabanımıza bağlanıyoruz
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Tursted_Connection=true");
        }

        //DB'de hangi nesne burada hangi nesneye karşılık gelecek?
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
