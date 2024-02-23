namespace MovieSearch.Domain.ValueObjects;

public readonly record struct Actor
{
    private readonly string _value;
    public Actor(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Actor cannot be empty.", nameof(value));

        _value = value;
    }

    public override string ToString()
    {
        return _value;
    }
}