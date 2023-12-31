﻿using Undersoft.SDK.Service.Data.Object.Detail;

namespace Undersoft.SSC.Web.Contracts.Details;

[Detail]
public class ManufacturerDetail : DataObject
{
    public ManufacturerDetail() { }

    public string? Name { get; set; }

    public string? Description { get; set; }

}
