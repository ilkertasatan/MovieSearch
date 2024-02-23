namespace MovieSearch.Domain.ValueObjects;

public readonly record struct Year
{
    private readonly int _value;
    public Year(int value)
    {
        if (value < 1800 || value > DateTime.UtcNow.Year)
            throw new ArgumentOutOfRangeException(nameof(value), "Year is out of range.");

        _value = value;
    }

    public override string ToString()
    {
        return _value.ToString();
    }
}