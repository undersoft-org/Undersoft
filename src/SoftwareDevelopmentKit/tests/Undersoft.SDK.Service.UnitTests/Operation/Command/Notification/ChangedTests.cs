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
/// Unit tests for the type <see cref="Changed"/>.
/// </summary>
public class Changed_3Tests
{
    private Changed<TStore, TEntity, TDto> _testClass;
    private IFixture _fixture;
    private Command<TDto> _commandCommandTDto;
    private Change<TStore, TEntity, TDto> _commandChangeTStoreTEntityTDto;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Changed"/>.
    /// </summary>
    public Changed_3Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._commandCommandTDto = _fixture.Create<Command<TDto>>();
        this._commandChangeTStoreTEntityTDto = _fixture.Create<Change<TStore, TEntity, TDto>>();
        this._testClass = _fixture.Create<Changed<TStore, TEntity, TDto>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new Changed<TStore, TEntity, TDto>(this._commandCommandTDto);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Changed<TStore, TEntity, TDto>(this._commandChangeTStoreTEntityTDto);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the command parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCommand()
    {
        FluentActions.Invoking(() => new Changed<TStore, TEntity, TDto>(default(Command<TDto>))).Should().Throw<ArgumentNullException>().WithParameterName("command");
        FluentActions.Invoking(() => new Changed<TStore, TEntity, TDto>(default(Change<TStore, TEntity, TDto>))).Should().Throw<ArgumentNullException>().WithParameterName("command");
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