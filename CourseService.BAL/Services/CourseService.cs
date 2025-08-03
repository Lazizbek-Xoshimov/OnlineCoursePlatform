using AutoMapper;
using CourseService.BAL.DTOs;
using CourseService.BAL.Exceptions;
using CourseService.BAL.Interfaces;
using CourseService.DAL.Contacts;
using CourseService.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseService.BAL.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepositoy _courseRepository;
    private readonly IMapper _mapper;

    public CourseService(ICourseRepositoy courseRepository, IMapper mapper)
    {
        _courseRepository = courseRepository;
        _mapper = mapper;
    }

    public async Task<CourseForResultDto> CreateAsync(CourseForCreateDto dto)
    {
        var course = await _courseRepository.SelectAll()
            .FirstOrDefaultAsync(c => c.CourseName.ToLower() == dto.CourseName.ToLower());
        if (course is not null)
            throw new CustomException(409, "Course is already exist");

        var mappedCourse = _mapper.Map<Course>(dto);
        mappedCourse.CreatedAt = DateTime.UtcNow;

        var result = await _courseRepository.InsertAsync(mappedCourse);
        await _courseRepository.SaveChangeAsync();

        return _mapper.Map<CourseForResultDto>(result);
    }

    public async Task<CourseForResultDto> ModifyAsync(short id, CourseForUpdateDto dto)
    {
        var course = await _courseRepository.SelectByIdAsync(id);
        if (course is null)
            throw new CustomException(404, "Course is not found");

        var mappedCourse = _mapper.Map<Course>(dto);
        mappedCourse.UpdatedAt = DateTime.UtcNow;

        await _courseRepository.SaveChangeAsync();

        return _mapper.Map<CourseForResultDto>(mappedCourse);
    }

    public async Task<bool> RemoveAsync(short id)
    {
        var course = await _courseRepository.DeleteAsync(id);
        if (course == false)
            throw new CustomException(404, "Course is not found");

        await _courseRepository.SaveChangeAsync();
        return true;
    }

    public async Task<IEnumerable<CourseForResultDto>> RetrieveAllAsync()
    {
        var courses = _courseRepository.SelectAll();

        return _mapper.Map<IEnumerable<CourseForResultDto>>(courses);
    }

    public async Task<CourseForResultDto> RetrieveByIdAsync(short id)
    {
        var course = await _courseRepository.SelectByIdAsync(id);
        if (course is null)
            throw new CustomException(404, "Course is not found");

        return _mapper.Map<CourseForResultDto>(course);
    }
}
