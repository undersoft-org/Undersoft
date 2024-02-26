using System;
using System.Linq.Expressions;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Client;
using Undersoft.SDK.Service.Data.Remote;
using TOrigin = System.String;
using TTarget = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Remote;

/// <summary>
/// Unit tests for the type <see cref="RemoteLinkExtensions"/>.
/// </summary>
public class RemoteLinkExtensionsTests
{
    private IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

    /// <summary>
    /// Checks that the RemoteSetToSet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoteSetToSet()
    {
        // Arrange
        var context = _fixture.Create<OpenDataContext>();
        var middlekey = _fixture.Create<Expression<Func<IRemoteLink<TOrigin, TTarget>, object>>>();
        var targetkey = _fixture.Create<Expression<Func<TTarget, object>>>();

        // Act
        var result = context.RemoteSetToSet<TOrigin, TTarget>(middlekey, targetkey);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RemoteSetToSet method throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRemoteSetToSetWithNullContext()
    {
        FluentActions.Invoking(() => default(OpenDataContext).RemoteSetToSet<TOrigin, TTarget>(_fixture.Create<Expression<Func<IRemoteLink<TOrigin, TTarget>, object>>>(), _fixture.Create<Expression<Func<TTarget, object>>>())).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }

    /// <summary>
    /// Checks that the RemoteSetToSet method throws when the middlekey parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRemoteSetToSetWithNullMiddlekey()
    {
        FluentActions.Invoking(() => _fixture.Create<OpenDataContext>().RemoteSetToSet<TOrigin, TTarget>(default(Expression<Func<IRemoteLink<TOrigin, TTarget>, object>>), _fixture.Create<Expression<Func<TTarget, object>>>())).Should().Throw<ArgumentNullException>().WithParameterName("middlekey");
    }

    /// <summary>
    /// Checks that the RemoteSetToSet method throws when the targetkey parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRemoteSetToSetWithNullTargetkey()
    {
        FluentActions.Invoking(() => _fixture.Create<OpenDataContext>().RemoteSetToSet<TOrigin, TTarget>(_fixture.Create<Expression<Func<IRemoteLink<TOrigin, TTarget>, object>>>(), default(Expression<Func<TTarget, object>>))).Should().Throw<ArgumentNullException>().WithParameterName("targetkey");
    }

    /// <summary>
    /// Checks that the RemoteOneToSet method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoteOneToSet()
    {
        // Arrange
        var context = _fixture.Create<OpenDataContext>();
        var originkey = _fixture.Create<Expression<Func<TOrigin, object>>>();
        var targetkey = _fixture.Create<Expression<Func<TTarget, object>>>();

        // Act
        var result = context.RemoteOneToSet<TOrigin, TTarget>(originkey, targetkey);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RemoteOneToSet method throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRemoteOneToSetWithNullContext()
    {
        FluentActions.Invoking(() => default(OpenDataContext).RemoteOneToSet<TOrigin, TTarget>(_fixture.Create<Expression<Func<TOrigin, object>>>(), _fixture.Create<Expression<Func<TTarget, object>>>())).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }

    /// <summary>
    /// Checks that the RemoteOneToSet method throws when the originkey parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRemoteOneToSetWithNullOriginkey()
    {
        FluentActions.Invoking(() => _fixture.Create<OpenDataContext>().RemoteOneToSet<TOrigin, TTarget>(default(Expression<Func<TOrigin, object>>), _fixture.Create<Expression<Func<TTarget, object>>>())).Should().Throw<ArgumentNullException>().WithParameterName("originkey");
    }

    /// <summary>
    /// Checks that the RemoteOneToSet method throws when the targetkey parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRemoteOneToSetWithNullTargetkey()
    {
        FluentActions.Invoking(() => _fixture.Create<OpenDataContext>().RemoteOneToSet<TOrigin, TTarget>(_fixture.Create<Expression<Func<TOrigin, object>>>(), default(Expression<Func<TTarget, object>>))).Should().Throw<ArgumentNullException>().WithParameterName("targetkey");
    }

    /// <summary>
    /// Checks that the RemoteOneToOne method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallRemoteOneToOne()
    {
        // Arrange
        var context = _fixture.Create<OpenDataContext>();
        var originkey = _fixture.Create<Expression<Func<TOrigin, object>>>();
        var targetkey = _fixture.Create<Expression<Func<TTarget, object>>>();

        // Act
        var result = context.RemoteOneToOne<TOrigin, TTarget>(originkey, targetkey);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RemoteOneToOne method throws when the context parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRemoteOneToOneWithNullContext()
    {
        FluentActions.Invoking(() => default(OpenDataContext).RemoteOneToOne<TOrigin, TTarget>(_fixture.Create<Expression<Func<TOrigin, object>>>(), _fixture.Create<Expression<Func<TTarget, object>>>())).Should().Throw<ArgumentNullException>().WithParameterName("context");
    }

    /// <summary>
    /// Checks that the RemoteOneToOne method throws when the originkey parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRemoteOneToOneWithNullOriginkey()
    {
        FluentActions.Invoking(() => _fixture.Create<OpenDataContext>().RemoteOneToOne<TOrigin, TTarget>(default(Expression<Func<TOrigin, object>>), _fixture.Create<Expression<Func<TTarget, object>>>())).Should().Throw<ArgumentNullException>().WithParameterName("originkey");
    }

    /// <summary>
    /// Checks that the RemoteOneToOne method throws when the targetkey parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallRemoteOneToOneWithNullTargetkey()
    {
        FluentActions.Invoking(() => _fixture.Create<OpenDataContext>().RemoteOneToOne<TOrigin, TTarget>(_fixture.Create<Expression<Func<TOrigin, object>>>(), default(Expression<Func<TTarget, object>>))).Should().Throw<ArgumentNullException>().WithParameterName("targetkey");
    }
}