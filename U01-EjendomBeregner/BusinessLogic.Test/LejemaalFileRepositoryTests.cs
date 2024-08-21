using EjendomBeregner.BusinessLogic;
using Moq;

namespace BusinessLogic.Test;

public class LejemaalFileRepositoryTests
{
    [Theory]
    [InlineData("1, 5, 2", 1, 5, 2)]
    [InlineData("2, 10.8, 3", 2, 10.8, 3)]
    [InlineData("3, 20.5, 4.5", 3, 20.5, 4.5)]
    public void Given_Csv_Lines_Valid__Then_Lejemaal_Is_Returned(string csvLine, int expectedLejlighednummer,
        double expectedKvadratmeter, double expectedRum)
    {
        // Arrange
        var fileWrapperMock = new Mock<IFileWrapper>();
        fileWrapperMock.Setup(x => x.ReadAllLines(It.IsAny<string>())).Returns(new[] { csvLine });

        var sut = new LejemaalFileRepository(String.Empty, fileWrapperMock.Object);

        // Act
        var actual = sut.HentLejemaal().First();
        // Assert
        Assert.Equal(expectedLejlighednummer, actual.Lejlighednummer);
        Assert.Equal(expectedKvadratmeter, actual.Kvadratmeter, 5);
        Assert.Equal(expectedRum, actual.Rum, 5);
    }
}