using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Object.Detail;

namespace Undersoft.SDK.Service.UnitTests.Data.Object.Detail;

/// <summary>
/// Unit tests for the type <see cref="DetailAttribute"/>.
/// </summary>
public class DetailAttributeTests
{
    private DetailAttribute _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="DetailAttribute"/>.
    /// </summary>
    public DetailAttributeTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<DetailAttribute>();
    }
}

/// <summary>
/// Unit tests for the type <see cref="DetailsAttribute"/>.
/// </summary>
public class DetailsAttributeTests
{
    private DetailsAttribute _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="DetailsAttribute"/>.
    /// </summary>
    public DetailsAttributeTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<DetailsAttribute>();
    }
}