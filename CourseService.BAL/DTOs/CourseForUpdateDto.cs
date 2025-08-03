using CourseService.DAL.Models;

namespace CourseService.BAL.DTOs;

public class CourseForUpdateDto
{
    public short Id { get; set; }
    public string CourseName { get; set; }

    public ICollection<CourseGroup> Courses { get; set; } = new List<CourseGroup>();

    public DateTime UpdatedAt { get; set; }
}
