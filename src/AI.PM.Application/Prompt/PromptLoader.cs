namespace AI.PM.Application.Prompt;

public class PromptLoader
{
    private readonly string _promptFolder;

    public PromptLoader()
    {
        _promptFolder = Path.Combine(
            AppContext.BaseDirectory,
            "Prompts");
    }

    public string Load(string fileName)
    {
        var path = Path.Combine(_promptFolder, fileName);

        if (!File.Exists(path))
            throw new FileNotFoundException(path);

        return File.ReadAllText(path);
    }
}