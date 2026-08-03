using AI.PM.Contracts.Requests;
using AI.PM.Contracts.Responses;

namespace AI.PM.Application.Interfaces;

public interface IUserStoryService
{
    Task<UserStoryResponse> GenerateAsync(UserStoryRequest request);
}