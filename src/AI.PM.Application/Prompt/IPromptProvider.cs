namespace AI.PM.Application.Prompt;

public interface IPromptProvider
{
    Task<string> LoadAsync(string promptName);
}