using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Proxies;
using Undersoft.SDK.Rubrics;
using T = System.String;

namespace Undersoft.SDK.UnitTests.Proxies;

/// <summary>
/// Unit tests for the type <see cref="ProxyCreator"/>.
/// </summary>
public class ProxyCreator_1Tests
{
    private ProxyCreator<T> _testClass;
    private IFixture _fixture;
    private string _sleeveName;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ProxyCreator"/>.
    /// </summary>
    public ProxyCreator_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._sleeveName = _fixture.Create<string>();
        this._testClass = _fixture.Create<ProxyCreator<T>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new ProxyCreator<T>();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new ProxyCreator<T>(this._sleeveName);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the constructor throws when the sleeveName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidSleeveName(string value)
    {
        FluentActions.Invoking(() => new ProxyCreator<T>(value)).Should().Throw<ArgumentNullException>().WithParameterName("sleeveName");
    }
}

/// <summary>
/// Unit tests for the type <see cref="ProxyCreator"/>.
/// </summary>
public class ProxyCreatorTests
{
    private ProxyCreator _testClass;
    private IFixture _fixture;
    private Type _figureModelType;
    private string _figureTypeName;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ProxyCreator"/>.
    /// </summary>
    public ProxyCreatorTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._figureModelType = _fixture.Create<Type>();
        this._figureTypeName = _fixture.Create<string>();
        this._testClass = _fixture.Create<ProxyCreator>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new ProxyCreator(this._figureModelType);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new ProxyCreator(this._figureModelType, this._figureTypeName);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the figureModelType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullFigureModelType()
    {
        FluentActions.Invoking(() => new ProxyCreator(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("figureModelType");
        FluentActions.Invoking(() => new ProxyCreator(default(Type), this._figureTypeName)).Should().Throw<ArgumentNullException>().WithParameterName("figureModelType");
    }

    /// <summary>
    /// Checks that the constructor throws when the figureTypeName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidFigureTypeName(string value)
    {
        FluentActions.Invoking(() => new ProxyCreator(this._figureModelType, value)).Should().Throw<ArgumentNullException>().WithParameterName("figureTypeName");
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
    /// Checks that the Create method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreate()
    {
        // Arrange
        var obj = _fixture.Create<object>();

        // Act
        var result = this._testClass.Create(obj);

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
    /// Checks that the Rubrics property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRubrics()
    {
        // Arrange
        var testValue = _fixture.Create<IRubrics>();

        // Act
        this._testClass.Rubrics = testValue;

        // Assert
        this._testClass.Rubrics.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the Size property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSize()
    {
        // Arrange
        var testValue = _fixture.Create<int>();

        // Act
        this._testClass.Size = testValue;

        // Assert
        this._testClass.Size.Should().Be(testValue);
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
    /// Checks that the Traceable property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTraceable()
    {
        // Arrange
        var testValue = _fixture.Create<bool>();

        // Act
        this._testClass.Traceable = testValue;

        // Assert
        this._testClass.Traceable.Should().Be(testValue);
    }
}

/// <summary>
/// Unit tests for the type <see cref="SleeveCompilerException"/>.
/// </summary>
public class SleeveCompilerExceptionTests
{
    private SleeveCompilerException _testClass;
    private IFixture _fixture;
    private string _message;
    private Exception _innerException;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="SleeveCompilerException"/>.
    /// </summary>
    public SleeveCompilerExceptionTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._message = _fixture.Create<string>();
        this._innerException = _fixture.Create<Exception>();
        this._testClass = _fixture.Create<SleeveCompilerException>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new SleeveCompilerException(this._message, this._innerException);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the innerException parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullInnerException()
    {
        FluentActions.Invoking(() => new SleeveCompilerException(this._message, default(Exception))).Should().Throw<ArgumentNullException>().WithParameterName("innerException");
    }

    /// <summary>
    /// Checks that the constructor throws when the message parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidMessage(string value)
    {
        FluentActions.Invoking(() => new SleeveCompilerException(value, this._innerException)).Should().Throw<ArgumentNullException>().WithParameterName("message");
    }
}