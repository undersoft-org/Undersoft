using System;
using System.Reflection;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Undersoft.SDK;
using Undersoft.SDK.Invoking;
using Undersoft.SDK.Rubrics;
using Undersoft.SDK.Uniques;
using TEntity = System.String;

namespace Undersoft.SDK.UnitTests.Rubrics;

/// <summary>
/// Unit tests for the type <see cref="MemberRubric"/>.
/// </summary>
public class MemberRubricTests
{
    private MemberRubric _testClass;
    private IFixture _fixture;
    private FieldInfo _fieldFieldInfo;
    private FieldRubric _fieldFieldRubric;
    private Mock<IMemberRubric> _memberIMemberRubric;
    private MethodInfo _methodMethodInfo;
    private MethodRubric _methodMethodRubric;
    private PropertyInfo _propertyPropertyInfo;
    private PropertyRubric _propertyPropertyRubric;
    private MemberRubric _memberMemberRubric;
    private bool _copyMode;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="MemberRubric"/>.
    /// </summary>
    public MemberRubricTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._fieldFieldInfo = _fixture.Create<FieldInfo>();
        this._fieldFieldRubric = _fixture.Create<FieldRubric>();
        this._memberIMemberRubric = _fixture.Freeze<Mock<IMemberRubric>>();
        this._methodMethodInfo = _fixture.Create<MethodInfo>();
        this._methodMethodRubric = _fixture.Create<MethodRubric>();
        this._propertyPropertyInfo = _fixture.Create<PropertyInfo>();
        this._propertyPropertyRubric = _fixture.Create<PropertyRubric>();
        this._memberMemberRubric = _fixture.Create<MemberRubric>();
        this._copyMode = _fixture.Create<bool>();
        this._testClass = _fixture.Create<MemberRubric>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new MemberRubric();

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new MemberRubric(this._fieldFieldInfo);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new MemberRubric(this._fieldFieldRubric);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new MemberRubric(this._memberIMemberRubric.Object);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new MemberRubric(this._methodMethodInfo);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new MemberRubric(this._methodMethodRubric);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new MemberRubric(this._propertyPropertyInfo);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new MemberRubric(this._propertyPropertyRubric);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new MemberRubric(this._memberMemberRubric, this._copyMode);

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the field parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullField()
    {
        FluentActions.Invoking(() => new MemberRubric(default(FieldInfo))).Should().Throw<ArgumentNullException>().WithParameterName("field");
        FluentActions.Invoking(() => new MemberRubric(default(FieldRubric))).Should().Throw<ArgumentNullException>().WithParameterName("field");
    }

    /// <summary>
    /// Checks that instance construction throws when the member parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullMember()
    {
        FluentActions.Invoking(() => new MemberRubric(default(IMemberRubric))).Should().Throw<ArgumentNullException>().WithParameterName("member");
        FluentActions.Invoking(() => new MemberRubric(default(MemberRubric), this._copyMode)).Should().Throw<ArgumentNullException>().WithParameterName("member");
    }

    /// <summary>
    /// Checks that instance construction throws when the method parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullMethod()
    {
        FluentActions.Invoking(() => new MemberRubric(default(MethodInfo))).Should().Throw<ArgumentNullException>().WithParameterName("method");
        FluentActions.Invoking(() => new MemberRubric(default(MethodRubric))).Should().Throw<ArgumentNullException>().WithParameterName("method");
    }

    /// <summary>
    /// Checks that instance construction throws when the property parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullProperty()
    {
        FluentActions.Invoking(() => new MemberRubric(default(PropertyInfo))).Should().Throw<ArgumentNullException>().WithParameterName("property");
        FluentActions.Invoking(() => new MemberRubric(default(PropertyRubric))).Should().Throw<ArgumentNullException>().WithParameterName("property");
    }

    /// <summary>
    /// Checks that the GetCustomAttributes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetCustomAttributesWithInherit()
    {
        // Arrange
        var inherit = _fixture.Create<bool>();

        // Act
        var result = this._testClass.GetCustomAttributes(inherit);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetCustomAttributes method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetCustomAttributesWithTypeAndBool()
    {
        // Arrange
        var attributeType = _fixture.Create<Type>();
        var inherit = _fixture.Create<bool>();

        // Act
        var result = this._testClass.GetCustomAttributes(attributeType, inherit);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetCustomAttributes method throws when the attributeType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetCustomAttributesWithTypeAndBoolWithNullAttributeType()
    {
        FluentActions.Invoking(() => this._testClass.GetCustomAttributes(default(Type), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("attributeType");
    }

    /// <summary>
    /// Checks that the IsDefined method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallIsDefined()
    {
        // Arrange
        var attributeType = _fixture.Create<Type>();
        var inherit = _fixture.Create<bool>();

        // Act
        var result = this._testClass.IsDefined(attributeType, inherit);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the IsDefined method throws when the attributeType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallIsDefinedWithNullAttributeType()
    {
        FluentActions.Invoking(() => this._testClass.IsDefined(default(Type), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("attributeType");
    }

    /// <summary>
    /// Checks that the ShalowCopy method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallShalowCopy()
    {
        // Arrange
        var dst = _fixture.Create<MemberRubric>();

        // Act
        var result = this._testClass.ShalowCopy(dst);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ShalowCopy method throws when the dst parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallShalowCopyWithNullDst()
    {
        FluentActions.Invoking(() => this._testClass.ShalowCopy(default(MemberRubric))).Should().Throw<ArgumentNullException>().WithParameterName("dst");
    }

    /// <summary>
    /// Checks that the CopyAttributeValues method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCopyAttributeValues()
    {
        // Arrange
        var dst = _fixture.Create<MemberRubric>();

        // Act
        var result = this._testClass.CopyAttributeValues(dst);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CopyAttributeValues method throws when the dst parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCopyAttributeValuesWithNullDst()
    {
        FluentActions.Invoking(() => this._testClass.CopyAttributeValues(default(MemberRubric))).Should().Throw<ArgumentNullException>().WithParameterName("dst");
    }

    /// <summary>
    /// Checks that the AutoId method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAutoId()
    {
        // Act
        var result = this._testClass.AutoId();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetPriority method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetPriority()
    {
        // Act
        var result = this._testClass.GetPriority();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetId method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetIdWithLong()
    {
        // Arrange
        var id = _fixture.Create<long>();

        // Act
        var result = this._testClass.SetId(id);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetId method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetIdWithObject()
    {
        // Arrange
        var id = _fixture.Create<object>();

        // Act
        var result = this._testClass.SetId(id);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetId method throws when the id parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSetIdWithObjectWithNullId()
    {
        FluentActions.Invoking(() => this._testClass.SetId(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("id");
    }

    /// <summary>
    /// Checks that the Equals method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallEquals()
    {
        // Arrange
        var other = _fixture.Create<IUnique>();

        // Act
        var result = this._testClass.Equals(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Equals method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallEqualsWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.Equals(default(IUnique))).Should().Throw<ArgumentNullException>().WithParameterName("other");
    }

    /// <summary>
    /// Checks that the CompareTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallCompareTo()
    {
        // Arrange
        var other = _fixture.Create<IUnique>();

        // Act
        var result = this._testClass.CompareTo(other);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the CompareTo method throws when the other parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallCompareToWithNullOther()
    {
        FluentActions.Invoking(() => this._testClass.CompareTo(default(IUnique))).Should().Throw<ArgumentNullException>().WithParameterName("other");
    }

    /// <summary>
    /// Checks that the GetFlag method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetFlag()
    {
        // Arrange
        var state = _fixture.Create<StateFlags>();

        // Act
        this._testClass.GetFlag(state);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the SetFlag method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSetFlag()
    {
        // Arrange
        var state = _fixture.Create<StateFlags>();
        var flag = _fixture.Create<bool>();

        // Act
        this._testClass.SetFlag(state, flag);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Sign method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallSign()
    {
        // Arrange
        var entity = _fixture.Create<TEntity>();

        // Act
        var result = ((IOrigin)this._testClass).Sign<TEntity>(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Sign method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallSignWithNullEntity()
    {
        FluentActions.Invoking(() => ((IOrigin)this._testClass).Sign<TEntity>(default(TEntity))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the Stamp method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallStamp()
    {
        // Arrange
        var entity = _fixture.Create<TEntity>();

        // Act
        var result = ((IOrigin)this._testClass).Stamp<TEntity>(entity);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Stamp method throws when the entity parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallStampWithNullEntity()
    {
        FluentActions.Invoking(() => ((IOrigin)this._testClass).Stamp<TEntity>(default(TEntity))).Should().Throw<ArgumentNullException>().WithParameterName("entity");
    }

    /// <summary>
    /// Checks that the DeclaringType property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetDeclaringType()
    {
        // Assert
        this._testClass.DeclaringType.Should().BeAssignableTo<Type>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the DisplayName property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetDisplayName()
    {
        this._testClass.CheckProperty(x => x.DisplayName);
    }

    /// <summary>
    /// Checks that setting the Editable property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetEditable()
    {
        this._testClass.CheckProperty(x => x.Editable);
    }

    /// <summary>
    /// Checks that the Empty property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetEmpty()
    {
        // Assert
        this._testClass.Empty.Should().BeAssignableTo<IUnique>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the FieldId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetFieldId()
    {
        this._testClass.CheckProperty(x => x.FieldId);
    }

    /// <summary>
    /// Checks that setting the InstantField property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetInstantField()
    {
        this._testClass.CheckProperty(x => x.InstantField, _fixture.Create<FieldInfo>(), _fixture.Create<FieldInfo>());
    }

    /// <summary>
    /// Checks that setting the InstantType property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetInstantType()
    {
        this._testClass.CheckProperty(x => x.InstantType, _fixture.Create<Type>(), _fixture.Create<Type>());
    }

    /// <summary>
    /// Checks that the Getter property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetGetter()
    {
        // Assert
        this._testClass.Getter.Should().BeAssignableTo<MethodInfo>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the IdentityOrder property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIdentityOrder()
    {
        this._testClass.CheckProperty(x => x.IdentityOrder);
    }

    /// <summary>
    /// Checks that setting the IsAutoincrement property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIsAutoincrement()
    {
        this._testClass.CheckProperty(x => x.IsAutoincrement);
    }

    /// <summary>
    /// Checks that setting the IsDBNull property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIsDBNull()
    {
        this._testClass.CheckProperty(x => x.IsDBNull);
    }

    /// <summary>
    /// Checks that setting the Expandable property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetExpandable()
    {
        this._testClass.CheckProperty(x => x.Expandable);
    }

    /// <summary>
    /// Checks that setting the IsIdentity property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIsIdentity()
    {
        this._testClass.CheckProperty(x => x.IsIdentity);
    }

    /// <summary>
    /// Checks that setting the IsLink property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIsLink()
    {
        this._testClass.CheckProperty(x => x.IsLink);
    }

    /// <summary>
    /// Checks that setting the IsKey property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIsKey()
    {
        this._testClass.CheckProperty(x => x.IsKey);
    }

    /// <summary>
    /// Checks that setting the IsUnique property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetIsUnique()
    {
        this._testClass.CheckProperty(x => x.IsUnique);
    }

    /// <summary>
    /// Checks that setting the LinkValue property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetLinkValue()
    {
        this._testClass.CheckProperty(x => x.LinkValue);
    }

    /// <summary>
    /// Checks that setting the LinkOperation property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetLinkOperation()
    {
        this._testClass.CheckProperty(x => x.LinkOperation, _fixture.Create<OperationType>(), _fixture.Create<OperationType>());
    }

    /// <summary>
    /// Checks that setting the InvokeMethod property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetInvokeMethod()
    {
        this._testClass.CheckProperty(x => x.InvokeMethod);
    }

    /// <summary>
    /// Checks that setting the InvokeTarget property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetInvokeTarget()
    {
        this._testClass.CheckProperty(x => x.InvokeTarget);
    }

    /// <summary>
    /// Checks that setting the InvokeType property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetInvokeType()
    {
        this._testClass.CheckProperty(x => x.InvokeType, _fixture.Create<Type>(), _fixture.Create<Type>());
    }

    /// <summary>
    /// Checks that setting the Invoker property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetInvoker()
    {
        this._testClass.CheckProperty(x => x.Invoker, _fixture.Create<IInvoker>(), _fixture.Create<IInvoker>());
    }

    /// <summary>
    /// Checks that the MemberInfo property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetMemberInfo()
    {
        // Assert
        this._testClass.MemberInfo.Should().BeAssignableTo<MemberInfo>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MemberType property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetMemberType()
    {
        // Assert
        this._testClass.MemberType.As<object>().Should().BeAssignableTo<MemberTypes>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Name property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetName()
    {
        // Assert
        this._testClass.Name.Should().BeAssignableTo<string>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ReflectedType property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetReflectedType()
    {
        // Assert
        this._testClass.ReflectedType.Should().BeAssignableTo<Type>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the Required property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRequired()
    {
        this._testClass.CheckProperty(x => x.Required);
    }

    /// <summary>
    /// Checks that setting the RubricAttributes property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRubricAttributes()
    {
        this._testClass.CheckProperty(x => x.RubricAttributes, _fixture.Create<object[]>(), _fixture.Create<object[]>());
    }

    /// <summary>
    /// Checks that setting the RubricId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRubricId()
    {
        this._testClass.CheckProperty(x => x.RubricId);
    }

    /// <summary>
    /// Checks that setting the RubricInfo property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRubricInfo()
    {
        this._testClass.CheckProperty(x => x.RubricInfo, _fixture.Create<MemberInfo>(), _fixture.Create<MemberInfo>());
    }

    /// <summary>
    /// Checks that the RubricModule property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetRubricModule()
    {
        // Assert
        this._testClass.RubricModule.Should().BeAssignableTo<Module>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the RubricName property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRubricName()
    {
        this._testClass.CheckProperty(x => x.RubricName);
    }

    /// <summary>
    /// Checks that setting the RubricOffset property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRubricOffset()
    {
        this._testClass.CheckProperty(x => x.RubricOffset);
    }

    /// <summary>
    /// Checks that the RubricParameterInfo property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetRubricParameterInfo()
    {
        // Assert
        this._testClass.RubricParameterInfo.Should().BeAssignableTo<ParameterInfo[]>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the RubricReturnType property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetRubricReturnType()
    {
        // Assert
        this._testClass.RubricReturnType.Should().BeAssignableTo<Type>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the Rubrics property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRubrics()
    {
        this._testClass.CheckProperty(x => x.Rubrics, _fixture.Create<MemberRubrics>(), _fixture.Create<MemberRubrics>());
    }

    /// <summary>
    /// Checks that setting the RubricSize property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRubricSize()
    {
        this._testClass.CheckProperty(x => x.RubricSize);
    }

    /// <summary>
    /// Checks that setting the RubricType property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetRubricType()
    {
        this._testClass.CheckProperty(x => x.RubricType, _fixture.Create<Type>(), _fixture.Create<Type>());
    }

    /// <summary>
    /// Checks that the Setter property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetSetter()
    {
        // Assert
        this._testClass.Setter.Should().BeAssignableTo<MethodInfo>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the AggregationOperand property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetAggregationOperand()
    {
        this._testClass.CheckProperty(x => x.AggregationOperand, _fixture.Create<AggregationOperand>(), _fixture.Create<AggregationOperand>());
    }

    /// <summary>
    /// Checks that setting the AggregationOrdinal property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetAggregationOrdinal()
    {
        this._testClass.CheckProperty(x => x.AggregationOrdinal);
    }

    /// <summary>
    /// Checks that setting the AggregateRubric property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetAggregateRubric()
    {
        this._testClass.CheckProperty(x => x.AggregateRubric, _fixture.Create<IRubric>(), _fixture.Create<IRubric>());
    }

    /// <summary>
    /// Checks that the VirtualInfo property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetVirtualInfo()
    {
        // Assert
        this._testClass.VirtualInfo.Should().BeAssignableTo<IMemberRubric>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that setting the Visible property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetVisible()
    {
        this._testClass.CheckProperty(x => x.Visible);
    }

    /// <summary>
    /// Checks that setting the CodeNo property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetCodeNo()
    {
        this._testClass.CheckProperty(x => x.CodeNo);
    }

    /// <summary>
    /// Checks that setting the Created property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetCreated()
    {
        this._testClass.CheckProperty(x => x.Created);
    }

    /// <summary>
    /// Checks that setting the Creator property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetCreator()
    {
        this._testClass.CheckProperty(x => x.Creator);
    }

    /// <summary>
    /// Checks that setting the Id property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetId()
    {
        this._testClass.CheckProperty(x => x.Id);
    }

    /// <summary>
    /// Checks that setting the TypeId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTypeId()
    {
        this._testClass.CheckProperty(x => x.TypeId);
    }

    /// <summary>
    /// Checks that setting the Modified property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetModified()
    {
        this._testClass.CheckProperty(x => x.Modified);
    }

    /// <summary>
    /// Checks that setting the Modifier property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetModifier()
    {
        this._testClass.CheckProperty(x => x.Modifier);
    }

    /// <summary>
    /// Checks that setting the OriginId property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetOriginId()
    {
        this._testClass.CheckProperty(x => x.OriginId);
    }

    /// <summary>
    /// Checks that setting the TypeName property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTypeName()
    {
        this._testClass.CheckProperty(x => x.TypeName);
    }

    /// <summary>
    /// Checks that setting the Time property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetTime()
    {
        this._testClass.CheckProperty(x => x.Time);
    }

    /// <summary>
    /// Checks that setting the Label property correctly raises PropertyChanged events.
    /// </summary>
    [TestMethod]
    public void CanSetAndGetLabel()
    {
        this._testClass.CheckProperty(x => x.Label);
    }
}