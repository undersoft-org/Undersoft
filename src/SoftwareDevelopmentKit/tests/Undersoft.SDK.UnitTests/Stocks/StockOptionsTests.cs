using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Instant.Series;
using Undersoft.SDK.Stocks;
using T = System.String;

namespace Undersoft.SDK.UnitTests.Stocks;

/// <summary>
/// Unit tests for the type <see cref="StockOptions"/>.
/// </summary>
public class StockOptions_1Tests
{
    private StockOptions<T> _testClass;
    private IFixture _fixture;
    private Mock<IInstantSeries> _instantSeries;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="StockOptions"/>.
    /// </summary>
    public StockOptions_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._instantSeries = _fixture.Freeze<Mock<IInstantSeries>>();
        this._testClass = _fixture.Create<StockOptions<T>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new StockOptions<T>();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new StockOptions<T>(this._instantSeries.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the instantSeries parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullInstantSeries()
    {
        FluentActions.Invoking(() => new StockOptions<T>(default(IInstantSeries))).Should().Throw<ArgumentNullException>().WithParameterName("instantSeries");
    }
}

/// <summary>
/// Unit tests for the type <see cref="StockOptions"/>.
/// </summary>
public class StockOptionsTests
{
    private StockOptions _testClass;
    private IFixture _fixture;
    private Mock<IInstantSeries> _instantSeries;
    private Type _type;
    private int _blockSize;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="StockOptions"/>.
    /// </summary>
    public StockOptionsTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._instantSeries = _fixture.Freeze<Mock<IInstantSeries>>();
        this._type = _fixture.Create<Type>();
        this._blockSize = _fixture.Create<int>();
        this._testClass = _fixture.Create<StockOptions>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new StockOptions();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new StockOptions(this._instantSeries.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new StockOptions(this._type);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new StockOptions(this._type, this._blockSize);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the instantSeries parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullInstantSeries()
    {
        FluentActions.Invoking(() => new StockOptions(default(IInstantSeries))).Should().Throw<ArgumentNullException>().WithParameterName("instantSeries");
    }

    /// <summary>
    /// Checks that instance construction throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullType()
    {
        FluentActions.Invoking(() => new StockOptions(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
        FluentActions.Invoking(() => new StockOptions(default(Type), this._blockSize)).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the InstantSeriesCreator property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetInstantSeriesCreator()
    {
        // Arrange
        var testValue = _fixture.Create<IInstantSeries>();

        // Act
        this._testClass.InstantSeriesCreator = testValue;

        // Assert
        this._testClass.InstantSeriesCreator.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Type property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetType()
    {
        // Arrange
        var testValue = _fixture.Create<Type>();

        // Act
        this._testClass.Type = testValue;

        // Assert
        this._testClass.Type.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the ItemType property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetItemType()
    {
        // Arrange
        var testValue = _fixture.Create<Type>();

        // Act
        this._testClass.ItemType = testValue;

        // Assert
        this._testClass.ItemType.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the RegistrySuffix property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRegistrySuffix()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.RegistrySuffix = testValue;

        // Assert
        this._testClass.RegistrySuffix.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the SectorSuffix property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSectorSuffix()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.SectorSuffix = testValue;

        // Assert
        this._testClass.SectorSuffix.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the FileName property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetFileName()
    {
        // Assert
        this._testClass.FileName.Should().BeAssignableTo<string>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the StockName property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetStockName()
    {
        // Assert
        this._testClass.StockName.Should().BeAssignableTo<string>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the FilePath property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetFilePath()
    {
        // Assert
        this._testClass.FilePath.Should().BeAssignableTo<string>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the StockPath property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetStockPath()
    {
        // Assert
        this._testClass.StockPath.Should().BeAssignableTo<string>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BasePath property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetBasePath()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.BasePath = testValue;

        // Assert
        this._testClass.BasePath.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the SectorSize property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSectorSize()
    {
        // Arrange
        var testValue = _fixture.Create<ushort>();

        // Act
        this._testClass.SectorSize = testValue;

        // Assert
        this._testClass.SectorSize.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the ClusterSize property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetClusterSize()
    {
        // Arrange
        var testValue = _fixture.Create<ushort>();

        // Act
        this._testClass.ClusterSize = testValue;

        // Assert
        this._testClass.ClusterSize.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the Oversized property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOversized()
    {
        // Arrange
        var testValue = _fixture.Create<bool>();

        // Act
        this._testClass.Oversized = testValue;

        // Assert
        this._testClass.Oversized.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the IsOwner property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIsOwner()
    {
        // Arrange
        var testValue = _fixture.Create<bool>();

        // Act
        this._testClass.IsOwner = testValue;

        // Assert
        this._testClass.IsOwner.Should().Be(testValue);
    }

    /// <summary>
    /// Checks that the BlockSize property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetBlockSize()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.BlockSize = testValue;

        // Assert
        this._testClass.BlockSize.Should().Be(testValue);
    }
}