using System.Net;
using Dapper;
using Domain.Models;
using Domain.Responses;
using Infrastructure.DataContext;

namespace Infrastructure.Services.TagService;

public class TagService : ITagService
{
    private readonly DapperContext _context;

    public TagService(DapperContext context)
    {
        _context = context;
    }

    public async Task<Response<List<Tag>>> GetTagsAsync()
    {
        try
        {
            var sql = $"Select * from tags";
            var result = await _context.Connection().QueryAsync<Tag>(sql);
            return new Response<List<Tag>>(result.ToList());
        }
        catch (Exception e)
        {
            return new Response<List<Tag>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<Tag>> GetTagByIdAsync(int id)
    {
        try
        {

        var sql = $"Select * from tags where id = {@id}";
        var result = await _context.Connection().QueryFirstOrDefaultAsync<Tag>(sql);
        if (result != null) return new Response<Tag>(result);
        return new Response<Tag>(HttpStatusCode.BadRequest, "Not found");

        }
        catch (Exception e)
        {
            return new Response<Tag>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<string>> CreateTagAsync(Tag tag)
    {
        try
        {
            var sql = $"Insert into tags(title,context)" +
                      $"values ('{tag.Title}','{tag.Context}')";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<string>("Successfully");
            return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<string>> UpdateTagAsync(Tag tag)
    {
        try
        {
            var sql = $"Update tags " +
                      $"set title = '{tag.Title}', context = '{tag.Context}' where id = {@tag.Id}";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<string>("Successfully");
            return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> DeleteTagAsync(int id)
    {
        try
        {
            var sql = $"Delete from tags where id = {@id}";
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