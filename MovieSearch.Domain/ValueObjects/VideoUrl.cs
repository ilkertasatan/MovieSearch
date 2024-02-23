namespace MovieSearch.Domain.ValueObjects;

public readonly record struct VideoUrl
{
    private readonly string _value;
    public VideoUrl(string value)
    {
        _value = value;
    }

    public override string ToString()
    {
        return _value;
    }
}