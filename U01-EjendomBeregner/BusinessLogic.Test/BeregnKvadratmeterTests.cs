using EjendomBeregner.BusinessLogic;
using EjendomBeregner.BusinessLogic.Domain;
using EjendomBeregner.BusinessLogic.Infrastructure;
using Moq;

namespace BusinessLogic.Test;

public class BeregnKvadratmeterTests
{
    [Fact]
    public void Kvadratmeter_Sum_Stemmer_Med_Lejemaalsum()
    {
        // Arrange
        var lejemaals = new List<Lejemaal>
        {
            new() { Kvadratmeter = 5 },
            new() { Kvadratmeter = 20 },
            new() { Kvadratmeter = 30 }
        };
        var lejemaalRepositoryMock = new Mock<ILejemaalRepository>();
        lejemaalRepositoryMock.Setup(p => p.HentLejemaal()).Returns(lejemaals);

        var expected = lejemaals.Sum(l => l.Kvadratmeter);
        var sut = new EjendomBeregnerService(lejemaalRepositoryMock.Object);

        // Act 
        var actual = sut.BeregnKvadratmeter();
        // Assert
        Assert.Equal(expected, actual);
    }
}