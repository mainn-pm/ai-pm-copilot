using AI.PM.Application.Interfaces;
using AI.PM.Contracts.Requests;
using AI.PM.Contracts.Responses;
using AI.PM.Domain.Interfaces;

namespace AI.PM.Application.Services;

public class ChatService : IChatService
{
    private readonly IAIClient _aiClient;

    public ChatService(IAIClient aiClient)
    {
        _aiClient = aiClient;
    }

    public async Task<ChatResponse> ChatAsync(ChatRequest request)
    {
        var reply = await _aiClient.ChatAsync(request.Message);

        return new ChatResponse
        {
            Reply =  reply

        };
    }
}