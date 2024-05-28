using ContentMicroservice.Dtos.Content;
using ContentMicroservice.Models;
using ContentMicroservice.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContentMicroservice.Controllers;


[Route("api/v1/content")]
[ApiController]
public class ContentController(IContentRepository contentRepository) : ControllerBase
{
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await contentRepository.GetContents());
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> Get(Guid id)
    {
        var content = await contentRepository.GetContent(id);

        if (content is null)
        {
            return NotFound($"Content with ID:{id} not found");
        }

        return Ok(content);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] CreateContentDto content)
    {
        return Ok(await contentRepository.CreateContent(content));
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateContentDto content)
    {
        var newContent = await contentRepository.UpdateContent(id, content);

        if (newContent is null)
        {
            return NotFound($"Content with ID:{id} not found");
        }

        return Ok(newContent);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleteResult = await contentRepository.DeleteContent(id);

        if (!deleteResult)
        {
            return NotFound($"Content with ID:{id} not found");
        }

        return NoContent();
    }

    [HttpGet("{id}/episode")]
    [Authorize]
    public async Task<IActionResult> GetEpisodes(Guid id)
    {
        var episodes = await contentRepository.GetEpisodes(id);

        if (episodes is null)
        {
            return NotFound($"Content with ID:{id} not found");
        }

        return Ok(episodes);
    }
}