using Domain.Models;
using Domain.Responses;
using Infrastructure.Services.PostService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("/api/Posts")]
[ApiController]
public class PostController(IPostService postService):ControllerBase
{
    private readonly IPostService _postService = postService;
    [HttpGet]
    public async Task<Response<List<Post>>> GetPostsAsync()
    {
        return await _postService.GetPostsAsync();
    }
    [HttpGet("{postid:int}")]
    public async Task<Response<Post>> GetPostByIdAsync(int postid)
    {
        return await _postService.GetPostByIdAsync(postid);
    }
    [HttpPost]
    public async Task<Response<string>> CreatePostAsync(Post post)
    {
        return await _postService.CreatePostAsync(post);
    }
    [HttpPut]
    public async Task<Response<string>> UpdatePostAsync(Post post)
    {
        return await _postService.UpdatePostAsync(post);
    }
    [HttpDelete("{postid:int}")]
    public async Task<Response<bool>> DeletePostAsync(int postid)
    {
        return await _postService.DeletePostAsync(postid);
    }
}