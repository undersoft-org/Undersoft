using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Series.Universe.Base;

namespace Undersoft.SDK.UnitTests.Series.Universe.Base;

/// <summary>
/// Unit tests for the type <see cref="Universe"/>.
/// </summary>
public class UniverseTests
{
    private class TestUniverse : Universe
    {
        public override void Add(int baseOffset, int offsetFactor, int indexOffset, int x)
        {
        }

        public override void Add(int x)
        {
        }

        public override bool Contains(int baseOffset, int offsetFactor, int indexOffset, int x)
        {
            return default(bool);
        }

        public override bool Contains(int x)
        {
            return default(bool);
        }

        public override void FirstAdd(int baseOffset, int offsetFactor, int indexOffset, int x)
        {
        }

        public override void FirstAdd(int x)
        {
        }

        public override int Next(int baseOffset, int offsetFactor, int indexOffset, int x)
        {
            return default(int);
        }

        public override int Next(int x)
        {
            return default(int);
        }

        public override int Previous(int baseOffset, int offsetFactor, int indexOffset, int x)
        {
            return default(int);
        }

        public override int Previous(int x)
        {
            return default(int);
        }

        public override bool Remove(int baseOffset, int offsetFactor, int indexOffset, int x)
        {
            return default(bool);
        }

        public override bool Remove(int x)
        {
            return default(bool);
        }

        public override int IndexMax { get; }
        public override int IndexMin { get; }
        public override int Size { get; }
    }

    private TestUniverse _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Universe"/>.
    /// </summary>
    public UniverseTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<TestUniverse>();
    }

    /// <summary>
    /// Checks that the IndexMax property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetIndexMax()
    {
        // Assert
        this._testClass.IndexMax.As<object>().Should().BeAssignableTo<int>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IndexMin property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetIndexMin()
    {
        // Assert
        this._testClass.IndexMin.As<object>().Should().BeAssignableTo<int>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Size property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetSize()
    {
        // Assert
        this._testClass.Size.As<object>().Should().BeAssignableTo<int>();

        Assert.Fail("Create or modify test");
    }
}