using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //productla ilgili veritabanında yapılacak islemler :ekle,sil,güncelle,filtrele,göster,listele vb....
    public interface IProductDal
    {
        List<Product> GetAll();

        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);

        List<Product> GetAllByCategory(int categoryId);

    }
}
