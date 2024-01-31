namespace Undersoft.SDK.Invoking
{
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using Undersoft.SDK.Uniques;

    [DataContract]
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public class Argument : Identifiable, IArgument
    {
        [JsonIgnore]
        [IgnoreDataMember]
        private Type _type;

        public Argument() { }

        public Argument(IArgument value, string method, string target = null)
        {
            Set(value, method, target);
        }

        public Argument(object value, string method, string target = null)
        {
            Set(value.GetType().Name, value, method, target);
        }

        public Argument(string name, object value, string method, string target = null)
        {
            Set(name, value, method, target);
        }

        public Argument(string name, Type type, string method, string target = null)
        {
            Set(name, type.Default(), method, target);
        }

        public Argument(string name, string typeName, string method, string target = null)
        {
            Set(name, Assemblies.FindType(typeName), method, target);
        }

        public Argument(ParameterInfo info, string method, string target = null)
        {
            Set(info, method, target);
        }

        public string TargetName { get; set; }

        public string MethodName { get; set; }

        public string Name { get; set; }

        public byte[] Binaries { get; set; }

        public int Position { get; set; } = -1;

        public string ArgumentTypeName { get; set; } 

        public void Serialize(object value)
        {
            if (value != null)
            {
                Binaries = value.ToJsonBytes();
                ArgumentTypeName = value.GetType().FullName;
            }
        }

        public object Deserialize()
        {
            if (Binaries != null && TypeName != null)
            {
                var t = Assemblies.FindType(ArgumentTypeName);
                if (t != null)
                    return Binaries.FromJson(t);
            }
            return null;
        }

        public T Deserialize<T>() where T : class
        {
            if (Binaries != null)
            {
                return Binaries.FromJson<T>();
            }
            return null;
        }

        public void Set(ParameterInfo item, string method, string target = null)
        {
            Name = item.Name;
            _type = item.ParameterType;
            Position = item.Position;
            ArgumentTypeName = _type.FullName;
            MethodName = method;
            TargetName = target;
            Id = Name.UniqueKey();
            TypeId = ArgumentTypeName.UniqueKey();
        }

        public void Set(IArgument item, string method, string target = null)
        {
            Name = item.Name;
            Binaries = item.Binaries;
            Position = item.Position;
            ArgumentTypeName = item.ArgumentTypeName;
            MethodName = method;
            TargetName = target;
            Id = Name.UniqueKey();
            TypeId = ArgumentTypeName.UniqueKey();
        }

        public void Set(
            string name,
            object value,
            string method,
            string target = null,
            int position = 0
        )
        {
            Name = name;
            _type = value.GetType();
            ArgumentTypeName = _type.FullName;
            Serialize(value);
            Position = position;
            MethodName = method;
            TargetName = target;
            Id = Name.UniqueKey();
            TypeId = ArgumentTypeName.UniqueKey();
        }

        public void Set(
            string name,
            Type type,
            string method,
            string target = null,
            int position = 0
        )
        {
            Name = name;
            _type = type;
            ArgumentTypeName = _type.FullName;
            Position = position;
            MethodName = method;
            TargetName = target;
            Id = Name.UniqueKey();
            TypeId = ArgumentTypeName.UniqueKey();
        }
    }
}
