using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmailSenderWeb.Models
{
    public class EmailSendFormModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Recipient email address is invalid.")]
        [Display(Name = "Recipient")]
        public string Recipient { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Subject")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Email Subject must be between 5 and 50 characters.")]
        public string Subject { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Body")]
        [StringLength(5000, MinimumLength = 10, ErrorMessage = "Email Body must be between 10 and 5000 characters.")]
        public string Body { get; set; } = string.Empty; 
    }
}
