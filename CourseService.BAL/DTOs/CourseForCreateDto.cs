using CourseService.DAL.Models;

namespace CourseService.BAL.DTOs;

public class CourseForCreateDto
{
    public string CourseName { get; set; }

    public ICollection<CourseGroup> Courses { get; set; } = new List<CourseGroup>();

    public DateTime CreatedAt { get; set; }
}
