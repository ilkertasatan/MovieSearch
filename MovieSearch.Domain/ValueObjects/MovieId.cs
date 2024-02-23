namespace MovieSearch.Domain.ValueObjects;

public readonly record struct MovieId
{
    private readonly string _value;
    
    public MovieId(string value)
    {
        _value = value;
    }

    public bool IsEmpty() => string.IsNullOrWhiteSpace(_value);

    public override string ToString()
    {
        return _value;
    }
}