using CourseService.BAL.DTOs;

namespace CourseService.BAL.Interfaces;

public interface ICourseService
{
    public Task<CourseForResultDto> CreateAsync(CourseForCreateDto dto);
    public Task<CourseForResultDto> RetrieveByIdAsync(short id);
    public Task<IEnumerable<CourseForResultDto>> RetrieveAllAsync();
    public Task<CourseForResultDto> ModifyAsync(short id, CourseForUpdateDto dto);
    public Task<bool> RemoveAsync(short id);
}
