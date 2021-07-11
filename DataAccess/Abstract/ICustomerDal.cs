using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    internal interface ICustomerDal : IEntityRepository<Customer>
    {
    }
}