using System.Linq.Expressions;
using UserService.Domain.Entities;

namespace UserService.Infrastructure.Interfaces;

public interface IUserRepository
{
    public Task<User> InsertAsync(User user);
    public Task<User> SelectAsync(Expression<Func<User, bool>> expression);
    public IQueryable<User> SelectAll(Expression<Func<User, bool>> expression = null);
    public User UpdateAsync(User user);
    public Task<bool> DeleteAsync(Expression<Func<User, bool>> expression);
    public Task<bool> SaveChangeAsync();
}
