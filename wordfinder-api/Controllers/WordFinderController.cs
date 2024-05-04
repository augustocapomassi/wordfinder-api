using Microsoft.AspNetCore.Mvc;
using WordFinder.Services;

namespace WordFinder.Api.Controllers;

[ApiController]
public class WordFinderController : ControllerBase
{
    private readonly IWordFinderService wordFinderService;

    public WordFinderController(IWordFinderService wordFinderService)
    {
        this.wordFinderService = wordFinderService;
    }

    [HttpPost("set-matrix")]
    public async Task<ActionResult> SetMatrix(
        IEnumerable<string> matrix)
    {
        await wordFinderService.SetMatrix(matrix);
        return NoContent();
    }

    [HttpGet("find-words")]
    public async Task<ActionResult<IEnumerable<string>>> FindWords([FromQuery] IEnumerable<string> wordsToFind)
    {
        var result = await wordFinderService.FindWords(wordsToFind);

        if (result.Any())
        {
            return Ok(result);
        }

        return NoContent();
    }
}