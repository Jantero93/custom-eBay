using backend.Models;

namespace backend.Interfaces.Services
{
    public interface IItemService
    {
        public Task<Item> PostItem(Item item);
    }
}
