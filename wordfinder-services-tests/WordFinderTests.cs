using FluentAssertions;
using Xunit;

namespace WordFinder.Services.Tests;

public class WordFinderServiceTests
{
    [Fact]
    public void Find_ShouldReturnTop10WordsInTheCorrespondingOrder_WhenWordsHorizontalAreFound()
    {
        // Arrange
        string[] wordsToFind = ["chill", "cold", "wind"];
        string[] matrix = [
            "chill",
            "coldx",
            "windx",
            "chill",
            "chill",
            "coldx",
            "coldx",
            "coldx",
            "windx"];
        var finder = new WordFinder(matrix);

        // Act
        var foundWords = finder.Find(wordsToFind).ToArray();

        // Assert
        foundWords.Count().Should().Be(3);
        foundWords[0].Should().Be("cold");
        foundWords[1].Should().Be("chill");
        foundWords[2].Should().Be("wind");
    }

    [Fact]
    public void Find_ShouldReturnTop10WordsInTheCorrespondingOrder_WhenWordsVerticalAreFound()
    {
        // Arrange
        string[] wordsToFind = ["chill", "cold", "wind"];
        string[] matrix = [
            "cxchal",
            "hxcold",
            "ixwind",
            "lxcsil",
            "lchill",
            "coldtx",
            "coldrt"
            ];
        var finder = new WordFinder(matrix);

        // Act
        var foundWords = finder.Find(wordsToFind).ToArray();

        // Assert
        foundWords.Count().Should().Be(3);
        foundWords[0].Should().Be("cold");
        foundWords[1].Should().Be("chill");
        foundWords[2].Should().Be("wind");
    }

    [Fact]
    public void Find_ShouldReturnEmptyList_WhenNoWordsFound()
    {
        // Arrange
        IEnumerable<string> matrix = ["abcd", "efgh", "ijkl"];
        IEnumerable<string> wordstream = ["mnop", "qrst", "uvwx"];
        var finder = new WordFinder(matrix);

        // Act
        var foundWords = finder.Find(wordstream);

        // Assert
        foundWords.Should().BeEmpty();
    }
}