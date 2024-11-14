using ProductManagement.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ProductManagement.Services;

public class ProductService
{
    private readonly IMongoCollection<Product> _productCollection;

    public ProductService(
        IOptions<ProductStoreDatabaseSettings> productStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            productStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            bookStoreDatabaseSettings.Value.DatabaseName);

        _productCollection = mongoDatabase.GetCollection<Product>(
            productStoreDatabaseSettings.Value.ProductCollectionName);
    }

    public async Task<List<Product>> GetAsync() =>
        await _productCollection.Find(_ => true).ToListAsync();

    public async Task<Product?> GetAsync(string id) =>
        await _productCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Product nProduct) =>
        await _productCollection.InsertOneAsync(nProduct);

    public async Task UpdateAsync(string id, Product nProduct) =>
        await _productCollection.ReplaceOneAsync(x => x.Id == id, nProduct);

    public async Task RemoveAsync(string id) =>
        await _productCollection.DeleteOneAsync(x => x.Id == id);
}