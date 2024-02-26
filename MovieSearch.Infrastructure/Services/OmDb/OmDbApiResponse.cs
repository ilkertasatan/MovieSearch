namespace MovieSearch.Infrastructure.Services.OmDb;

public sealed class OmDbApiResponse
{
    public string ImdbId { get; set; }
    public string Title { get; set; }
    public string Year { get; set; }
    public string Genre { get; set; }
    public string Director { get; set; }
    public string Writer { get; set; }
    public string Actors { get; set; }
    public string Plot { get; set; }
    public string Language { get; set; }
}