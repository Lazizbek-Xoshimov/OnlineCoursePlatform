using AutoMapper;
using UserService.Application.DTOs.UserDTOs;
using UserService.Application.Exceptions;
using UserService.Application.Interfaces;
using UserService.Domain.Entities;
using UserService.Infrastructure.Interfaces;

namespace UserService.Application.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserService(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<UserForResultDTO> CreateAsync(UserForCreationDTO dto)
    {
        var user = await _userRepository.SelectAsync(u => u.Email.ToLower() == dto.Email.ToLower());
        if (user is not null)
            throw new CustomException(409, "User is already exist");

        var mappedUser = _mapper.Map<User>(dto);
        mappedUser.CreatedAt = DateTime.UtcNow;

        var result = await _userRepository.InsertAsync(mappedUser);
        await _userRepository.SaveChangeAsync();

        return _mapper.Map<UserForResultDTO>(result);
    }

    public async Task<UserForResultDTO> ModifyAsync(short id, UserForUpdateDTO dto)
    {
        var user = await _userRepository.SelectAsync(u => u.Id == dto.Id);
        if (user is not null)
            throw new CustomException(404, "User is not found");

        var mappedUser = _mapper.Map<User>(dto);
        mappedUser.UpdatedAt = DateTime.UtcNow;

        await _userRepository.SaveChangeAsync();

        return _mapper.Map<UserForResultDTO>(mappedUser);
    }

    public async Task<bool> RemoveAsync(short id)
    {
        var user = await _userRepository.DeleteAsync(u => u.Id == id);
        if (user is false)
            throw new CustomException(404, "User is not found");

        await _userRepository.SaveChangeAsync();

        return user;
    }

    public async Task<IEnumerable<UserForResultDTO>> RetrieveAllAsync()
    {
        var users = _userRepository.SelectAll();

        return _mapper.Map<IEnumerable<UserForResultDTO>>(users);
    }

    public async Task<UserForResultDTO> RetrieveByIdAsync(short id)
    {
        var user = await _userRepository.SelectAsync(u => u.Id == id);
        if (user is null)
            throw new CustomException(404, "User is not found");

        return _mapper.Map<UserForResultDTO>(user);
    }
}
