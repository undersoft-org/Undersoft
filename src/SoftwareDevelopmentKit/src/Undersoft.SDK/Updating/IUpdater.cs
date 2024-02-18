using Undersoft.SDK.Instant;

namespace Undersoft.SDK.Updating;

using Proxies;
using Rubrics;
using Undersoft.SDK.Proxies;

public interface IUpdater : IInstant
{
    IProxy Source { get; }

    IRubrics Rubrics { get; set; }

    object Clone();

    E Patch<E>() where E : class;
    E Patch<E>(E item) where E : class;

    E Put<E>() where E : class;
    E Put<E>(E item) where E : class;

    UpdatedItem[] Detect<E>(E item) where E : class;
}
