using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Rubrics;
using Undersoft.SDK.Series;

namespace Undersoft.SDK.UnitTests.Rubrics;

/// <summary>
/// Unit tests for the type <see cref="RubricSqlMappings"/>.
/// </summary>
public class RubricSqlMappingsTests
{
    private RubricSqlMappings _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RubricSqlMappings"/>.
    /// </summary>
    public RubricSqlMappingsTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<RubricSqlMappings>();
    }

    /// <summary>
    /// Checks that the EmptyVector method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEmptyVector()
    {
        // Arrange
        var size = _fixture.Create<int>();

        // Act
        var result = this._testClass.EmptyVector(size);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the EmptyItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEmptyItem()
    {
        // Act
        var result = this._testClass.EmptyItem();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the EmptyTable method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEmptyTable()
    {
        // Arrange
        var size = _fixture.Create<int>();

        // Act
        var result = this._testClass.EmptyTable(size);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewItemWithRubricSqlMapping()
    {
        // Arrange
        var value = _fixture.Create<RubricSqlMapping>();

        // Act
        var result = this._testClass.NewItem(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewItem method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewItemWithRubricSqlMappingWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.NewItem(default(RubricSqlMapping))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the NewItem maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void NewItemWithRubricSqlMappingPerformsMapping()
    {
        // Arrange
        var value = _fixture.Create<RubricSqlMapping>();

        // Act
        var result = this._testClass.NewItem(value);

        // Assert
        result.Value.Should().BeSameAs(value);
    }

    /// <summary>
    /// Checks that the NewItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewItemWithISeriesItemOfRubricSqlMapping()
    {
        // Arrange
        var value = _fixture.Create<ISeriesItem<RubricSqlMapping>>();

        // Act
        var result = this._testClass.NewItem(value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewItem method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewItemWithISeriesItemOfRubricSqlMappingWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.NewItem(default(ISeriesItem<RubricSqlMapping>))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the NewItem maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void NewItemWithISeriesItemOfRubricSqlMappingPerformsMapping()
    {
        // Arrange
        var value = _fixture.Create<ISeriesItem<RubricSqlMapping>>();

        // Act
        var result = this._testClass.NewItem(value);

        // Assert
        result.Value.Should().BeSameAs(value);
    }

    /// <summary>
    /// Checks that the NewItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewItemWithObjectAndRubricSqlMapping()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var value = _fixture.Create<RubricSqlMapping>();

        // Act
        var result = this._testClass.NewItem(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewItem method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewItemWithObjectAndRubricSqlMappingWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.NewItem(default(object), _fixture.Create<RubricSqlMapping>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the NewItem method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewItemWithObjectAndRubricSqlMappingWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.NewItem(_fixture.Create<object>(), default(RubricSqlMapping))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the NewItem maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void NewItemWithObjectAndRubricSqlMappingPerformsMapping()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var value = _fixture.Create<RubricSqlMapping>();

        // Act
        var result = this._testClass.NewItem(key, value);

        // Assert
        result.Value.Should().BeSameAs(value);
    }

    /// <summary>
    /// Checks that the NewItem method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNewItemWithLongAndRubricSqlMapping()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var value = _fixture.Create<RubricSqlMapping>();

        // Act
        var result = this._testClass.NewItem(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the NewItem method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallNewItemWithLongAndRubricSqlMappingWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.NewItem(_fixture.Create<long>(), default(RubricSqlMapping))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the NewItem maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void NewItemWithLongAndRubricSqlMappingPerformsMapping()
    {
        // Arrange
        var key = _fixture.Create<long>();
        var value = _fixture.Create<RubricSqlMapping>();

        // Act
        var result = this._testClass.NewItem(key, value);

        // Assert
        result.Value.Should().BeSameAs(value);
    }
}