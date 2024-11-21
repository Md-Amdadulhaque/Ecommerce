using E_commerce.Interface;
using E_commerce.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace E_commerce.Services
{
    public class CategoryServices:ICategoryService
    {
        private  IDatabaseService<Category> _databaseService;

        //ublic CategoryServices()

        public CategoryServices(IDatabaseService<Category> databaseService)
        {
            _databaseService = databaseService;
        }

        //public IDatabaseService<Category> databaseService => _databaseService;


        public async Task<List<Category>> GetAsync()
        {
            var categories = await _databaseService.GetAllAsync();
            return categories;
        }


        public async Task<Category?> GetAsync(string id)
        {
            var category = await _databaseService.FindAsync(id);
            return category;
        }

        public async Task CreateAsync(Category category)
        {
            await _databaseService.AddAsync(category);
        }



        public async Task UpdateAsync(string id, Category updatedCategory) 
        {
              await _databaseService.UpdateAsync(id, updatedCategory);
        }

        public async Task RemoveAsync(string id)
        {
            await _databaseService.DeleteAsync(id);
        }
    }
}
