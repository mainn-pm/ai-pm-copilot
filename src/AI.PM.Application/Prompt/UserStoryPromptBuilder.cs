namespace AI.PM.Application.Prompt;

public class UserStoryPromptBuilder
{
    private readonly IPromptProvider _provider;

    public UserStoryPromptBuilder(
        IPromptProvider provider)
    {
        _provider = provider;
    }

    public async Task<string> BuildAsync(
        string requirement)
    {
        var template =
            await _provider.LoadAsync("UserStory");

        return template.Replace(
            "{{requirement}}",
            requirement);
    }
}