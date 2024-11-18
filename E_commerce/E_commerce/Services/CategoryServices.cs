using E_commerce.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace E_commerce.Services
{
    public class CategoryServices
    {
        private readonly IMongoCollection<Category> _categoryCollection;


        public CategoryServices(

            IOptions<CategoryStoreDatabaseSetting> categoryStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                categoryStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                categoryStoreDatabaseSettings.Value.DatabaseName);

            _categoryCollection = mongoDatabase.GetCollection<Category>(
                categoryStoreDatabaseSettings.Value.E_commerceCollectionName2);

        }


        public async Task<List<Category>> GetAsync() =>
        await _categoryCollection.Find(_ => true).ToListAsync();

        public async Task<Category?> GetAsync(string id) =>
            await _categoryCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Category newCategory) =>
            await _categoryCollection.InsertOneAsync(newCategory);

        public async Task UpdateAsync(string id, Category updatedCategory) =>
            await _categoryCollection.ReplaceOneAsync(x => x.Id == id, updatedCategory);

        public async Task RemoveAsync(string id) =>
            await _categoryCollection.DeleteOneAsync(x => x.Id == id);
    }
}
