using Yuri.DataAccess.Data;
using Yuri.DataAccess.Repository.IRepository;
using Yuri.Models;

namespace Yuri.DataAccess.Repository
{
	public class CategoryRepository : Repository<Category>, ICategoryRepository
	{

		private ApplicationDbContext _db;

		public CategoryRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}




		public void Update(Category obj)
		{
			_db.Categories.Update(obj);
		}
	}
}
