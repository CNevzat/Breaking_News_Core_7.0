using BreakingNews_Core7._0.Models.Entity;
using System.Linq.Expressions;

namespace BreakingNews_Core7._0.Models.Repository.Abstract
{
	public interface IRepository<T> where T : class
	{
		IEnumerable<T> GetList(string? includeProps = null);

		T Get(Expression<Func<T,bool>>filter, string? includeProps = null);

		void Add(T entity);

		void Remove(T entity);	

		void Update(T entity);
		void Save();
    }
}
