﻿using E_commerce.Interface;
using MongoDB.Driver;

namespace E_commerce.Services
{
    public class DatabaseService<T>:IDatabaseService<T> where T : class
    {
      
        private readonly IMongoCollection<T> _collection;


        public DatabaseService(IMongoDbContext<T> context,string collectionName) {
            _collection = context.GetCollection<T>(collectionName);
        }


        public async Task<List<T>> GetAllAsync()
        {
            return await _collection.Find(_ =>true).ToListAsync();
        }

        public async Task<T> FindAsync(string id)
        {
            return await _collection.Find(Builders<T>.Filter.Eq("id", id)).FirstOrDefaultAsync();
        }

        public async Task AddAsync(T newData)
        {
            await _collection.InsertOneAsync(newData);
        }

        public async Task UpdateAsync(string id,T newData) {
            await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("id", id), newData);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("id",id));
        }
          




    }
}
