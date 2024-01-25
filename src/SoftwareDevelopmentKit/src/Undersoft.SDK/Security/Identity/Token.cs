namespace Undersoft.SDK.Security.Identity;

public class Token : Identifiable
{
    public virtual long UserId { get; set; }

    public virtual string LoginProvider { get; set; }

    public virtual string Name { get; set; }

    public virtual string Value { get; set; }
}