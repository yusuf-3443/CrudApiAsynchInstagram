using Domain.Models;
using Domain.Responses;

namespace Infrastructure.Services.PostCategoryService;

public interface IPostCategoryService
{
    Task<Response<List<PostCategory>>> GetPostCategorysAsync();
    Task<Response<PostCategory>> GetPostCategoryByIdAsync(int id);
    Task<Response<string>> CreatePostCategoryAsync(PostCategory postCategory);
    Task<Response<string>> UpdatePostCategoryAsync(PostCategory postCategory);
    Task<Response<bool>> DeletePostCategoryAsync(int id);
}