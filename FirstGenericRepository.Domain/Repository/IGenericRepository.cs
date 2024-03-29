﻿using System.Linq.Expressions;

namespace FirstGenericRepository.Domain.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        T? GetById(int id);

        T? GetByGuid(Guid id);
        IEnumerable<T> GetAll();

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);


    }
}
