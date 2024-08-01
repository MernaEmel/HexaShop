using Microsoft.AspNetCore.Identity; 
namespace HexaShop.Models
{
    public class AppUser:IdentityUser
    {
        public string? address { get; set; }

    }
}
