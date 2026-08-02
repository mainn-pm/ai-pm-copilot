namespace AI.PM.Domain.Models;

public sealed record AIResponse(
    string Content,
    string Provider,
    string Model);