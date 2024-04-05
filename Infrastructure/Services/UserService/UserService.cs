using System.Net;
using Dapper;
using Domain.Models;
using Domain.Responses;
using Infrastructure.DataContext;

namespace Infrastructure.Services.UserService;

public class UserService : IUserService
{
    private readonly DapperContext _context;

    public UserService(DapperContext context)
    {
        _context = context;
    }

    public async Task<Response<List<User>>> GetUsersAsync()
    {
        try
        {

        var sql = $"Select * from users";
        var result = await _context.Connection().QueryAsync<User>(sql);
        return new Response<List<User>>(result.ToList());
        
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<List<User>>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public async Task<Response<User>> GetUserByIdAsync(int id)
    {
        try
        {

        var sql = $"Select * from users where id = {@id}";
        var result = await _context.Connection().QueryFirstOrDefaultAsync<User>(sql);
        if (result != null) return new Response<User>(result);
        return new Response<User>(HttpStatusCode.BadRequest, "Not Found");
        
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<User>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public async Task<Response<string>> CreateUserAsync(User user)
    {
        try
        {
            var sql = $"Insert into users(firstname,lastname,phone,email,password)" +
                      $"values ('{user.FirstName}','{user.LastName}','{user.Phone}','{user.Email}','{user.Password}')";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<string>("Successfully");
            return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<string>> UpdateUserAsync(User user)
    {
        try
        {
            var sql = $"Update users " +
                      $"set firstname = '{user.FirstName}',lastname = '{user.LastName}',phone = '{user.Phone}',email = '{user.Email}',password = '{user.Password}' where id = {@user.Id}";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<string>("Successfully");
            return new Response<string>(HttpStatusCode.BadRequest,"Failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> DeleteUserAsync(int id)
    {
        try
        {
        var sql = $"Delete from users where id = {@id}";
        var result = await _context.Connection().ExecuteAsync(sql);
        if (result > 0) return new Response<bool>(true);
        return new Response<bool>(HttpStatusCode.BadRequest, "Failed");
        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
        }
}