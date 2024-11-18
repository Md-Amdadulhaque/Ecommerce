using E_commerce.Models;
using E_commerce.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryServices _categoryServices;
        public CategoryController(CategoryServices categoryServices) {

            _categoryServices = categoryServices;

        }

        [HttpGet]
        public async Task<List<Category>> Get()=>
        await _categoryServices.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Category>> Get(string id)
        {
            var category = await _categoryServices.GetAsync(id);

            if (category is null)
            {
                return NotFound();
            }

            return category;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Category newCategory)
        {
            await _categoryServices.CreateAsync(newCategory);

            return CreatedAtAction(nameof(Get), new { id = newCategory.Id }, newCategory);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Category updatedCategory)
        {
            var category = await _categoryServices.GetAsync(id);

            if (category is null)
            {
                return NotFound();
            }

            updatedCategory.Id = category.Id;

            await _categoryServices.UpdateAsync(id, updatedCategory);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var category= await _categoryServices.GetAsync(id);

            if (category is null)
            {
                return NotFound();
            }

            await _categoryServices.RemoveAsync(id);

            return NoContent();
        }



    }
}