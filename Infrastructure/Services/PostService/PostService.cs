using System.Net;
using Dapper;
using Domain.Models;
using Domain.Responses;
using Infrastructure.DataContext;

namespace Infrastructure.Services.PostService;

public class PostService : IPostService
{
    private readonly DapperContext _context;

    public PostService(DapperContext context)
    {
        _context = context;
    }

    public async Task<Response<List<Post>>> GetPostsAsync()
    {
        try
        {
            var sql = $"Select * from posts";
            var result = await _context.Connection().QueryAsync<Post>(sql);
            return new Response<List<Post>>(result.ToList());
        }
        catch (Exception e)
        {
            return new Response<List<Post>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<Post>> GetPostByIdAsync(int id)
    {
        try
        {
            var sql = $"Select * from posts where id = {@id}";
            var result = await _context.Connection().QueryFirstOrDefaultAsync<Post>(sql);
            if (result != null) return new Response<Post>(result);
            return new Response<Post>(HttpStatusCode.BadRequest, "Not found");
        }
        catch (Exception e)
        {
            return new Response<Post>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<string>> CreatePostAsync(Post post)
    {
        try
        {
            var sql = $"Insert into posts(authorid,title,summary,published) " +
                      $"values ({post.AuthorId},'{post.Title}','{post.Summary}',{post.Published})";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<string>("Successfully");
            return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<string>> UpdatePostAsync(Post post)
    {
        try
        {
            var sql = $"Update posts " +
                      $"set authorid = {post.AuthorId},title = '{post.Title}','{post.Summary}',{post.Published} where id = {@post.Id}";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<string>("Successfully");
            return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> DeletePostAsync(int id)
    {
        try
        {
            var sql = $"Delete from posts where id = {@id}";
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