namespace E_commerce.Models
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public List<Subcategory> Subcategories = new List<Subcategory>();

    }
}
