using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Yuri.DataAccess.Data;
using Yuri.DataAccess.Repository.IRepository;

namespace Yuri.DataAccess.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{

		private readonly ApplicationDbContext _db;

		internal DbSet<T> dbSet;

		public Repository(ApplicationDbContext db)
		{
			_db = db;
			this.dbSet = _db.Set<T>();
		}


		public void Add(T entity)
		{
			dbSet.Add(entity);
		}


		// 같은 의미 //Category? categoryFromDb2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();
		public T Get(Expression<Func<T, bool>> filter)
		{
			IQueryable<T> query = dbSet;
			query = query.Where(filter);
			return query.FirstOrDefault();
		}

		public IEnumerable<T> GetAll()
		{
			IQueryable<T> query = dbSet;
			return query.ToList();
		}

		public void Remove(T entity)
		{
			dbSet.Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entity)
		{
			dbSet.RemoveRange(entity);
		}
	}
}
