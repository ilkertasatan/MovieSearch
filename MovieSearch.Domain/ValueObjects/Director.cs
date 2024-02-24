namespace MovieSearch.Domain.ValueObjects;

public readonly record struct Director
{
    private readonly string _value;

    public static IEnumerable<Director> Parse(string directors)
    {
        return directors.Split(",").Select(director => new Director(director.Trim()));
    }

    public override string ToString()
    {
        return _value;
    }

    private Director(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Director cannot be empty.", nameof(value));

        _value = value;
    }
}