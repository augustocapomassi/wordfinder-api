namespace WordFinder.Services;

internal class WordFinderFactory : IWordFinderFactory
{
    public Task<WordFinder> Create(string[] matrix)
    {
        var length = matrix.First().Length;

        if (length > 64 || matrix.Count() > 64)
        {
            throw new ArgumentOutOfRangeException($"Matrix length {length} cannot be greater than 64x64");
        }

        foreach (var word in matrix) 
        {
            if (!word.Length.Equals(length))
            {
                throw new ArgumentException($"Invalid word length inside the matrix, all words should be of length {length} and {word} is of length {word.Length}");
            }
        }

        return Task.FromResult(new WordFinder(matrix));
    }
}