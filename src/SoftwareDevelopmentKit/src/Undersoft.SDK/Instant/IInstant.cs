﻿namespace Undersoft.SDK.Instant
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;
    using Uniques;

    public interface IInstant : IUnique
    {
        object this[string propertyName] { get; set; }

        object this[int fieldId] { get; set; }        

        Uscn Code { get; set; }
    }

    public interface IValueArray : IInstant
    {
        object[] ValueArray { get; set; }
    }
}