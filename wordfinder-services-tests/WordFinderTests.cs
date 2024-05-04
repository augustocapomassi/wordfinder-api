using AutoFixture;
using AutoFixture.AutoMoq;
using Xunit;

namespace WordFinder.Services.Tests;

public class WordFinderServiceTests
{
    private readonly IFixture fixture = new Fixture().Customize(new AutoMoqCustomization { ConfigureMembers = true });

    [Fact]
    public void Find_ShouldReturnTop10Words_WhenWordsAreFound()
    {
        // Arrange
        var matrix = new List<string> { "chill", "crrld", "olwdd", "cold" };
        var wordstream = new List<string> { "chill", "cold", "wind", "chill", "chill", "cold", "cold", "cold", "cold", "wind" };
        var finder = new WordFinder(matrix);

        // Act
        var foundWords = finder.Find(wordstream);

        // Assert
        Assert.Equal(2, foundWords.Count());
        Assert.Contains("chill", foundWords);
        Assert.Contains("cold", foundWords);
    }

    [Fact]
    public void Find_ShouldReturnEmptyList_WhenNoWordsFound()
    {
        // Arrange
        var matrix = new List<string> { "abcd", "efgh", "ijkl" };
        var wordstream = new List<string> { "mnop", "qrst", "uvwx" };
        var finder = new WordFinder(matrix);

        // Act
        var foundWords = finder.Find(wordstream);

        // Assert
        Assert.Empty(foundWords);
    }
}