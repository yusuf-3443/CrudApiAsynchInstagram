using Domain.Models;
using Domain.Responses;

namespace Infrastructure.Services.PostService;

public interface IPostService
{
    Task<Response<List<Post>>> GetPostsAsync();
    Task<Response<Post>> GetPostByIdAsync(int id);
    Task<Response<string>> CreatePostAsync(Post post);
    Task<Response<string>> UpdatePostAsync(Post post);
    Task<Response<bool>> DeletePostAsync(int id);
}