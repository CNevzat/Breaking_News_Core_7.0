using BreakingNews_Core7._0.Models.Entity;
using System.Linq.Expressions;

namespace BreakingNews_Core7._0.Models.Repository.Abstract
{
	public interface INewsRepository : IRepository<News>
	{
        // News entity'sine ait özel bir method eklenmek isterse buraya yazılır
        IEnumerable<News> getAllNewsByCategory(Expression<Func<News, bool>> filter, string? includeProps = null);
    }
}
