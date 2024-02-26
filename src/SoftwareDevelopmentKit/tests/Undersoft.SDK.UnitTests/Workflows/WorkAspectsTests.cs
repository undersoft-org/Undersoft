using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Invoking;
using Undersoft.SDK.Workflows;
using Undersoft.SDK.Workflows.Notes;

namespace Undersoft.SDK.UnitTests.Workflows;

/// <summary>
/// Unit tests for the type <see cref="WorkAspects"/>.
/// </summary>
public class WorkAspectsTests
{
    private WorkAspects _testClass;
    private IFixture _fixture;
    private string _name;
    private WorkNotes _notes;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="WorkAspects"/>.
    /// </summary>
    public WorkAspectsTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._name = _fixture.Create<string>();
        this._notes = _fixture.Create<WorkNotes>();
        this._testClass = _fixture.Create<WorkAspects>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new WorkAspects(this._name, this._notes);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that the constructor throws when the name parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotConstructWithInvalidName(string value)
    {
        FluentActions.Invoking(() => new WorkAspects(value, this._notes)).Should().Throw<ArgumentNullException>().WithParameterName("name");
    }

    /// <summary>
    /// Checks that the Get method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGet()
    {
        // Arrange
        var key = _fixture.Create<string>();

        // Act
        var result = this._testClass.Get(key);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Get method throws when the key parameter is null, empty or white space.
    /// </summary>
    /// <param name="value">The parameter that receives the test case values.</param>
    [DataTestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("   ")]
    public void CannotCallGetWithInvalidKey(string value)
    {
        FluentActions.Invoking(() => this._testClass.Get(value)).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithAspect()
    {
        // Arrange
        var aspect = _fixture.Create<WorkAspect>();

        // Act
        this._testClass.Add(aspect);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the aspect parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithAspectWithNullAspect()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(WorkAspect))).Should().Throw<ArgumentNullException>().WithParameterName("aspect");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithAspects()
    {
        // Arrange
        var aspects = _fixture.Create<IEnumerable<WorkAspect>>();

        // Act
        this._testClass.Add(aspects);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the aspects parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithAspectsWithNullAspects()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(IEnumerable<WorkAspect>))).Should().Throw<ArgumentNullException>().WithParameterName("aspects");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithObjectAndWorkAspect()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var value = _fixture.Create<WorkAspect>();

        // Act
        var result = this._testClass.Add(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithObjectAndWorkAspectWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(object), _fixture.Create<WorkAspect>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Add method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithObjectAndWorkAspectWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.Add(_fixture.Create<object>(), default(WorkAspect))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithObjectAndIEnumerableOfWorkItem()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var value = _fixture.Create<IEnumerable<WorkItem>>();

        // Act
        this._testClass.Add(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithObjectAndIEnumerableOfWorkItemWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(object), _fixture.Create<IEnumerable<WorkItem>>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Add method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithObjectAndIEnumerableOfWorkItemWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.Add(_fixture.Create<object>(), default(IEnumerable<WorkItem>))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithObjectAndIEnumerableOfIInvoker()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var value = _fixture.Create<IEnumerable<IInvoker>>();

        // Act
        var result = this._testClass.Add(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithObjectAndIEnumerableOfIInvokerWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(object), _fixture.Create<IEnumerable<IInvoker>>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Add method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithObjectAndIEnumerableOfIInvokerWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.Add(_fixture.Create<object>(), default(IEnumerable<IInvoker>))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that the Add method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddWithObjectAndIInvoker()
    {
        // Arrange
        var key = _fixture.Create<object>();
        var value = _fixture.Create<IInvoker>();

        // Act
        this._testClass.Add(key, value);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Add method throws when the key parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithObjectAndIInvokerWithNullKey()
    {
        FluentActions.Invoking(() => this._testClass.Add(default(object), _fixture.Create<IInvoker>())).Should().Throw<ArgumentNullException>().WithParameterName("key");
    }

    /// <summary>
    /// Checks that the Add method throws when the value parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddWithObjectAndIInvokerWithNullValue()
    {
        FluentActions.Invoking(() => this._testClass.Add(_fixture.Create<object>(), default(IInvoker))).Should().Throw<ArgumentNullException>().WithParameterName("value");
    }

    /// <summary>
    /// Checks that setting the Name property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetName()
    {
        this._testClass.CheckProperty(x => x.Name);
    }

    /// <summary>
    /// Checks that setting the Methods property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetMethods()
    {
        this._testClass.CheckProperty(x => x.Methods, _fixture.Create<WorkMethods>(), _fixture.Create<WorkMethods>());
    }

    /// <summary>
    /// Checks that setting the Notes property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetNotes()
    {
        this._testClass.CheckProperty(x => x.Notes, _fixture.Create<WorkNotes>(), _fixture.Create<WorkNotes>());
    }

    /// <summary>
    /// Checks that the indexer functions correctly.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIndexer()
    {
        var testValue = _fixture.Create<WorkAspect>();
        this._testClass[_fixture.Create<object>()].Should().BeAssignableTo<WorkAspect>();
        this._testClass[_fixture.Create<object>()] = testValue;
        this._testClass[_fixture.Create<object>()].Should().BeSameAs(testValue);
    }
}