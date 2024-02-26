using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK;
using Undersoft.SDK.Uniques;

namespace Undersoft.SDK.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="Identifiable"/>.
/// </summary>
public class IdentifiableTests
{
    private Identifiable _testClass;
    private IFixture _fixture;
    private bool _autoId;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Identifiable"/>.
    /// </summary>
    public IdentifiableTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._autoId = _fixture.Create<bool>();
        this._testClass = _fixture.Create<Identifiable>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new Identifiable();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Identifiable(this._autoId);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the AutoId method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAutoId()
    {
        // Act
        var result = this._testClass.AutoId();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetPriority method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetPriority()
    {
        // Act
        var result = this._testClass.GetPriority();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetPriority method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetPriority()
    {
        // Arrange
        var priority = _fixture.Create<byte>();

        // Act
        var result = this._testClass.SetPriority(priority);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetFlag method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetFlag()
    {
        // Arrange
        var state = _fixture.Create<StateFlags>();
        var flag = _fixture.Create<bool>();

        // Act
        this._testClass.SetFlag(state, flag);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetFlag method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetFlag()
    {
        // Arrange
        var state = _fixture.Create<StateFlags>();

        // Act
        this._testClass.GetFlag(state);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetId method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetIdWithLong()
    {
        // Arrange
        var id = _fixture.Create<long>();

        // Act
        var result = this._testClass.SetId(id);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetId method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetIdWithObject()
    {
        // Arrange
        var id = _fixture.Create<object>();

        // Act
        var result = this._testClass.SetId(id);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetId method throws when the id parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetIdWithObjectWithNullId()
    {
        FluentActions.Invoking(() => this._testClass.SetId(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("id");
    }

    /// <summary>
    /// Checks that setting the Id property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetId()
    {
        this._testClass.CheckProperty(x => x.Id);
    }

    /// <summary>
    /// Checks that setting the TypeId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTypeId()
    {
        this._testClass.CheckProperty(x => x.TypeId);
    }

    /// <summary>
    /// Checks that setting the TypeName property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTypeName()
    {
        this._testClass.CheckProperty(x => x.TypeName);
    }

    /// <summary>
    /// Checks that setting the CodeNo property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetCodeNo()
    {
        this._testClass.CheckProperty(x => x.CodeNo);
    }

    /// <summary>
    /// Checks that setting the Time property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTime()
    {
        this._testClass.CheckProperty(x => x.Time);
    }
}