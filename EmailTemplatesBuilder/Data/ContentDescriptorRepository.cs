using EmailTemplatesBuilder.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmailTemplatesBuilder.Data
{
    public class ContentDescriptorRepository : IContentDescriptor
    {
        private readonly EmailDBContext _emailDBContext;

        public ContentDescriptorRepository(EmailDBContext emailDBContext)
        {
            _emailDBContext = emailDBContext;
        }

        public async Task AddDescriptor(ContentDescriptor descriptor)
        {
            _emailDBContext.Descriptors.Add(descriptor);
            await _emailDBContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<SelectListItem>> GetAllDescriptors()
        {
            var descriptors =  await _emailDBContext.Descriptors.ToListAsync();

            return descriptors.Select(d => new SelectListItem(d.Description, d.Id.ToString()));
        }

        public async Task RemoveDescriptor(Guid descriptor_id)
        {
            _emailDBContext.Remove(_emailDBContext.Descriptors.FirstOrDefault(d => d.Id == descriptor_id));
            await _emailDBContext.SaveChangesAsync();
        }

        public async Task UpdateDescriptor(ContentDescriptor descriptor)
        {
            var descriptorToUpdate = _emailDBContext.Descriptors.FirstOrDefault(d => d.Id == descriptor.Id);
            if (descriptorToUpdate != null)
            {
                descriptorToUpdate.Description = descriptor.Description;
               await _emailDBContext.SaveChangesAsync();
            }

            throw new Exception("Couldn't update descriptor");
        }
    }
}
