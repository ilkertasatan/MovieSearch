using MovieSearch.Domain.ValueObjects;

namespace MovieSearch.Domain.Movies;

public class Movie : IMaybeExist
{
    private readonly List<Genre> _genres = [];
    private readonly List<Director> _directors = [];
    private readonly List<Writer> _writers = [];
    private readonly List<Actor> _actors = [];
    private readonly List<Language> _languages = [];
    private readonly List<VideoUri> _videoUris = [];

    public MovieId MovieId { get;}
    
    public Title Title { get; }

    public Year Year { get; }

    public IReadOnlyCollection<Genre> Genres => _genres;

    public IReadOnlyCollection<Director> Directors => _directors;

    public IReadOnlyCollection<Writer> Writers => _writers;

    public IReadOnlyCollection<Actor> Actors => _actors;

    public Plot Plot { get; }

    public IReadOnlyCollection<Language> Languages => _languages;

    public IReadOnlyCollection<VideoUri> VideoUris => _videoUris;

    public static Movie New(
        MovieId movieId,
        Title title,
        Year year,
        IEnumerable<Genre> genres,
        IEnumerable<Director> directors,
        IEnumerable<Writer> writers,
        IEnumerable<Actor> actors,
        Plot plot,
        IEnumerable<Language> languages)
    {
        return new Movie(
            movieId,
            title,
            year,
            genres,
            directors,
            writers,
            actors,
            plot,
            languages);
    }
    
    public void AddVideoUris(IEnumerable<VideoUri> videoUris)
    {
        _videoUris.AddRange(videoUris);
    }

    public bool Exists()
    {
        return MovieId.IsEmpty();
    }

    private Movie(
        MovieId movieId,
        Title title,
        Year year,
        IEnumerable<Genre> genres,
        IEnumerable<Director> directors,
        IEnumerable<Writer> writers,
        IEnumerable<Actor> actors,
        Plot plot,
        IEnumerable<Language> languages)
    {
        Title = title;
        Year = year;
        _genres.AddRange(genres);
        _directors.AddRange(directors);
        _writers.AddRange(writers);
        _actors.AddRange(actors);
        Plot = plot;
        _languages.AddRange(languages);
    }
}