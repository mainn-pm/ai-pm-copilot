using AI.PM.Application.Interfaces;
using AI.PM.Application.Prompt;
using AI.PM.Contracts.Requests;
using AI.PM.Contracts.Responses;
using AI.PM.Domain.Interfaces;

namespace AI.PM.Application.Services;

public class UserStoryService : IUserStoryService
{
    private readonly IAIClient _aiClient;
    private readonly UserStoryPromptBuilder _promptBuilder;

    public UserStoryService(
        IAIClient aiClient,
        UserStoryPromptBuilder promptBuilder)
    {
        _aiClient = aiClient;
        _promptBuilder = promptBuilder;
    }

    public async Task<UserStoryResponse> GenerateAsync(UserStoryRequest request)
    {
        var prompt = await _promptBuilder.BuildAsync(request.Requirement);

        var result = await _aiClient.ChatAsync(prompt);

        return new UserStoryResponse
        {
            Content = result
        };
    }
}