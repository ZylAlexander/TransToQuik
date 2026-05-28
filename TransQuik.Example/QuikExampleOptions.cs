namespace TransQuik.Example;

public sealed class QuikExampleOptions
{
    public const string SectionName = "Quik";

    public string Path { get; init; } = string.Empty;
    public string ClassCode { get; init; } = string.Empty;
    public string SecCode { get; init; } = string.Empty;
    public string Account { get; init; } = string.Empty;
    public bool PlaceDemoOrder { get; init; }
    public bool PlaceDemoStopOrder { get; init; }
    public bool CancelLastOrder { get; init; }
}
