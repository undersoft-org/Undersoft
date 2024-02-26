using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Blob;
using Undersoft.SDK.Service.Infrastructure.FileSystem;

namespace Undersoft.SDK.Service.Infrastructure.UnitTests.FileSystem;

/// <summary>
/// Unit tests for the type <see cref="DefaultBlobFilePathCalculator"/>.
/// </summary>
[TestClass]
public class DefaultBlobFilePathCalculatorTests
{
    private DefaultBlobFilePathCalculator _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="DefaultBlobFilePathCalculator"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<DefaultBlobFilePathCalculator>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new DefaultBlobFilePathCalculator();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the Calculate method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCalculate()
    {
        // Arrange
        var args = _fixture.Create<BlobProviderArgs>();

        // Act
        var result = this._testClass.Calculate(args);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Calculate method throws when the args parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCalculateWithNullArgs()
    {
        FluentActions.Invoking(() => this._testClass.Calculate(default(BlobProviderArgs))).Should().Throw<ArgumentNullException>().WithParameterName("args");
    }
}