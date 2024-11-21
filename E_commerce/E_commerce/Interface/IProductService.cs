﻿using E_commerce.Models;

namespace E_commerce.Interface
{
    public interface IProductService
    {

        
        public Task<List<Product>> GetAsync();

        public Task<Product?> GetWithIdAsync(string id);

        public Task CreateAsync(Product newProduct);


        public Task UpdateAsync(string id, Product product);
        


        public Task RemoveAsync(string id);
        

    }
}
