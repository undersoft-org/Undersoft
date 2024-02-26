using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant;

namespace Undersoft.SDK.UnitTests.Instant;

/// <summary>
/// Unit tests for the type <see cref="InstantCompilerBaseConstructors"/>.
/// </summary>
public class InstantCompilerBaseConstructorsTests
{
    private InstantCompilerBaseConstructors _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="InstantCompilerBaseConstructors"/>.
    /// </summary>
    public InstantCompilerBaseConstructorsTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<InstantCompilerBaseConstructors>();
    }
}