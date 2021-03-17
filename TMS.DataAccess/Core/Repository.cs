using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace TMS.DataAccess.Core
{
    public class Repository : IRepository
    {
        DataContext context;

        public Repository(IDbFactory dbFactory)
        {
            context = dbFactory.GetDataContext;
        }


        public IQueryable<T> All<T>() where T : class
        {
            return context.Set<T>().AsQueryable();
        }

        public bool Contains<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return context.Set<T>().Any(predicate);
        }

        public void Create<T>(T TObject) where T : class
        {
            context.Set<T>().Add(TObject);
        }

        public void Delete<T>(T TObject) where T : class
        {
            context.Set<T>().Remove(TObject);
        }

        public void Delete<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var objects = Filter(predicate);
            foreach(var obj in objects)
            {
                context.Set<T>().Remove(obj);
            }
        }

        public void ExecuteProcedure(string procedureCommand, params SqlParameter[] sqlParams)
        {
            context.Database.ExecuteSqlRaw(procedureCommand, sqlParams);
        }

        public IEnumerable<T> Filter<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return context.Set<T>().Where(predicate).AsQueryable();
        }

        public IEnumerable<T> Filter<T>(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50) where T : class
        {
            int skipCount = index * size;
            var resetSet = filter != null ? context.Set<T>().Where(filter).AsQueryable() : context.Set<T>().AsQueryable();
            resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);
            total = resetSet.Count();
            return resetSet.AsQueryable();
        }

        public T Find<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return context.Set<T>().FirstOrDefault(predicate);
        }

        public void Update<T>(T TObject) where T : class
        {
            var entry = context.Entry(TObject);
            context.Set<T>().Attach(TObject);
            entry.State = EntityState.Modified;
        }
    }
}
