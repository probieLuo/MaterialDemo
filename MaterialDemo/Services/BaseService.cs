using MaterialDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace MaterialDemo.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        public virtual async Task<bool> AddAsync(T entity)
        {
            try
            {
                using (var context = new TestContext())
                {
                    context.Set<T>().Add(entity);
                    int result = await context.SaveChangesAsync();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            try
            {
                using (var context = new TestContext())
                {
                    var entity = context.Set<T>().Find(id);
                    if (entity != null)
                    {
                        context.Set<T>().Remove(entity);
                        int result = await context.SaveChangesAsync();
                        return result > 0;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                using (var context = new TestContext())
                {
                    var entities = await context.Set<T>().ToListAsync();
                    return entities.AsEnumerable();
                }
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<T>();
            }
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            try
            {
                using (var context = new TestContext())
                {
                    var entity = await context.Set<T>().FindAsync(id);
                    return entity;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                using (var context = new TestContext())
                {
                    context.Set<T>().Update(entity);
                    int result = await context.SaveChangesAsync();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
