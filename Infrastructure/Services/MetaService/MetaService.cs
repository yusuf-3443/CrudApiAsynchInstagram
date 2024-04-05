using System.Net;
using Dapper;
using Domain.Models;
using Domain.Responses;
using Infrastructure.DataContext;

namespace Infrastructure.Services.MetaService;

public class MetaService : IMetaService
{
    private readonly DapperContext _context;

    public MetaService(DapperContext context)
    {
        _context = context;
    }

    public async Task<Response<List<Meta>>> GetMetasAsync()
    {
        try
        {

        var sql = $"Select * from metas";
        var result = await _context.Connection().QueryAsync<Meta>(sql);
        return new Response<List<Meta>>(result.ToList());
        
        }
        catch (Exception e)
        {
            return new Response<List<Meta>>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public async Task<Response<Meta>> GetMetaByIdAsync(int id)
    {
        try
        {
            var sql = $"Select * from metas where id = {@id}";
            var result = await _context.Connection().QueryFirstOrDefaultAsync<Meta>(sql);
            if (result != null) return new Response<Meta>(result);
            return new Response<Meta>(HttpStatusCode.BadRequest, "Not found");
        }
        catch (Exception e)
        {
            return new Response<Meta>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<string>> CreateMetaAsync(Meta meta)
    {
        try
        {
            var sql = $"Insert into metas(postid,key,context)" +
                      $"values ({meta.PostId},'{meta.Key}','{meta.Context}')";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<string>("Successfully");
            return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<string>> UpdateMetaAsync(Meta meta)
    {
        try
        {
            var sql = $"Update metas set " +
                      $"postid = {meta.PostId},key = '{meta.Key}',context = '{meta.Context}' where id = {@meta.Id}";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<string>("Successfully");
            return new Response<string>(HttpStatusCode.BadRequest, "failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> DeleteMetaAsync(int id)
    {
        try
        {
            var sql = $"Delete from metas where id = {@id}";
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