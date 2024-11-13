namespace E_commerce.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int price { get; set; }
        public Subcategory subcategory { get; set; }
        public int parentId { get; set; }

    }
}
