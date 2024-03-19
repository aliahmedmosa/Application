using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UomRepository : GenericRepository<UOM>, IUomRepository
    {
        public UomRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
