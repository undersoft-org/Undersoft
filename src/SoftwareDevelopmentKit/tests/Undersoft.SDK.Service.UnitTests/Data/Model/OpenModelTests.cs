using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Identifier;
using Undersoft.SDK.Service.Data.Model;
using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SDK.Service.Data.Object.Setting;
using TDetail = Undersoft.SDK.Service.Data.Object.Detail.ObjectDetail;
using TGroup = System.AttributeTargets;
using TSetting = Undersoft.SDK.Service.Data.Object.Setting.ObjectSetting;
using TViewModel = Undersoft.SDK.Service.Data.Remote.RemoteLink;

namespace Undersoft.SDK.Service.UnitTests.Data.Model;

/// <summary>
/// Unit tests for the type <see cref="OpenModel"/>.
/// </summary>
public class OpenModel_4Tests
{
    private OpenModel<TViewModel, TDetail, TSetting, TGroup> _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="OpenModel"/>.
    /// </summary>
    public OpenModel_4Tests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<OpenModel<TViewModel, TDetail, TSetting, TGroup>>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new OpenModel<TViewModel, TDetail, TSetting, TGroup>();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that setting the Identifiers property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIdentifiers()
    {
        this._testClass.CheckProperty(x => x.Identifiers, _fixture.Create<IdentifierSet<TViewModel>>(), _fixture.Create<IdentifierSet<TViewModel>>());
    }

    /// <summary>
    /// Checks that setting the Details property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetDetails()
    {
        this._testClass.CheckProperty(x => x.Details, _fixture.Create<DetailSet<TDetail>>(), _fixture.Create<DetailSet<TDetail>>());
    }

    /// <summary>
    /// Checks that setting the Settings property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSettings()
    {
        this._testClass.CheckProperty(x => x.Settings, _fixture.Create<SettingSet<TSetting>>(), _fixture.Create<SettingSet<TSetting>>());
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