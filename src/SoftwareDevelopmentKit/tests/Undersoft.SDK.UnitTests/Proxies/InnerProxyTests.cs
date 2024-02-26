using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Proxies;

namespace Undersoft.SDK.UnitTests.Proxies;

/// <summary>
/// Unit tests for the type <see cref="InnerProxy"/>.
/// </summary>
public class InnerProxyTests
{
    private class TestInnerProxy : InnerProxy
    {
        public TestInnerProxy(bool autoId) : base(autoId)
        {
        }

        public TestInnerProxy() : base()
        {
        }

        public void PublicCreateProxy(Func<InnerProxy, IProxy> compileAction)
        {
            base.CreateProxy(compileAction);
        }

        public IProxy PublicCreateProxy()
        {
            return base.CreateProxy();
        }
    }

    private TestInnerProxy _testClass;
    private IFixture _fixture;
    private bool _autoId;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="InnerProxy"/>.
    /// </summary>
    public InnerProxyTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._autoId = _fixture.Create<bool>();
        this._testClass = _fixture.Create<TestInnerProxy>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestInnerProxy(this._autoId);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestInnerProxy();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the PublicCreateProxy method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateProxyWithCompileAction()
    {
        // Arrange
        Func<InnerProxy, IProxy> compileAction = x => _fixture.Create<IProxy>();

        // Act
        this._testClass.PublicCreateProxy(compileAction);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicCreateProxy method throws when the compileAction parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateProxyWithCompileActionWithNullCompileAction()
    {
        FluentActions.Invoking(() => this._testClass.PublicCreateProxy(default(Func<InnerProxy, IProxy>))).Should().Throw<ArgumentNullException>().WithParameterName("compileAction");
    }

    /// <summary>
    /// Checks that the PublicCreateProxy method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateProxyWithNoParameters()
    {
        // Act
        var result = this._testClass.PublicCreateProxy();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Proxy property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetProxy()
    {
        // Assert
        this._testClass.Proxy.Should().BeAssignableTo<IProxy>();

        Assert.Fail("Create or modify test");
    }
}