namespace MovieSearch.Domain.ValueObjects;

public readonly record struct Year
{
    private readonly string _value;
    
    public Year(string value)
    {
        _value = value;
    }

    public override string ToString()
    {
        return _value;
    }
}