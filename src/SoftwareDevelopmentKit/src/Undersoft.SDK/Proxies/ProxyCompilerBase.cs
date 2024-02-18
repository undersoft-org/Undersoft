using Undersoft.SDK.Instant;

namespace Undersoft.SDK.Proxies;

using Rubrics;
using System.Reflection;
using System.Reflection.Emit;
using Undersoft.SDK.Series;
using Uniques;

public abstract class ProxyCompilerBase : InstantCompilerBase
{
    protected int rubricCount;
    protected InstantType instantType;
    protected ProxyCreator proxyCreator;

    public ISeries<RubricModel> rubricBuilders;

    public ProxyCompilerBase(ProxyCreator creator, ISeries<RubricModel> rubricBuilders)
    {
        proxyCreator = creator;
        this.rubricBuilders = rubricBuilders;
        rubricCount = this.rubricBuilders.Count;
    }

    public abstract Type CompileProxyType(string typeName);

    public abstract TypeBuilder GetTypeBuilder(string typeName);

    public abstract void CreateCompareToMethod(TypeBuilder tb);

    public abstract void CreateEqualsMethod(TypeBuilder tb);

    public abstract void CreateFieldsAndProperties(TypeBuilder tb);

    public abstract void CreateGetBytesMethod(TypeBuilder tb);

    public abstract void CreateTargetProperty(TypeBuilder tb, Type type, string name);

    public abstract void CreateItemByIntProperty(TypeBuilder tb);

    public abstract void CreateItemByStringProperty(TypeBuilder tb);

    public abstract void CreateRubricsProperty(TypeBuilder tb, Type type, string name);

    public abstract void CreateCodeProperty(TypeBuilder tb, Type type, string name);

    public abstract void CreateValueArrayProperty(TypeBuilder tb);

    public virtual void CreateGetEmptyProperty(TypeBuilder tb)
    {
        PropertyBuilder prop = tb.DefineProperty(
            "Empty",
            PropertyAttributes.HasDefault,
            typeof(IUnique),
            Type.EmptyTypes
        );

        PropertyInfo iprop = typeof(IUnique).GetProperty("Empty");

        MethodInfo accessor = iprop.GetGetMethod();

        ParameterInfo[] args = accessor.GetParameters();
        Type[] argTypes = Array.ConvertAll(args, a => a.ParameterType);

        MethodBuilder getter = tb.DefineMethod(
            accessor.Name,
            accessor.Attributes & ~MethodAttributes.Abstract,
            accessor.CallingConvention,
            accessor.ReturnType,
            argTypes
        );
        tb.DefineMethodOverride(getter, accessor);

        prop.SetGetMethod(getter);
        ILGenerator il = getter.GetILGenerator();

        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Ldflda, rubricBuilders[0].Member.InstantField);
        il.EmitCall(OpCodes.Call, typeof(Uscn).GetMethod("get_Empty"), null);
        il.Emit(OpCodes.Ret);
    }

    public virtual void CreateGetGenericByIntMethod(TypeBuilder tb)
    {
        string[] typeParameterNames = { "V" };
        GenericTypeParameterBuilder[] typeParameters = tb.DefineGenericParameters(
            typeParameterNames
        );

        MethodInfo mi = typeof(IInstant)
            .GetMethod("Get", new Type[] { typeof(int) })
            .GetGenericMethodDefinition();

        ParameterInfo[] args = mi.GetParameters();
        Type[] argTypes = Array.ConvertAll(args, a => a.ParameterType);

        MethodBuilder method = tb.DefineMethod(
            mi.Name,
            mi.Attributes & ~MethodAttributes.Abstract,
            mi.CallingConvention,
            mi.ReturnType,
            argTypes
        );

        tb.DefineMethodOverride(method, mi);

        ILGenerator il = method.GetILGenerator();

        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Ldflda, rubricBuilders[0].Member.InstantField);
        il.Emit(OpCodes.Ldarg_1);
        il.EmitCall(
            OpCodes.Call,
            typeof(Uscn).GetMethod("CompareTo", new Type[] { typeof(IUnique) }),
            null
        );
        il.Emit(OpCodes.Ret);
    }

    public virtual void CreateGetIdBytesMethod(TypeBuilder tb)
    {
        MethodInfo createArray = typeof(IUnique).GetMethod("GetIdBytes");

        ParameterInfo[] args = createArray.GetParameters();
        Type[] argTypes = Array.ConvertAll(args, a => a.ParameterType);

        MethodBuilder method = tb.DefineMethod(
            createArray.Name,
            createArray.Attributes & ~MethodAttributes.Abstract,
            createArray.CallingConvention,
            createArray.ReturnType,
            argTypes
        );
        tb.DefineMethodOverride(method, createArray);

        ILGenerator il = method.GetILGenerator();
        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Ldflda, rubricBuilders[0].Member.InstantField);
        il.EmitCall(OpCodes.Call, typeof(Uscn).GetMethod("GetIdBytes"), null);
        il.Emit(OpCodes.Ret);
    }

    public virtual void CreateGetIdMethod(TypeBuilder tb)
    {
        MethodInfo createArray = typeof(IUnique).GetMethod("GetId");

        ParameterInfo[] args = createArray.GetParameters();
        Type[] argTypes = Array.ConvertAll(args, a => a.ParameterType);

        MethodBuilder method = tb.DefineMethod(
            createArray.Name,
            createArray.Attributes & ~MethodAttributes.Abstract,
            createArray.CallingConvention,
            createArray.ReturnType,
            argTypes
        );
        tb.DefineMethodOverride(method, createArray);

        ILGenerator il = method.GetILGenerator();

        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Ldflda, rubricBuilders[0].Member.InstantField);
        il.EmitCall(OpCodes.Call, typeof(Uscn).GetMethod("GetId"), null);
        il.Emit(OpCodes.Ret);
    }

    public virtual void CreateGetTypeIdMethod(TypeBuilder tb)
    {
        MethodInfo createArray = typeof(IUnique).GetMethod("GetTypeId");

        ParameterInfo[] args = createArray.GetParameters();
        Type[] argTypes = Array.ConvertAll(args, a => a.ParameterType);

        MethodBuilder method = tb.DefineMethod(
            createArray.Name,
            createArray.Attributes & ~MethodAttributes.Abstract,
            createArray.CallingConvention,
            createArray.ReturnType,
            argTypes
        );
        tb.DefineMethodOverride(method, createArray);

        ILGenerator il = method.GetILGenerator();

        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Ldflda, rubricBuilders[0].Member.InstantField);
        il.EmitCall(OpCodes.Call, typeof(Uscn).GetMethod("GetTypeId"), null);
        il.Emit(OpCodes.Ret);
    }

    public virtual void CreateSetIdMethod(TypeBuilder tb)
    {
        MethodInfo createArray = typeof(IUnique).GetMethod("SetId");

        ParameterInfo[] args = createArray.GetParameters();
        Type[] argTypes = Array.ConvertAll(args, a => a.ParameterType);

        MethodBuilder method = tb.DefineMethod(
            createArray.Name,
            createArray.Attributes & ~MethodAttributes.Abstract,
            createArray.CallingConvention,
            createArray.ReturnType,
            argTypes
        );
        tb.DefineMethodOverride(method, createArray);

        ILGenerator il = method.GetILGenerator();

        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Ldarg_1);
        il.Emit(OpCodes.Ldflda, rubricBuilders[0].Member.InstantField);
        il.EmitCall(OpCodes.Call, typeof(Uscn).GetMethod("SetId"), null);
        il.Emit(OpCodes.Ret);
    }

    public virtual void CreateSetTypeIdMethod(TypeBuilder tb)
    {
        MethodInfo createArray = typeof(IUnique).GetMethod("SetTypeId");

        ParameterInfo[] args = createArray.GetParameters();
        Type[] argTypes = Array.ConvertAll(args, a => a.ParameterType);

        MethodBuilder method = tb.DefineMethod(
            createArray.Name,
            createArray.Attributes & ~MethodAttributes.Abstract,
            createArray.CallingConvention,
            createArray.ReturnType,
            argTypes
        );
        tb.DefineMethodOverride(method, createArray);

        ILGenerator il = method.GetILGenerator();

        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Ldarg_1);
        il.Emit(OpCodes.Ldflda, rubricBuilders[0].Member.InstantField);
        il.EmitCall(OpCodes.Call, typeof(Uscn).GetMethod("SetTypeId"), null);
        il.Emit(OpCodes.Ret);
    }

    public virtual void CreateIdProperty(TypeBuilder tb)
    {
        PropertyBuilder prop = tb.DefineProperty(
            "Id",
            PropertyAttributes.HasDefault,
            typeof(ulong),
            new Type[] { typeof(ulong) }
        );

        PropertyInfo iprop = typeof(IUnique).GetProperty("Id");

        MethodInfo accessor = iprop.GetGetMethod();

        ParameterInfo[] args = accessor.GetParameters();
        Type[] argTypes = Array.ConvertAll(args, a => a.ParameterType);

        MethodBuilder getter = tb.DefineMethod(
            accessor.Name,
            accessor.Attributes & ~MethodAttributes.Abstract,
            accessor.CallingConvention,
            accessor.ReturnType,
            argTypes
        );
        tb.DefineMethodOverride(getter, accessor);

        prop.SetGetMethod(getter);
        ILGenerator il = getter.GetILGenerator();

        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Ldflda, rubricBuilders[0].Member.InstantField);
        il.EmitCall(OpCodes.Call, typeof(Uscn).GetProperty("Id").GetGetMethod(), null);
        il.Emit(OpCodes.Ret);

        MethodInfo mutator = iprop.GetSetMethod();

        args = mutator.GetParameters();
        argTypes = Array.ConvertAll(args, a => a.ParameterType);

        MethodBuilder setter = tb.DefineMethod(
            mutator.Name,
            mutator.Attributes & ~MethodAttributes.Abstract,
            mutator.CallingConvention,
            mutator.ReturnType,
            argTypes
        );
        tb.DefineMethodOverride(setter, mutator);

        prop.SetSetMethod(setter);
        il = setter.GetILGenerator();

        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Ldflda, rubricBuilders[0].Member.InstantField);
        il.Emit(OpCodes.Ldarg_1);
        il.EmitCall(OpCodes.Call, typeof(Uscn).GetProperty("Id").GetSetMethod(), null);
        il.Emit(OpCodes.Ret);
    }

    public virtual void CreateTypeIdProperty(TypeBuilder tb)
    {
        PropertyBuilder prop = tb.DefineProperty(
            "TypeId",
            PropertyAttributes.HasDefault,
            typeof(ulong),
            new Type[] { typeof(ulong) }
        );

        PropertyInfo iprop = typeof(IUnique).GetProperty("TypeId");

        MethodInfo accessor = iprop.GetGetMethod();

        ParameterInfo[] args = accessor.GetParameters();
        Type[] argTypes = Array.ConvertAll(args, a => a.ParameterType);

        MethodBuilder getter = tb.DefineMethod(
            accessor.Name,
            accessor.Attributes & ~MethodAttributes.Abstract,
            accessor.CallingConvention,
            accessor.ReturnType,
            argTypes
        );
        tb.DefineMethodOverride(getter, accessor);

        prop.SetGetMethod(getter);
        ILGenerator il = getter.GetILGenerator();

        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Ldflda, rubricBuilders[0].Member.InstantField);
        il.EmitCall(OpCodes.Call, typeof(Uscn).GetProperty("TypeId").GetGetMethod(), null);
        il.Emit(OpCodes.Ret);

        MethodInfo mutator = iprop.GetSetMethod();

        args = mutator.GetParameters();
        argTypes = Array.ConvertAll(args, a => a.ParameterType);

        MethodBuilder setter = tb.DefineMethod(
            mutator.Name,
            mutator.Attributes & ~MethodAttributes.Abstract,
            mutator.CallingConvention,
            mutator.ReturnType,
            argTypes
        );
        tb.DefineMethodOverride(setter, mutator);

        prop.SetSetMethod(setter);
        il = setter.GetILGenerator();

        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Ldflda, rubricBuilders[0].Member.InstantField);
        il.Emit(OpCodes.Ldarg_1);
        il.EmitCall(OpCodes.Call, typeof(Uscn).GetProperty("TypeId").GetSetMethod(), null);
        il.Emit(OpCodes.Ret);
    }

}
