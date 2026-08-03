using AI.PM.Application.Interfaces;
using AI.PM.Contracts.Requests;
using AI.PM.Contracts.Responses;
using AI.PM.Domain.Interfaces;
using AI.PM.Application.Prompt;

namespace AI.PM.Application.Services;

public class ChatService : IChatService
{
    private readonly IAIClient _aiClient;
    private readonly PromptBuilder _promptBuilder;

    public ChatService(IAIClient aiClient, PromptBuilder promptBuilder)
    {
        _aiClient = aiClient;
        _promptBuilder = promptBuilder;
    }

    public async Task<ChatResponse> ChatAsync(ChatRequest request)
    {
        var prompt = _promptBuilder.Build(request.Message);

        var reply = await _aiClient.ChatAsync(prompt);

        return new ChatResponse
        {
            Reply =  reply

        };
    }
}