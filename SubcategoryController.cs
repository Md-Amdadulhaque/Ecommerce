using E_commerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoryController : ControllerBase
    {
        List<Subcategory> subcategories = new List<Subcategory>();
        List<Category> categories = new List<Category>();



        [HttpGet]
        public List<Subcategory> GetProducts()
        {
            return subcategories;
        }
        [HttpGet("{id}/getWithID")]
        public List<Product> GetProducts(int id)
        {   
            List<Product> products = new List<Product>();
            for (int i = 0; i < subcategories.Count; i++)
            {
                if (subcategories[i].Id == id) return subcategories[i].Products;

            }
            return products;
        }

        [HttpPost]
        public void Post(Subcategory subcategory)
        { 
            subcategories.Add(subcategory);
            subcategory.subcategory = subcategory;
            return;
        }

        [HttpDelete]
        public void Delete(int id, int categoryid)
        {

            for (int i = 0; i < categories.Count(); i++)
            {
                var ToRemove = categories[i].Subcategories.Single(r => r.Id == id);
                categories[i].Subcategories.Remove(ToRemove);
            }

            var itemToRemove = subcategories.Single(r => r.Id == id);
            subcategories.Remove(itemToRemove);


        }

    }
}
