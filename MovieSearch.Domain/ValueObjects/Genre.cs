namespace MovieSearch.Domain.ValueObjects;

public readonly record struct Genre
{
    private readonly string _value;

    public static IEnumerable<Genre> Parse(string genres)
    {
        return genres.Split(",").Select(genre => new Genre(genre));
    }

    public override string ToString()
    {
        return _value;
    }

    private Genre(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Genre cannot be empty.", nameof(value));

        _value = value;
    }
}