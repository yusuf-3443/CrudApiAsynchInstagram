using Domain.Models;
using Domain.Responses;

namespace Infrastructure.Services.PostTagService;

public interface IPostTagService
{
    Task<Response<List<PostTag>>> GetPostTagsAsync();
    Task<Response<PostTag>> GetPostTagByIdAsync(int id);
    Task<Response<string>> CreatePostTagAsync(PostTag postTag);
    Task<Response<string>> UpdatePostTagAsync(PostTag postTag);
    Task<Response<bool>> DeletePostTagAsync(int id);
}