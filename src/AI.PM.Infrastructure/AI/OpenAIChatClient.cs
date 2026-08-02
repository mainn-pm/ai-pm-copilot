using AI.PM.Domain.Interfaces;
using AI.PM.Infrastructure.Configuration;
using Microsoft.Extensions.Options;

namespace AI.PM.Infrastructure.AI;

public class OpenAIChatClient : IAIClient
{
    private readonly HttpClient _httpClient;
    private readonly OpenAISettings _settings;

    public OpenAIChatClient(
        HttpClient httpClient,
        IOptions<OpenAISettings> options)
    {
        _httpClient = httpClient;
        _settings = options.Value;
    }

    public async Task<string> ChatAsync(
        string prompt,
        CancellationToken cancellationToken = default)
    {
        // Tạm thời chưa gọi OpenAI
        await Task.CompletedTask;

        return $"OpenAI Client nhận được: {prompt}";
    }
}