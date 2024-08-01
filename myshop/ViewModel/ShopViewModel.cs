using HexaShop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace HexaShop.ViewModel
{
    public class ShopViewModel
    {
        public List<Product> products { get; set; }
        public List<Category> categories { get; set; }
        public int CurrentPage { get; set; }
        public int pages { get; set; }
    }
}
