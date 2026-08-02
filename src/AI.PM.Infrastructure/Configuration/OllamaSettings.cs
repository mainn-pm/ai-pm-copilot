namespace AI.PM.Infrastructure.Configuration;

public class OllamaSettings
{
    public const string SectionName = "Ollama";

    public string BaseUrl { get; set; } =
        "http://localhost:11434";

    public string Model { get; set; } =
        "gemma3:4b";
}