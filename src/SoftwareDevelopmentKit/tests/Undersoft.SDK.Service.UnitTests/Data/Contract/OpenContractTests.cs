using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SDK.Service.Data.Identifier;
using Undersoft.SDK.Service.Data.Object;
using TContract = Undersoft.SDK.Service.Data.Remote.RemoteLink;
using TDetail = Undersoft.SDK.Service.Data.Object.Detail.ObjectDetail;
using TGroup = System.AttributeTargets;
using TSetting = Undersoft.SDK.Service.Data.Object.Setting.ObjectSetting;

namespace Undersoft.SDK.Service.UnitTests.Data.Contract;

/// <summary>
/// Unit tests for the type <see cref="OpenContract"/>.
/// </summary>
public class OpenContract_4Tests
{
    private OpenContract<TContract, TDetail, TSetting, TGroup> _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="OpenContract"/>.
    /// </summary>
    public OpenContract_4Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<OpenContract<TContract, TDetail, TSetting, TGroup>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new OpenContract<TContract, TDetail, TSetting, TGroup>();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that setting the Identifiers property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIdentifiers()
    {
        this._testClass.CheckProperty(x => x.Identifiers, _fixture.Create<IdentifierSet<TContract>>(), _fixture.Create<IdentifierSet<TContract>>());
    }

    /// <summary>
    /// Checks that setting the Details property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetDetails()
    {
        this._testClass.CheckProperty(x => x.Details, _fixture.Create<ObjectSet<TDetail>>(), _fixture.Create<ObjectSet<TDetail>>());
    }

    /// <summary>
    /// Checks that setting the Settings property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSettings()
    {
        this._testClass.CheckProperty(x => x.Settings, _fixture.Create<ObjectSet<TSetting>>(), _fixture.Create<ObjectSet<TSetting>>());
    }

    /// <summary>
    /// Checks that setting the Group property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetGroup()
    {
        this._testClass.CheckProperty(x => x.Group, _fixture.Create<TGroup>(), _fixture.Create<TGroup>());
    }
}