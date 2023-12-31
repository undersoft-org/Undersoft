﻿using System.Reflection;

namespace Microsoft.AspNetCore.Components.Routing;

#if NET6_0_OR_GREATER
[ExcludeFromCodeCoverage]
internal readonly struct RouteKey : IEquatable<RouteKey>
{
    public readonly Assembly? AppAssembly;
    public readonly HashSet<Assembly>? AdditionalAssemblies;

    public RouteKey(Assembly? appAssembly, IEnumerable<Assembly>? additionalAssemblies)
    {
        AppAssembly = appAssembly;
        AdditionalAssemblies = additionalAssemblies is null ? null : new HashSet<Assembly>(additionalAssemblies);
    }

    public override bool Equals(object? obj)
    {
        return obj is RouteKey other && Equals(other);
    }

    public bool Equals(RouteKey other)
    {
        if (!Equals(AppAssembly, other.AppAssembly))
        {
            return false;
        }

        if (AdditionalAssemblies is null && other.AdditionalAssemblies is null)
        {
            return true;
        }

        if (AdditionalAssemblies is null || other.AdditionalAssemblies is null)
        {
            return false;
        }

        return AdditionalAssemblies.Count == other.AdditionalAssemblies.Count &&
            AdditionalAssemblies.SetEquals(other.AdditionalAssemblies);
    }

    public override int GetHashCode()
    {
        if (AppAssembly is null)
        {
            return 0;
        }

        if (AdditionalAssemblies is null)
        {
            return AppAssembly.GetHashCode();
        }

        return HashCode.Combine(AppAssembly, AdditionalAssemblies.Count);
    }
}
#endif
