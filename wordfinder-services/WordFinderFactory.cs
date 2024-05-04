namespace WordFinder.Services;

internal class WordFinderFactory : IWordFinderFactory
{
    public Task<WordFinder> Create(IEnumerable<string> matrix)
    {
        return Task.FromResult(new WordFinder(matrix));
    }
}