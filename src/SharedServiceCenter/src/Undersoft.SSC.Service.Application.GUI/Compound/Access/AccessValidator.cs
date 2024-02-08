using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Access;
using Undersoft.SDK.Service.Application.GUI.Generic;
using Undersoft.SDK.Service.Data.Store;
using Undersoft.SDK.Service.Operation.Command;

namespace Undersoft.SSC.Service.Application.Client.Pages.Access;

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
        );
        ValidationScope(
            CommandMode.Access | CommandMode.Update,
            () =>
            {
                ValidateExist<IAccountStore, Contracts.Account>(
                    (cmd) => a => a.User != null ? a.User.Email == cmd.Email : false
                );
            }
        );
        ValidationScope(
            CommandMode.Create,
            () =>
            {
                ValidateRequired(p => p.Data.FirstName);
                ValidateRequired(p => p.Data.LastName);
                ValidateRequired(p => p.Data.RetypePassword);
                ValidateNotEqual(p => p.Data.Password, p => p.Data.RetypePassword);
                ValidateNotExist<IAccountStore, Contracts.Account>(
                    (cmd) =>
                        a =>
                            a.User != null
                                ? a.User.Email == cmd.Email || a.User.UserName == cmd.UserName
                                : false
                );
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
