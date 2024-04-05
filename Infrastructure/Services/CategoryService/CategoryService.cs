using System.Net;
using Dapper;
using Domain.Models;
using Domain.Responses;
using Infrastructure.DataContext;

public class CategoryService : ICategoryService
{
    private readonly DapperContext _context;

    public CategoryService(DapperContext context)
    {
        _context = context;
    }

    public async Task<Response<List<Category>>> GetCategorysAsync()
    {
        try
        {

        var sql = $"Select * from categories";
        var result = await _context.Connection().QueryAsync<Category>(sql);
        return new Response<List<Category>>(result.ToList());
        
        }
        catch (Exception e)
        {
            return new Response<List<Category>>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public async Task<Response<Category>> GetCategoryByIdAsync(int id)
    {
        try
        {
            var sql = $"Select * from categories where id = {@id}";
            var result = await _context.Connection().QueryFirstOrDefaultAsync<Category>(sql);
            if (result != null) return new Response<Category>(result);
            return new Response<Category>(HttpStatusCode.BadRequest, "Not found");
        }
        catch (Exception e)
        {
            return new Response<Category>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<string>> CreateCategoryAsync(Category category)
    {
        try
        {

        var sql = $"Insert into categories(title,context)" +
                  $"values ('{category.Title}','{category.Context}')";
        var result = await _context.Connection().ExecuteAsync(sql);
        if (result > 0) return new Response<string>("Successfully");
        return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public async Task<Response<string>> UpdateCategoryAsync(Category category)
    {
        try
        {

        var sql = $"Update categories set " +
                  $"title = '{category.Title}', context = '{category.Context}' where id = {@category.Id}";
        var result = await _context.Connection().ExecuteAsync(sql);
        if (result > 0) return new Response<string>("Successfully");
        return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public async Task<Response<bool>> DeleteCategoryAsync(int id)
    {
        try
        {
            var sql = $"Delete from categories where id = {@id}";
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