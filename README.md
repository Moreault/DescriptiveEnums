![DescriptiveEnums](https://github.com/Moreault/DescriptiveEnums/blob/master/descriptiveenums.png)
# DescriptiveEnums
Adds a [Description("Text")] attribute that you can use on enum values and get using the GetDescription method in order to return better-formatted strings than a simple ToString() would.

## Getting started

```c#
public enum MyEnum
{
	[Description("First value")]
	Value1,
	[Description("Second value")]
	Value2,
	[Description("Third value")]
	Value3
}
```

```c#
public void Method(MyEnum value)
{
	//Will return the string of text that is in the enum's [Description] attribute
	var description = value.GetDescription();
	...
	//You can also use TryGetDescription which will never throw an exception and return the enum's ToString() result if it has no [Description]
	var description2 = value.TryGetDescription();
}
```

```c#
public void Method(MyEnum? value)
{
	//Nullable enums are also supported and are used in the exact same way though bear in mind that null enums will throw an exception
	var description = value.GetDescription();
	...
	//Will not throw an exception if it's null. It will return an empty string instead
	var description2 = value.TryGetDescription();
}
```

## Undefined values

```c#
public void Method(MyEnum value)
{
	//What if some bozo tries to pass something like (MyEnum)-8 for which there is no enum member defined?
	value.ThrowIfUndefined(); //Will throw something along the lines of "Value '-8' is undefined for enum 'MyEnum'"

	//Or you can do this if you don't like the above default message
	value.ThrowIfUndefined("Better message!");
}
```

```c#
public MyEnum Value
{
	get => _value;
	//You can also inline it in a set like so
	init => _value = value.ThrowIfUndefined();
}
```