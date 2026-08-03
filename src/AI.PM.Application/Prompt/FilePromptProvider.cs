namespace AI.PM.Application.Prompt;

public class FilePromptProvider : IPromptProvider
{
    private readonly string _promptFolder;

    public FilePromptProvider()
    {
        _promptFolder = Path.Combine(
            AppContext.BaseDirectory,
            "Prompts");
    }

    public async Task<string> LoadAsync(string promptName)
    {
        var file = Path.Combine(
            _promptFolder,
            $"{promptName}.md");

        if (!File.Exists(file))
            throw new FileNotFoundException(file);

        return await File.ReadAllTextAsync(file);
    }
}