using System.Collections;
using Undersoft.SDK.Series;
using Undersoft.SDK.Uniques;

namespace Undersoft.SDK.Updating;

using Invoking;
using Rubrics;
using Undersoft.SDK;
using Undersoft.SDK.Proxies;

public class Updater : IUpdater
{
    protected ProxyCreator creator;
    protected IProxy source;
    protected Type type;
    protected int counter = 0;
    protected bool traceable;

    public IProxy Source
    {
        get => source;
        set => source = value;
    }

    public Action<Updater, object> MemberUpdate { get; set; }

    public IInvoker TraceEvent { get; set; }

    public Updater() { }

    public Updater(object item, IInvoker traceChanges)
    {
        if (traceChanges != null)
        {
            TraceEvent = traceChanges;
            traceable = true;
        }

        type = item.GetType();

        if (type.IsAssignableTo(typeof(IProxy)))
            Combine(item as IProxy);
        else if (type.IsAssignableTo(typeof(IInnerProxy)))
            Combine(item as IInnerProxy);
        else
            Combine(item);
    }

    public Updater(object item) : this(item, null) { }

    public Updater(IProxy proxy)
    {
        Combine(proxy);
    }

    protected virtual ProxyCreator GetCreator(Type type)
    {
        return creator ??= ProxyFactory.GetCreator(type);
    }

    protected virtual void Combine(IProxy proxy)
    {
        type = proxy.Target.GetType();
        if (proxy.Rubrics == null)
            proxy.Rubrics = GetCreator(type).Rubrics;
        source = proxy;
    }

    protected virtual void Combine(IInnerProxy proxy)
    {
        if (type == null)
            type = proxy.GetType();
        source = proxy.Proxy;
    }

    protected virtual void Combine(object item)
    {
        source = GetCreator(type ??= item.GetType()).Create(item);
    }

    public object Patch(object item)
    {
        MemberUpdate = (o, t) => o.Patch(t);

        IProxy target = item.ToProxy();
        if (item.GetType() != type)
            PatchNotEqualTypes(target);
        else
            PatchEqualTypes(target);

        return item;
    }

    public E Patch<E>(E item) where E : class
    {
        MemberUpdate = (o, t) => o.Patch(t);

        IProxy target = item.ToProxy();
        if (typeof(E) != type)
            PatchNotEqualTypes(target);
        else
            PatchEqualTypes(target);

        return item;
    }

    public E Patch<E>() where E : class
    {
        return Patch(typeof(E).New<E>());
    }

    public object Put(object item)
    {
        MemberUpdate = (o, t) => o.Put(t);

        IProxy target = item.ToProxy();
        if (target != null)
        {
            if (item.GetType() != type)
                PutNotEqualTypes(target);
            else
                PutEqualTypes(target);
        }
        return item;
    }

    public E Put<E>(E item) where E : class
    {
        MemberUpdate = (o, t) => o.Put(t);

        IProxy target = item.ToProxy();
        if (target != null)
        {
            if (typeof(E) != type)
                PutNotEqualTypes(target);
            else
                PutEqualTypes(target);
        }
        return item;
    }

    public E Put<E>() where E : class
    {
        return Put(typeof(E).New<E>());
    }

    public object Clone()
    {
        var clone = type.New();
        var _clone = creator.Create(clone);
        _clone.PutFrom(source);
        return clone;
    }

    protected void PatchEqualTypes(IProxy target)
    {
        counter = 0;
        var _target = target;

        Rubrics
            .Where(r => !r.IsKey && !r.RubricName.Equals("proxy"))
            .ForEach(
                (rubric) =>
                {
                    var targetndex = rubric.RubricId;
                    var originValue = Source[targetndex];
                    var targetValue = _target[targetndex];

                    if (
                        !originValue.NullOrEquals(targetValue)
                        && !RecursiveUpdate(originValue, targetValue, target, rubric, rubric)
                    )
                    {
                        _target[targetndex] = originValue;
                    }
                }
            );
    }

    protected void PatchNotEqualTypes(IProxy target)
    {
        counter = 0;
        var _target = target;

        Rubrics
            .Where(r => !r.IsKey && !r.RubricName.Equals("proxy"))
            .ForEach(
                (originRubric) =>
                {
                    var name = originRubric.Name;
                    if (_target.Rubrics.TryGet(name, out MemberRubric targetRubric))
                    {
                        var originValue = Source[originRubric.RubricId];
                        var targetIndex = targetRubric.RubricId;
                        var targetValue = _target[targetIndex];

                        if (
                            !originValue.NullOrEquals(targetValue)
                            && !RecursiveUpdate(
                                originValue,
                                targetValue,
                                target,
                                originRubric,
                                targetRubric
                            )
                        )
                        {
                            if (targetRubric.RubricType.IsAssignableTo(originRubric.RubricType))
                            {
                                _target[targetIndex] = originValue;
                            }
                        }
                    }
                }
            );
    }

    protected void PutEqualTypes(IProxy target)
    {
        counter = 0;
        var _target = target;

        Rubrics
            .Where(r => !r.IsKey && !r.RubricName.Equals("proxy"))
            .ForEach(
                (rubric) =>
                {
                    var targetndex = rubric.RubricId;
                    var originValue = Source[targetndex];
                    var targetValue = _target[targetndex];

                    if (
                        originValue != null
                        && !RecursiveUpdate(originValue, targetValue, target, rubric, rubric)
                    )
                    {
                        _target[targetndex] = originValue;
                    }
                }
            );
    }

    protected void PutNotEqualTypes(IProxy target)
    {
        counter = 0;
        var _target = target;

        Rubrics
            .Where(r => !r.IsKey && !r.RubricName.Equals("proxy"))
            .ForEach(
                (originRubric) =>
                {
                    var name = originRubric.Name;
                    if (_target.Rubrics.TryGet(name, out MemberRubric targetRubric))
                    {
                        var originValue = Source[originRubric.RubricId];
                        if (originValue == null)
                            return;

                        var targetIndex = targetRubric.RubricId;
                        var targetValue = _target[targetIndex];

                        if (
                            originValue != null
                            && !RecursiveUpdate(
                                originValue,
                                targetValue,
                                target,
                                originRubric,
                                targetRubric
                            )
                        )
                        {
                            if (targetRubric.RubricType.IsAssignableTo(originRubric.RubricType))
                            {
                                _target[targetIndex] = originValue;
                            }
                        }
                    }
                }
            );
    }

    private bool RecursiveUpdate(
        object originValue,
        object targetValue,
        IProxy target,
        IRubric originRubric,
        IRubric targetRubric
    )
    {
        var originType = originRubric.RubricType;
        var targetType = targetRubric.RubricType;

        if (originType.IsValueType || originType == typeof(string) || originType.IsArray)
            return false;

        if (targetValue == null)
        {
            target[targetRubric.RubricId] = targetValue = targetType.New();

            if (traceable)
                targetValue = TraceEvent.Invoke(target.Target, targetRubric.RubricName, targetType);
        }

        if (originValue == null)
        {
            originValue = originType.New();
        }

        if (originType.IsAssignableTo(typeof(IEnumerable)))
        {
            IEnumerable originItems = (IEnumerable)originValue;
            var originItemType = originType.GetEnumerableElementType();
            if (originItemType == null || !originItemType.IsValueType)
            {
                if (targetType.IsAssignableTo(typeof(IEnumerable)))
                {
                    IEnumerable targetItems = (IEnumerable)targetValue;
                    var targetItemType = targetType.GetEnumerableElementType();
                    if (targetItemType == null || !targetItemType.IsValueType)
                    {
                        if (
                            targetType.IsAssignableTo(typeof(IFindableSeries))
                            && originItemType.IsAssignableTo(typeof(IIdentifiable))
                        )
                        {
                            IFindableSeries targetFindable = (IFindableSeries)targetValue;

                            foreach (var originItem in originItems)
                            {
                                var targetItem = targetFindable[originItem];
                                if (targetItem != null)
                                {
                                    if (traceable)
                                        targetItem = TraceEvent.Invoke(targetItem, null, null);

                                    MemberUpdate(new Updater(originItem, TraceEvent), targetItem);
                                }
                                else if (originItemType != targetItemType)
                                {
                                    targetItem = targetItemType.New();

                                    ((IIdentifiable)targetItem).Id = ((IIdentifiable)originItem).Id;

                                    originItem.PatchTo(targetItem, TraceEvent);

                                    if (traceable)
                                        targetItem = TraceEvent.Invoke(targetItem, null, null);

                                    ((IList)targetItems).Add(targetItem);
                                }
                                else
                                {
                                    if (traceable)
                                        targetItem = TraceEvent.Invoke(originItem, null, null);

                                    ((IList)targetItems).Add(originItem);
                                }
                            }

                            return true;
                        }

                        GreedyLookup(originItems, targetItems, originItemType, targetItemType);
                    }
                }
            }
        }

        if (traceable)
            targetValue = TraceEvent.Invoke(targetValue, null, null);

        MemberUpdate(new Updater(originValue, TraceEvent), targetValue);

        return false;
    }

    private bool GreedyLookup(
        IEnumerable originItems,
        IEnumerable targetItems,
        Type originItemType,
        Type targetItemType
    )
    {
        if (
            !originItemType.IsAssignableTo(typeof(IIdentifiable))
            || !targetItemType.IsAssignableTo(typeof(IIdentifiable))
        )
            return false;

        foreach (var originItem in originItems)
        {
            bool founded = false;
            foreach (var targetItem in targetItems)
            {
                if (((IIdentifiable)originItem).Id == ((IIdentifiable)targetItem).Id)
                {
                    var _targetItem = targetItem;
                    if (traceable)
                        _targetItem = TraceEvent.Invoke(_targetItem, null, null);

                    MemberUpdate(new Updater(originItem, TraceEvent), _targetItem);

                    founded = true;
                    break;
                }
            }

            if (!founded)
            {
                object targetItem = null;
                if (originItemType != targetItemType)
                {
                    targetItem = targetItemType.New();
                    ((IIdentifiable)targetItem).Id = ((IIdentifiable)originItem).Id;
                    if (traceable)
                        targetItem = TraceEvent.Invoke(targetItem, null, null);
                    ((IList)targetItems).Add(originItem.PatchTo(targetItem, TraceEvent));
                }
                else
                {
                    if (traceable)
                        targetItem = TraceEvent.Invoke(originItem, null, null);
                    ((IList)targetItems).Add(originItem);
                }
            }
        }

        return true;
    }

    private static HashSet<string> excludedRubrics;

    public HashSet<string> ExcludedRubrics
    {
        get => excludedRubrics ??= new HashSet<string>(new string[] { "proxy", "valuearray" });
    }

    public bool Equals(IUnique other)
    {
        return source.Equals(other);
    }

    public int CompareTo(IUnique other)
    {
        return source.CompareTo(other);
    }

    public long Id
    {
        get => source.Id;
        set => source.Id = value;
    }

    public long TypeId
    {
        get => source.TypeId;
        set => source.TypeId = value;
    }

    public object this[string propertyName]
    {
        get => source[propertyName];
        set => source[propertyName] = value;
    }

    public object this[int fieldId]
    {
        get => source[fieldId];
        set => source[fieldId] = value;
    }

    public Uscn Code
    {
        get => source.Code;
        set => source.Code = value;
    }

    public IRubrics Rubrics
    {
        get => source.Rubrics;
        set => source.Rubrics = value;
    }

    public object Target
    {
        get => source.Target;
        set => source.Target = value;
    }
}
