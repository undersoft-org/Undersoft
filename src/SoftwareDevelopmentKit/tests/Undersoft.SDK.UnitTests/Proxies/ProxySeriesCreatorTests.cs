using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Instant;
using Undersoft.SDK.Proxies;
using Undersoft.SDK.Rubrics;
using T = System.String;

namespace Undersoft.SDK.UnitTests.Proxies;

/// <summary>
/// Unit tests for the type <see cref="ProxySeriesCreator"/>.
/// </summary>
public class ProxySeriesCreator_1Tests
{
    private ProxySeriesCreator<T> _testClass;
    private IFixture _fixture;
    private bool _threadSafe;
    private string _seriesName;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ProxySeriesCreator"/>.
    /// </summary>
    public ProxySeriesCreator_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._threadSafe = _fixture.Create<bool>();
        this._seriesName = _fixture.Create<string>();
        this._testClass = _fixture.Create<ProxySeriesCreator<T>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new ProxySeriesCreator<T>();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new ProxySeriesCreator<T>(this._threadSafe);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new ProxySeriesCreator<T>(this._seriesName);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new ProxySeriesCreator<T>(this._seriesName, this._threadSafe);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the constructor throws when the seriesName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidSeriesName(string value)
    {
        FluentActions.Invoking(() => new ProxySeriesCreator<T>(value)).Should().Throw<ArgumentNullException>().WithParameterName("seriesName");
        FluentActions.Invoking(() => new ProxySeriesCreator<T>(value, this._threadSafe)).Should().Throw<ArgumentNullException>().WithParameterName("seriesName");
    }
}

/// <summary>
/// Unit tests for the type <see cref="ProxySeriesCreator"/>.
/// </summary>
public class ProxySeriesCreatorTests
{
    private ProxySeriesCreator _testClass;
    private IFixture _fixture;
    private ProxyCreator _proxyGenerator;
    private string _seriesTypeName;
    private bool _safeThread;
    private Mock<IInstant> _instant;
    private bool _threadSafe;
    private Type _proxyModelType;
    private string _seriesName;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ProxySeriesCreator"/>.
    /// </summary>
    public ProxySeriesCreatorTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._proxyGenerator = _fixture.Create<ProxyCreator>();
        this._seriesTypeName = _fixture.Create<string>();
        this._safeThread = _fixture.Create<bool>();
        this._instant = _fixture.Freeze<Mock<IInstant>>();
        this._threadSafe = _fixture.Create<bool>();
        this._proxyModelType = _fixture.Create<Type>();
        this._seriesName = _fixture.Create<string>();
        this._testClass = _fixture.Create<ProxySeriesCreator>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new ProxySeriesCreator(this._proxyGenerator, this._seriesTypeName, this._safeThread);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new ProxySeriesCreator(this._instant.Object, this._threadSafe);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new ProxySeriesCreator(this._proxyModelType, this._threadSafe);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new ProxySeriesCreator(this._proxyModelType, this._seriesName, this._threadSafe);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the proxyGenerator parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullProxyGenerator()
    {
        FluentActions.Invoking(() => new ProxySeriesCreator(default(ProxyCreator), this._seriesTypeName, this._safeThread)).Should().Throw<ArgumentNullException>().WithParameterName("proxyGenerator");
    }

    /// <summary>
    /// Checks that instance construction throws when the instant parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullInstant()
    {
        FluentActions.Invoking(() => new ProxySeriesCreator(default(IInstant), this._threadSafe)).Should().Throw<ArgumentNullException>().WithParameterName("instant");
    }

    /// <summary>
    /// Checks that instance construction throws when the proxyModelType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullProxyModelType()
    {
        FluentActions.Invoking(() => new ProxySeriesCreator(default(Type), this._threadSafe)).Should().Throw<ArgumentNullException>().WithParameterName("proxyModelType");
        FluentActions.Invoking(() => new ProxySeriesCreator(default(Type), this._seriesName, this._threadSafe)).Should().Throw<ArgumentNullException>().WithParameterName("proxyModelType");
    }

    /// <summary>
    /// Checks that the constructor throws when the seriesTypeName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidSeriesTypeName(string value)
    {
        FluentActions.Invoking(() => new ProxySeriesCreator(this._proxyGenerator, value, this._safeThread)).Should().Throw<ArgumentNullException>().WithParameterName("seriesTypeName");
    }

    /// <summary>
    /// Checks that the constructor throws when the seriesName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidSeriesName(string value)
    {
        FluentActions.Invoking(() => new ProxySeriesCreator(this._proxyModelType, value, this._threadSafe)).Should().Throw<ArgumentNullException>().WithParameterName("seriesName");
    }

    /// <summary>
    /// Checks that the Create method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreate()
    {
        // Act
        var result = this._testClass.Create();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the New method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallNew()
    {
        // Act
        var result = this._testClass.New();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Rubrics property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetRubrics()
    {
        // Assert
        this._testClass.Rubrics.Should().BeAssignableTo<IRubrics>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Size property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetSize()
    {
        // Assert
        this._testClass.Size.As<object>().Should().BeAssignableTo<int>();

        Assert.Fail("Create or modify test");
    }
}