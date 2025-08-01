using Microsoft.AspNetCore.Mvc;
using UserService.Application.DTOs.UserDTOs;
using UserService.Application.Interfaces;

namespace UserServiceWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var users = await _userService.RetrieveAllAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(short id)
    {
        var user = await _userService.RetrieveByIdAsync(id);
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] UserForCreationDTO dto)
    {
        var user = await _userService.CreateAsync(dto);
        return Ok(user);
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync(short id, [FromBody] UserForUpdateDTO dto)
    {
        var user = await _userService.ModifyAsync(id, dto);
        return Ok(user);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(short id)
    {
        var user = await _userService.RemoveAsync(id);
        return Ok(user);
    }
}
