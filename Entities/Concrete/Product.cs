using Core.Entities;

namespace Entities.Concrete
{
    //diger katmanlardan ulasılması icin public
    //default:internal=sadece bu proje erisebilir (entitites)
    public class Product : IEntity
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
    }
}