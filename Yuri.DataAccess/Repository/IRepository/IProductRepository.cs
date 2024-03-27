using Yuri.Models;

namespace Yuri.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {

        void Update(Product obj);


    }
}
