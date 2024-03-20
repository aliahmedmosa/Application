using Domain.Entities;

namespace Persistence.Repositories
{
    public class UomRepository : GenericRepository<UOM>, IUomRepository
    {
        public UomRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}