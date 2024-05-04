namespace WordFinder.Services;

internal class WordFinderService : IWordFinderService
{
    private readonly IWordFinderFactory wordFinderFactory;
    private WordFinder? wordFinder;

    public WordFinderService(IWordFinderFactory wordFinderFactory)
    {
        this.wordFinderFactory = wordFinderFactory;
    }

    public async ValueTask<IEnumerable<string>> FindWords(IEnumerable<string> wordsToFind)
    {
        if (wordFinderFactory == null)
        {
            throw new ArgumentNullException(nameof(wordFinderFactory));
        }

        var foundWords = wordFinder!.Find(wordsToFind);

        return foundWords;
    }

    public async Task SetMatrix(IEnumerable<string> matrix)
    {
        wordFinder = await wordFinderFactory.Create(matrix);
    }
}

