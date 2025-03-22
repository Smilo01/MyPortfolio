﻿using MyPortfolio.Models;
using System.Linq.Expressions;

namespace MyPortfolio.Data
{
           // Interfaces/IGenericRepository.cs
        public interface IBaseRepository<T> where T : class
        {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
    }
 
}
