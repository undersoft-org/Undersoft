using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Proxies;
using T = System.String;

namespace Undersoft.SDK.UnitTests.Proxies;

/// <summary>
/// Unit tests for the type <see cref="Proxy"/>.
/// </summary>
public class Proxy_1Tests
{
    private class TestProxy : Proxy<T>
    {
        public TestProxy(T target) : base(target)
        {
        }

        public TestProxy(T target, Action<IInnerProxy, T> compilationAction) : base(target, compilationAction)
        {
        }

        public void PublicCreateProxy(Action<IInnerProxy, T> compilationAction)
        {
            base.CreateProxy(compilationAction);
        }

        public IProxy PublicCreateProxy()
        {
            return base.CreateProxy();
        }

        public T Publictarget { get => base.target; set => base.target = value; }
    }

    private TestProxy _testClass;
    private IFixture _fixture;
    private T _target;
    private Action<IInnerProxy, T> _compilationAction;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Proxy"/>.
    /// </summary>
    public Proxy_1Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._target = _fixture.Create<T>();
        this._compilationAction = (x, y) => { };
        this._testClass = _fixture.Create<TestProxy>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestProxy(this._target);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestProxy(this._target, this._compilationAction);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the compilationAction parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCompilationAction()
    {
        FluentActions.Invoking(() => new TestProxy(this._target, default(Action<IInnerProxy, T>))).Should().Throw<ArgumentNullException>().WithParameterName("compilationAction");
    }

    /// <summary>
    /// Checks that the PublicCreateProxy method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateProxyWithCompilationAction()
    {
        // Arrange
        Action<IInnerProxy, T> compilationAction = (x, y) => { };

        // Act
        this._testClass.PublicCreateProxy(compilationAction);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicCreateProxy method throws when the compilationAction parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateProxyWithCompilationActionWithNullCompilationAction()
    {
        FluentActions.Invoking(() => this._testClass.PublicCreateProxy(default(Action<IInnerProxy, T>))).Should().Throw<ArgumentNullException>().WithParameterName("compilationAction");
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
    /// Checks that setting the Publictarget property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPublictarget()
    {
        this._testClass.CheckProperty(x => x.Publictarget, _fixture.Create<T>(), _fixture.Create<T>());
    }
}

/// <summary>
/// Unit tests for the type <see cref="Proxy"/>.
/// </summary>
public class ProxyTests
{
    private class TestProxy : Proxy
    {
        public TestProxy() : base()
        {
        }

        public TestProxy(object target) : base(target)
        {
        }

        public TestProxy(object target, Func<InnerProxy, IProxy> compilationAction) : base(target, compilationAction)
        {
        }

        public void PublicCreateProxy(Func<InnerProxy, IProxy> compilationAction)
        {
            base.CreateProxy(compilationAction);
        }

        public IProxy PublicCreateProxy()
        {
            return base.CreateProxy();
        }

        public object Publictarget { get => base.target; set => base.target = value; }
    }

    private TestProxy _testClass;
    private IFixture _fixture;
    private object _target;
    private Func<InnerProxy, IProxy> _compilationAction;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="Proxy"/>.
    /// </summary>
    public ProxyTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._target = _fixture.Create<object>();
        this._compilationAction = x => _fixture.Create<IProxy>();
        this._testClass = _fixture.Create<TestProxy>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestProxy();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestProxy(this._target);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new TestProxy(this._target, this._compilationAction);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the target parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullTarget()
    {
        FluentActions.Invoking(() => new TestProxy(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("target");
        FluentActions.Invoking(() => new TestProxy(default(object), this._compilationAction)).Should().Throw<ArgumentNullException>().WithParameterName("target");
    }

    /// <summary>
    /// Checks that instance construction throws when the compilationAction parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCompilationAction()
    {
        FluentActions.Invoking(() => new TestProxy(this._target, default(Func<InnerProxy, IProxy>))).Should().Throw<ArgumentNullException>().WithParameterName("compilationAction");
    }

    /// <summary>
    /// Checks that the PublicCreateProxy method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateProxyWithCompilationAction()
    {
        // Arrange
        Func<InnerProxy, IProxy> compilationAction = x => _fixture.Create<IProxy>();

        // Act
        this._testClass.PublicCreateProxy(compilationAction);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the PublicCreateProxy method throws when the compilationAction parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateProxyWithCompilationActionWithNullCompilationAction()
    {
        FluentActions.Invoking(() => this._testClass.PublicCreateProxy(default(Func<InnerProxy, IProxy>))).Should().Throw<ArgumentNullException>().WithParameterName("compilationAction");
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
    /// Checks that setting the Publictarget property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetPublictarget()
    {
        this._testClass.CheckProperty(x => x.Publictarget, _fixture.Create<object>(), _fixture.Create<object>());
    }
}