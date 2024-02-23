namespace MovieSearch.Domain.ValueObjects;

public readonly record struct Title
{
    private readonly string _value;
    public Title(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Title cannot be empty.", nameof(value));

        _value = value;
    }
    
    public override string ToString()
    {
        return _value;
    }
}