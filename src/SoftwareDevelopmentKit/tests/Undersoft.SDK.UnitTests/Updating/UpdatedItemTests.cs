using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Updating;

namespace Undersoft.SDK.UnitTests.Updating;

/// <summary>
/// Unit tests for the type <see cref="UpdatedItem"/>.
/// </summary>
public class UpdatedItemTests
{
    private UpdatedItem _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="UpdatedItem"/>.
    /// </summary>
    public UpdatedItemTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<UpdatedItem>();
    }
}