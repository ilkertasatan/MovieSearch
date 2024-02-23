namespace MovieSearch.Domain.ValueObjects;

public readonly record struct Language
{
    private readonly string _value;
    
    public static IEnumerable<Language> Parse(string languages)
    {
        return languages.Split(",").Select(language => new Language(language));
    }

    public override string ToString()
    {
        return _value;
    }

    private Language(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Language cannot be empty.", nameof(value));

        _value = value;
    }
}