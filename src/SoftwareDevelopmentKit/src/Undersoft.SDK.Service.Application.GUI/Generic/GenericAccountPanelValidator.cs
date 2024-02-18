using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SDK.Service.Application.GUI.Generic;

public class GenericAccountPanelValidator : ViewValidator<Account>
{
    public GenericAccountPanelValidator(IServicer servicer) : base(servicer)
    {
        ValidationScope(
            OperationType.Access | OperationType.Create | OperationType.Update,
            () =>
            {
                ValidateEmail(p => p.Model.Credentials.Email);
                ValidateRequired(p => p.Model.Credentials.Email);
            }
        );
        ValidationScope(
            OperationType.Access | OperationType.Create | OperationType.Change,
            () =>
            {
                ValidateRequired(p => p.Model.Credentials.Password);
            }
        );
        ValidationScope(
            OperationType.Create,
            () =>
            {
                ValidateRequired(p => p.Model.Credentials.FirstName);
                ValidateRequired(p => p.Model.Credentials.LastName);
                ValidateEqual(p => p.Model.Credentials.RetypedPassword, p => p.Model.Credentials.Password);
            }
        );
        ValidationScope(
            OperationType.Change,
            () =>
            {
                ValidateRequired(p => p.Model.Credentials.NewPassword);
                ValidateEqual(p => p.Model.Credentials.RetypedPassword, p => p.Model.Credentials.NewPassword);
            }
        );
        ValidationScope(
            OperationType.Setup,
            () =>
            {
                ValidateRequired(p => p.Model.Credentials.EmailConfirmationToken);
            }
        );
        ValidationScope(
            OperationType.Delete,
            () =>
            {
                ValidateRequired(p => p.Model.Credentials.PasswordResetToken);
            }
        );
    }
}
