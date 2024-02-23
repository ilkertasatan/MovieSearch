namespace MovieSearch.Domain.ValueObjects;

public readonly record struct VideoUri
{
    private readonly string _value;
    
    public VideoUri(string value)
    {
        _value = value;
    }

    public override string ToString()
    {
        return _value;
    }
}