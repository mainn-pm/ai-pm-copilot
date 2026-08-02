namespace AI.PM.Infrastructure.AI.Models;

public sealed class OpenAIRequest
{
    public string model { get; set; } = "";

    public string input { get; set; } = "";
}