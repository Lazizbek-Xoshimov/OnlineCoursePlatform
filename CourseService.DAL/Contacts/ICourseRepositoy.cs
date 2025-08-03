using CourseService.DAL.Models;

namespace CourseService.DAL.Contacts;

public interface ICourseRepositoy
{
    public Task<Course> InsertAsync(Course course);
    public Task<Course> SelectByIdAsync(short id);
    public IQueryable<Course> SelectAll();
    public Task<Course> UpdateAsync(Course course);
    public Task<bool> DeleteAsync(short id);
    public Task<bool> SaveChangeAsync();
}
