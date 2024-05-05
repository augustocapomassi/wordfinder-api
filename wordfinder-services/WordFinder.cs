namespace WordFinder.Services;

internal class WordFinder(IEnumerable<string> matrix)
{
    private readonly char[,] matrix = ConvertToGrid(matrix.ToArray());

    static char[,] ConvertToGrid(string[] matrix)
    {
        int rows = matrix.Count();
        int cols = matrix.First().Length;

        char[,] grid = new char[rows, cols];

        int i = 0;
        foreach (string row in matrix)
        {
            for (int j = 0; j < cols; j++)
            {
                grid[i, j] = row[j];
            }
            i++;
        }

        return grid;
    }

    public IEnumerable<string> Find(IEnumerable<string> wordsToFind)
    {
        var wordsCount = new Dictionary<string, int>();

        int rows = this.matrix.GetLength(0);
        int cols = this.matrix.GetLength(1);

        foreach (string word in wordsToFind)
        {
            this.CheckHorizontally(wordsCount, rows, cols, word);

            this.CheckVertically(wordsCount, rows, cols, word);
        }

        return wordsCount.OrderByDescending(kv => kv.Value)
            .Take(10)
            .Select(kv => kv.Key);
    }

    private void CheckHorizontally(Dictionary<string, int> wordsCount, int rows, int cols, string word)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j <= cols - word.Length; j++)
            {
                string horizontal = string.Empty;
                for (int k = 0; k < word.Length; k++)
                {
                    horizontal += this.matrix[i, j + k];
                }
                if (horizontal == word)
                {
                    AddWordAndIncreaseCounter(wordsCount, word);
                    break;
                }
            }
        }
    }

    private void CheckVertically(Dictionary<string, int> wordsCount, int rows, int cols, string word)
    {
        for (int i = 0; i < cols; i++)
        {
            for (int j = 0; j <= rows - word.Length; j++)
            {
                string vertical = string.Empty;
                for (int k = 0; k < word.Length; k++)
                {
                    vertical += this.matrix[j + k, i];
                }
                if (vertical == word)
                {
                    AddWordAndIncreaseCounter(wordsCount, word);
                    break;
                }
            }
        }
    }

    private static void AddWordAndIncreaseCounter(Dictionary<string, int> wordCounter, string word)
    {
        if (wordCounter.TryGetValue(word, out _))
        {
            wordCounter[word]++;

            return;
        }

        wordCounter[word] = 1;
    }
}