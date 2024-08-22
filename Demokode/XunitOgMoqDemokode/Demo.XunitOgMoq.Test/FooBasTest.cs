using Demo.XunitOgMoq.BusinessLogic;
using Moq;

namespace Demo.XunitOgMoq.Test
{
    public class FooBasTest
    {
        [Theory]
        [InlineData("Hello", "HelloBar")]
        [InlineData("Chokolade", "ChokoladeBar")]
        public void Bar_GetBarTest(string foo, string expected)
        {
            var mockFoo = new Mock<IFoo>();
            mockFoo.Setup(foo => foo.GetFoo()).Returns(foo);
            var bar = new Bar(mockFoo.Object);
            var result = bar.GetBar();
            Assert.Equal(expected, result);

        }
    }
}