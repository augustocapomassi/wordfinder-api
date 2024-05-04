namespace WordFinder.Services;

internal interface IWordFinderFactory
{
    Task<WordFinder> Create(IEnumerable<string> matrix);
}