using Domain.Models;
using Domain.Responses;

public interface ICategoryService
{
    Task<Response<List<Category>>> GetCategorysAsync();
    Task<Response<Category>> GetCategoryByIdAsync(int id);
    Task<Response<string>> CreateCategoryAsync(Category category);
    Task<Response<string>> UpdateCategoryAsync(Category category);
    Task<Response<bool>> DeleteCategoryAsync(int id);
}