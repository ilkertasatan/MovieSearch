namespace MovieSearch.Domain.ValueObjects;

public readonly record struct Writer
{
    private readonly string _value;

    public static IEnumerable<Writer> Parse(string writers)
    {
        return writers.Split(",").Select(writer => new Writer(writer.Trim()));
    }

    public override string ToString()
    {
        return _value;
    }

    private Writer(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Writer cannot be empty.", nameof(value));

        _value = value;
    }
}