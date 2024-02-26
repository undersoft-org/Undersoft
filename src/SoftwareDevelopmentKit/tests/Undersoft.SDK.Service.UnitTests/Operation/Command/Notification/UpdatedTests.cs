using System;
using System.Linq.Expressions;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Operation.Command;
using Undersoft.SDK.Service.Operation.Command.Notification;
using TDto = Undersoft.SDK.Stocks.StockContext;
using TEntity = Undersoft.SDK.Stocks.StockContext;
using TStore = System.String;

namespace Undersoft.SDK.Service.UnitTests.Operation.Command.Notification;

/// <summary>
/// Unit tests for the type <see cref="Updated"/>.
/// </summary>
public class Updated_3Tests
{
    private Updated<TStore, TEntity, TDto> _testClass;
    private IFixture _fixture;
    private Update<TStore, TEntity, TDto> _command;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Updated"/>.
    /// </summary>
    public Updated_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._command = _fixture.Create<Update<TStore, TEntity, TDto>>();
        this._testClass = _fixture.Create<Updated<TStore, TEntity, TDto>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new Updated<TStore, TEntity, TDto>(this._command);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the command parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCommand()
    {
        FluentActions.Invoking(() => new Updated<TStore, TEntity, TDto>(default(Update<TStore, TEntity, TDto>))).Should().Throw<ArgumentNullException>().WithParameterName("command");
    }

    /// <summary>
    /// Checks that the Conditions property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetConditions()
    {
        // Assert
        this._testClass.Conditions.Should().BeAssignableTo<Func<TDto, Expression<Func<TEntity, bool>>>[]>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Predicate property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPredicate()
    {
        // Assert
        this._testClass.Predicate.Should().BeAssignableTo<Func<TDto, Expression<Func<TEntity, bool>>>>();

        Assert.Fail("Create or modify test");
    }
}