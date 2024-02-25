using EmailTemplatesBuilder.Data;
using EmailTemplatesBuilder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmailTemplatesBuilder.Pages
{
    public class EditItemModel : PageModel
    {
        private readonly IItemRepository _itemRepository;
        private readonly IContentDescriptor _contentDescriptor;


        public EditItemModel(IItemRepository itemRepository, IContentDescriptor contentDescriptor)
        {
            _itemRepository = itemRepository;
            _contentDescriptor = contentDescriptor;
        }

        [BindProperty]
        public Item Item { get; set; }


        [BindProperty]
        public IEnumerable<SelectListItem> Descriptors { get; set; }

        public async Task<IActionResult> OnGet(Guid item_id)
        {

            Descriptors = await _contentDescriptor.GetAllDescriptors();
            Item = await _itemRepository.GetItem(item_id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                await _itemRepository.UpdateItem(Item);
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
