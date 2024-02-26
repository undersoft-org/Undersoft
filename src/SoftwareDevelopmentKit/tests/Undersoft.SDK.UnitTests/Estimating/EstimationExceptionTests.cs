using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Estimating;

namespace Undersoft.SDK.UnitTests.Estimating;

/// <summary>
/// Unit tests for the type <see cref="EstimatingException"/>.
/// </summary>
public class EstimatingExceptionTests
{
    private EstimatingException _testClass;
    private IFixture _fixture;
    private EstimatingExceptionList _exceptionList;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="EstimatingException"/>.
    /// </summary>
    public EstimatingExceptionTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._exceptionList = _fixture.Create<EstimatingExceptionList>();
        this._testClass = _fixture.Create<EstimatingException>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new EstimatingException(this._exceptionList);

        // Assert
        instance.Should().NotBeNull();
    }
}

/// <summary>
/// Unit tests for the type <see cref="EstimatingExceptionRegistry"/>.
/// </summary>
public class EstimatingExceptionRegistryTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());
}