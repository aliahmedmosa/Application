using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ItemRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Item>> GetAllAsyncWithInclude()
        => await _dbContext.Items.AsNoTracking().Include(x => x.UOM).ToListAsync();

        public async Task<bool> IsUomExisting(int uomId)
        {
            var response = await _dbContext.UOMs.FindAsync(uomId);
            return response != null;
        }
    }
}
