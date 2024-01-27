using ProtoBuf.Grpc.Configuration;
using System.Reflection;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Linq;

namespace Undersoft.SDK.Service.Server
{
    internal class GrpcDataServerBinder : ServiceBinder
    {
        private readonly IServiceRegistry registry;

        public GrpcDataServerBinder(IServiceRegistry registry)
        {
            this.registry = registry;
        }

        public override IList<object> GetMetadata(MethodInfo method, Type contractType, Type serviceType)
        {
            var resolvedServiceType = serviceType;
            if (serviceType.IsInterface)
                resolvedServiceType = registry.Get(serviceType)?.ImplementationInstance?.GetType() ?? serviceType;

            return base.GetMetadata(method, contractType, resolvedServiceType);
        }

        protected override string GetDefaultName(Type contractType)
        {
            var fullname = base.GetDefaultName(contractType);

            var dataName = fullname.Split('_').LastOrDefault();

            var endpointName = StoreRoutes.StreamDataRoute + "/" + dataName + "Stream";

            return endpointName;
        }
    }
}