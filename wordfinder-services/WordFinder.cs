namespace WordFinder.Services;

internal class WordFinder
{
    private readonly TrieNode root = new TrieNode();

    public WordFinder(IEnumerable<string> matrix)
    {
        foreach (var word in matrix)
        {
            InsertWord(word);
        }
    }

    private void InsertWord(string word)
    {
        var node = root;
        foreach (var ch in word)
        {
            if (!node.Children.TryGetValue(ch, out TrieNode? value))
            {
                value = new TrieNode();
                node.Children[ch] = value;
            }
            node = value;
        }
        node.IsEndOfWord = true;
    }

    public IEnumerable<string> Find(IEnumerable<string> wordstream)
    {
        var wordCounts = new Dictionary<string, int>();

        foreach (var word in wordstream)
        {
            var visited = new HashSet<string>();
            foreach (var position in root.Children.Keys)
            {
                FindWords(word, root.Children[position], position.ToString(), visited, wordCounts);
            }
        }

        return wordCounts.OrderByDescending(kv => kv.Value)
            .Take(10)
            .Select(kv => kv.Key);
    }

    private static void FindWords(
        string word,
        TrieNode node,
        string path,
        HashSet<string> visited,
        Dictionary<string, int> wordCounts)
    {
        if (node.IsEndOfWord && !visited.Contains(path))
        {
            if (!wordCounts.TryGetValue(word, out int value))
            {
                value = 0;
                wordCounts[word] = value;
            }
            wordCounts[word] = ++value;
            visited.Add(path);
        }

        foreach (var position in node.Children.Keys)
        {
            var nextNode = node.Children[position];
            if (word.StartsWith(path + position))
            {
                FindWords(word, nextNode, path + position, visited, wordCounts);
            }
        }
    }

    private class TrieNode
    {
        public Dictionary<char, TrieNode> Children { get; } = [];

        public bool IsEndOfWord { get; set; }
    }
}