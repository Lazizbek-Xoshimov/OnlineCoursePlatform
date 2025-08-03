using CourseService.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseService.DAL.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseGroup> CourseGroups {  get; set; }
}
