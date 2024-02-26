using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Undersoft.SDK.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="TypeExtensions"/>.
/// </summary>
public class TypeExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the Default method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDefault()
    {
        // Arrange
        var @type = _fixture.Create<Type>();

        // Act
        var result = type.Default();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Default method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDefaultWithNullType()
    {
        FluentActions.Invoking(() => default(Type).Default()).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the DefaultHighBits method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallDefaultHighBits()
    {
        // Arrange
        var @type = _fixture.Create<Type>();

        // Act
        var result = type.DefaultHighBits();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the DefaultHighBits method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallDefaultHighBitsWithNullType()
    {
        FluentActions.Invoking(() => default(Type).DefaultHighBits()).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the GetEnumerableElementType method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetEnumerableElementType()
    {
        // Arrange
        var seqType = _fixture.Create<Type>();

        // Act
        var result = seqType.GetEnumerableElementType();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetEnumerableElementType method throws when the seqType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetEnumerableElementTypeWithNullSeqType()
    {
        FluentActions.Invoking(() => default(Type).GetEnumerableElementType()).Should().Throw<ArgumentNullException>().WithParameterName("seqType");
    }

    /// <summary>
    /// Checks that the GetGenericMethod method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetGenericMethod()
    {
        // Arrange
        var owner = _fixture.Create<Type>();
        var methodName = _fixture.Create<string>();

        // Act
        var result = owner.GetGenericMethod(methodName);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetGenericMethod method throws when the owner parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetGenericMethodWithNullOwner()
    {
        FluentActions.Invoking(() => default(Type).GetGenericMethod(_fixture.Create<string>())).Should().Throw<ArgumentNullException>().WithParameterName("owner");
    }

    /// <summary>
    /// Checks that the GetGenericMethod method throws when the methodName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetGenericMethodWithInvalidMethodName(string value)
    {
        FluentActions.Invoking(() => _fixture.Create<Type>().GetGenericMethod(value)).Should().Throw<ArgumentNullException>().WithParameterName("methodName");
    }

    /// <summary>
    /// Checks that the GetGenericMethod maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void GetGenericMethodPerformsMapping()
    {
        // Arrange
        var owner = _fixture.Create<Type>();
        var methodName = _fixture.Create<string>();

        // Act
        var result = owner.GetGenericMethod(methodName);

        // Assert
        result.MemberType.Should().Be(owner.MemberType);
    }

    /// <summary>
    /// Checks that the GetImplementedGenericTypes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetImplementedGenericTypes()
    {
        // Arrange
        var seqType = _fixture.Create<Type>();

        // Act
        var result = seqType.GetImplementedGenericTypes();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetImplementedGenericTypes method throws when the seqType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetImplementedGenericTypesWithNullSeqType()
    {
        FluentActions.Invoking(() => default(Type).GetImplementedGenericTypes()).Should().Throw<ArgumentNullException>().WithParameterName("seqType");
    }

    /// <summary>
    /// Checks that the GetAssignableTypes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetAssignableTypes()
    {
        // Arrange
        var seqType = _fixture.Create<Type>();

        // Act
        var result = seqType.GetAssignableTypes();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetAssignableTypes method throws when the seqType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetAssignableTypesWithNullSeqType()
    {
        FluentActions.Invoking(() => default(Type).GetAssignableTypes()).Should().Throw<ArgumentNullException>().WithParameterName("seqType");
    }
}