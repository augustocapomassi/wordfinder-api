namespace WordFinder.Services;

public interface IWordFinderService
{
    public Task SetMatrix(IEnumerable<string> matrix);

    public ValueTask<IEnumerable<string>> FindWords(IEnumerable<string> wordsToFind);
}

