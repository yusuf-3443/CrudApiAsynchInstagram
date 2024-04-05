using System.Net;
using Dapper;
using Domain.Models;
using Domain.Responses;
using Infrastructure.DataContext;

namespace Infrastructure.Services.PostCategoryService;

public class PostCategoryService : IPostCategoryService
{
    private readonly DapperContext _context;

    public PostCategoryService(DapperContext context)
    {
        _context = context;
    }

    public async Task<Response<List<PostCategory>>> GetPostCategorysAsync()
    {
        try
        {

        var sql = $"Select * from postcategories";
        var result = await _context.Connection().QueryAsync<PostCategory>(sql);
        return new Response<List<PostCategory>>(result.ToList());
        
        }
        catch (Exception e)
        {
            return new Response<List<PostCategory>>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public async Task<Response<PostCategory>> GetPostCategoryByIdAsync(int id)
    {
        try
        {
            var sql = $"Select * from postcategories where id = {@id}";
            var result = await _context.Connection().QueryFirstOrDefaultAsync<PostCategory>(sql);
            if (result != null) return new Response<PostCategory>(result);
            return new Response<PostCategory>(HttpStatusCode.BadRequest, "Not found");
        }
        catch (Exception e)
        {
            return new Response<PostCategory>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<string>> CreatePostCategoryAsync(PostCategory postCategory)
    {
        try
        {

        var sql = $"Insert into postcategories(postid,categoryid)" +
                  $"values ({postCategory.PostId},{postCategory.CategoryId})";
        var result = await _context.Connection().ExecuteAsync(sql);
        if (result > 0) return new Response<string>("Successfully");
        return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public async Task<Response<string>> UpdatePostCategoryAsync(PostCategory postCategory)
    {
        try
        {

        var sql = $"Update postcategories set " +
                  $"postid = {postCategory.PostId},categoryid = {postCategory.CategoryId} where id = {@postCategory.Id}";
        var result = await _context.Connection().ExecuteAsync(sql);
        if (result > 0) return new Response<string>("Successfully");
        return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public async Task<Response<bool>> DeletePostCategoryAsync(int id)
    {
        try
        {
            var sql = $"Delete from postcategories where id = {@id}";
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