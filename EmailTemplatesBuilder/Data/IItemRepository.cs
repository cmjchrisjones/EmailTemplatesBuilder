using EmailTemplatesBuilder.Models;

namespace EmailTemplatesBuilder.Data
{
    public interface IItemRepository
    {
        Task AddItem(Item item);

        Task RemoveItem(Guid item_id);

        Task UpdateItem(Item item);

        Task<List<Item>> GetAllItems();

        Task<Item> GetItem(Guid item_Id);
    }
}
