namespace DescriptiveEnums.Tests;

[TestClass]
public sealed class MissingDescriptionExceptionTests : Tester
{
    public enum Garbage
    {
        One,
        Two,
        Three
    }

    [TestMethod]
    public void Constructor_Always_SetValue()
    {
        //Arrange
        var value = Dummy.Create<Garbage>();

        //Act
        var exception = new MissingDescriptionException<Garbage>(value);

        //Assert
        exception.Value.Should().Be(value);
    }

    [TestMethod]
    public void Constructor_Always_SetMessage()
    {
        //Arrange
        var value = Dummy.Create<Garbage>();

        //Act
        var exception = new MissingDescriptionException<Garbage>(value);

        //Assert
        exception.Message.Should().Be(string.Format(Exceptions.EnumDoesNotHaveDescription, $"{nameof(Garbage)}.{value}"));
    }

}