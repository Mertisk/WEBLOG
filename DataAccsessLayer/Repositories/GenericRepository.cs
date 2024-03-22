﻿using DataAccessLayer.Abstract;
using DataAccsessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccsessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            using (var c = new Context())
            {
                c.Remove(t);
                c.SaveChanges();
            }
        }

        public T GetByID(int id)
        {
            using (var c = new Context())
            {
                return c.Set<T>().Find(id);
            }
        }

        public List<T> GetListAll()
        {
            using (var c = new Context())
            {
                return c.Set<T>().ToList();
            }
        }

        public List<T> GetListAll(Expression<Func<T, bool>> filter)
        {
            using (var c = new Context())
            {
                return c.Set<T>().Where(filter).ToList();
            }
        }

        public void Insert(T t)
        {
            using (var c = new Context())
            {
                c.Add(t);
                c.SaveChanges();
            }
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            using (var c = new Context())
            {
                return c.Set<T>().Where(filter).ToList();
            }
        }

        public void Update(T t)
        {
            using (var c = new Context())
            {
                c.Update(t);
                c.SaveChanges();
            }
        }
    }
}
