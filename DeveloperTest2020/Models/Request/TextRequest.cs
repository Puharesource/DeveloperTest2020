using System.ComponentModel.DataAnnotations;

namespace DeveloperTest2020.Models.Request
{
    public class TextRequest
    {
        [Display(Name = "Text")]
        [Required]
        public string Text { get; set; }
    }
}
