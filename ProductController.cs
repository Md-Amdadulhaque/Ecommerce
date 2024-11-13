using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using E_commerce.Models;

namespace E_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {    
        List<Product> products = new List<Product>();
        List<Subcategory> subcategories = new List<Subcategory>();
        List<Category>  categories = new List<Category>();



        [HttpGet]
        public List<Product> GetProducts()
        {
            return products; 
        }
        [HttpGet("{id}/getWithID")]
        public List<Product> GetProducts(int id)
        {
            List<Product> nproducts = products.FindAll(c=>c.Id == id);
            return nproducts;
        }

        [HttpPost]
        public void Post(Product product) {
            products.Add(product);
            for(int i = 0; i < subcategories.Count(); i++)
            {
                if(subcategories[i].Id == product.parentId)
                {
                    subcategories[i].subcategory.Products.Add(product);
                    return;
                }
            }
            return;
        }

        [HttpDelete]
        public void Delete(int id,int subcategoryid) {

            for (int i = 0; i < subcategories.Count(); i++)
            {
                if (subcategories[i].Id == subcategoryid)
                {
                    var rem = subcategories[i].Products.Single(r => r.Id == id);
                    subcategories[i].Products.Remove(rem);
                    break;
                }
            }

            var itemToRemove = products.Single(r => r.Id == id);
            products.Remove(itemToRemove);


        }

    }
}
