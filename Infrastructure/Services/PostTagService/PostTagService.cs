using System.Net;
using Dapper;
using Domain.Models;
using Domain.Responses;
using Infrastructure.DataContext;

namespace Infrastructure.Services.PostTagService;

public class PostTagService : IPostTagService
{
    private readonly DapperContext _context;

    public PostTagService(DapperContext context)
    {
        _context = context;
    }

    public async Task<Response<List<PostTag>>> GetPostTagsAsync()
    {
        try
        {

        var sql = $"Select * from posttags";
        var result = await _context.Connection().QueryAsync<PostTag>(sql);
        return new Response<List<PostTag>>(result.ToList());
        
        }
        catch (Exception e)
        {
            return new Response<List<PostTag>>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public async Task<Response<PostTag>> GetPostTagByIdAsync(int id)
    {
        try
        {
            var sql = $"Select * from posttags where id = {@id}";
            var result = await _context.Connection().QueryFirstOrDefaultAsync<PostTag>(sql);
            if (result != null) return new Response<PostTag>(result);
            return new Response<PostTag>(HttpStatusCode.BadRequest, "Not found");
        }
        catch (Exception e)
        {
            return new Response<PostTag>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<string>> CreatePostTagAsync(PostTag postTag)
    {
        try
        {
            var sql = $"Insert into posttags(postid,tagid)" +
                      $"values ({postTag.PostId},{postTag.TagId})";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<string>("Successfully");
            return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<string>> UpdatePostTagAsync(PostTag postTag)
    {
        try
        {
            var sql = $"Update posttags set" +
                      $" postid = {postTag.PostId},tagid = {postTag.TagId} where id = {@postTag.Id}";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<string>("Successfully");
            return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> DeletePostTagAsync(int id)
    {
        try
        {
            var sql = $"Delete from posttags where id = {@id}";
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