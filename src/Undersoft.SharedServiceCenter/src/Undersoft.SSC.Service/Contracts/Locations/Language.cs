using System.Runtime.Serialization;

namespace Undersoft.SSC.Service.Contracts.Locations;

[DataContract]
public class Language : DataObject
{
    [DataMember(Order = 12)]
    public string? Name { get; set; }

    [DataMember(Order = 13)]
    public string? LanguageCode { get; set; }
}
