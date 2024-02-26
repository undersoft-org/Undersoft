using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK;
using Undersoft.SDK.Uniques;
using TEntity = System.String;

namespace Undersoft.SDK.UnitTests;

/// <summary>
/// Unit tests for the type <see cref="Origin"/>.
/// </summary>
public class OriginTests
{
    private Origin _testClass;
    private IFixture _fixture;
    private bool _autoId;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Origin"/>.
    /// </summary>
    public OriginTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._autoId = _fixture.Create<bool>();
        this._testClass = _fixture.Create<Origin>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new Origin();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new Origin(this._autoId);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the Sign method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSign()
    {
        // Arrange
        var entity = _fixture.Create<TEntity>();

        // Act
        var result = this._testClass.Sign<TEntity>(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Stamp method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallStamp()
    {
        // Arrange
        var entity = _fixture.Create<TEntity>();

        // Act
        var result = this._testClass.Stamp<TEntity>(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEquals()
    {
        // Arrange
        var other = _fixture.Create<IUnique>();

        // Act
        var result = this._testClass.Equals(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEqualsWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.Equals(default(IUnique))).Should().Throw<ArgumentNullException>().WithParameterName("other");
    }

    /// <summary>
    /// Checks that the CompareTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompareTo()
    {
        // Arrange
        var other = _fixture.Create<IUnique>();

        // Act
        var result = this._testClass.CompareTo(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompareTo method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompareToWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.CompareTo(default(IUnique))).Should().Throw<ArgumentNullException>().WithParameterName("other");
    }

    /// <summary>
    /// Checks that setting the OriginId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOriginId()
    {
        this._testClass.CheckProperty(x => x.OriginId);
    }

    /// <summary>
    /// Checks that setting the Modified property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetModified()
    {
        this._testClass.CheckProperty(x => x.Modified);
    }

    /// <summary>
    /// Checks that setting the Modifier property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetModifier()
    {
        this._testClass.CheckProperty(x => x.Modifier);
    }

    /// <summary>
    /// Checks that setting the Created property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetCreated()
    {
        this._testClass.CheckProperty(x => x.Created);
    }

    /// <summary>
    /// Checks that setting the Creator property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetCreator()
    {
        this._testClass.CheckProperty(x => x.Creator);
    }

    /// <summary>
    /// Checks that setting the Index property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndex()
    {
        this._testClass.CheckProperty(x => x.Index);
    }

    /// <summary>
    /// Checks that setting the Label property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetLabel()
    {
        this._testClass.CheckProperty(x => x.Label);
    }
}