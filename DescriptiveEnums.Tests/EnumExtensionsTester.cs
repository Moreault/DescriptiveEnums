using Newtonsoft.Json.Linq;

namespace DescriptiveEnums.Tests;

[TestClass]
public class EnumExtensionsTester
{
    [TestClass]
    public class GetDescription : Tester
    {
        [TestMethod]
        public void WhenEnumIsNull_Throw()
        {
            //Arrange
            DummyEnum? value = null;

            //Act
            var action = () => value.GetDescription();

            //Assert
            action.Should().Throw<ArgumentNullException>().WithParameterName(nameof(value));
        }
        
        [TestMethod]
        [DataRow("It's something", DummyEnum.Something)]
        [DataRow("It's something else!", DummyEnum.SomethingElse)]
        [DataRow("It's the last thing", DummyEnum.OneFinalThing)]
        public void WhenThereIsAssociatedAttribute_ReturnValue(string stringValue, DummyEnum enumValue)
        {
            //Arrange

            //Act
            var result = enumValue.GetDescription();

            //Assert
            result.Should().Be(stringValue);
        }

        [TestMethod]
        public void WhenThereIsNoAssociatedAttribute_Throw()
        {
            //Arrange

            //Act
            var action = () => DummyEnum.AnotherThing.GetDescription();

            //Assert
            action.Should().Throw<Exception>().WithMessage(string.Format(Exceptions.EnumDoesNotHaveDescription, "DummyEnum.AnotherThing"));
        }

        [TestMethod]
        [DataRow("It's something", DummyEnum.Something)]
        [DataRow("It's something else!", DummyEnum.SomethingElse)]
        [DataRow("It's the last thing", DummyEnum.OneFinalThing)]
        public void WhenIsNullableButNotNull_Return(string stringValue, DummyEnum? enumValue)
        {
            //Arrange

            //Act
            var result = enumValue.GetDescription();

            //Assert
            result.Should().Be(stringValue);
        }

        [TestMethod]
        public void WhenEnumContainsDuplicateBaseMemberNames_DoNotThrow()
        {
            //Arrange
            var value = Fixture.Create<EnumWithMemberNames>();

            //Act
            var action = () => value.GetDescription();

            //Assert
            action.Should().NotThrow();
        }
    }

    [TestClass]
    public class TryGetDescription : Tester
    {
        [TestMethod]
        public void WhenEnumIsNull_ReturnEmpty()
        {
            //Arrange
            DummyEnum? value = null;

            //Act
            var result = value.TryGetDescription();

            //Assert
            result.Should().BeEmpty();
        }
        
        [TestMethod]
        [DataRow("It's something", DummyEnum.Something)]
        [DataRow("It's something else!", DummyEnum.SomethingElse)]
        [DataRow("It's the last thing", DummyEnum.OneFinalThing)]
        public void WhenThereIsAssociatedAttribute_ReturnValue(string stringValue, DummyEnum enumValue)
        {
            //Arrange

            //Act
            var result = enumValue.TryGetDescription();

            //Assert
            result.Should().Be(stringValue);
        }

        [TestMethod]
        [DataRow("It's something", DummyEnum.Something)]
        [DataRow("It's something else!", DummyEnum.SomethingElse)]
        [DataRow("It's the last thing", DummyEnum.OneFinalThing)]
        public void WhenThereIsAssociatedAttributeOnNullable_ReturnValue(string stringValue, DummyEnum? enumValue)
        {
            //Arrange

            //Act
            var result = enumValue.TryGetDescription();

            //Assert
            result.Should().Be(stringValue);
        }

        [TestMethod]
        public void WhenThereIsNoAssociatedAttribute_ReturnRegularToString()
        {
            //Arrange

            //Act
            var result = DummyEnum.AnotherThing.TryGetDescription();

            //Assert
            result.Should().Be("AnotherThing");
        }

        [TestMethod]
        public void WhenThereIsNoAssociatedAttributeOnNullable_ReturnRegularToString()
        {
            //Arrange
            DummyEnum? value = DummyEnum.AnotherThing;

            //Act
            var result = value.TryGetDescription();

            //Assert
            result.Should().Be("AnotherThing");
        }
    }
    
    [TestClass]
    public class ThrowIfUndefined : Tester
    {
        [TestMethod]
        public void WhenValueIsUndefined_Throw()
        {
            //Arrange
            var value = (DummyEnum)(-14);

            //Act
            var action = () => value.ThrowIfUndefined();

            //Assert
            action.Should().Throw<ArgumentException>().WithMessage(string.Format(Exceptions.EnumValueIsUndefined, value, typeof(DummyEnum)));
        }

        [TestMethod]
        public void WhenValueIsUndefinedWithCustomMessage_ThrowWithCustomMessage()
        {
            //Arrange
            var value = (DummyEnum)(-14);
            var message = Fixture.Create<string>();

            //Act
            var action = () => value.ThrowIfUndefined(message);

            //Assert
            action.Should().Throw<ArgumentException>().WithMessage(message);
        }

        [TestMethod]
        public void WhenValueIsDefined_DoNotThrow()
        {
            //Arrange
            var value = Fixture.Create<DummyEnum>();

            //Act
            var action = () => value.ThrowIfUndefined();

            //Assert
            action.Should().NotThrow();
        }

        [TestMethod]
        public void WhenValueIsDefined_ReturnValueThatWasPassed()
        {
            //Arrange
            var value = Fixture.Create<DummyEnum>();

            //Act
            var result = value.ThrowIfUndefined();

            //Assert
            result.Should().Be(value);
        }

        [TestMethod]
        public void WhenValueIsNullableAndDefined_ReturnValueThatWasPassed()
        {
            //Arrange
            var value = Fixture.Create<DummyEnum>();

            //Act
            var result = value.ThrowIfUndefined();

            //Assert
            result.Should().Be(value);
        }
    }

    [TestClass]
    public class ThrowIfUndefined_Nullable : Tester
    {
        [TestMethod]
        public void WhenValueIsNull_Throw()
        {
            //Arrange
            DummyEnum? value = null!;

            //Act
            var action = () => value.ThrowIfUndefined();

            //Assert
            action.Should().Throw<ArgumentNullException>().WithParameterName(nameof(value));
        }

        [TestMethod]
        public void WhenValueIsUndefined_Throw()
        {
            //Arrange
            var value = (DummyEnum?)(-14);

            //Act
            var action = () => value.ThrowIfUndefined();

            //Assert
            action.Should().Throw<ArgumentException>().WithMessage(string.Format(Exceptions.EnumValueIsUndefined, value, typeof(DummyEnum)));
        }

        [TestMethod]
        public void WhenValueIsUndefinedWithCustomMessage_ThrowWithCustomMessage()
        {
            //Arrange
            var value = (DummyEnum?)(-14);
            var message = Fixture.Create<string>();

            //Act
            var action = () => value.ThrowIfUndefined(message);

            //Assert
            action.Should().Throw<ArgumentException>().WithMessage(message);
        }

        [TestMethod]
        public void WhenValueIsDefined_DoNotThrow()
        {
            //Arrange
            var value = Fixture.Create<DummyEnum?>();

            //Act
            var action = () => value.ThrowIfUndefined();

            //Assert
            action.Should().NotThrow();
        }

        [TestMethod]
        public void WhenValueIsDefined_ReturnValueThatWasPassed()
        {
            //Arrange
            var value = Fixture.Create<DummyEnum?>();

            //Act
            var result = value.ThrowIfUndefined();

            //Assert
            result.Should().Be(value);
        }

        [TestMethod]
        public void WhenValueIsNullableAndDefined_ReturnValueThatWasPassed()
        {
            //Arrange
            var value = Fixture.Create<DummyEnum?>();

            //Act
            var result = value.ThrowIfUndefined();

            //Assert
            result.Should().Be(value);
        }
    }
}