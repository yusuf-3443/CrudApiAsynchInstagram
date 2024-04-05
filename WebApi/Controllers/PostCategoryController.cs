using Domain.Models;
using Domain.Responses;
using Infrastructure.Services.PostCategoryService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("/api/PostCategorys")]
[ApiController]
public class PostCategoryController(IPostCategoryService postCategoryService):ControllerBase
{
    private readonly IPostCategoryService _postCategoryService = postCategoryService;
    [HttpGet]
    public async Task<Response<List<PostCategory>>> GetPostCategorysAsync()
    {
        return await _postCategoryService.GetPostCategorysAsync();
    }
    [HttpGet("{postCategoryid:int}")]
    public async Task<Response<PostCategory>> GetPostCategoryByIdAsync(int postCategoryid)
    {
        return await _postCategoryService.GetPostCategoryByIdAsync(postCategoryid);
    }
    [HttpPost]
    public async Task<Response<string>> CreatePostCategoryAsync(PostCategory postCategory)
    {
        return await _postCategoryService.CreatePostCategoryAsync(postCategory);
    }
    [HttpPut]
    public async Task<Response<string>> UpdatePostCategoryAsync(PostCategory postCategory)
    {
        return await _postCategoryService.UpdatePostCategoryAsync(postCategory);
    }
    [HttpDelete("{postCategoryid:int}")]
    public async Task<Response<bool>> DeletePostCategoryAsync(int postCategoryid)
    {
        return await _postCategoryService.DeletePostCategoryAsync(postCategoryid);
    }
}