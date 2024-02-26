using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Server.Documentation;

namespace Undersoft.SDK.Service.Server.UnitTests.Documentation;

/// <summary>
/// Unit tests for the type <see cref="IgnoreApiAttribute"/>.
/// </summary>
[TestClass]
public class IgnoreApiAttributeTests
{
    private IgnoreApiAttribute _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="IgnoreApiAttribute"/>.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<IgnoreApiAttribute>();
    }
}