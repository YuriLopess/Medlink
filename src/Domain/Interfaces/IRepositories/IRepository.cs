﻿namespace MedLink.Domain.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        public Task Add(T entity);
        public Task Update(T entity);
        public Task Delete(T entity);
        public Task<T?> Get(Guid entityId);
        public Task<List<T>> GetAll();
    }
}