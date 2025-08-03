using CourseService.DAL.Contacts;
using CourseService.DAL.Data;
using CourseService.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseService.DAL.Repositories;

public class CourseRepository : ICourseRepositoy
{
    private readonly AppDbContext _dbContext;
    private readonly DbSet<Course> _dbSet;

    public CourseRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<Course>();
    }

    public async Task<bool> DeleteAsync(short id)
    {
        var course = await _dbSet.FirstOrDefaultAsync(c => c.Id == id);
        if (course == null)
            return false;

        _dbSet.Remove(course);
        return true;
    }

    public async Task<Course> InsertAsync(Course course)
    {
        var result = await _dbSet.AddAsync(course);
        return result.Entity;
    }

    public async Task<bool> SaveChangeAsync()
    {
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public IQueryable<Course> SelectAll()
    {
        return _dbSet;
    }

    public async Task<Course> SelectByIdAsync(short id)
    {
        return await _dbSet.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Course> UpdateAsync(Course course)
    {
        var result = _dbSet.Update(course);
        return result.Entity;
    }
}
