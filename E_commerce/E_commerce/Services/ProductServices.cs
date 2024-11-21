﻿using E_commerce.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using E_commerce.Interface;
namespace E_commerce.Services;

public class ProductServices:IProductService
{
    private readonly DatabaseService<Product> _databaseService;

    public ProductServices(DatabaseService<Product> databaseService)
    {
        _databaseService = databaseService;
    }



    public async Task<List<Product>> GetAsync()
    {
        var products = await _databaseService.GetAllAsync();
        return products;
    }


    public async Task<Product?> GetWithIdAsync(string id)
    {
        var product = await _databaseService.FindAsync(id);
        return product;
    }

    public async Task CreateAsync(Product product)
    {
        await _databaseService.AddAsync(product);
    }



    public async Task UpdateAsync(string id,Product updatedProduct)
    {
        await _databaseService.UpdateAsync(id, updatedProduct);
    }

    public async Task RemoveAsync(string id)
    {
        await _databaseService.DeleteAsync(id);
    }






}
