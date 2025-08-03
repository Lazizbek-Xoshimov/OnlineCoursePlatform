namespace CourseService.DAL.Models;

public class CourseGroup
{
    public short Id { get; set; }
    public string GroupName { get; set; }
    public string Direction { get; set; }

    public DateTime CreatedAt {  get; set; }
    public DateTime UpdatedAt { get; set; }
}
