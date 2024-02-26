using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK;
using Undersoft.SDK.Invoking;
using Undersoft.SDK.Service.Operation.Invocation;
using Undersoft.SDK.Uniques;
using TDto = System.String;

namespace Undersoft.SDK.Service.UnitTests.Operation.Invocation;

/// <summary>
/// Unit tests for the type <see cref="Invocation"/>.
/// </summary>
public class Invocation_1Tests
{
    private Invocation<TDto> _testClass;
    private IFixture _fixture;
    private OperationType _commandMode;
    private Type _serviceType;
    private string _method;
    private object _argument;
    private Arguments _arguemnts;
    private object[] _arguments;
    private byte[] _binaries;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Invocation"/>.
    /// </summary>
    public Invocation_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._commandMode = _fixture.Create<OperationType>();
        this._serviceType = _fixture.Create<Type>();
        this._method = _fixture.Create<string>();
        this._argument = _fixture.Create<object>();
        this._arguemnts = _fixture.Create<Arguments>();
        this._arguments = _fixture.Create<object[]>();
        this._binaries = _fixture.Create<byte[]>();
        this._testClass = _fixture.Create<Invocation<TDto>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new Invocation<TDto>();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invocation<TDto>(this._commandMode, this._serviceType, this._method, this._argument);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invocation<TDto>(this._commandMode, this._serviceType, this._method, this._arguemnts);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invocation<TDto>(this._commandMode, this._serviceType, this._method, this._arguments);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Invocation<TDto>(this._commandMode, this._serviceType, this._method, this._binaries);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the serviceType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullServiceType()
    {
        FluentActions.Invoking(() => new Invocation<TDto>(this._commandMode, default(Type), this._method, this._argument)).Should().Throw<ArgumentNullException>().WithParameterName("serviceType");
        FluentActions.Invoking(() => new Invocation<TDto>(this._commandMode, default(Type), this._method, this._arguemnts)).Should().Throw<ArgumentNullException>().WithParameterName("serviceType");
        FluentActions.Invoking(() => new Invocation<TDto>(this._commandMode, default(Type), this._method, this._arguments)).Should().Throw<ArgumentNullException>().WithParameterName("serviceType");
        FluentActions.Invoking(() => new Invocation<TDto>(this._commandMode, default(Type), this._method, this._binaries)).Should().Throw<ArgumentNullException>().WithParameterName("serviceType");
    }

    /// <summary>
    /// Checks that instance construction throws when the argument parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullArgument()
    {
        FluentActions.Invoking(() => new Invocation<TDto>(this._commandMode, this._serviceType, this._method, default(object))).Should().Throw<ArgumentNullException>().WithParameterName("argument");
    }

    /// <summary>
    /// Checks that instance construction throws when the arguemnts parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullArguemnts()
    {
        FluentActions.Invoking(() => new Invocation<TDto>(this._commandMode, this._serviceType, this._method, default(Arguments))).Should().Throw<ArgumentNullException>().WithParameterName("arguemnts");
    }

    /// <summary>
    /// Checks that instance construction throws when the arguments parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullArguments()
    {
        FluentActions.Invoking(() => new Invocation<TDto>(this._commandMode, this._serviceType, this._method, default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("arguments");
    }

    /// <summary>
    /// Checks that instance construction throws when the binaries parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullBinaries()
    {
        FluentActions.Invoking(() => new Invocation<TDto>(this._commandMode, this._serviceType, this._method, default(byte[]))).Should().Throw<ArgumentNullException>().WithParameterName("binaries");
    }

    /// <summary>
    /// Checks that the constructor throws when the method parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidMethod(string value)
    {
        FluentActions.Invoking(() => new Invocation<TDto>(this._commandMode, this._serviceType, value, this._argument)).Should().Throw<ArgumentNullException>().WithParameterName("method");
        FluentActions.Invoking(() => new Invocation<TDto>(this._commandMode, this._serviceType, value, this._arguemnts)).Should().Throw<ArgumentNullException>().WithParameterName("method");
        FluentActions.Invoking(() => new Invocation<TDto>(this._commandMode, this._serviceType, value, this._arguments)).Should().Throw<ArgumentNullException>().WithParameterName("method");
        FluentActions.Invoking(() => new Invocation<TDto>(this._commandMode, this._serviceType, value, this._binaries)).Should().Throw<ArgumentNullException>().WithParameterName("method");
    }

    /// <summary>
    /// Checks that the CompareTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompareTo()
    {
        // Arrange
        var other = _fixture.Create<IUnique>();

        // Act
        var result = this._testClass.CompareTo(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompareTo method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompareToWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.CompareTo(default(IUnique))).Should().Throw<ArgumentNullException>().WithParameterName("other");
    }

    /// <summary>
    /// Checks that the Return property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetReturn()
    {
        // Arrange
        var testValue = _fixture.Create<TDto>();

        // Act
        this._testClass.Return = testValue;

        // Assert
        this._testClass.Return.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Id property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetId()
    {
        // Arrange
        var testValue = _fixture.Create<long>();

        // Act
        this._testClass.Id = testValue;

        // Assert
        this._testClass.Id.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the TypeId property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTypeId()
    {
        // Arrange
        var testValue = _fixture.Create<long>();

        // Act
        this._testClass.TypeId = testValue;

        // Assert
        this._testClass.TypeId.Should().Be(testValue);
    }
}