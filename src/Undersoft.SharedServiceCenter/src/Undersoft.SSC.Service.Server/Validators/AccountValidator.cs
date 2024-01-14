using Undersoft.SDK.Service.Server.Operation.Command;
using Undersoft.SDK.Service.Server.Operation.Command.Validator;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Server.Validators;

public class MemberValidator : CommandSetValidator<Member>
{
    public MemberValidator(IServicer ultimatr) : base(ultimatr)
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
            ValidateNotExist<IEntryStore, Member>(
                (cmd) =>
                    (e) => (e.Label == cmd.Label)
                        || (e.Identifiers[IdKind.Email].Value == cmd.Identifiers[IdKind.Email].Value
                        || (e.Identifiers[IdKind.Name].Value == cmd.Identifiers[IdKind.Name].Value)
                        || (e.Identifiers[IdKind.Phone].Value == cmd.Identifiers[IdKind.Phone].Value)),
                "Members already exists"
                );
            }
        );
        ValidationScope(
            CommandMode.Update | CommandMode.Change,
            () =>
            {
                ValidateRequired(p => p.Contract.Identifiers[IdKind.Name].Value);
                ValidateExist<IEntryStore, Member>((cmd) => (e) => e.Id == cmd.Id);
            }
        );
        ValidationScope(
            CommandMode.Delete,
            () =>
            {
                ValidateRequired(a => a.Contract.Id);
                ValidateExist<IEntryStore, Member>((cmd) => (e) => e.Id == cmd.Id);
            }
        );
    }
}
