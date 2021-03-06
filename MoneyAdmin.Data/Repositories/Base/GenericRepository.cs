﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace MoneyAdmin.Data.Repositories.Base
{
    abstract public class GenericRepository<T, TC>
        : IGenericRepository<T>
        where T : class
        where TC : DbContext, new()
    {
        private TC _entities = new TC();

        public TC Context
        {
            get { return _entities; }
            set { _entities = value; }
        }

        public T Find(int id)
        {
            return _entities.Set<T>().Find(id);
        }

        public virtual IQueryable<T> AsQueryable()
        {
            return _entities.Set<T>();
        }

        public virtual IEnumerable<T> AsEnumerable()
        {
            return _entities.Set<T>();
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> conditions)
        {
            return _entities.Set<T>().Where(conditions);

        }

        public virtual IGenericRepository<T> Add(T entity)
        {
            _entities.Set<T>().Add(entity);
            return this;
        }

        public virtual IGenericRepository<T> Update(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
            return this;
        }

        public virtual IGenericRepository<T> Delete(T entity)
        {
            _entities.Entry(entity).State = EntityState.Deleted;
            return this;
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }
    }
}
