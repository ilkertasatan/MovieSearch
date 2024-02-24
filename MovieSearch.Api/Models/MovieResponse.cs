namespace MovieSearch.Api.Models;

/// <summary>
/// Movie Response
/// </summary>
public sealed class MovieResponse
{
    public MovieResponse(
        string movieId,
        string title,
        string year,
        List<string> genres,
        List<string> directors,
        List<string> writers,
        List<string> actors,
        string plot,
        List<string> languages, 
        List<string> videoUris)
    {
        MovieId = movieId;
        Title = title;
        Year = year;
        Genres = genres;
        Directors = directors;
        Writers = writers;
        Actors = actors;
        Plot = plot;
        Languages = languages;
        VideoUris = videoUris;
    }

    public string MovieId { get; }

    public string Title { get; }

    public string Year { get; }

    public List<string> Genres { get; }

    public List<string> Directors { get; }

    public List<string> Writers { get; }

    public List<string> Actors { get; }

    public string Plot { get; }

    public List<string> Languages { get; }
    
    public List<string> VideoUris { get; }
}