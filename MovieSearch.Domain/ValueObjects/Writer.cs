namespace MovieSearch.Domain.ValueObjects;

public readonly record struct Writer
{
    private readonly string _value;
    public Writer(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Writer cannot be empty.", nameof(value));

        _value = value;
    }

    public override string ToString()
    {
        return _value;
    }
}