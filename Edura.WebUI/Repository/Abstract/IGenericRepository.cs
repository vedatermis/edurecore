﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace Edura.WebUI.Repository.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity: class
    {
        TEntity Get(int id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Edit(TEntity entity);
        void Save();
    }
}