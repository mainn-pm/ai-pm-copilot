using AI.PM.Domain.Interfaces;
using AI.PM.Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using OpenAI.Chat;

namespace AI.PM.Infrastructure.AI;

public sealed class OpenAIChatClient : IAIClient
{
    private readonly ChatClient _chatClient;

    public OpenAIChatClient(IOptions<OpenAISettings> options)
    {
        var settings = options.Value;

        _chatClient = new ChatClient(
            model: settings.Model,
            apiKey: settings.ApiKey);
    }

    public async Task<string> ChatAsync(
        string prompt,
        CancellationToken cancellationToken = default)
    {
        var result = await _chatClient.CompleteChatAsync(
            new[]
            {
                new UserChatMessage(prompt)
            },
            cancellationToken: cancellationToken);

        return result.Value.Content.FirstOrDefault()?.Text
            ?? "Không có phản hồi từ GPT.";
    }
}