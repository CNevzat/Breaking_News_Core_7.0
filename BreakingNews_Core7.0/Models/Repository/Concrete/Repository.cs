using BreakingNews_Core7._0.Models.Entity;
using BreakingNews_Core7._0.Models.Repository.Abstract;
using BreakingNews_Core7._0.Utility;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BreakingNews_Core7._0.Models.Repository.Concrete
{
	public class Repository<T> : IRepository<T> where T : class 
	{
		private readonly ApplicationDBContext _dbContext;
		internal DbSet<T> dbSet;

		public Repository(ApplicationDBContext dbContext)
		{
			_dbContext = dbContext;
			this.dbSet = dbContext.Set<T>();
			_dbContext.News.Include(k => k.Category).Include(k => k.CategoryID);
		}

		public void Add(T entity)
		{
			_dbContext.Set<T>().Add(entity);
			_dbContext.SaveChanges();
		}

		public T Get(Expression<Func<T, bool>> filter, string? includeProps = null)
		{
			IQueryable<T> sorgu = dbSet;
			sorgu = sorgu.Where(filter);

			if (!string.IsNullOrEmpty(includeProps))
			{
				foreach (var item in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					sorgu = sorgu.Include(item);
				}
			}
			return sorgu.FirstOrDefault();
		}

		public IEnumerable<T> GetList(string? includeProps = null)
		{
			IQueryable<T> sorgu = dbSet;
			if (!string.IsNullOrEmpty(includeProps))
			{
				foreach (var item in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					sorgu = sorgu.Include(item);
				}
			}
			return sorgu.ToList();
		}

		public void Remove(T entity)
		{
			dbSet.Remove(entity);
		}

		public void Save()
		{
			_dbContext.SaveChanges();	
		}

		public void Update(T entity)
		{
			dbSet.Update(entity);
		}
       
    }
}
