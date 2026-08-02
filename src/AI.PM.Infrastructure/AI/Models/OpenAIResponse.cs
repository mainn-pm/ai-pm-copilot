using System.Text.Json.Serialization;

namespace AI.PM.Infrastructure.AI.Models;

public sealed class OpenAIResponse
{
    [JsonPropertyName("output_text")]
    public string? OutputText { get; set; }
}