using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using AutoMapper.Configuration;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Undersoft.SDK.Service.Data.Mapper;
using TDestination = System.String;
using TSource = System.String;

namespace Undersoft.SDK.Service.UnitTests.Data.Mapper;

/// <summary>
/// Unit tests for the type <see cref="MapperProfile"/>.
/// </summary>
public class MapperProfileTests
{
    private MapperProfile _testClass;
    private IFixture _fixture;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="MapperProfile"/>.
    /// </summary>
    public MapperProfileTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._testClass = _fixture.Create<MapperProfile>();
    }
}

/// <summary>
/// Unit tests for the type <see cref="DataMapper"/>.
/// </summary>
public class DataMapperTests
{
    private DataMapper _testClass;
    private IFixture _fixture;
    private IMapperProfile[] _profiles;

    /// <summary>
    /// Sets up the dependencies required for the tests for <see cref="DataMapper"/>.
    /// </summary>
    public DataMapperTests()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        this._profiles = _fixture.Create<IMapperProfile[]>();
        this._testClass = _fixture.Create<DataMapper>();
    }

    /// <summary>
    /// Checks that instance construction works.
    /// </summary>
    [TestMethod]
    public void CanConstruct()
    {
        // Act
        var instance = new DataMapper(this._profiles);

        // Assert
        instance.Should().NotBeNull();

        // Act
        instance = new DataMapper();

        // Assert
        instance.Should().NotBeNull();
    }

    /// <summary>
    /// Checks that instance construction throws when the profiles parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotConstructWithNullProfiles()
    {
        FluentActions.Invoking(() => new DataMapper(default(IMapperProfile[]))).Should().Throw<ArgumentNullException>().WithParameterName("profiles");
    }

    /// <summary>
    /// Checks that the AddProfiles method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallAddProfiles()
    {
        // Arrange
        var profiles = _fixture.Create<IMapperProfile[]>();

        // Act
        DataMapper.AddProfiles(profiles);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the AddProfiles method throws when the profiles parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallAddProfilesWithNullProfiles()
    {
        FluentActions.Invoking(() => DataMapper.AddProfiles(default(IMapperProfile[]))).Should().Throw<ArgumentNullException>().WithParameterName("profiles");
    }

    /// <summary>
    /// Checks that the GetMapper method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetMapper()
    {
        // Act
        var result = DataMapper.GetMapper();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryCreateMap method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryCreateMapWithReverse()
    {
        // Arrange
        var reverse = _fixture.Create<bool>();

        // Act
        var result = this._testClass.TryCreateMap<TSource, TDestination>(reverse);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryCreateMap method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryCreateMapWithObjectAndBool()
    {
        // Arrange
        var source = _fixture.Create<object>();
        var reverse = _fixture.Create<bool>();

        // Act
        var result = this._testClass.TryCreateMap<TDestination>(source, reverse);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryCreateMap method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallTryCreateMapWithObjectAndBoolWithNullSource()
    {
        FluentActions.Invoking(() => this._testClass.TryCreateMap<TDestination>(default(object), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the TryCreateMap method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryCreateMapWithSourceAndDestinationAndReverse()
    {
        // Arrange
        var source = _fixture.Create<Type>();
        var destination = _fixture.Create<Type>();
        var reverse = _fixture.Create<bool>();

        // Act
        var result = this._testClass.TryCreateMap(source, destination, reverse);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryCreateMap method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallTryCreateMapWithSourceAndDestinationAndReverseWithNullSource()
    {
        FluentActions.Invoking(() => this._testClass.TryCreateMap(default(Type), _fixture.Create<Type>(), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the TryCreateMap method throws when the destination parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallTryCreateMapWithSourceAndDestinationAndReverseWithNullDestination()
    {
        FluentActions.Invoking(() => this._testClass.TryCreateMap(_fixture.Create<Type>(), default(Type), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("destination");
    }

    /// <summary>
    /// Checks that the TryCreateMap method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryCreateMapWithIQueryableAndBool()
    {
        // Arrange
        var source = _fixture.Create<IQueryable>();
        var reverse = _fixture.Create<bool>();

        // Act
        var result = this._testClass.TryCreateMap<TDestination>(source, reverse);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the TryCreateMap method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallTryCreateMapWithIQueryableAndBoolWithNullSource()
    {
        FluentActions.Invoking(() => this._testClass.TryCreateMap<TDestination>(default(IQueryable), _fixture.Create<bool>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the TryCreateMap method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallTryCreateMapWithPairAndReverse()
    {
        // Arrange
        var pair = _fixture.Create<TypePair>();
        var reverse = _fixture.Create<bool>();

        // Act
        var result = this._testClass.TryCreateMap(pair, reverse);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetValidTypePair method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetValidTypePair()
    {
        // Arrange
        var pair = _fixture.Create<TypePair>();

        // Act
        var result = this._testClass.GetValidTypePair(pair);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetValidType method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallGetValidType()
    {
        // Arrange
        var @type = _fixture.Create<Type>();

        // Act
        var result = this._testClass.GetValidType(type);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the GetValidType method throws when the type parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallGetValidTypeWithNullType()
    {
        FluentActions.Invoking(() => this._testClass.GetValidType(default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("type");
    }

    /// <summary>
    /// Checks that the MapExist method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapExistWithTSourceAndTDestination()
    {
        // Act
        var result = this._testClass.MapExist<TSource, TDestination>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MapExist method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapExistWithTDestinationAndObject()
    {
        // Arrange
        var source = _fixture.Create<object>();

        // Act
        var result = this._testClass.MapExist<TDestination>(source);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MapExist method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapExistWithTDestinationAndObjectWithNullSource()
    {
        FluentActions.Invoking(() => this._testClass.MapExist<TDestination>(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the MapExist method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapExistWithTypePair()
    {
        // Arrange
        var pair = _fixture.Create<TypePair>();

        // Act
        var result = this._testClass.MapExist(pair);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MapExist method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapExistWithTypeAndType()
    {
        // Arrange
        var source = _fixture.Create<Type>();
        var destination = _fixture.Create<Type>();

        // Act
        var result = this._testClass.MapExist(source, destination);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MapExist method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapExistWithTypeAndTypeWithNullSource()
    {
        FluentActions.Invoking(() => this._testClass.MapExist(default(Type), _fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the MapExist method throws when the destination parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapExistWithTypeAndTypeWithNullDestination()
    {
        FluentActions.Invoking(() => this._testClass.MapExist(_fixture.Create<Type>(), default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("destination");
    }

    /// <summary>
    /// Checks that the MapExist method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapExistWithIQueryableAndType()
    {
        // Arrange
        var source = _fixture.Create<IQueryable>();
        var destination = _fixture.Create<Type>();

        // Act
        var result = this._testClass.MapExist(source, destination);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MapExist method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapExistWithIQueryableAndTypeWithNullSource()
    {
        FluentActions.Invoking(() => this._testClass.MapExist(default(IQueryable), _fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the MapExist method throws when the destination parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapExistWithIQueryableAndTypeWithNullDestination()
    {
        FluentActions.Invoking(() => this._testClass.MapExist(_fixture.Create<IQueryable>(), default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("destination");
    }

    /// <summary>
    /// Checks that the MapExist method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapExistWithIQueryable()
    {
        // Arrange
        var source = _fixture.Create<IQueryable>();

        // Act
        var result = this._testClass.MapExist<TDestination>(source);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MapExist method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapExistWithIQueryableWithNullSource()
    {
        FluentActions.Invoking(() => this._testClass.MapExist<TDestination>(default(IQueryable))).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the MapNotExist method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapNotExistWithTypePair()
    {
        // Arrange
        var pair = _fixture.Create<TypePair>();

        // Act
        var result = this._testClass.MapNotExist(pair);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MapNotExist method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapNotExistWithTypeAndType()
    {
        // Arrange
        var source = _fixture.Create<Type>();
        var destination = _fixture.Create<Type>();

        // Act
        var result = this._testClass.MapNotExist(source, destination);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MapNotExist method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapNotExistWithTypeAndTypeWithNullSource()
    {
        FluentActions.Invoking(() => this._testClass.MapNotExist(default(Type), _fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the MapNotExist method throws when the destination parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapNotExistWithTypeAndTypeWithNullDestination()
    {
        FluentActions.Invoking(() => this._testClass.MapNotExist(_fixture.Create<Type>(), default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("destination");
    }

    /// <summary>
    /// Checks that the MapNotExist method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapNotExistWithTSourceAndTDestination()
    {
        // Act
        var result = this._testClass.MapNotExist<TSource, TDestination>();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MapNotExist method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapNotExistWithTDestinationAndObject()
    {
        // Arrange
        var source = _fixture.Create<object>();

        // Act
        var result = this._testClass.MapNotExist<TDestination>(source);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the MapNotExist method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapNotExistWithTDestinationAndObjectWithNullSource()
    {
        FluentActions.Invoking(() => this._testClass.MapNotExist<TDestination>(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the Build method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallBuild()
    {
        // Act
        var result = this._testClass.Build();

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Map method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapWithObjectAndActionOfIMappingOperationOptionsOfObjectAndTDestination()
    {
        // Arrange
        var source = _fixture.Create<object>();
        Action<IMappingOperationOptions<object, TDestination>> opts = x => { };

        // Act
        var result = this._testClass.Map<TDestination>(source, opts
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Map method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapWithObjectAndActionOfIMappingOperationOptionsOfObjectAndTDestinationWithNullSource()
    {
        FluentActions.Invoking(() => this._testClass.Map<TDestination>(default(object), x => { })).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the Map method throws when the opts parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapWithObjectAndActionOfIMappingOperationOptionsOfObjectAndTDestinationWithNullOpts()
    {
        FluentActions.Invoking(() => this._testClass.Map<TDestination>(_fixture.Create<object>(), default(Action<IMappingOperationOptions<object, TDestination>>))).Should().Throw<ArgumentNullException>().WithParameterName("opts");
    }

    /// <summary>
    /// Checks that the Map method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapWithTSourceAndActionOfIMappingOperationOptionsOfTSourceAndTDestination()
    {
        // Arrange
        var source = _fixture.Create<TSource>();
        Action<IMappingOperationOptions<TSource, TDestination>> opts = x => { };

        // Act
        var result = this._testClass.Map<TSource, TDestination>(source, opts
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Map method throws when the opts parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapWithTSourceAndActionOfIMappingOperationOptionsOfTSourceAndTDestinationWithNullOpts()
    {
        FluentActions.Invoking(() => this._testClass.Map<TSource, TDestination>(_fixture.Create<TSource>(), default(Action<IMappingOperationOptions<TSource, TDestination>>))).Should().Throw<ArgumentNullException>().WithParameterName("opts");
    }

    /// <summary>
    /// Checks that the Map method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapWithSourceAndDestinationAndOpts()
    {
        // Arrange
        var source = _fixture.Create<TSource>();
        var destination = _fixture.Create<TDestination>();
        Action<IMappingOperationOptions<TSource, TDestination>> opts = x => { };

        // Act
        var result = this._testClass.Map<TSource, TDestination>(source, destination, opts
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Map method throws when the opts parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapWithSourceAndDestinationAndOptsWithNullOpts()
    {
        FluentActions.Invoking(() => this._testClass.Map<TSource, TDestination>(_fixture.Create<TSource>(), _fixture.Create<TDestination>(), default(Action<IMappingOperationOptions<TSource, TDestination>>))).Should().Throw<ArgumentNullException>().WithParameterName("opts");
    }

    /// <summary>
    /// Checks that the Map method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapWithSourceAndSourceTypeAndDestinationTypeAndOpts()
    {
        // Arrange
        var source = _fixture.Create<object>();
        var sourceType = _fixture.Create<Type>();
        var destinationType = _fixture.Create<Type>();
        Action<IMappingOperationOptions<object, object>> opts = x => { };

        // Act
        var result = this._testClass.Map(source, sourceType, destinationType, opts
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Map method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapWithSourceAndSourceTypeAndDestinationTypeAndOptsWithNullSource()
    {
        FluentActions.Invoking(() => this._testClass.Map(default(object), _fixture.Create<Type>(), _fixture.Create<Type>(), x => { })).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the Map method throws when the sourceType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapWithSourceAndSourceTypeAndDestinationTypeAndOptsWithNullSourceType()
    {
        FluentActions.Invoking(() => this._testClass.Map(_fixture.Create<object>(), default(Type), _fixture.Create<Type>(), x => { })).Should().Throw<ArgumentNullException>().WithParameterName("sourceType");
    }

    /// <summary>
    /// Checks that the Map method throws when the destinationType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapWithSourceAndSourceTypeAndDestinationTypeAndOptsWithNullDestinationType()
    {
        FluentActions.Invoking(() => this._testClass.Map(_fixture.Create<object>(), _fixture.Create<Type>(), default(Type), x => { })).Should().Throw<ArgumentNullException>().WithParameterName("destinationType");
    }

    /// <summary>
    /// Checks that the Map method throws when the opts parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapWithSourceAndSourceTypeAndDestinationTypeAndOptsWithNullOpts()
    {
        FluentActions.Invoking(() => this._testClass.Map(_fixture.Create<object>(), _fixture.Create<Type>(), _fixture.Create<Type>(), default(Action<IMappingOperationOptions<object, object>>))).Should().Throw<ArgumentNullException>().WithParameterName("opts");
    }

    /// <summary>
    /// Checks that the Map method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapWithSourceAndDestinationAndSourceTypeAndDestinationTypeAndOpts()
    {
        // Arrange
        var source = _fixture.Create<object>();
        var destination = _fixture.Create<object>();
        var sourceType = _fixture.Create<Type>();
        var destinationType = _fixture.Create<Type>();
        Action<IMappingOperationOptions<object, object>> opts = x => { };

        // Act
        var result = this._testClass.Map(source, destination, sourceType, destinationType, opts
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Map method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapWithSourceAndDestinationAndSourceTypeAndDestinationTypeAndOptsWithNullSource()
    {
        FluentActions.Invoking(() => this._testClass.Map(default(object), _fixture.Create<object>(), _fixture.Create<Type>(), _fixture.Create<Type>(), x => { })).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the Map method throws when the destination parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapWithSourceAndDestinationAndSourceTypeAndDestinationTypeAndOptsWithNullDestination()
    {
        FluentActions.Invoking(() => this._testClass.Map(_fixture.Create<object>(), default(object), _fixture.Create<Type>(), _fixture.Create<Type>(), x => { })).Should().Throw<ArgumentNullException>().WithParameterName("destination");
    }

    /// <summary>
    /// Checks that the Map method throws when the sourceType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapWithSourceAndDestinationAndSourceTypeAndDestinationTypeAndOptsWithNullSourceType()
    {
        FluentActions.Invoking(() => this._testClass.Map(_fixture.Create<object>(), _fixture.Create<object>(), default(Type), _fixture.Create<Type>(), x => { })).Should().Throw<ArgumentNullException>().WithParameterName("sourceType");
    }

    /// <summary>
    /// Checks that the Map method throws when the destinationType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapWithSourceAndDestinationAndSourceTypeAndDestinationTypeAndOptsWithNullDestinationType()
    {
        FluentActions.Invoking(() => this._testClass.Map(_fixture.Create<object>(), _fixture.Create<object>(), _fixture.Create<Type>(), default(Type), x => { })).Should().Throw<ArgumentNullException>().WithParameterName("destinationType");
    }

    /// <summary>
    /// Checks that the Map method throws when the opts parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapWithSourceAndDestinationAndSourceTypeAndDestinationTypeAndOptsWithNullOpts()
    {
        FluentActions.Invoking(() => this._testClass.Map(_fixture.Create<object>(), _fixture.Create<object>(), _fixture.Create<Type>(), _fixture.Create<Type>(), default(Action<IMappingOperationOptions<object, object>>))).Should().Throw<ArgumentNullException>().WithParameterName("opts");
    }

    /// <summary>
    /// Checks that the ProjectTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallProjectToWithIQueryableAndObjectAndArrayOfExpressionOfFuncOfTDestinationAndObject()
    {
        // Arrange
        var source = _fixture.Create<IQueryable>();
        var parameters = _fixture.Create<object>();
        var membersToExpand = _fixture.Create<Expression<Func<TDestination, object>>[]>();

        // Act
        var result = this._testClass.ProjectTo<TDestination>(source, parameters, membersToExpand
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ProjectTo method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallProjectToWithIQueryableAndObjectAndArrayOfExpressionOfFuncOfTDestinationAndObjectWithNullSource()
    {
        FluentActions.Invoking(() => this._testClass.ProjectTo<TDestination>(default(IQueryable), _fixture.Create<object>(), _fixture.Create<Expression<Func<TDestination, object>>[]>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the ProjectTo method throws when the membersToExpand parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallProjectToWithIQueryableAndObjectAndArrayOfExpressionOfFuncOfTDestinationAndObjectWithNullMembersToExpand()
    {
        FluentActions.Invoking(() => this._testClass.ProjectTo<TDestination>(_fixture.Create<IQueryable>(), _fixture.Create<object>(), default(Expression<Func<TDestination, object>>[]))).Should().Throw<ArgumentNullException>().WithParameterName("membersToExpand");
    }

    /// <summary>
    /// Checks that the ProjectTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallProjectToWithIQueryableAndIDictionaryOfStringAndObjectAndArrayOfString()
    {
        // Arrange
        var source = _fixture.Create<IQueryable>();
        var parameters = _fixture.Create<IDictionary<string, object>>();
        var membersToExpand = _fixture.Create<string[]>();

        // Act
        var result = this._testClass.ProjectTo<TDestination>(source, parameters, membersToExpand
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ProjectTo method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallProjectToWithIQueryableAndIDictionaryOfStringAndObjectAndArrayOfStringWithNullSource()
    {
        FluentActions.Invoking(() => this._testClass.ProjectTo<TDestination>(default(IQueryable), _fixture.Create<IDictionary<string, object>>(), _fixture.Create<string[]>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the ProjectTo method throws when the parameters parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallProjectToWithIQueryableAndIDictionaryOfStringAndObjectAndArrayOfStringWithNullParameters()
    {
        FluentActions.Invoking(() => this._testClass.ProjectTo<TDestination>(_fixture.Create<IQueryable>(), default(IDictionary<string, object>), _fixture.Create<string[]>())).Should().Throw<ArgumentNullException>().WithParameterName("parameters");
    }

    /// <summary>
    /// Checks that the ProjectTo method throws when the membersToExpand parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallProjectToWithIQueryableAndIDictionaryOfStringAndObjectAndArrayOfStringWithNullMembersToExpand()
    {
        FluentActions.Invoking(() => this._testClass.ProjectTo<TDestination>(_fixture.Create<IQueryable>(), _fixture.Create<IDictionary<string, object>>(), default(string[]))).Should().Throw<ArgumentNullException>().WithParameterName("membersToExpand");
    }

    /// <summary>
    /// Checks that the ProjectTo method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallProjectToWithSourceAndDestinationTypeAndParametersAndMembersToExpand()
    {
        // Arrange
        var source = _fixture.Create<IQueryable>();
        var destinationType = _fixture.Create<Type>();
        var parameters = _fixture.Create<IDictionary<string, object>>();
        var membersToExpand = _fixture.Create<string[]>();

        // Act
        var result = this._testClass.ProjectTo(source, destinationType, parameters, membersToExpand
        );

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ProjectTo method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallProjectToWithSourceAndDestinationTypeAndParametersAndMembersToExpandWithNullSource()
    {
        FluentActions.Invoking(() => this._testClass.ProjectTo(default(IQueryable), _fixture.Create<Type>(), _fixture.Create<IDictionary<string, object>>(), _fixture.Create<string[]>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the ProjectTo method throws when the destinationType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallProjectToWithSourceAndDestinationTypeAndParametersAndMembersToExpandWithNullDestinationType()
    {
        FluentActions.Invoking(() => this._testClass.ProjectTo(_fixture.Create<IQueryable>(), default(Type), _fixture.Create<IDictionary<string, object>>(), _fixture.Create<string[]>())).Should().Throw<ArgumentNullException>().WithParameterName("destinationType");
    }

    /// <summary>
    /// Checks that the ProjectTo method throws when the membersToExpand parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallProjectToWithSourceAndDestinationTypeAndParametersAndMembersToExpandWithNullMembersToExpand()
    {
        FluentActions.Invoking(() => this._testClass.ProjectTo(_fixture.Create<IQueryable>(), _fixture.Create<Type>(), _fixture.Create<IDictionary<string, object>>(), default(string[]))).Should().Throw<ArgumentNullException>().WithParameterName("membersToExpand");
    }

    /// <summary>
    /// Checks that the Map method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapWithTDestinationAndObject()
    {
        // Arrange
        var source = _fixture.Create<object>();

        // Act
        var result = this._testClass.Map<TDestination>(source);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Map method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapWithTDestinationAndObjectWithNullSource()
    {
        FluentActions.Invoking(() => this._testClass.Map<TDestination>(default(object))).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the Map method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapWithTSource()
    {
        // Arrange
        var source = _fixture.Create<TSource>();

        // Act
        var result = this._testClass.Map<TSource, TDestination>(source);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Map method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapWithTSourceAndTDestination()
    {
        // Arrange
        var source = _fixture.Create<TSource>();
        var destination = _fixture.Create<TDestination>();

        // Act
        var result = this._testClass.Map<TSource, TDestination>(source, destination);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Map method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapWithSourceAndSourceTypeAndDestinationType()
    {
        // Arrange
        var source = _fixture.Create<object>();
        var sourceType = _fixture.Create<Type>();
        var destinationType = _fixture.Create<Type>();

        // Act
        var result = this._testClass.Map(source, sourceType, destinationType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Map method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapWithSourceAndSourceTypeAndDestinationTypeWithNullSource()
    {
        FluentActions.Invoking(() => this._testClass.Map(default(object), _fixture.Create<Type>(), _fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the Map method throws when the sourceType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapWithSourceAndSourceTypeAndDestinationTypeWithNullSourceType()
    {
        FluentActions.Invoking(() => this._testClass.Map(_fixture.Create<object>(), default(Type), _fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("sourceType");
    }

    /// <summary>
    /// Checks that the Map method throws when the destinationType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapWithSourceAndSourceTypeAndDestinationTypeWithNullDestinationType()
    {
        FluentActions.Invoking(() => this._testClass.Map(_fixture.Create<object>(), _fixture.Create<Type>(), default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("destinationType");
    }

    /// <summary>
    /// Checks that the Map method functions correctly.
    /// </summary>
    [TestMethod]
    public void CanCallMapWithSourceAndDestinationAndSourceTypeAndDestinationType()
    {
        // Arrange
        var source = _fixture.Create<object>();
        var destination = _fixture.Create<object>();
        var sourceType = _fixture.Create<Type>();
        var destinationType = _fixture.Create<Type>();

        // Act
        var result = this._testClass.Map(source, destination, sourceType, destinationType);

        // Assert
        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the Map method throws when the source parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapWithSourceAndDestinationAndSourceTypeAndDestinationTypeWithNullSource()
    {
        FluentActions.Invoking(() => this._testClass.Map(default(object), _fixture.Create<object>(), _fixture.Create<Type>(), _fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("source");
    }

    /// <summary>
    /// Checks that the Map method throws when the destination parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapWithSourceAndDestinationAndSourceTypeAndDestinationTypeWithNullDestination()
    {
        FluentActions.Invoking(() => this._testClass.Map(_fixture.Create<object>(), default(object), _fixture.Create<Type>(), _fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("destination");
    }

    /// <summary>
    /// Checks that the Map method throws when the sourceType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapWithSourceAndDestinationAndSourceTypeAndDestinationTypeWithNullSourceType()
    {
        FluentActions.Invoking(() => this._testClass.Map(_fixture.Create<object>(), _fixture.Create<object>(), default(Type), _fixture.Create<Type>())).Should().Throw<ArgumentNullException>().WithParameterName("sourceType");
    }

    /// <summary>
    /// Checks that the Map method throws when the destinationType parameter is null.
    /// </summary>
    [TestMethod]
    public void CannotCallMapWithSourceAndDestinationAndSourceTypeAndDestinationTypeWithNullDestinationType()
    {
        FluentActions.Invoking(() => this._testClass.Map(_fixture.Create<object>(), _fixture.Create<object>(), _fixture.Create<Type>(), default(Type))).Should().Throw<ArgumentNullException>().WithParameterName("destinationType");
    }

    /// <summary>
    /// Checks that the MapperExtension property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetMapperExtension()
    {
        // Assert
        this._testClass.MapperExtension.Should().BeAssignableTo<MapperConfigurationExpression>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ConfigurationProvider property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetConfigurationProvider()
    {
        // Assert
        this._testClass.ConfigurationProvider.Should().BeAssignableTo<IConfigurationProvider>();

        Assert.Fail("Create or modify test");
    }

    /// <summary>
    /// Checks that the ServiceCtor property can be read from.
    /// </summary>
    [TestMethod]
    public void CanGetServiceCtor()
    {
        // Assert
        this._testClass.ServiceCtor.Should().BeAssignableTo<Func<Type, object>>();

        Assert.Fail("Create or modify test");
    }
}