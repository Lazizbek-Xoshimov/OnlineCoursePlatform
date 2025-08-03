using CourseService.DAL.Models;

namespace CourseService.BAL.DTOs;

public class CourseForResultDto
{
    public short Id { get; set; }
    public string CourseName { get; set; }

    public ICollection<CourseGroup> Courses { get; set; } = new List<CourseGroup>();

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
