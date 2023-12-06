using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SDK.Service.Data.Identifier;

public class Identifiers<TObject> : KeyedCollection<long, Identifier<TObject>>, IFindableSeries<Identifier<TObject>>, IIdentifiers, IIdentifiers<TObject> where TObject : IDataObject
{
    [JsonIgnore] private static ISeries<Identifier<TObject>> _identifiers = new Registry<Identifier<TObject>>(true);

    public IDataObject this[IdKind kind]
    {
        get => this.FirstOrDefault(o => o.Kind == kind);
        set => ((IIdentifier<TObject>)value).PutTo(this.FirstOrDefault(o => o.Kind == kind));
    }

    object IFindableSeries.this[object key]
    {
        get => _identifiers[key];
        set => ((IFindableSeries)_identifiers)[key] = value;
    }

    public Identifiers() : base()
    {
    }

    public Identifier<TObject> Search(object id)
    {
        return _identifiers[id];
    }

    public Identifier<TObject> this[object id]
    {
        get => _identifiers[id];
        set => _identifiers[id] = value;
    }

    public new Identifier<TObject> this[int id]
    {
        get => _identifiers[id];
        set => _identifiers[id] = value;
    }

    protected override long GetKeyForItem(Identifier<TObject> item)
    {
        if (item.Id == 0)
            item.AutoId();

        return item.Id;
    }

    protected new KeyedCollection<long, Identifier<TObject>> Dictionary { get => this; }

    protected override void ClearItems()
    {
        _identifiers.Clear();
        base.ClearItems();
    }

    protected override void SetItem(int index, Identifier<TObject> item)
    {
        _identifiers[index] = item;
        base.SetItem(index, item);
    }

    protected override void InsertItem(int index, Identifier<TObject> item)
    {
        _identifiers.Put(item);
        base.InsertItem(index, item);
    }

    protected override void RemoveItem(int index)
    {
        _identifiers.Remove(this[index].Key);
        Remove(index);
    }


    public void UpdateIdentifiers(TObject model)
    {
        var rubrics = ((IInnerProxy)model).Proxy.Rubrics;
        rubrics.KeyRubrics.ForEach(r =>
        {
            Add(
                new Identifier<TObject>()
                {
                    ObjectId = model.Id,
                    Kind = Enum.TryParse(r.Name, true, out IdKind kind)
                        ? kind
                        : IdKind.None,
                    Value = this[r.RubricId].ToString(),
                    Name = r.Name
                }
            );
        });
    }
}

public interface IIdentifiers
{
    IDataObject this[IdKind kind] { get; set; }
}

public interface IIdentifiers<TObject> : IIdentifiers where TObject : IDataObject
{
    Identifier<TObject> this[int id] { get; set; }
    Identifier<TObject> this[object id] { get; set; }

    Identifier<TObject> Search(object id);
}
