using System.ComponentModel.DataAnnotations;

namespace HexaShop.Models
{
    public class Category
    {

      
        public int Id { get; set; }
        [Required]
       
        public string Name { get; set; }
        
    }
}
