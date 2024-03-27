using Yuri.Models;

namespace Yuri.DataAccess.Repository.IRepository
{
	public interface ICategoryRepository : IRepository<Category>
	{

		void Update(Category obj);


	}
}
