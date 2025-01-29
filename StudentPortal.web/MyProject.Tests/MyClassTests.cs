using Xunit;
using MyProject;

public class MyClassTests
{
    [Fact]
    public void TestMethod()
    {
        // Arrange
        var myClass = new MyClassTests();

        // Act
        var result = myClass.MyMethod();

        // Assert
        Assert.Equal(expected: "Hello, World!", actual: result);
    }

    private IAsyncEnumerable<char>? MyMethod()
    {
        throw new NotImplementedException();
    }
}
