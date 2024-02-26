using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Instant;
using Undersoft.SDK.Instant.Series;
using Undersoft.SDK.Stocks;
using Undersoft.SDK.Uniques;
using T = System.String;

namespace Undersoft.SDK.UnitTests.Stocks;

/// <summary>
/// Unit tests for the type <see cref="Stock"/>.
/// </summary>
public class Stock_1Tests
{
    private Stock<T> _testClass;
    private IFixture _fixture;
    private Mock<IInstantSeries> _instantSeries;
    private StockOptions<T> _optionsStockOptionsT;
    private Action<StockOptions<T>> _optionsActionStockOptionsT;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Stock"/>.
    /// </summary>
    public Stock_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._instantSeries = _fixture.Freeze<Mock<IInstantSeries>>();
        this._optionsStockOptionsT = _fixture.Create<StockOptions<T>>();
        this._optionsActionStockOptionsT = x => { };
        this._testClass = _fixture.Create<Stock<T>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new Stock<T>();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Stock<T>(this._instantSeries.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Stock<T>(this._optionsStockOptionsT);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Stock<T>(this._optionsActionStockOptionsT);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the instantSeries parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullInstantSeries()
    {
        FluentActions.Invoking(() => new Stock<T>(default(IInstantSeries))).Should().Throw<ArgumentNullException>().WithParameterName("instantSeries");
    }

    /// <summary>
    /// Checks that instance construction throws when the options parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullOptions()
    {
        FluentActions.Invoking(() => new Stock<T>(default(StockOptions<T>))).Should().Throw<ArgumentNullException>().WithParameterName("options");
        FluentActions.Invoking(() => new Stock<T>(default(Action<StockOptions<T>>))).Should().Throw<ArgumentNullException>().WithParameterName("options");
    }
}

/// <summary>
/// Unit tests for the type <see cref="Stock"/>.
/// </summary>
public class StockTests
{
    private Stock _testClass;
    private IFixture _fixture;
    private Mock<IInstantSeries> _instantSeries;
    private Type _type;
    private StockOptions _optionsStockOptions;
    private Action<StockOptions> _optionsActionStockOptions;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Stock"/>.
    /// </summary>
    public StockTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._instantSeries = _fixture.Freeze<Mock<IInstantSeries>>();
        this._type = _fixture.Create<Type>();
        this._optionsStockOptions = _fixture.Create<StockOptions>();
        this._optionsActionStockOptions = x => { };
        this._testClass = _fixture.Create<Stock>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new Stock();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Stock(this._instantSeries.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Stock(this._type);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Stock(this._optionsStockOptions);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Stock(this._optionsActionStockOptions);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the instantSeries parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullInstantSeries()
    {
        FluentActions.Invoking(() => new Stock(default(IInstantSeries))).Should().Throw<ArgumentNullException>().WithParameterName("instantSeries");
    }

    /// <summary>
    /// Checks that instance construction throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullType()
    {
        FluentActions.Invoking(() => new Stock(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that instance construction throws when the options parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullOptions()
    {
        FluentActions.Invoking(() => new Stock(default(StockOptions))).Should().Throw<ArgumentNullException>().WithParameterName("options");
        FluentActions.Invoking(() => new Stock(default(Action<StockOptions>))).Should().Throw<ArgumentNullException>().WithParameterName("options");
    }

    /// <summary>
    /// Checks that the SetInstantSeriesCreator method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetInstantSeriesCreator()
    {
        // Arrange
        var instantSeries = _fixture.Create<IInstantSeries>();

        _optionsStockOptions.Setup(mock => mock.Type).Returns(_fixture.Create<Type>());
        _optionsStockOptions.Setup(mock => mock.InstantSize).Returns(_fixture.Create<int>());

        // Act
        this._testClass.SetInstantSeriesCreator(instantSeries);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetInstantSeriesCreator method throws when the instantSeries parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetInstantSeriesCreatorWithNullInstantSeries()
    {
        FluentActions.Invoking(() => this._testClass.SetInstantSeriesCreator(default(IInstantSeries))).Should().Throw<ArgumentNullException>().WithParameterName("instantSeries");
    }

    /// <summary>
    /// Checks that the Write method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallWrite()
    {
        // Act
        this._testClass.Write();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Read method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRead()
    {
        // Act
        this._testClass.Read();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Open method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallOpen()
    {
        // Act
        this._testClass.Open();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Close method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallClose()
    {
        // Act
        this._testClass.Close();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGet()
    {
        // Arrange
        var serialcode = _fixture.Create<Uscn>();

        // Act
        var result = this._testClass.Get(serialcode);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Set method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSet()
    {
        // Arrange
        var figure = _fixture.Create<IInstant>();

        // Act
        var result = this._testClass.Set(figure);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Set method throws when the figure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetWithNullFigure()
    {
        FluentActions.Invoking(() => this._testClass.Set(default(IInstant))).Should().Throw<ArgumentNullException>().WithParameterName("figure");
    }

    /// <summary>
    /// Checks that the GetSector method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetSectorWithIndexAndZyx()
    {
        // Arrange
        var index = _fixture.Create<ulong>();

        // Act
        var result = this._testClass.GetSector(index, out var zyx);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetSector method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetSectorWithUscn()
    {
        // Arrange
        var serialcode = _fixture.Create<Uscn>();

        // Act
        var result = this._testClass.GetSector(serialcode);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetSector method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetSectorWithIInstant()
    {
        // Arrange
        var figure = _fixture.Create<IInstant>();

        // Act
        var result = this._testClass.GetSector(figure);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetSector method throws when the figure parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetSectorWithIInstantWithNullFigure()
    {
        FluentActions.Invoking(() => this._testClass.GetSector(default(IInstant))).Should().Throw<ArgumentNullException>().WithParameterName("figure");
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForIntAndString()
    {
        var testValue = _fixture.Create<object>();
        this._testClass[_fixture.Create<int>(), _fixture.Create<string>()].Should().BeAssignableTo<object>();
        this._testClass[_fixture.Create<int>(), _fixture.Create<string>()] = testValue;
        this._testClass[_fixture.Create<int>(), _fixture.Create<string>()].Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForIntAndInt()
    {
        var testValue = _fixture.Create<object>();
        this._testClass[_fixture.Create<int>(), _fixture.Create<int>()].Should().BeAssignableTo<object>();
        this._testClass[_fixture.Create<int>(), _fixture.Create<int>()] = testValue;
        this._testClass[_fixture.Create<int>(), _fixture.Create<int>()].Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForIntAndIntAndType()
    {
        var testValue = _fixture.Create<object>();
        this._testClass[_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<Type>()].Should().BeAssignableTo<object>();
        this._testClass[_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<Type>()] = testValue;
        this._testClass[_fixture.Create<int>(), _fixture.Create<int>(), _fixture.Create<Type>()].Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForInt()
    {
        var testValue = _fixture.Create<object>();
        this._testClass[_fixture.Create<int>()].Should().BeAssignableTo<object>();
        this._testClass[_fixture.Create<int>()] = testValue;
        this._testClass[_fixture.Create<int>()].Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexerForUscn()
    {
        var testValue = _fixture.Create<object>();
        this._testClass[_fixture.Create<Uscn>()].Should().BeAssignableTo<object>();
        this._testClass[_fixture.Create<Uscn>()] = testValue;
        this._testClass[_fixture.Create<Uscn>()].Should().BeSameAs(testValue);
    }
}