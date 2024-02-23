namespace MovieSearch.Domain.ValueObjects;

public readonly record struct Plot
{
    private readonly string _value;
    public Plot(string value)
    {
        _value = value;
    }

    public override string ToString()
    {
        return _value;
    }
}