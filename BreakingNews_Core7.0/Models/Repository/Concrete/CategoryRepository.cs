using BreakingNews_Core7._0.Models.Entity;
using BreakingNews_Core7._0.Models.Repository.Abstract;
using BreakingNews_Core7._0.Utility;

namespace BreakingNews_Core7._0.Models.Repository.Concrete
{
	public class CategoryRepository : Repository<Category> , ICategoryRepository
	{
		private ApplicationDBContext _dbContext;

		public CategoryRepository(ApplicationDBContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}
	}
}
