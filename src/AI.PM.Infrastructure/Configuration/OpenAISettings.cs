using AI.PM.Infrastructure.Configuration;

namespace AI.PM.Infrastructure.Configuration;

public class OpenAISettings
{
    public const string SectionName = "OpenAI";

    public string ApiKey { get; set; } = "";

    public string Model { get; set; } = "gpt-5.5";
    
    public string BaseUrl { get; set; } = "https://api.openai.com/v1/";
}