using Domain.Models;
using Domain.Responses;
using Infrastructure.Services.PostTagService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("/api/PostTags")]
[ApiController]
public class PostTagController(IPostTagService postTagService):ControllerBase
{
    private readonly IPostTagService _postTagService = postTagService;
    [HttpGet]
    public async Task<Response<List<PostTag>>> GetPostTagsAsync()
    {
        return await _postTagService.GetPostTagsAsync();
    }
    [HttpGet("{postTagid:int}")]
    public async Task<Response<PostTag>> GetPostTagByIdAsync(int postTagid)
    {
        return await _postTagService.GetPostTagByIdAsync(postTagid);
    }
    [HttpPost]
    public async Task<Response<string>> CreatePostTagAsync(PostTag postTag)
    {
        return await _postTagService.CreatePostTagAsync(postTag);
    }
    [HttpPut]
    public async Task<Response<string>> UpdatePostTagAsync(PostTag postTag)
    {
        return await _postTagService.UpdatePostTagAsync(postTag);
    }
    [HttpDelete("{postTagid:int}")]
    public async Task<Response<bool>> DeletePostTagAsync(int postTagid)
    {
        return await _postTagService.DeletePostTagAsync(postTagid);
    }
}