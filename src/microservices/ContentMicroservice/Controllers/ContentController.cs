using ContentMicroservice.Models;
using ContentMicroservice.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContentMicroservice.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
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
    public async Task<IActionResult> Create(Content content)
    {
        return Ok(await contentRepository.CreateContent(content));
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Update(Guid id, Content content)
    {
        content.Id = id;

        var newContent = await contentRepository.UpdateContent(content);

        if (content is null)
        {
            return NotFound($"Content with ID:{id} not found");
        }

        return Ok(newContent);
    }

    [HttpDelete]
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
}