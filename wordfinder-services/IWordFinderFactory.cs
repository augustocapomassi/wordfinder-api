namespace WordFinder.Services;

internal interface IWordFinderFactory
{
    Task<WordFinder> Create(string[] matrix);
}