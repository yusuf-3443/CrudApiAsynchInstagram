using Domain.Models;
using Domain.Responses;
using Infrastructure.Services.MetaService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("/api/Metas")]
[ApiController]
public class MetaController(IMetaService metaService):ControllerBase
{
    private readonly IMetaService _metaService = metaService;

    [HttpGet]
    public async Task<Response<List<Meta>>> GetMetasAsync()
    {
        return await _metaService.GetMetasAsync();
    }

    [HttpGet("{metaid:int}")]
    public async Task<Response<Meta>> GetMetaByIdAsync(int metaid)
    {
        return await _metaService.GetMetaByIdAsync(metaid);
    }

    [HttpPost]
    public async Task<Response<string>> CreateMetaAsync(Meta meta)
    {
        return await _metaService.CreateMetaAsync(meta);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateMetaAsync(Meta meta)
    {
        return await _metaService.UpdateMetaAsync(meta);
    }

    [HttpDelete("{metaid:int}")]
    public async Task<Response<bool>> DeleteMetaAsync(int metaid)
    {
        return await _metaService.DeleteMetaAsync(metaid);
    }
}