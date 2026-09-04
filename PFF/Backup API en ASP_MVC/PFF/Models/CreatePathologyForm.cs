using System.ComponentModel.DataAnnotations;

namespace PFF.App.Models
{
    public class CreatePathologyForm
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; } = default!;
    }
}
