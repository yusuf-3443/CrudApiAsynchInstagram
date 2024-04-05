using Domain.Models;
using Domain.Responses;

namespace Infrastructure.Services.TagService;

public interface ITagService
{
    Task<Response<List<Tag>>> GetTagsAsync();
    Task<Response<Tag>> GetTagByIdAsync(int id);
    Task<Response<string>> CreateTagAsync(Tag tag);
    Task<Response<string>> UpdateTagAsync(Tag tag);
    Task<Response<bool>> DeleteTagAsync(int id);
}