namespace CourseService.DAL.Models;

public class Course
{
    public short Id { get; set; }
    public string CourseName { get; set; }
    
    public ICollection<CourseGroup> Courses { get; set; } = new List<CourseGroup>();

    public DateTime CreatedAt {  get; set; }
    public DateTime UpdatedAt {  get; set; }
}
