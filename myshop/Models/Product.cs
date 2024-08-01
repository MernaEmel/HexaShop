using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HexaShop.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "You must enter the name of the product")]

        public String Name { get; set; }
        [Required(ErrorMessage = "You must enter the price of the product")]
        

        public float Price { get; set; }

        [Required(ErrorMessage = "You must enter the quantity of the product")]
        public int Quantity { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        public string ImagePath { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? category { get; set; }
        public int ShopId { get; set; }
        public Shop? shop { get; set;}


    }
}
