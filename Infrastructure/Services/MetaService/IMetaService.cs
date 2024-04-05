using Domain.Models;
using Domain.Responses;

namespace Infrastructure.Services.MetaService;

public interface IMetaService
{
    Task<Response<List<Meta>>> GetMetasAsync();
    Task<Response<Meta>> GetMetaByIdAsync(int id);
    Task<Response<string>> CreateMetaAsync(Meta meta);
    Task<Response<string>> UpdateMetaAsync(Meta meta);
    Task<Response<bool>> DeleteMetaAsync(int id);
}