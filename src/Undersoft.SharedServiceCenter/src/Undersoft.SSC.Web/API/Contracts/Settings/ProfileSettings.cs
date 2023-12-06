namespace Undersoft.SSC.Web.API.Contracts.Settings;

public class ProfileSettings : DataObject
{
    public ProfileSettings() { }

    public string? AvatarPath { get; set; }

    public string? BoardPath { get; set; }

    public string? LogoPath { get; set; }

    public string? ProfilePath { get; set; }
}
