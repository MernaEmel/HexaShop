using System.ComponentModel.DataAnnotations;

namespace HexaShop.Models
{
    public class Contact
    {
       
            [Key]
            public int Id { get; set; }
            [Required(ErrorMessage = "Please enter your name")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Please enter your email")]
            [EmailAddress(ErrorMessage = "Invalid email address")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Please enter your message")]
            public string Message { get; set; }
        
    }
}
