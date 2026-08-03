using AI.PM.Application.Interfaces;
using AI.PM.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;

namespace AI.PM.Api.Controllers;

[ApiController]
[Route("api/pm")]
public class PMController : ControllerBase
{
    private readonly IUserStoryService _userStoryService;

    public PMController(IUserStoryService userStoryService)
    {
        _userStoryService = userStoryService;
    }

    [HttpPost("user-story")]
    public async Task<IActionResult> UserStory(UserStoryRequest request)
    {
        var result = await _userStoryService.GenerateAsync(request);

        return Ok(result);
    }
}