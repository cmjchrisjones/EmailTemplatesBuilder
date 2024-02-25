using EmailTemplatesBuilder.Data;
using EmailTemplatesBuilder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmailTemplatesBuilder.Pages
{
    public class BuilderModel : PageModel
    {
        private readonly IItemRepository _itemRepository;
        private readonly IEmailSender _emailSender;

        [BindProperty]
        public string? Content { get; set; }

        public BuilderModel(IItemRepository itemRepository, IEmailSender emailSender)
        {
            _itemRepository = itemRepository;
            _emailSender = emailSender;

        }

        public List<Item> Items { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Items = await _itemRepository.GetAllItems();
            return Page();
        }

        public async Task<IActionResult> OnPostSendEmailAsync()
        {
            //_emailSender.SendEmail(new Message(new List<string> { "test@test.com" }, "Testing 123", Content));

            var message = new Message
            {
                To = new List<MimeKit.MailboxAddress> { new MimeKit.MailboxAddress("test", "codemazetest@mailinator.com") },
                Subject = "Test email",
                Content = "This is the content from our email."
            };
            _emailSender.SendEmail(message);


            return Page();
        }
    }
}
