﻿using Undersoft.SDK.Service.Data.Object.Detail;

namespace Undersoft.SSC.Service.Contracts.Details;

[Detail]
public class CommandDetail : DataObject
{
    public CommandDetail() { }

    public string? Name { get; set; }

    public string? Description { get; set; }

}
