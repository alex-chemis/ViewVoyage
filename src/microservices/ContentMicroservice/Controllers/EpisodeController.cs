using ContentMicroservice.Dtos.Episode;
using ContentMicroservice.Models;
using ContentMicroservice.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContentMicroservice.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class EpisodeController(IEpisodeRepository episodeRepository) : ControllerBase
{
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await episodeRepository.GetEpisodes());
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> Get(Guid id)
    {
        var episode = await episodeRepository.GetEpisode(id);

        if (episode is null)
        {
            return NotFound($"Episode with ID:{id} not found");
        }

        return Ok(episode);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] CreateEpisodeDto episode)
    {
        var newEpisode = await episodeRepository.CreateEpisode(episode);

        if (newEpisode is null)
        {
            return NotFound($"Content with ID:{episode.ContentId} not found");
        }

        return Ok(newEpisode);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateEpisodeDto episode)
    {
        var newEpisode = await episodeRepository.UpdateEpisode(id, episode);

        if (newEpisode is null)
        {
            return NotFound($"Episode with ID:{id} not found");
        }

        return Ok(newEpisode);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleteResult = await episodeRepository.DeleteEpisode(id);

        if (!deleteResult)
        {
            return NotFound($"Episode with ID:{id} not found");
        }

        return NoContent();
    }
}
