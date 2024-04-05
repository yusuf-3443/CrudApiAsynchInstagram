using Domain.Models;
using Domain.Responses;

namespace Infrastructure.Services.CommentService;

public interface ICommentService
{
    Task<Response<List<Comment>>> GetCommentsAsync();
    Task<Response<Comment>> GetCommentByIdAsync(int id);
    Task<Response<string>> CreateCommentAsync(Comment comment);
    Task<Response<string>> UpdateCommentAsync(Comment comment);
    Task<Response<bool>> DeleteCommentAsync(int id);
}