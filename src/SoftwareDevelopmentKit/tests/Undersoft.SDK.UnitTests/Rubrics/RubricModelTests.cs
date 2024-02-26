using System;
using System.Reflection;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Rubrics;

namespace Undersoft.SDK.UnitTests.Rubrics;

/// <summary>
/// Unit tests for the type <see cref="RubricModel"/>.
/// </summary>
public class RubricModelTests
{
    private RubricModel _testClass;
    private IFixture _fixture;
    private MemberRubric _member;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="RubricModel"/>.
    /// </summary>
    public RubricModelTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._member = _fixture.Create<MemberRubric>();
        this._testClass = _fixture.Create<RubricModel>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new RubricModel(this._member);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the member parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullMember()
    {
        FluentActions.Invoking(() => new RubricModel(default(MemberRubric))).Should().Throw<ArgumentNullException>().WithParameterName("member");
    }

    /// <summary>
    /// Checks that the SetMember method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetMember()
    {
        // Arrange
        var member = _fixture.Create<MemberRubric>();

        // Act
        var result = this._testClass.SetMember(member);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetMember method throws when the member parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetMemberWithNullMember()
    {
        FluentActions.Invoking(() => this._testClass.SetMember(default(MemberRubric))).Should().Throw<ArgumentNullException>().WithParameterName("member");
    }

    /// <summary>
    /// Checks that the SetMember maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void SetMemberPerformsMapping()
    {
        // Arrange
        var member = _fixture.Create<MemberRubric>();

        // Act
        var result = this._testClass.SetMember(member);

        // Assert
        result.DeclaringType.Should().BeSameAs(member.DeclaringType);
        result.MemberType.Should().Be(member.MemberType);
        result.Name.Should().BeSameAs(member.Name);
        result.ReflectedType.Should().BeSameAs(member.ReflectedType);
    }

    /// <summary>
    /// Checks that the SetProperty method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetProperty()
    {
        // Arrange
        var @property = _fixture.Create<PropertyRubric>();

        // Act
        var result = this._testClass.SetProperty(property);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetProperty method throws when the property parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetPropertyWithNullProperty()
    {
        FluentActions.Invoking(() => this._testClass.SetProperty(default(PropertyRubric))).Should().Throw<ArgumentNullException>().WithParameterName("property");
    }

    /// <summary>
    /// Checks that the SetField method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetField()
    {
        // Arrange
        var @field = _fixture.Create<FieldRubric>();

        // Act
        var result = this._testClass.SetField(field);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetField method throws when the field parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetFieldWithNullField()
    {
        FluentActions.Invoking(() => this._testClass.SetField(default(FieldRubric))).Should().Throw<ArgumentNullException>().WithParameterName("field");
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
    /// Checks that setting the FieldName property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetFieldName()
    {
        this._testClass.CheckProperty(x => x.FieldName);
    }

    /// <summary>
    /// Checks that setting the Type property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetType()
    {
        this._testClass.CheckProperty(x => x.Type, _fixture.Create<Type>(), _fixture.Create<Type>());
    }

    /// <summary>
    /// Checks that setting the Member property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetMember()
    {
        this._testClass.CheckProperty(x => x.Member, _fixture.Create<MemberRubric>(), _fixture.Create<MemberRubric>());
    }

    /// <summary>
    /// Checks that setting the Property property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetProperty()
    {
        this._testClass.CheckProperty(x => x.Property, _fixture.Create<PropertyRubric>(), _fixture.Create<PropertyRubric>());
    }

    /// <summary>
    /// Checks that setting the Field property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetField()
    {
        this._testClass.CheckProperty(x => x.Field, _fixture.Create<FieldRubric>(), _fixture.Create<FieldRubric>());
    }

    /// <summary>
    /// Checks that setting the Getter property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetGetter()
    {
        this._testClass.CheckProperty(x => x.Getter, _fixture.Create<MethodInfo>(), _fixture.Create<MethodInfo>());
    }

    /// <summary>
    /// Checks that setting the Setter property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetSetter()
    {
        this._testClass.CheckProperty(x => x.Setter, _fixture.Create<MethodInfo>(), _fixture.Create<MethodInfo>());
    }

    /// <summary>
    /// Checks that setting the FieldType property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetFieldType()
    {
        this._testClass.CheckProperty(x => x.FieldType, _fixture.Create<Type>(), _fixture.Create<Type>());
    }
}