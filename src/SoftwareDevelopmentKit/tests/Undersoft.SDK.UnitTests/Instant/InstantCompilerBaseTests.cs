using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Instant;
using Undersoft.SDK.Instant.Attributes;
using Undersoft.SDK.Rubrics;
using Undersoft.SDK.Rubrics.Attributes;

namespace Undersoft.SDK.UnitTests.Instant;

/// <summary>
/// Unit tests for the type <see cref="InstantCompilerBase"/>.
/// </summary>
public class InstantCompilerBaseTests
{
    private InstantCompilerBase _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="InstantCompilerBase"/>.
    /// </summary>
    public InstantCompilerBaseTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<InstantCompilerBase>();
    }

    /// <summary>
    /// Checks that the ResolveMemberAttributes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallResolveMemberAttributes()
    {
        // Arrange
        var fb = _fixture.Create<FieldBuilder>();
        var mi = _fixture.Create<MemberInfo>();
        var mr = _fixture.Create<MemberRubric>();

        // Act
        var result = this._testClass.ResolveMemberAttributes(fb, mi, mr);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ResolveMemberAttributes method throws when the fb parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallResolveMemberAttributesWithNullFb()
    {
        FluentActions.Invoking(() => this._testClass.ResolveMemberAttributes(default(FieldBuilder), _fixture.Create<MemberInfo>(), _fixture.Create<MemberRubric>())).Should().Throw<ArgumentNullException>().WithParameterName("fb");
    }

    /// <summary>
    /// Checks that the ResolveMemberAttributes method throws when the mi parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallResolveMemberAttributesWithNullMi()
    {
        FluentActions.Invoking(() => this._testClass.ResolveMemberAttributes(_fixture.Create<FieldBuilder>(), default(MemberInfo), _fixture.Create<MemberRubric>())).Should().Throw<ArgumentNullException>().WithParameterName("mi");
    }

    /// <summary>
    /// Checks that the ResolveMemberAttributes method throws when the mr parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallResolveMemberAttributesWithNullMr()
    {
        FluentActions.Invoking(() => this._testClass.ResolveMemberAttributes(_fixture.Create<FieldBuilder>(), _fixture.Create<MemberInfo>(), default(MemberRubric))).Should().Throw<ArgumentNullException>().WithParameterName("mr");
    }

    /// <summary>
    /// Checks that the ResolveMemberAttributes maps values from the input to the returned instance.
    /// </summary>
    [TestMethod]
    public void ResolveMemberAttributesPerformsMapping()
    {
        // Arrange
        var fb = _fixture.Create<FieldBuilder>();
        var mi = _fixture.Create<MemberInfo>();
        var mr = _fixture.Create<MemberRubric>();

        // Act
        var result = this._testClass.ResolveMemberAttributes(fb, mi, mr);

        // Assert
        result.DeclaringType.Should().BeSameAs(fb.DeclaringType);
        result.Name.Should().BeSameAs(fb.Name);
        result.ReflectedType.Should().BeSameAs(fb.ReflectedType);
        result.DeclaringType.Should().BeSameAs(mi.DeclaringType);
        result.MemberType.Should().Be(mi.MemberType);
        result.Name.Should().BeSameAs(mi.Name);
        result.ReflectedType.Should().BeSameAs(mi.ReflectedType);
    }

    /// <summary>
    /// Checks that the ResolveMarshalAsAttributeForArray method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallResolveMarshalAsAttributeForArray()
    {
        // Arrange
        var @field = _fixture.Create<FieldBuilder>();
        var member = _fixture.Create<MemberRubric>();
        var @type = _fixture.Create<Type>();

        // Act
        this._testClass.ResolveMarshalAsAttributeForArray(field, member, type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ResolveMarshalAsAttributeForArray method throws when the field parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallResolveMarshalAsAttributeForArrayWithNullField()
    {
        FluentActions.Invoking(() => this._testClass.ResolveMarshalAsAttributeForArray(default(FieldBuilder), _fixture.Create<MemberRubric>(), _fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("field");
    }

    /// <summary>
    /// Checks that the ResolveMarshalAsAttributeForArray method throws when the member parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallResolveMarshalAsAttributeForArrayWithNullMember()
    {
        FluentActions.Invoking(() => this._testClass.ResolveMarshalAsAttributeForArray(_fixture.Create<FieldBuilder>(), default(MemberRubric), _fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("member");
    }

    /// <summary>
    /// Checks that the ResolveMarshalAsAttributeForArray method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallResolveMarshalAsAttributeForArrayWithNullType()
    {
        FluentActions.Invoking(() => this._testClass.ResolveMarshalAsAttributeForArray(_fixture.Create<FieldBuilder>(), _fixture.Create<MemberRubric>(), default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the ResolveMarshalAsAttributeForString method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallResolveMarshalAsAttributeForString()
    {
        // Arrange
        var @field = _fixture.Create<FieldBuilder>();
        var member = _fixture.Create<MemberRubric>();
        var @type = _fixture.Create<Type>();

        // Act
        this._testClass.ResolveMarshalAsAttributeForString(field, member, type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ResolveMarshalAsAttributeForString method throws when the field parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallResolveMarshalAsAttributeForStringWithNullField()
    {
        FluentActions.Invoking(() => this._testClass.ResolveMarshalAsAttributeForString(default(FieldBuilder), _fixture.Create<MemberRubric>(), _fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("field");
    }

    /// <summary>
    /// Checks that the ResolveMarshalAsAttributeForString method throws when the member parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallResolveMarshalAsAttributeForStringWithNullMember()
    {
        FluentActions.Invoking(() => this._testClass.ResolveMarshalAsAttributeForString(_fixture.Create<FieldBuilder>(), default(MemberRubric), _fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("member");
    }

    /// <summary>
    /// Checks that the ResolveMarshalAsAttributeForString method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallResolveMarshalAsAttributeForStringWithNullType()
    {
        FluentActions.Invoking(() => this._testClass.ResolveMarshalAsAttributeForString(_fixture.Create<FieldBuilder>(), _fixture.Create<MemberRubric>(), default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the CreateInstantCreatorAsAttribute method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateInstantCreatorAsAttribute()
    {
        // Arrange
        var @field = _fixture.Create<FieldBuilder>();
        var attrib = _fixture.Create<InstantAsAttribute>();

        // Act
        this._testClass.CreateInstantCreatorAsAttribute(field, attrib);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateInstantCreatorAsAttribute method throws when the field parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateInstantCreatorAsAttributeWithNullField()
    {
        FluentActions.Invoking(() => this._testClass.CreateInstantCreatorAsAttribute(default(FieldBuilder), _fixture.Create<InstantAsAttribute>())).Should().Throw<ArgumentNullException>().WithParameterName("field");
    }

    /// <summary>
    /// Checks that the CreateInstantCreatorAsAttribute method throws when the attrib parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateInstantCreatorAsAttributeWithNullAttrib()
    {
        FluentActions.Invoking(() => this._testClass.CreateInstantCreatorAsAttribute(_fixture.Create<FieldBuilder>(), default(InstantAsAttribute))).Should().Throw<ArgumentNullException>().WithParameterName("attrib");
    }

    /// <summary>
    /// Checks that the CreateInstantCreatorDisplayAttribute method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateInstantCreatorDisplayAttribute()
    {
        // Arrange
        var @field = _fixture.Create<FieldBuilder>();
        var attrib = _fixture.Create<DisplayRubricAttribute>();

        // Act
        this._testClass.CreateInstantCreatorDisplayAttribute(field, attrib);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateInstantCreatorDisplayAttribute method throws when the field parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateInstantCreatorDisplayAttributeWithNullField()
    {
        FluentActions.Invoking(() => this._testClass.CreateInstantCreatorDisplayAttribute(default(FieldBuilder), _fixture.Create<DisplayRubricAttribute>())).Should().Throw<ArgumentNullException>().WithParameterName("field");
    }

    /// <summary>
    /// Checks that the CreateInstantCreatorDisplayAttribute method throws when the attrib parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateInstantCreatorDisplayAttributeWithNullAttrib()
    {
        FluentActions.Invoking(() => this._testClass.CreateInstantCreatorDisplayAttribute(_fixture.Create<FieldBuilder>(), default(DisplayRubricAttribute))).Should().Throw<ArgumentNullException>().WithParameterName("attrib");
    }

    /// <summary>
    /// Checks that the CreateInstantCreatorIdentityAttribute method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateInstantCreatorIdentityAttribute()
    {
        // Arrange
        var @field = _fixture.Create<FieldBuilder>();
        var attrib = _fixture.Create<IdentityRubricAttribute>();

        // Act
        this._testClass.CreateInstantCreatorIdentityAttribute(field, attrib);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateInstantCreatorIdentityAttribute method throws when the field parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateInstantCreatorIdentityAttributeWithNullField()
    {
        FluentActions.Invoking(() => this._testClass.CreateInstantCreatorIdentityAttribute(default(FieldBuilder), _fixture.Create<IdentityRubricAttribute>())).Should().Throw<ArgumentNullException>().WithParameterName("field");
    }

    /// <summary>
    /// Checks that the CreateInstantCreatorIdentityAttribute method throws when the attrib parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateInstantCreatorIdentityAttributeWithNullAttrib()
    {
        FluentActions.Invoking(() => this._testClass.CreateInstantCreatorIdentityAttribute(_fixture.Create<FieldBuilder>(), default(IdentityRubricAttribute))).Should().Throw<ArgumentNullException>().WithParameterName("attrib");
    }

    /// <summary>
    /// Checks that the CreateInstantCreatorKeyAttribute method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateInstantCreatorKeyAttribute()
    {
        // Arrange
        var @field = _fixture.Create<FieldBuilder>();
        var attrib = _fixture.Create<KeyRubricAttribute>();

        // Act
        this._testClass.CreateInstantCreatorKeyAttribute(field, attrib);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateInstantCreatorKeyAttribute method throws when the field parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateInstantCreatorKeyAttributeWithNullField()
    {
        FluentActions.Invoking(() => this._testClass.CreateInstantCreatorKeyAttribute(default(FieldBuilder), _fixture.Create<KeyRubricAttribute>())).Should().Throw<ArgumentNullException>().WithParameterName("field");
    }

    /// <summary>
    /// Checks that the CreateInstantCreatorKeyAttribute method throws when the attrib parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateInstantCreatorKeyAttributeWithNullAttrib()
    {
        FluentActions.Invoking(() => this._testClass.CreateInstantCreatorKeyAttribute(_fixture.Create<FieldBuilder>(), default(KeyRubricAttribute))).Should().Throw<ArgumentNullException>().WithParameterName("attrib");
    }

    /// <summary>
    /// Checks that the CreateInstantCreatorRequiredAttribute method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateInstantCreatorRequiredAttribute()
    {
        // Arrange
        var @field = _fixture.Create<FieldBuilder>();

        // Act
        this._testClass.CreateInstantCreatorRequiredAttribute(field);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateInstantCreatorRequiredAttribute method throws when the field parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateInstantCreatorRequiredAttributeWithNullField()
    {
        FluentActions.Invoking(() => this._testClass.CreateInstantCreatorRequiredAttribute(default(FieldBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("field");
    }

    /// <summary>
    /// Checks that the CreateInstantCreatorVisibleAttribute method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateInstantCreatorVisibleAttribute()
    {
        // Arrange
        var @field = _fixture.Create<FieldBuilder>();

        // Act
        this._testClass.CreateInstantCreatorVisibleAttribute(field);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateInstantCreatorVisibleAttribute method throws when the field parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateInstantCreatorVisibleAttributeWithNullField()
    {
        FluentActions.Invoking(() => this._testClass.CreateInstantCreatorVisibleAttribute(default(FieldBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("field");
    }

    /// <summary>
    /// Checks that the CreateInstantCreatorExpandAttribute method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateInstantCreatorExpandAttribute()
    {
        // Arrange
        var @field = _fixture.Create<FieldBuilder>();

        // Act
        this._testClass.CreateInstantCreatorExpandAttribute(field);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateInstantCreatorExpandAttribute method throws when the field parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateInstantCreatorExpandAttributeWithNullField()
    {
        FluentActions.Invoking(() => this._testClass.CreateInstantCreatorExpandAttribute(default(FieldBuilder))).Should().Throw<ArgumentNullException>().WithParameterName("field");
    }

    /// <summary>
    /// Checks that the CreateInstantCreatorAggregateAttribute method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateInstantCreatorAggregateAttribute()
    {
        // Arrange
        var @field = _fixture.Create<FieldBuilder>();
        var attrib = _fixture.Create<RubricAggregateAttribute>();

        // Act
        this._testClass.CreateInstantCreatorAggregateAttribute(field, attrib);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateInstantCreatorAggregateAttribute method throws when the field parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateInstantCreatorAggregateAttributeWithNullField()
    {
        FluentActions.Invoking(() => this._testClass.CreateInstantCreatorAggregateAttribute(default(FieldBuilder), _fixture.Create<RubricAggregateAttribute>())).Should().Throw<ArgumentNullException>().WithParameterName("field");
    }

    /// <summary>
    /// Checks that the CreateInstantCreatorAggregateAttribute method throws when the attrib parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateInstantCreatorAggregateAttributeWithNullAttrib()
    {
        FluentActions.Invoking(() => this._testClass.CreateInstantCreatorAggregateAttribute(_fixture.Create<FieldBuilder>(), default(RubricAggregateAttribute))).Should().Throw<ArgumentNullException>().WithParameterName("attrib");
    }

    /// <summary>
    /// Checks that the CreateInstantCreatorLinkAttribute method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateInstantCreatorLinkAttribute()
    {
        // Arrange
        var @field = _fixture.Create<FieldBuilder>();
        var attrib = _fixture.Create<LinkAttribute>();

        // Act
        this._testClass.CreateInstantCreatorLinkAttribute(field, attrib);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateInstantCreatorLinkAttribute method throws when the field parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateInstantCreatorLinkAttributeWithNullField()
    {
        FluentActions.Invoking(() => this._testClass.CreateInstantCreatorLinkAttribute(default(FieldBuilder), _fixture.Create<LinkAttribute>())).Should().Throw<ArgumentNullException>().WithParameterName("field");
    }

    /// <summary>
    /// Checks that the CreateInstantCreatorLinkAttribute method throws when the attrib parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateInstantCreatorLinkAttributeWithNullAttrib()
    {
        FluentActions.Invoking(() => this._testClass.CreateInstantCreatorLinkAttribute(_fixture.Create<FieldBuilder>(), default(LinkAttribute))).Should().Throw<ArgumentNullException>().WithParameterName("attrib");
    }

    /// <summary>
    /// Checks that the CreateInstantCreatorInvokeAttribute method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateInstantCreatorInvokeAttribute()
    {
        // Arrange
        var @field = _fixture.Create<FieldBuilder>();
        var attrib = _fixture.Create<InvokeAttribute>();

        // Act
        this._testClass.CreateInstantCreatorInvokeAttribute(field, attrib);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateInstantCreatorInvokeAttribute method throws when the field parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateInstantCreatorInvokeAttributeWithNullField()
    {
        FluentActions.Invoking(() => this._testClass.CreateInstantCreatorInvokeAttribute(default(FieldBuilder), _fixture.Create<InvokeAttribute>())).Should().Throw<ArgumentNullException>().WithParameterName("field");
    }

    /// <summary>
    /// Checks that the CreateInstantCreatorInvokeAttribute method throws when the attrib parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateInstantCreatorInvokeAttributeWithNullAttrib()
    {
        FluentActions.Invoking(() => this._testClass.CreateInstantCreatorInvokeAttribute(_fixture.Create<FieldBuilder>(), default(InvokeAttribute))).Should().Throw<ArgumentNullException>().WithParameterName("attrib");
    }

    /// <summary>
    /// Checks that the CreateMarshaAslAttribute method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCreateMarshaAslAttribute()
    {
        // Arrange
        var @field = _fixture.Create<FieldBuilder>();
        var attrib = _fixture.Create<MarshalAsAttribute>();

        // Act
        this._testClass.CreateMarshaAslAttribute(field, attrib);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CreateMarshaAslAttribute method throws when the field parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateMarshaAslAttributeWithNullField()
    {
        FluentActions.Invoking(() => this._testClass.CreateMarshaAslAttribute(default(FieldBuilder), _fixture.Create<MarshalAsAttribute>())).Should().Throw<ArgumentNullException>().WithParameterName("field");
    }

    /// <summary>
    /// Checks that the CreateMarshaAslAttribute method throws when the attrib parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCreateMarshaAslAttributeWithNullAttrib()
    {
        FluentActions.Invoking(() => this._testClass.CreateMarshaAslAttribute(_fixture.Create<FieldBuilder>(), default(MarshalAsAttribute))).Should().Throw<ArgumentNullException>().WithParameterName("attrib");
    }
}