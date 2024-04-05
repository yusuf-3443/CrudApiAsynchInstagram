using System.Net;
using Dapper;
using Domain.Models;
using Domain.Responses;
using Infrastructure.DataContext;

namespace Infrastructure.Services.CommentService;

public class CommentService : ICommentService
{
    private readonly DapperContext _context;

    public CommentService(DapperContext context)
    {
        _context = context;
    }

    public async Task<Response<List<Comment>>> GetCommentsAsync()
    {
        try
        {
            var sql = $"Select * from comments";
            var result = await _context.Connection().QueryAsync<Comment>(sql);
            return new Response<List<Comment>>(result.ToList());
        }
        catch (Exception e)
        {
            return new Response<List<Comment>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<Comment>> GetCommentByIdAsync(int id)
    {
        try
        {
            var sql = $"Select * from comments where id = {@id}";
            var result = await _context.Connection().QueryFirstOrDefaultAsync<Comment>(sql);
            if (result != null) return new Response<Comment>(result);
            return new Response<Comment>(HttpStatusCode.BadRequest, "Not found");
        }
        catch (Exception e)
        {
            return new Response<Comment>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<string>> CreateCommentAsync(Comment comment)
    {
        try
        {
            var sql = $"Insert into comments(postid,title,published,context)" +
                      $"values ({comment.PostId},'{comment.Title}',{comment.Published},'{comment.Context}')";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<string>("Successfully");
            return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<string>> UpdateCommentAsync(Comment comment)
    {
        try
        {
            var sql = $"Update comments set" +
                      $" postid = {comment.PostId},title = '{comment.Title}',{comment.Published},'{comment.Context}' where id = {@comment.Id}";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<string>("Successfully");
            return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> DeleteCommentAsync(int id)
    {
        try
        {

        var sql = $"Delete from comments where id = {@id}";
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