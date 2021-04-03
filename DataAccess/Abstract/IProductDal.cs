using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    //productla ilgili veritabanında yapılacak islemler :ekle,sil,güncelle,filtrele,göster,listele vb....
    public interface IProductDal:IEntityRepository<Product>
    {
    }
}

//Code Refactoring
