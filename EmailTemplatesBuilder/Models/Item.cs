using System.ComponentModel.DataAnnotations;

namespace EmailTemplatesBuilder.Models
{
    public class Item
    {
        public Guid Id { get; set; }

        [Required]

        public string? Name { get; set; }

        [Required]
        public string? Text { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        [Required]
        public string? CreatedBy { get; set; }

        public string? UpdatedBy { get; set; }

        public ContentDescriptor? ContentDescriptor { get; set; }

        public Guid ContentDescriptorId { get; set; }
    }
}
