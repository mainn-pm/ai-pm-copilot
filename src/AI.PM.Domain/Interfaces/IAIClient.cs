using AI.PM.Domain.Models;

namespace AI.PM.Domain.Interfaces;

public interface IAIClient
{
    Task<string> ChatAsync(
        string prompt,
        CancellationToken cancellationToken = default);
}