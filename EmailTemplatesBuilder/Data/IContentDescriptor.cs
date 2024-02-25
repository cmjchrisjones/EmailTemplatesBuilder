using EmailTemplatesBuilder.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmailTemplatesBuilder.Data
{
    public interface IContentDescriptor
    {
        public Task AddDescriptor(ContentDescriptor descriptor);

        public Task RemoveDescriptor(Guid descriptor_id);

        public Task UpdateDescriptor(ContentDescriptor descriptor);

        public Task<IEnumerable<SelectListItem>> GetAllDescriptors();
    }
}
