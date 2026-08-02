using AI.PM.Infrastructure.Configuration;

namespace AI.PM.Infrastructure.Configuration;

public class OpenAISettings
{
    public const string SectionName = "OpenAI";

    public string ApiKey { get; set; } = string.Empty;

    public string Model { get; set; } = "gpt-5.5";
    
}