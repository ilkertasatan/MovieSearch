namespace MovieSearch.Domain.ValueObjects;

public readonly record struct Genre
{
    private readonly string _value;
    public Genre(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Genre cannot be empty.", nameof(value));

        _value = value;
    }

    public override string ToString()
    {
        return _value;
    }
}