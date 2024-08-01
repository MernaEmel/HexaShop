namespace HexaShop.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int  Quantity { get; set; }
        public int ProductId { get; set; }
        public Product product { get; set; }
        public string UserId { get; set; }
        public AppUser user { get; set; }

    }
}
