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
/// Unit tests for the type <see cref="CreatedSet"/>.
/// </summary>
public class CreatedSet_3Tests
{
    private CreatedSet<TStore, TEntity, TDto> _testClass;
    private IFixture _fixture;
    private CreateSet<TStore, TEntity, TDto> _commands;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="CreatedSet"/>.
    /// </summary>
    public CreatedSet_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._commands = _fixture.Create<CreateSet<TStore, TEntity, TDto>>();
        this._testClass = _fixture.Create<CreatedSet<TStore, TEntity, TDto>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new CreatedSet<TStore, TEntity, TDto>();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new CreatedSet<TStore, TEntity, TDto>(this._commands);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the commands parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCommands()
    {
        FluentActions.Invoking(() => new CreatedSet<TStore, TEntity, TDto>(default(CreateSet<TStore, TEntity, TDto>))).Should().Throw<ArgumentNullException>().WithParameterName("commands");
    }

    /// <summary>
    /// Checks that the Predicate property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPredicate()
    {
        // Assert
        this._testClass.Predicate.Should().BeAssignableTo<Func<TEntity, Expression<Func<TEntity, bool>>>>();

        Assert.Fail("Create or modify test");
    }
}