using MaterialDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace MaterialDemo.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService() : base()
        {
        }

        public override async Task<bool> AddAsync(User entity)
        {
            try
            {
                using (var context = new TestContext())
                {
                    User user = await context.Users.Where(x => x.Name == entity.Name).FirstOrDefaultAsync();
                    if (user == null)
                    {
                        await context.Users.AddAsync(entity);
                        int result = await context.SaveChangesAsync();
                        return result > 0;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<User> GetByNameAsync(string userName)
        {
            try
            {
                using (var context = new TestContext())
                {
                    var user = await context.Users
                        .Where(x => x.Name == userName)
                        .FirstOrDefaultAsync();
                    return user;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
