using FeedbackReport.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackReport.DAL.Data
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        protected readonly DalContext context;
        internal DbSet<T> dbSet;
        public readonly ILogger logger;

        public GenericRepo(DalContext context, ILogger logger)
        {
            this.context = context;
            this.logger = logger;
            this.dbSet = context.Set<T>();
        }

        public virtual async Task AddAsync(T entity)
        {
            try
            {
                dbSet.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Generic Repo} Add function error", typeof(DbSet<T>));
            }
        }

        public virtual async Task AddRangeAsync(IEnumerable<T> entities)
        {
            try
            {
                await dbSet.AddRangeAsync(entities);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Generic Repo} AddRange function error", typeof(DbSet<T>));
            }
        }

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                return await dbSet.Where(expression).ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Generic Repo} Find function error", typeof(DbSet<T>));
                return new List<T>();
            }
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Generic Repo} GetAll function error", typeof(DbSet<T>));
                return new List<T>();
            }
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            try
            {
                return await dbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Generic Repo} Find function error", typeof(DbSet<T>));
                return null;
            }
        }

        public virtual async Task RemoveAsync(T entity)
        {
            try
            {
                dbSet.Remove(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Generic Repo} Remove function error", typeof(DbSet<T>));
            }
        }

        public virtual async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            try
            {
                dbSet.RemoveRange(entities);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Generic Repo} RemoveRange function error", typeof(DbSet<T>));
            }
        }

        public virtual async Task UpdateAsync(T entity)
        {
            try
            {
                PropertyInfo propertyInfo = entity.GetType().GetProperty("ModifiedAt");
                propertyInfo.SetValue(entity, DateTime.Now);
                context.Update(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Generic Repo} Update function error", typeof(DbSet<T>));
            }

        }

        public virtual async Task<int> CountAsync()
        {
            try
            {
                return await context.Set<T>().CountAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Generic Repo} Count function error", typeof(DbSet<T>));
                return 0;
            }
        }
    }
}
