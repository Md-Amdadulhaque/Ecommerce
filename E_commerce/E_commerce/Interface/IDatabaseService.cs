﻿using MongoDB.Driver;

namespace E_commerce.Interface
{
    public interface IDatabaseService<T> where T : class
    {
        public Task<List<T>> GetAllAsync();

        public Task<T> FindAsync(string id);

        public Task AddAsync(T newData);


        public Task UpdateAsync(string id, T newData);

        public Task DeleteAsync(string id);

    }
}
