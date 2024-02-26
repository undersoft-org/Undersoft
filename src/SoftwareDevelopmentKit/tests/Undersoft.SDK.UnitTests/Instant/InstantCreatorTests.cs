using System;
using System.Collections.Generic;
using System.Reflection;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant;
using Undersoft.SDK.Rubrics;
using T = System.String;

namespace Undersoft.SDK.UnitTests.Instant;

/// <summary>
/// Unit tests for the type <see cref="InstantCreator"/>.
/// </summary>
public class InstantCreator_1Tests
{
    private InstantCreator<T> _testClass;
    private IFixture _fixture;
    private InstantType _modeType;
    private string _createdTypeName;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="InstantCreator"/>.
    /// </summary>
    public InstantCreator_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._modeType = _fixture.Create<InstantType>();
        this._createdTypeName = _fixture.Create<string>();
        this._testClass = _fixture.Create<InstantCreator<T>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new InstantCreator<T>(this._modeType);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new InstantCreator<T>(this._createdTypeName, this._modeType);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the constructor throws when the createdTypeName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidCreatedTypeName(string value)
    {
        FluentActions.Invoking(() => new InstantCreator<T>(value, this._modeType)).Should().Throw<ArgumentNullException>().WithParameterName("createdTypeName");
    }
}

/// <summary>
/// Unit tests for the type <see cref="InstantCreator"/>.
/// </summary>
public class InstantCreatorTests
{
    private InstantCreator _testClass;
    private IFixture _fixture;
    private IList<MemberInfo> _instantMembers;
    private InstantType _modeType;
    private string _createdTypeName;
    private MemberRubrics _instantRubrics;
    private Type _baseOnType;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="InstantCreator"/>.
    /// </summary>
    public InstantCreatorTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._instantMembers = _fixture.Create<IList<MemberInfo>>();
        this._modeType = _fixture.Create<InstantType>();
        this._createdTypeName = _fixture.Create<string>();
        this._instantRubrics = _fixture.Create<MemberRubrics>();
        this._baseOnType = _fixture.Create<Type>();
        this._testClass = _fixture.Create<InstantCreator>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new InstantCreator(this._instantMembers, this._modeType);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new InstantCreator(this._instantMembers, this._createdTypeName, this._modeType);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new InstantCreator(this._instantRubrics, this._createdTypeName, this._modeType);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new InstantCreator(this._baseOnType, this._modeType);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new InstantCreator(this._baseOnType, this._createdTypeName, this._modeType);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the instantMembers parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullInstantMembers()
    {
        FluentActions.Invoking(() => new InstantCreator(default(IList<MemberInfo>), this._modeType)).Should().Throw<ArgumentNullException>().WithParameterName("instantMembers");
        FluentActions.Invoking(() => new InstantCreator(default(IList<MemberInfo>), this._createdTypeName, this._modeType)).Should().Throw<ArgumentNullException>().WithParameterName("instantMembers");
    }

    /// <summary>
    /// Checks that instance construction throws when the instantRubrics parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullInstantRubrics()
    {
        FluentActions.Invoking(() => new InstantCreator(default(MemberRubrics), this._createdTypeName, this._modeType)).Should().Throw<ArgumentNullException>().WithParameterName("instantRubrics");
    }

    /// <summary>
    /// Checks that instance construction throws when the baseOnType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullBaseOnType()
    {
        FluentActions.Invoking(() => new InstantCreator(default(Type), this._modeType)).Should().Throw<ArgumentNullException>().WithParameterName("baseOnType");
        FluentActions.Invoking(() => new InstantCreator(default(Type), this._createdTypeName, this._modeType)).Should().Throw<ArgumentNullException>().WithParameterName("baseOnType");
    }

    /// <summary>
    /// Checks that the constructor throws when the createdTypeName parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidCreatedTypeName(string value)
    {
        FluentActions.Invoking(() => new InstantCreator(this._instantMembers, value, this._modeType)).Should().Throw<ArgumentNullException>().WithParameterName("createdTypeName");
        FluentActions.Invoking(() => new InstantCreator(this._instantRubrics, value, this._modeType)).Should().Throw<ArgumentNullException>().WithParameterName("createdTypeName");
        FluentActions.Invoking(() => new InstantCreator(this._baseOnType, value, this._modeType)).Should().Throw<ArgumentNullException>().WithParameterName("createdTypeName");
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
    /// Checks that the IsDerived property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIsDerived()
    {
        // Arrange
        var testValue = _fixture.Create<bool>();

        // Act
        this._testClass.IsDerived = testValue;

        // Assert
        this._testClass.IsDerived.Should().Be(testValue);
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
}

/// <summary>
/// Unit tests for the type <see cref="InstantTypeCompilerException"/>.
/// </summary>
public class InstantTypeCompilerExceptionTests
{
    private InstantTypeCompilerException _testClass;
    private IFixture _fixture;
    private string _message;
    private Exception _innerException;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="InstantTypeCompilerException"/>.
    /// </summary>
    public InstantTypeCompilerExceptionTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._message = _fixture.Create<string>();
        this._innerException = _fixture.Create<Exception>();
        this._testClass = _fixture.Create<InstantTypeCompilerException>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new InstantTypeCompilerException(this._message, this._innerException);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the innerException parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullInnerException()
    {
        FluentActions.Invoking(() => new InstantTypeCompilerException(this._message, default(Exception))).Should().Throw<ArgumentNullException>().WithParameterName("innerException");
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
        FluentActions.Invoking(() => new InstantTypeCompilerException(value, this._innerException)).Should().Throw<ArgumentNullException>().WithParameterName("message");
    }
}