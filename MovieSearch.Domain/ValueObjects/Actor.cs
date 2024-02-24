namespace MovieSearch.Domain.ValueObjects;

public readonly record struct Actor
{
    private readonly string _value;
    
    public static IEnumerable<Actor> Parse(string actors)
    {
        return actors.Split(",").Select(actor => new Actor(actor.Trim()));
    }

    public override string ToString()
    {
        return _value;
    }

    private Actor(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Actor cannot be empty.", nameof(value));

        _value = value;
    }
}