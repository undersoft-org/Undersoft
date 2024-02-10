using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Access;
using Undersoft.SDK.Service.Application.GUI.View;
using Undersoft.SDK.Service.Operation.Command;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Access;

public class AccessValidator : ViewValidator<Credentials>
{
    public AccessValidator(IServicer servicer) : base(servicer)
    {
        ValidationScope(
            CommandMode.Access | CommandMode.Create | CommandMode.Update,
            () =>
            {
                ValidateEmail(p => p.Model.Email);
            }
        );
        ValidationScope(
            CommandMode.Access | CommandMode.Create | CommandMode.Change,
            () =>
            {
                ValidateRequired(p => p.Model.Password);
            }
        ); ;
        ValidationScope(
            CommandMode.Create,
            () =>
            {
                ValidateRequired(p => p.Model.FirstName);
                ValidateRequired(p => p.Model.LastName);
                ValidateRequired(p => p.Model.RetypePassword);
                ValidateNotEqual(p => p.Model.Password, p => p.Model.RetypePassword);
            }
        );
        ValidationScope(
            CommandMode.Create | CommandMode.Change,
            () =>
            {
                ValidateRequired(p => p.Model.NewPassword);
                ValidateRequired(p => p.Model.RetypePassword);
                ValidateNotEqual(p => p.Model.NewPassword, p => p.Model.RetypePassword);
            }
        );
        ValidationScope(
            CommandMode.Change,
            () =>
            {
                ValidateRequired(p => p.Model.RetypePassword);
            }
        );
        ValidationScope(
            CommandMode.Setup,
            () =>
            {
                ValidateRequired(p => p.Model.EmailConfirmationToken);
            }
        );
        ValidationScope(
            CommandMode.Delete,
            () =>
            {
                ValidateRequired(p => p.Model.PasswordResetToken);
            }
        );
    }
}
