namespace E_commerce.Models
{
    public class Subcategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Category category { get; set; }
        public Subcategory subcategory { get; set; }
        public int parentId { get; set; }

        public List<Product> Products = new List<Product>();

    }
}
