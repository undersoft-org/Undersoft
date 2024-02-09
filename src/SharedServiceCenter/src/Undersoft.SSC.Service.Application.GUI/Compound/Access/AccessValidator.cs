using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Access;
using Undersoft.SDK.Service.Application.GUI.Generic;
using Undersoft.SDK.Service.Operation.Command;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Access;

public class AccessValidator : GenericValidator<Credentials>
{
    public AccessValidator(IServicer servicer) : base(servicer)
    {
        ValidationScope(
            CommandMode.Access | CommandMode.Create | CommandMode.Update,
            () =>
            {
                ValidateEmail(p => p.Data.Email);
            }
        );
        ValidationScope(
            CommandMode.Access | CommandMode.Create | CommandMode.Change,
            () =>
            {
                ValidateRequired(p => p.Data.Password);
            }
        ); ;
        ValidationScope(
            CommandMode.Create,
            () =>
            {
                ValidateRequired(p => p.Data.FirstName);
                ValidateRequired(p => p.Data.LastName);
                ValidateRequired(p => p.Data.RetypePassword);
                ValidateNotEqual(p => p.Data.Password, p => p.Data.RetypePassword);
            }
        );
        ValidationScope(
            CommandMode.Create | CommandMode.Change,
            () =>
            {
                ValidateRequired(p => p.Data.NewPassword);
                ValidateRequired(p => p.Data.RetypePassword);
                ValidateNotEqual(p => p.Data.NewPassword, p => p.Data.RetypePassword);
            }
        );
        ValidationScope(
            CommandMode.Change,
            () =>
            {
                ValidateRequired(p => p.Data.RetypePassword);
            }
        );
        ValidationScope(
            CommandMode.Setup,
            () =>
            {
                ValidateRequired(p => p.Data.EmailConfirmationToken);
            }
        );
        ValidationScope(
            CommandMode.Delete,
            () =>
            {
                ValidateRequired(p => p.Data.PasswordResetToken);
            }
        );
    }
}
