using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence.Contracts
{
    public interface IItemRepository:IGenericRepository<Item>
    {
        //Special For Item
        Task<List<Item>> GetAllAsyncWithInclude();
        Task<bool> IsUomExisting(int itemId);
    }
}
