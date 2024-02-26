using System;
using System.Reflection.Emit;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Proxies;
using Undersoft.SDK.Rubrics;
using Undersoft.SDK.Series;

namespace Undersoft.SDK.UnitTests.Proxies;

/// <summary>
/// Unit tests for the type <see cref="ProxyCompilerBase"/>.
/// </summary>
public class ProxyCompilerBaseTests
{
    private class TestProxyCompilerBase : ProxyCompilerBase
    {
        public TestProxyCompilerBase(ProxyCreator creator, ISeries<RubricModel> rubricBuilders) : base(creator, rubricBuilders)
        {
        }

        public override Type CompileProxyType(string typeName)
        {
            return default(Type);
        }

        public override TypeBuilder GetTypeBuilder(string typeName)
        {
            return default(TypeBuilder);
        }

        public override void CreateCompareToMethod(TypeBuilder tb)
        {
        }

        public override void CreateEqualsMethod(TypeBuilder tb)
        {
        }

        public override void CreateFieldsAndProperties(TypeBuilder tb)
        {
        }

        public override void CreateGetBytesMethod(TypeBuilder tb)
        {
        }

        public override void CreateTargetProperty(TypeBuilder tb, Type @type, string name)
        {
        }

        public override void CreateItemByIntProperty(TypeBuilder tb)
        {
        }

        public override void CreateItemByStringProperty(TypeBuilder tb)
        {
        }

        public override void CreateRubricsProperty(TypeBuilder tb, Type @type, string name)
        {
        }

        public override void CreateCodeProperty(TypeBuilder tb, Type @type, string name)
        {
        }

        public override void CreateValueArrayProperty(TypeBuilder tb)
        {
        }
    }

    private TestProxyCompilerBase _testClass;
    private IFixture _fixture;
    private ProxyCreator _creator;
    private Mock<ISeries<RubricModel>> _rubricBuilders;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="ProxyCompilerBase"/>.
    /// </summary>
    public ProxyCompilerBaseTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._creator = _fixture.Create<ProxyCreator>();
        this._rubricBuilders = _fixture.Freeze<Mock<ISeries<RubricModel>>>();
        this._testClass = _fixture.Create<TestProxyCompilerBase>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestProxyCompilerBase(this._creator, this._rubricBuilders.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the creator parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullCreator()
    {
        FluentActions.Invoking(() => new TestProxyCompilerBase(default(ProxyCreator), this._rubricBuilders.Object)).Should().Throw<ArgumentNullException>().WithParameterName("creator");
    }

    /// <summary>
    /// Checks that instance construction throws when the rubricBuilders parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRubricBuilders()
    {
        FluentActions.Invoking(() => new TestProxyCompilerBase(this._creator, default(ISeries<RubricModel>))).Should().Throw<ArgumentNullException>().WithParameterName("rubricBuilders");
    }

    /// <summary>
    /// Checks that the CreateGetEmptyProperty method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateGetEmptyProperty()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();

        // Act
        this._testClass.CreateGetEmptyProperty(tb);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateGetEmptyProperty method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateGetEmptyPropertyWithNullTb()
    {
        FluentActions.Invoking(() => this._testClass.CreateGetEmptyProperty(default(TypeBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }

    /// <summary>
    /// Checks that the CreateGetGenericByIntMethod method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateGetGenericByIntMethod()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();

        // Act
        this._testClass.CreateGetGenericByIntMethod(tb);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateGetGenericByIntMethod method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateGetGenericByIntMethodWithNullTb()
    {
        FluentActions.Invoking(() => this._testClass.CreateGetGenericByIntMethod(default(TypeBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }

    /// <summary>
    /// Checks that the CreateGetIdBytesMethod method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateGetIdBytesMethod()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();

        // Act
        this._testClass.CreateGetIdBytesMethod(tb);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateGetIdBytesMethod method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateGetIdBytesMethodWithNullTb()
    {
        FluentActions.Invoking(() => this._testClass.CreateGetIdBytesMethod(default(TypeBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }

    /// <summary>
    /// Checks that the CreateGetIdMethod method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateGetIdMethod()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();

        // Act
        this._testClass.CreateGetIdMethod(tb);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateGetIdMethod method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateGetIdMethodWithNullTb()
    {
        FluentActions.Invoking(() => this._testClass.CreateGetIdMethod(default(TypeBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }

    /// <summary>
    /// Checks that the CreateGetTypeIdMethod method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateGetTypeIdMethod()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();

        // Act
        this._testClass.CreateGetTypeIdMethod(tb);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateGetTypeIdMethod method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateGetTypeIdMethodWithNullTb()
    {
        FluentActions.Invoking(() => this._testClass.CreateGetTypeIdMethod(default(TypeBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }

    /// <summary>
    /// Checks that the CreateSetIdMethod method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateSetIdMethod()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();

        // Act
        this._testClass.CreateSetIdMethod(tb);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateSetIdMethod method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateSetIdMethodWithNullTb()
    {
        FluentActions.Invoking(() => this._testClass.CreateSetIdMethod(default(TypeBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }

    /// <summary>
    /// Checks that the CreateSetTypeIdMethod method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateSetTypeIdMethod()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();

        // Act
        this._testClass.CreateSetTypeIdMethod(tb);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateSetTypeIdMethod method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateSetTypeIdMethodWithNullTb()
    {
        FluentActions.Invoking(() => this._testClass.CreateSetTypeIdMethod(default(TypeBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }

    /// <summary>
    /// Checks that the CreateIdProperty method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateIdProperty()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();

        // Act
        this._testClass.CreateIdProperty(tb);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateIdProperty method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateIdPropertyWithNullTb()
    {
        FluentActions.Invoking(() => this._testClass.CreateIdProperty(default(TypeBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }

    /// <summary>
    /// Checks that the CreateTypeIdProperty method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateTypeIdProperty()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();

        // Act
        this._testClass.CreateTypeIdProperty(tb);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateTypeIdProperty method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateTypeIdPropertyWithNullTb()
    {
        FluentActions.Invoking(() => this._testClass.CreateTypeIdProperty(default(TypeBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }
}