using EmailTemplatesBuilder.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailTemplatesBuilder.Data
{
    public class ItemRepository : IItemRepository
    {
        private readonly EmailDBContext _emailDBContext;
        public ItemRepository(EmailDBContext emailDBContext)
        {
            _emailDBContext = emailDBContext;
        }

        public async Task AddItem(Item item)
        {
            item.CreatedAt = DateTime.Now;
            _emailDBContext.Items.Add(item);
            await _emailDBContext.SaveChangesAsync();
        }

        public async Task RemoveItem(Guid item_id)
        {
            var itemToRemove = _emailDBContext.Items.FirstOrDefault(p => p.Id == item_id);
            if (itemToRemove != null)
            {
                _emailDBContext.Items.Remove(itemToRemove);
                await _emailDBContext.SaveChangesAsync();
            }
        }

        public async Task UpdateItem(Item item)
        {
            var itemToUpdate = _emailDBContext.Items.FirstOrDefault(p => p.Id == item.Id);
            if (itemToUpdate != null)
            {
                itemToUpdate.Text = item.Text;
                itemToUpdate.ContentDescriptorId = item.ContentDescriptorId;
                itemToUpdate.UpdatedAt = DateTime.Now;
                itemToUpdate.UpdatedBy = item.UpdatedBy;
                await _emailDBContext.SaveChangesAsync();
            }
        }

        public async Task<List<Item>> GetAllItems()
        {
            return await _emailDBContext.Items.Include(_ => _.ContentDescriptor).ToListAsync();
        }
        public Task<Item> GetItem(Guid item_Id)
        {
            return _emailDBContext.Items.FirstOrDefaultAsync(p => p.Id == item_Id);
        }
    }
}
