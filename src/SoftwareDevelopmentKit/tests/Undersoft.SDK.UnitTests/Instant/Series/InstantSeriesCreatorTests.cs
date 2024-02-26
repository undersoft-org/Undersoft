using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Instant;
using Undersoft.SDK.Instant.Series;
using Undersoft.SDK.Rubrics;
using T = System.String;

namespace Undersoft.SDK.UnitTests.Instant.Series;

/// <summary>
/// Unit tests for the type <see cref="InstantSeriesCreator"/>.
/// </summary>
public class InstantSeriesCreator_1Tests
{
    private InstantSeriesCreator<T> _testClass;
    private IFixture _fixture;
    private InstantType _mode;
    private string _seriesName;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="InstantSeriesCreator"/>.
    /// </summary>
    public InstantSeriesCreator_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._mode = _fixture.Create<InstantType>();
        this._seriesName = _fixture.Create<string>();
        this._testClass = _fixture.Create<InstantSeriesCreator<T>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new InstantSeriesCreator<T>(this._mode);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new InstantSeriesCreator<T>(this._seriesName, this._mode);

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
        FluentActions.Invoking(() => new InstantSeriesCreator<T>(value, this._mode)).Should().Throw<ArgumentNullException>().WithParameterName("seriesName");
    }
}

/// <summary>
/// Unit tests for the type <see cref="InstantSeriesCreator"/>.
/// </summary>
public class InstantSeriesCreatorTests
{
    private InstantSeriesCreator _testClass;
    private IFixture _fixture;
    private InstantCreator _instantGenerator;
    private string _seriesTypeName;
    private bool _threadSafe;
    private Mock<IInstant> _instantObject;
    private InstantType _modeType;
    private MemberRubrics _instantRubrics;
    private string _instantTypeName;
    private bool _safeThread;
    private Type _instantModelType;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="InstantSeriesCreator"/>.
    /// </summary>
    public InstantSeriesCreatorTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._instantGenerator = _fixture.Create<InstantCreator>();
        this._seriesTypeName = _fixture.Create<string>();
        this._threadSafe = _fixture.Create<bool>();
        this._instantObject = _fixture.Freeze<Mock<IInstant>>();
        this._modeType = _fixture.Create<InstantType>();
        this._instantRubrics = _fixture.Create<MemberRubrics>();
        this._instantTypeName = _fixture.Create<string>();
        this._safeThread = _fixture.Create<bool>();
        this._instantModelType = _fixture.Create<Type>();
        this._testClass = _fixture.Create<InstantSeriesCreator>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new InstantSeriesCreator();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new InstantSeriesCreator(this._instantGenerator, this._seriesTypeName, this._threadSafe);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new InstantSeriesCreator(this._instantObject.Object, this._threadSafe);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new InstantSeriesCreator(this._instantObject.Object, this._seriesTypeName, this._modeType, this._threadSafe);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new InstantSeriesCreator(this._instantRubrics, this._seriesTypeName, this._instantTypeName, this._modeType, this._safeThread);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new InstantSeriesCreator(this._instantModelType, this._modeType, this._safeThread);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new InstantSeriesCreator(this._instantModelType, this._seriesTypeName, this._modeType, this._safeThread);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new InstantSeriesCreator(this._instantModelType, this._seriesTypeName, this._instantTypeName, this._modeType, this._safeThread);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the instantGenerator parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullInstantGenerator()
    {
        FluentActions.Invoking(() => new InstantSeriesCreator(default(InstantCreator), this._seriesTypeName, this._threadSafe)).Should().Throw<ArgumentNullException>().WithParameterName("instantGenerator");
    }

    /// <summary>
    /// Checks that instance construction throws when the instantObject parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullInstantObject()
    {
        FluentActions.Invoking(() => new InstantSeriesCreator(default(IInstant), this._threadSafe)).Should().Throw<ArgumentNullException>().WithParameterName("instantObject");
        FluentActions.Invoking(() => new InstantSeriesCreator(default(IInstant), this._seriesTypeName, this._modeType, this._threadSafe)).Should().Throw<ArgumentNullException>().WithParameterName("instantObject");
    }

    /// <summary>
    /// Checks that instance construction throws when the instantRubrics parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullInstantRubrics()
    {
        FluentActions.Invoking(() => new InstantSeriesCreator(default(MemberRubrics), this._seriesTypeName, this._instantTypeName, this._modeType, this._safeThread)).Should().Throw<ArgumentNullException>().WithParameterName("instantRubrics");
    }

    /// <summary>
    /// Checks that instance construction throws when the instantModelType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullInstantModelType()
    {
        FluentActions.Invoking(() => new InstantSeriesCreator(default(Type), this._modeType, this._safeThread)).Should().Throw<ArgumentNullException>().WithParameterName("instantModelType");
        FluentActions.Invoking(() => new InstantSeriesCreator(default(Type), this._seriesTypeName, this._modeType, this._safeThread)).Should().Throw<ArgumentNullException>().WithParameterName("instantModelType");
        FluentActions.Invoking(() => new InstantSeriesCreator(default(Type), this._seriesTypeName, this._instantTypeName, this._modeType, this._safeThread)).Should().Throw<ArgumentNullException>().WithParameterName("instantModelType");
    }

    /// <summary>
    /// Checks that the constructor throws when the seriesTypeName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidSeriesTypeName(string value)
    {
        FluentActions.Invoking(() => new InstantSeriesCreator(this._instantGenerator, value, this._threadSafe)).Should().Throw<ArgumentNullException>().WithParameterName("seriesTypeName");
        FluentActions.Invoking(() => new InstantSeriesCreator(this._instantObject.Object, value, this._modeType, this._threadSafe)).Should().Throw<ArgumentNullException>().WithParameterName("seriesTypeName");
        FluentActions.Invoking(() => new InstantSeriesCreator(this._instantRubrics, value, this._instantTypeName, this._modeType, this._safeThread)).Should().Throw<ArgumentNullException>().WithParameterName("seriesTypeName");
        FluentActions.Invoking(() => new InstantSeriesCreator(this._instantModelType, value, this._modeType, this._safeThread)).Should().Throw<ArgumentNullException>().WithParameterName("seriesTypeName");
        FluentActions.Invoking(() => new InstantSeriesCreator(this._instantModelType, value, this._instantTypeName, this._modeType, this._safeThread)).Should().Throw<ArgumentNullException>().WithParameterName("seriesTypeName");
    }

    /// <summary>
    /// Checks that the constructor throws when the instantTypeName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidInstantTypeName(string value)
    {
        FluentActions.Invoking(() => new InstantSeriesCreator(this._instantRubrics, this._seriesTypeName, value, this._modeType, this._safeThread)).Should().Throw<ArgumentNullException>().WithParameterName("instantTypeName");
        FluentActions.Invoking(() => new InstantSeriesCreator(this._instantModelType, this._seriesTypeName, value, this._modeType, this._safeThread)).Should().Throw<ArgumentNullException>().WithParameterName("instantTypeName");
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
    /// Checks that the CloneRubrics method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCloneRubrics()
    {
        // Act
        var result = this._testClass.CloneRubrics();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the BaseType property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetBaseType()
    {
        // Arrange
        var testValue = _fixture.Create<Type>();

        // Act
        this._testClass.BaseType = testValue;

        // Assert
        this._testClass.BaseType.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Name property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetName()
    {
        // Arrange
        var testValue = _fixture.Create<string>();

        // Act
        this._testClass.Name = testValue;

        // Assert
        this._testClass.Name.Should().Be(testValue);
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
}