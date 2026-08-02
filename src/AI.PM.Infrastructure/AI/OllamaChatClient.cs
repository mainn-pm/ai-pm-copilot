using System.Text;
using System.Text.Json;
using AI.PM.Domain.Interfaces;
using AI.PM.Infrastructure.Configuration;
using Microsoft.Extensions.Options;

namespace AI.PM.Infrastructure.AI;

public class OllamaChatClient : IAIClient
{
    private readonly HttpClient _httpClient;
    private readonly OllamaSettings _settings;

    public OllamaChatClient(
        HttpClient httpClient,
        IOptions<OllamaSettings> options)
    {
        _httpClient = httpClient;
        _settings = options.Value;
    }

    public async Task<string> ChatAsync(
        string prompt,
        CancellationToken cancellationToken = default)
    {
        var request = new OllamaGenerateRequest
        {
            Model = _settings.Model,
            Prompt = prompt,
            Stream = false
        };

        var json = JsonSerializer.Serialize(request);

        using var response = await _httpClient.PostAsync(
            $"{_settings.BaseUrl}/api/generate",
            new StringContent(json, Encoding.UTF8, "application/json"),
            cancellationToken);

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync(cancellationToken);

        var result = JsonSerializer.Deserialize<OllamaGenerateResponse>(
            content,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        return result?.Response ?? "Không có phản hồi từ Ollama.";
    }

    private sealed class OllamaGenerateRequest
    {
        public string Model { get; set; } = string.Empty;

        public string Prompt { get; set; } = string.Empty;

        public bool Stream { get; set; }
    }

    private sealed class OllamaGenerateResponse
    {
        public string Response { get; set; } = string.Empty;
    }
}