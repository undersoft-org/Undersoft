namespace Undersoft.SDK.Service
{
    public class ServiceObject<T> : ServiceObject, IServiceRegistryObject<T>
    {
        public new T Value { get; set; }

        public ServiceObject()
        {
        }

        public ServiceObject(T obj)
        {
            Value = obj;
        }
    }

    public class ServiceObject : IServiceRegistryObject
    {
        public object Value { get; set; }

        public ServiceObject()
        {
        }

        public ServiceObject(object obj)
        {
            Value = obj;
        }
    }
}