﻿using Microsoft.FluentUI.AspNetCore.Components;
using Undersoft.SDK.Rubrics.Attributes;
using Undersoft.SDK.Service.Data.Object;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Presenting.Downloads;

public class PresentingDownloads : DataObject
{
    [Link]
    [VisibleRubric]
    [DisplayRubric("Windows")]
    public string Windows { get; set; } = "/presenting/downloads/windows";
    public Icon WindowsIcon = new Icons.Regular.Size20.StoreMicrosoft();

    [Link]
    [VisibleRubric]
    [DisplayRubric("Android")]
    public string Android { get; set; } = "/presenting/downloads/android";
    public Icon AndroidIcon = new Icons.Regular.Size20.PhoneTablet();
}

