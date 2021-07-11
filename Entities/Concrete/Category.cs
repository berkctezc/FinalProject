using Core.Entities;

namespace Entities.Concrete
{
    //çıplak class kalmasın (interface implement etsin)
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}