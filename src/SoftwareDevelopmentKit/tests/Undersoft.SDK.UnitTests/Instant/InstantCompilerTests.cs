using System;
using System.Reflection.Emit;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK.Instant;
using Undersoft.SDK.Instant.Attributes;
using Undersoft.SDK.Rubrics;
using Undersoft.SDK.Series;

namespace Undersoft.SDK.UnitTests.Instant;

/// <summary>
/// Unit tests for the type <see cref="InstantCompiler"/>.
/// </summary>
public class InstantCompilerTests
{
    private class TestInstantCompiler : InstantCompiler
    {
        public TestInstantCompiler(
            InstantCreator instantInstantCreator,
            ISeries<RubricModel> rubricBuilders
        ) : base(instantInstantCreator, rubricBuilders
)
        {
        }

        public bool PublicIsDerived => base.IsDerived;

        public override Type CompileInstantType(string typeName)
        {
            return default(Type);
        }

        public override TypeBuilder GetTypeBuilder(string typeName)
        {
            return default(TypeBuilder);
        }

        public override void CreateFieldsAndProperties(TypeBuilder tb)
        {
        }

        public override void CreateGetBytesMethod(TypeBuilder tb)
        {
        }

        public override void CreateItemByIntProperty(TypeBuilder tb)
        {
        }

        public override void CreateItemByStringProperty(TypeBuilder tb)
        {
        }

        public override void CreateCodeProperty(TypeBuilder tb, Type @type, string name)
        {
        }

        public override void CreateValueArrayProperty(TypeBuilder tb)
        {
        }
    }

    private TestInstantCompiler _testClass;
    private IFixture _fixture;
    private InstantCreator _instantInstantCreator;
    private Mock<ISeries<RubricModel>> _rubricBuilders;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="InstantCompiler"/>.
    /// </summary>
    public InstantCompilerTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._instantInstantCreator = _fixture.Create<InstantCreator>();
        this._rubricBuilders = _fixture.Freeze<Mock<ISeries<RubricModel>>>();
        this._testClass = _fixture.Create<TestInstantCompiler>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new TestInstantCompiler(this._instantInstantCreator, this._rubricBuilders.Object);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the instantInstantCreator parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullInstantInstantCreator()
    {
        FluentActions.Invoking(() => new TestInstantCompiler(default(InstantCreator), this._rubricBuilders.Object)).Should().Throw<ArgumentNullException>().WithParameterName("instantInstantCreator");
    }

    /// <summary>
    /// Checks that instance construction throws when the rubricBuilders parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullRubricBuilders()
    {
        FluentActions.Invoking(() => new TestInstantCompiler(this._instantInstantCreator, default(ISeries<RubricModel>))).Should().Throw<ArgumentNullException>().WithParameterName("rubricBuilders");
    }

    /// <summary>
    /// Checks that the CreateCompareToMethod method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateCompareToMethod()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();

        // Act
        this._testClass.CreateCompareToMethod(tb);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateCompareToMethod method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateCompareToMethodWithNullTb()
    {
        FluentActions.Invoking(() => this._testClass.CreateCompareToMethod(default(TypeBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }

    /// <summary>
    /// Checks that the CreateEqualsMethod method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateEqualsMethod()
    {
        // Arrange
        var tb = _fixture.Create<TypeBuilder>();

        // Act
        this._testClass.CreateEqualsMethod(tb);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateEqualsMethod method throws when the tb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateEqualsMethodWithNullTb()
    {
        FluentActions.Invoking(() => this._testClass.CreateEqualsMethod(default(TypeBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("tb");
    }

    /// <summary>
    /// Checks that the CreateRubricAsAttribute method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateRubricAsAttribute()
    {
        // Arrange
        var @field = _fixture.Create<FieldBuilder>();
        var attrib = _fixture.Create<InstantAsAttribute>();

        // Act
        this._testClass.CreateRubricAsAttribute(field, attrib);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateRubricAsAttribute method throws when the field parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateRubricAsAttributeWithNullField()
    {
        FluentActions.Invoking(() => this._testClass.CreateRubricAsAttribute(default(FieldBuilder), _fixture.Create<InstantAsAttribute>())).Should().Throw<ArgumentNullException>().WithParameterName("field");
    }

    /// <summary>
    /// Checks that the CreateRubricAsAttribute method throws when the attrib parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateRubricAsAttributeWithNullAttrib()
    {
        FluentActions.Invoking(() => this._testClass.CreateRubricAsAttribute(_fixture.Create<FieldBuilder>(), default(InstantAsAttribute))).Should().Throw<ArgumentNullException>().WithParameterName("attrib");
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

    /// <summary>
    /// Checks that the PublicIsDerived property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetPublicIsDerived()
    {
        // Assert
        this._testClass.PublicIsDerived.As<object>().Should().BeAssignableTo<bool>();

        Assert.Fail("Create or modify test");
    }
}