﻿using System.Runtime.Serialization;

namespace Undersoft.SSC.Service.Contracts;

[DataContract]
public class Role : InnerProxy
{
    [DataMember(Order = 6)]
    public virtual string? Name { get; set; }

    [DataMember(Order = 7)]
    public virtual string? NormalizedName { get; set; }

    [DataMember(Order = 8)]
    public ObjectSet<Claim>? Claims { get; set; }
}
