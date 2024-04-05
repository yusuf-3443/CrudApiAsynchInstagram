using Domain.Models;
using Domain.Responses;
using Infrastructure.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("/api/Users")]
[ApiController]
public class UserController(IUserService userService):ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpGet]
    public async Task<Response<List<User>>> GetUsersAsync()
    {
        return await _userService.GetUsersAsync();
    }

    [HttpGet("{userid:int}")]
    public async Task<Response<User>> GetUserByIdAsync(int userid)
    {
        return await _userService.GetUserByIdAsync(userid);
    }

    [HttpPost]
    public async Task<Response<string>> CreateUserAsync(User user)
    {
        return await _userService.CreateUserAsync(user);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateUserAsync(User user)
    {
        return await _userService.UpdateUserAsync(user);
    }

    [HttpDelete("{userid:int}")]
    public async Task<Response<bool>> DeleteUserAsync(int userid)
    {
        return await _userService.DeleteUserAsync(userid);
    }
}