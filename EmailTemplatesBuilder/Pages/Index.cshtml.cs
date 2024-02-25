using EmailTemplatesBuilder.Data;
using EmailTemplatesBuilder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmailTemplatesBuilder.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IItemRepository _itemRepository;
        private readonly IContentDescriptor _contentDescriptor;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(IItemRepository itemRespository,
            IContentDescriptor contentDescriptor,
            ILogger<IndexModel> logger)
        {
            _itemRepository = itemRespository;
            _contentDescriptor = contentDescriptor;
            _logger = logger;
        }

        public List<Item> Items { get; set; }

        [BindProperty]
        public IEnumerable<SelectListItem> Descriptors { get; set; }

        [BindProperty]
        public Item Item { get; set; }

        [BindProperty]
        public ContentDescriptor NewDescriptor { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Items = await _itemRepository.GetAllItems();
            Descriptors = await _contentDescriptor.GetAllDescriptors();
            return Page();
        }

        public async Task<IActionResult> OnPostCreateNewItemAsync()
        {
            if (ModelState.IsValid)
            {
                await _itemRepository.AddItem(Item);
                return RedirectToPage("Index");
            }

            Items = await _itemRepository.GetAllItems();
            return Page();
        }

        public async Task<IActionResult> OnGetDeleteAsync(Guid id)
        { 
            await _itemRepository.RemoveItem(id);
            return RedirectToPage("Index");
        }

        public async Task<IActionResult> OnPostCreateNewDescriptor()
        {
            await _contentDescriptor.AddDescriptor(NewDescriptor);
            return RedirectToPage("Index");
        }

        public async Task<IActionResult> OnGetDeleteDescriptorAsync(Guid id)
        {
            await _contentDescriptor.RemoveDescriptor(id);
            return RedirectToPage("Index");
        }

        public async Task<IActionResult> OnPostUpdateDescriptorAsync()
        {
            await _contentDescriptor.UpdateDescriptor(NewDescriptor);
            return RedirectToPage("Index");
        }
    }
}
