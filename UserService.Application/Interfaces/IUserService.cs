using UserService.Application.DTOs.UserDTOs;

namespace UserService.Application.Interfaces;

public interface IUserService
{
    public Task<UserForResultDTO> CreateAsync(UserForCreationDTO dto);
    public Task<UserForResultDTO> RetrieveByIdAsync(short id);
    public Task<IEnumerable<UserForResultDTO>> RetrieveAllAsync();
    public Task<UserForResultDTO> ModifyAsync(short id, UserForUpdateDTO dto);
    public Task<bool> RemoveAsync(short id);
}
