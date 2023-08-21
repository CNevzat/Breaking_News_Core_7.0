using BreakingNews_Core7._0.Models.Entity;
using BreakingNews_Core7._0.Models.Repository.Abstract;
using BreakingNews_Core7._0.Utility;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BreakingNews_Core7._0.Models.Repository.Concrete
{
	public class NewsRepository : Repository<News> , INewsRepository
	{
		private ApplicationDBContext _dbContext;

		public NewsRepository(ApplicationDBContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
            _dbContext.News.Include(k => k.Category).Include(k => k.CategoryID);
        }

        public IEnumerable<News> getAllNewsByCategory(Expression<Func<News, bool>> filter, string? includeProps = null)
        {
            IQueryable<News> sorgu = _dbContext.Set<News>();
            sorgu = sorgu.Where(filter);

            if (!string.IsNullOrEmpty(includeProps))
            {
                foreach (var item in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    sorgu = sorgu.Include(item);
                }
            }
            return sorgu.ToList();
        }
    }
}
