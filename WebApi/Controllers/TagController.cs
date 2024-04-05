using Domain.Models;
using Domain.Responses;
using Infrastructure.Services.TagService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("/api/Tags")]
[ApiController]
public class TagController(ITagService tagService):ControllerBase
{
    private readonly ITagService _tagService = tagService;

    [HttpGet]
    public async Task<Response<List<Tag>>> GetTagsAsync()
    {
        return await _tagService.GetTagsAsync();
    }

    [HttpGet("{tagid:int}")]
    public async Task<Response<Tag>> GetTagByIdAsync(int tagid)
    {
        return await _tagService.GetTagByIdAsync(tagid);
    }

    [HttpPost]
    public async Task<Response<string>> CreateTagAsync(Tag tag)
    {
        return await _tagService.CreateTagAsync(tag);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateTagAsync(Tag tag)
    {
        return await _tagService.UpdateTagAsync(tag);
    }

    [HttpDelete("{tagid:int}")]
    public async Task<Response<bool>> DeleteTagAsync(int tagid)
    {
        return await _tagService.DeleteTagAsync(tagid);
    }
}