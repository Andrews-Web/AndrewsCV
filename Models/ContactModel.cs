using System.ComponentModel.DataAnnotations;

namespace Website_CV.Models
{
    public class ContactModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Number { get; set; }
        public string Details { get; set; }
    }
}
