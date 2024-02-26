using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Invoking;
using Undersoft.SDK.Service.Operation.Remote.Invocation;
using TModel = System.String;
using TService = System.String;
using TStore = System.String;

namespace Undersoft.SDK.Service.UnitTests.Operation.Remote.Invocation;

/// <summary>
/// Unit tests for the type <see cref="RemoteAction"/>.
/// </summary>
public class RemoteAction_3Tests
{
    private RemoteAction<TStore, TService, TModel> _testClass;
    private IFixture _fixture;
    private string _method;
    private object _argument;
    private Arguments _argumentsArguments;
    private object[] _argumentsUnknownType;
    private byte[] _argumentsUnknownType;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RemoteAction"/>.
    /// </summary>
    public RemoteAction_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._method = _fixture.Create<string>();
        this._argument = _fixture.Create<object>();
        this._argumentsArguments = _fixture.Create<Arguments>();
        this._argumentsUnknownType = _fixture.Create<object[]>();
        this._argumentsUnknownType = _fixture.Create<byte[]>();
        this._testClass = _fixture.Create<RemoteAction<TStore, TService, TModel>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RemoteAction<TStore, TService, TModel>();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RemoteAction<TStore, TService, TModel>(this._method, this._argument);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RemoteAction<TStore, TService, TModel>(this._method, this._argumentsArguments);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RemoteAction<TStore, TService, TModel>(this._method, this._argumentsUnknownType);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new RemoteAction<TStore, TService, TModel>(this._method, this._argumentsUnknownType);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the argument parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullArgument()
    {
        FluentActions.Invoking(() => new RemoteAction<TStore, TService, TModel>(this._method, default(object))).Should().Throw<ArgumentNullException>().WithParameterName("argument");
    }

    /// <summary>
    /// Checks that instance construction throws when the arguments parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullArguments()
    {
        FluentActions.Invoking(() => new RemoteAction<TStore, TService, TModel>(this._method, default(Arguments))).Should().Throw<ArgumentNullException>().WithParameterName("arguments");
        FluentActions.Invoking(() => new RemoteAction<TStore, TService, TModel>(this._method, default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("arguments");
        FluentActions.Invoking(() => new RemoteAction<TStore, TService, TModel>(this._method, default(byte[]))).Should().Throw<ArgumentNullException>().WithParameterName("arguments");
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
        FluentActions.Invoking(() => new RemoteAction<TStore, TService, TModel>(value, this._argument)).Should().Throw<ArgumentNullException>().WithParameterName("method");
        FluentActions.Invoking(() => new RemoteAction<TStore, TService, TModel>(value, this._argumentsArguments)).Should().Throw<ArgumentNullException>().WithParameterName("method");
        FluentActions.Invoking(() => new RemoteAction<TStore, TService, TModel>(value, this._argumentsUnknownType)).Should().Throw<ArgumentNullException>().WithParameterName("method");
        FluentActions.Invoking(() => new RemoteAction<TStore, TService, TModel>(value, this._argumentsUnknownType)).Should().Throw<ArgumentNullException>().WithParameterName("method");
    }
}