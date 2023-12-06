using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Undersoft.SDK.Service.Data.Object;

using Event;
using Instant.Proxies;

[DataContract]
[StructLayout(LayoutKind.Sequential)]
public class DataObject : InnerProxy, INotifyPropertyChanged, IDataObject
{
    public DataObject() : base() { }

    protected override IProxy CreateProxy()
    {
        Type type = this.GetDataType();

        if (TypeId == 0)
            TypeId = type.UniqueKey32();

        if (type.IsAssignableTo(typeof(IProxy)))
            return (IProxy)this;

        if (type.IsAssignableTo(typeof(Event)))
            return null;

        return ProxyFactory.GetCreator(type, TypeId).Create(this);
    }

}
