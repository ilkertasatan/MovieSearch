namespace MovieSearch.Domain.ValueObjects;

public readonly record struct Director
{
    private readonly string _value;
    public Director(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Director cannot be empty.", nameof(value));

        _value = value;
    }

    public override string ToString()
    {
        return _value;
    }
}