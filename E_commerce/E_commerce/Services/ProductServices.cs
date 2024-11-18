using E_commerce.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace E_commerce.Services;

public class ProductServices
{
    private readonly IMongoCollection<Product> _productCollection;

    
    public ProductServices(

        IOptions<ProductStoreDatabaseSetting> productStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            productStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            productStoreDatabaseSettings.Value.DatabaseName);

        _productCollection = mongoDatabase.GetCollection<Product>(
            productStoreDatabaseSettings.Value.E_commerceCollectionName1);
    }



    public async Task<List<Product>> GetAsync() =>
        await _productCollection.Find(_ => true).ToListAsync();

    public async Task<Product?> GetWithIdAsync(string id) =>
        await _productCollection.Find(b => b.Id == id).FirstOrDefaultAsync();


    public async Task CreateAsync(Product newProduct) =>
        await _productCollection.InsertOneAsync(newProduct);


    public async Task UpdateAsync(string id,Product product)
    {
        await _productCollection.ReplaceOneAsync(x  => x.Id == id, product);
    }


    public async Task RemoveAsync(string id) =>
       await _productCollection.DeleteOneAsync(x => x.Id == id);



}
