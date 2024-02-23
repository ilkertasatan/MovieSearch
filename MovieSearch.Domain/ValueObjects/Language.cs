namespace MovieSearch.Domain.ValueObjects;

public readonly record struct Language
{
    private readonly string _value;
    public Language(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Language cannot be empty.", nameof(value));

        _value = value;
    }

    public override string ToString()
    {
        return _value;
    }
}