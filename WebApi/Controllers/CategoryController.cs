using Domain.Models;
using Domain.Responses;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;

namespace WebApi.Controllers;

[Route("/api/Categorys")]
[ApiController]
public class CategoryController(ICategoryService categoryService):ControllerBase
{
    private readonly ICategoryService _categoryService = categoryService;

    [HttpGet]
    public async Task<Response<List<Category>>> GetCategorysAsync()
    {
        return await _categoryService.GetCategorysAsync();
    }

    [HttpGet("{categorytid:int}")]
    public async Task<Response<Category>> GetCategoryByIdAsync(int categoryid)
    {
        return await _categoryService.GetCategoryByIdAsync(categoryid);
    }

    [HttpPost]
    public async Task<Response<string>> CreateCategoryAsync(Category category)
    {
        return await _categoryService.CreateCategoryAsync(category);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateCategoryAsync(Category category)
    {
        return await _categoryService.UpdateCategoryAsync(category);
    }

    [HttpDelete("{categoryid:int}")]
    public async Task<Response<bool>> DeleteCategoryAsync(int categoryid)
    {
        return await _categoryService.DeleteCategoryAsync(categoryid);
    }
}