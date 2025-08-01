using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UserService.Domain.Entities;
using UserService.Infrastructure.AddDbContext;
using UserService.Infrastructure.Interfaces;

namespace UserService.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _dbContext;
    private readonly DbSet<User> _dbSet;

    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<User>();
    }
    public async Task<User> InsertAsync(User user)
    {
        var entity = await _dbSet.AddAsync(user);
        return entity.Entity;
    }

    public async Task<bool> DeleteAsync(Expression<Func<User, bool>> expression)
    {
        var user = await this.SelectAsync(expression);
        if (user == null)
            return false;

        _dbContext.Remove(user);
        return true;
    }

    public async Task<bool> SaveChangeAsync()
    {   
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public IQueryable<User> SelectAll(Expression<Func<User, bool>> expression = null)
    {
        return _dbSet is null ? _dbSet : _dbSet.Where(expression);
    }

    public async Task<User> SelectAsync(Expression<Func<User, bool>> expression)
    {
        return await _dbSet.FirstOrDefaultAsync(expression);
    }

    public User UpdateAsync(User user)
    {
        var entity = _dbSet.Update(user);
        return entity.Entity;
    }
}
