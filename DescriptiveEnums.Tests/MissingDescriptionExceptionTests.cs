namespace DescriptiveEnums.Tests;

[TestClass]
public sealed class MissingDescriptionExceptionTests : Tester
{
    public enum Dummy
    {
        One,
        Two,
        Three
    }

    [TestMethod]
    public void Constructor_Always_SetValue()
    {
        //Arrange
        var value = Fixture.Create<Dummy>();

        //Act
        var exception = new MissingDescriptionException<Dummy>(value);

        //Assert
        exception.Value.Should().Be(value);
    }

    [TestMethod]
    public void Constructor_Always_SetMessage()
    {
        //Arrange
        var value = Fixture.Create<Dummy>();

        //Act
        var exception = new MissingDescriptionException<Dummy>(value);

        //Assert
        exception.Message.Should().Be(string.Format(Exceptions.EnumDoesNotHaveDescription, $"{nameof(Dummy)}.{value}"));
    }

}