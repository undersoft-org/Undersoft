using System;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Invoking;
using Undersoft.SDK.Service.Data.Repository;

namespace Undersoft.SDK.Service.UnitTests.Data.Repository;

/// <summary>
/// Unit tests for the type <see cref="EventInvoker"/>.
/// </summary>
public class EventInvokerTests
{
    private EventInvoker _testClass;
    private IFixture _fixture;
    private StateOn _eventonStateOn;
    private string _eventonString;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="EventInvoker"/>.
    /// </summary>
    public EventInvokerTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._eventonStateOn = _fixture.Create<StateOn>();
        this._eventonString = _fixture.Create<string>();
        this._testClass = _fixture.Create<EventInvoker>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new EventInvoker(this._eventonStateOn);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new EventInvoker(this._eventonString);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the constructor throws when the eventon parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidEventon(string value)
    {
        FluentActions.Invoking(() => new EventInvoker(value)).Should().Throw<ArgumentNullException>().WithParameterName("eventon");
        FluentActions.Invoking(() => new EventInvoker(value)).Should().Throw<ArgumentNullException>().WithParameterName("eventon");
    }

    /// <summary>
    /// Checks that the Fire method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallFireAsync()
    {
        // Arrange
        var parameters = _fixture.Create<object[]>();

        // Act
        await this._testClass.Fire(parameters);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Fire method throws when the parameters parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallFireWithNullParametersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Fire(default(object[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("parameters");
    }

    /// <summary>
    /// Checks that the Invoke method functions correctly.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CanCallInvokeAsync()
    {
        // Arrange
        var parameters = _fixture.Create<object[]>();

        // Act
        await this._testClass.Invoke(parameters);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Invoke method throws when the parameters parameter is null.
    /// </summary>
    /// <returns>A task that represents the running test.</returns>
    [TestMethod]
    public async Task CannotCallInvokeWithNullParametersAsync()
    {
        await FluentActions.Invoking(() => this._testClass.Invoke(default(object[]))).Should().ThrowAsync<ArgumentNullException>().WithParameterName("parameters");
    }
}

/// <summary>
/// Unit tests for the type <see cref="RepositoryEvents"/>.
/// </summary>
public class RepositoryEventsTests
{
    private RepositoryEvents _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RepositoryEvents"/>.
    /// </summary>
    public RepositoryEventsTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<RepositoryEvents>();
    }

    /// <summary>
    /// Checks that the OnAdding property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOnAdding()
    {
        // Arrange
        var testValue = _fixture.Create<IInvoker>();

        // Act
        this._testClass.OnAdding = testValue;

        // Assert
        this._testClass.OnAdding.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the OnAddComplete property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOnAddComplete()
    {
        // Arrange
        var testValue = _fixture.Create<IInvoker>();

        // Act
        this._testClass.OnAddComplete = testValue;

        // Assert
        this._testClass.OnAddComplete.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the OnGetting property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOnGetting()
    {
        // Arrange
        var testValue = _fixture.Create<IInvoker>();

        // Act
        this._testClass.OnGetting = testValue;

        // Assert
        this._testClass.OnGetting.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the OnGetComplete property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOnGetComplete()
    {
        // Arrange
        var testValue = _fixture.Create<IInvoker>();

        // Act
        this._testClass.OnGetComplete = testValue;

        // Assert
        this._testClass.OnGetComplete.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the OnPatching property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOnPatching()
    {
        // Arrange
        var testValue = _fixture.Create<IInvoker>();

        // Act
        this._testClass.OnPatching = testValue;

        // Assert
        this._testClass.OnPatching.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the OnPatchComplete property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOnPatchComplete()
    {
        // Arrange
        var testValue = _fixture.Create<IInvoker>();

        // Act
        this._testClass.OnPatchComplete = testValue;

        // Assert
        this._testClass.OnPatchComplete.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the OnUpsert property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOnUpsert()
    {
        // Arrange
        var testValue = _fixture.Create<IInvoker>();

        // Act
        this._testClass.OnUpsert = testValue;

        // Assert
        this._testClass.OnUpsert.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the OnUpsertComplete property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOnUpsertComplete()
    {
        // Arrange
        var testValue = _fixture.Create<IInvoker>();

        // Act
        this._testClass.OnUpsertComplete = testValue;

        // Assert
        this._testClass.OnUpsertComplete.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the OnSetting property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOnSetting()
    {
        // Arrange
        var testValue = _fixture.Create<IInvoker>();

        // Act
        this._testClass.OnSetting = testValue;

        // Assert
        this._testClass.OnSetting.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the OnSetComplete property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOnSetComplete()
    {
        // Arrange
        var testValue = _fixture.Create<IInvoker>();

        // Act
        this._testClass.OnSetComplete = testValue;

        // Assert
        this._testClass.OnSetComplete.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the OnDeleting property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOnDeleting()
    {
        // Arrange
        var testValue = _fixture.Create<IInvoker>();

        // Act
        this._testClass.OnDeleting = testValue;

        // Assert
        this._testClass.OnDeleting.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the OnDeleteComplete property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOnDeleteComplete()
    {
        // Arrange
        var testValue = _fixture.Create<IInvoker>();

        // Act
        this._testClass.OnDeleteComplete = testValue;

        // Assert
        this._testClass.OnDeleteComplete.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the OnSaving property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOnSaving()
    {
        // Arrange
        var testValue = _fixture.Create<IInvoker>();

        // Act
        this._testClass.OnSaving = testValue;

        // Assert
        this._testClass.OnSaving.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the OnSaveComplete property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOnSaveComplete()
    {
        // Arrange
        var testValue = _fixture.Create<IInvoker>();

        // Act
        this._testClass.OnSaveComplete = testValue;

        // Assert
        this._testClass.OnSaveComplete.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the OnFiltering property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOnFiltering()
    {
        // Arrange
        var testValue = _fixture.Create<IInvoker>();

        // Act
        this._testClass.OnFiltering = testValue;

        // Assert
        this._testClass.OnFiltering.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the OnFilterComplete property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOnFilterComplete()
    {
        // Arrange
        var testValue = _fixture.Create<IInvoker>();

        // Act
        this._testClass.OnFilterComplete = testValue;

        // Assert
        this._testClass.OnFilterComplete.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the OnFinding property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOnFinding()
    {
        // Arrange
        var testValue = _fixture.Create<IInvoker>();

        // Act
        this._testClass.OnFinding = testValue;

        // Assert
        this._testClass.OnFinding.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the OnFindComplete property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOnFindComplete()
    {
        // Arrange
        var testValue = _fixture.Create<IInvoker>();

        // Act
        this._testClass.OnFindComplete = testValue;

        // Assert
        this._testClass.OnFindComplete.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the OnMapping property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOnMapping()
    {
        // Arrange
        var testValue = _fixture.Create<IInvoker>();

        // Act
        this._testClass.OnMapping = testValue;

        // Assert
        this._testClass.OnMapping.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the OnMapComplete property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOnMapComplete()
    {
        // Arrange
        var testValue = _fixture.Create<IInvoker>();

        // Act
        this._testClass.OnMapComplete = testValue;

        // Assert
        this._testClass.OnMapComplete.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the OnExist property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOnExist()
    {
        // Arrange
        var testValue = _fixture.Create<IInvoker>();

        // Act
        this._testClass.OnExist = testValue;

        // Assert
        this._testClass.OnExist.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the OnExistComplete property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOnExistComplete()
    {
        // Arrange
        var testValue = _fixture.Create<IInvoker>();

        // Act
        this._testClass.OnExistComplete = testValue;

        // Assert
        this._testClass.OnExistComplete.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the OnNonExist property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOnNonExist()
    {
        // Arrange
        var testValue = _fixture.Create<IInvoker>();

        // Act
        this._testClass.OnNonExist = testValue;

        // Assert
        this._testClass.OnNonExist.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the OnNonExistComplete property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOnNonExistComplete()
    {
        // Arrange
        var testValue = _fixture.Create<IInvoker>();

        // Act
        this._testClass.OnNonExistComplete = testValue;

        // Assert
        this._testClass.OnNonExistComplete.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the OnValidating property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOnValidating()
    {
        // Arrange
        var testValue = _fixture.Create<IInvoker>();

        // Act
        this._testClass.OnValidating = testValue;

        // Assert
        this._testClass.OnValidating.Should().BeSameAs(testValue);
    }

    /// <summary>
    /// Checks that the OnValidateComplete property can be read from and written to.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOnValidateComplete()
    {
        // Arrange
        var testValue = _fixture.Create<IInvoker>();

        // Act
        this._testClass.OnValidateComplete = testValue;

        // Assert
        this._testClass.OnValidateComplete.Should().BeSameAs(testValue);
    }
}