using Domain.Models;
using Domain.Responses;

namespace Infrastructure.Services.UserService;

public interface IUserService
{
    Task<Response<List<User>>> GetUsersAsync();
    Task<Response<User>> GetUserByIdAsync(int id);
    Task<Response<string>> CreateUserAsync(User user);
    Task<Response<string>> UpdateUserAsync(User user);
    Task<Response<bool>> DeleteUserAsync(int id);
}