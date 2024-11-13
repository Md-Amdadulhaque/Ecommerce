using E_commerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        List<Category> categories = new List<Category>();



        [HttpGet]
        public List<Category> GetProducts()
        {
            return categories;
        }
        [HttpGet("{id}/getWithID")]
        public List<Category> GetCategory(int id)
        {
            List<Category> category = new List<Category>();
            for (int i = 0; i < categories.Count; i++)
            {
                if (categories[i].id == id) category.Add(categories[i]);  

            }
            return category; ;
        }

        [HttpPost]
        public void Post(Category category)
        {
            categories.Add(category);
            return;
        }

        [HttpDelete]
        public void Delete(int categoryid)
        {

            var itemToRemove = categories.Single(r => r.id == categoryid);
            categories.Remove(itemToRemove);


        }
    }
}
