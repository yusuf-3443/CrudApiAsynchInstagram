using Domain.Models;
using Domain.Responses;
using Infrastructure.Services.CommentService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("/api/Comments")]
[ApiController]
public class CommentController(ICommentService commentService):ControllerBase
{
    private readonly ICommentService _commentService = commentService;

    [HttpGet]
    public async Task<Response<List<Comment>>> GetCommentsAsync()
    {
        return await _commentService.GetCommentsAsync();
    }

    [HttpGet("{commentid:int}")]
    public async Task<Response<Comment>> GetCommentByIdAsync(int commentid)
    {
        return await _commentService.GetCommentByIdAsync(commentid);
    }

    [HttpPost]
    public async Task<Response<string>> CreateCommentAsync(Comment comment)
    {
        return await _commentService.CreateCommentAsync(comment);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateCommentAsync(Comment comment)
    {
        return await _commentService.UpdateCommentAsync(comment);
    }

    [HttpDelete("{commentid:int}")]
    public async Task<Response<bool>> DeleteCommentAsync(int commentid)
    {
        return await _commentService.DeleteCommentAsync(commentid);
    }
}