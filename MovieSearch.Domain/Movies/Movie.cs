using MovieSearch.Domain.ValueObjects;

namespace MovieSearch.Domain.Movies;

public class Movie
{
    private readonly List<Genre> _genres = [];
    private readonly List<Director> _directors = [];
    private readonly List<Writer> _writers = [];
    private readonly List<Actor> _actors = [];
    private readonly List<Language> _languages = [];
    private readonly List<VideoUrl> _videoUrls = [];
    
    public Title Title { get; }

    public Year Year { get; }

    public IReadOnlyCollection<Genre> Genres => _genres;

    public IReadOnlyCollection<Director> Directors => _directors;

    public IReadOnlyCollection<Writer> Writers => _writers;

    public IReadOnlyCollection<Actor> Actors => _actors;

    public Plot Plot { get; }

    public IReadOnlyCollection<Language> Languages => _languages;

    public IReadOnlyCollection<VideoUrl> VideoUrls => _videoUrls;
    
    private Movie() { }
}