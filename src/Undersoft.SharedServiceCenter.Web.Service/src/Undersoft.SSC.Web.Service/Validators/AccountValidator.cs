using Undersoft.SDK.Service.Application.Operation.Command;
using Undersoft.SDK.Service.Application.Operation.Command.Validator;
using Undersoft.SSC.Web.Contracts;

namespace Undersoft.SSC.Web.Service.Validators;

public class AccountValidator : CommandSetValidator<Account>
{
    public AccountValidator(IServicer ultimatr) : base(ultimatr)
    {
        ValidationScope(
            CommandMode.Any,
            () =>
            {
                ValidateEmail(
                    p => p.Contract.Identifiers != null ? p.Contract.Identifiers[IdKind.Email].Value : null
                );
            });

        ValidationScope(
            CommandMode.Create | CommandMode.Upsert,
            () =>
            {
                ValidateRequired(p => p.Contract.Identifiers != null ? p.Contract.Identifiers[IdKind.Email].Value : null);
            }
        );
        ValidationScope(
            CommandMode.Create,
            () =>
            {
            ValidateNotExist<IEntryStore, Account>(
                (cmd) =>
                    (e) => (e.Label == cmd.Label)
                        || (e.Identifiers[IdKind.Email].Value == cmd.Identifiers[IdKind.Email].Value
                        || (e.Identifiers[IdKind.Name].Value == cmd.Identifiers[IdKind.Name].Value)
                        || (e.Identifiers[IdKind.Phone].Value == cmd.Identifiers[IdKind.Phone].Value)),
                "Account already exists"
                );
            }
        );
        ValidationScope(
            CommandMode.Update | CommandMode.Change,
            () =>
            {
                ValidateRequired(p => p.Contract.Identifiers[IdKind.Name].Value);
                ValidateExist<IEntryStore, Account>((cmd) => (e) => e.Id == cmd.Id);
            }
        );
        ValidationScope(
            CommandMode.Delete,
            () =>
            {
                ValidateRequired(a => a.Contract.Id);
                ValidateExist<IEntryStore, Account>((cmd) => (e) => e.Id == cmd.Id);
            }
        );
    }
}
