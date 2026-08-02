using AI.PM.Application.Interfaces;
using AI.PM.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;

namespace AI.PM.Api.Controllers;

[ApiController]
[Route("api/chat")]
public class ChatController : ControllerBase
{
    private readonly IChatService _chatService;

    public ChatController(IChatService chatService)
    {
        _chatService = chatService;
    }

    [HttpPost]
    public async Task<IActionResult> Chat(ChatRequest request)
    {
        var result = await _chatService.ChatAsync(request);
        return Ok(result);
    }
}