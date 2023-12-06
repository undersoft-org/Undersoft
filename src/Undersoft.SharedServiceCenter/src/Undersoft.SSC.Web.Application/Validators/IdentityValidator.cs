namespace Undersoft.SSC.Web.Service.Validators;

//public class IdentityDetailsValidator : CommandSetValidator<IdentityDetails>
//{
    //public IdentityDetailsValidator(IServicer ultimatr) : base(ultimatr)
    //{
    //    ValidationScope(
    //        CommandMode.Any,
    //        () =>
    //        {
    //            ValidateEmail(
    //                p => p.Data.[DetailKind.Identity].Identifiers[IdKind.Email].Value
    //            );
    //            ValidateEmail(
    //                p => p.Data.Identifiers[IdKind.Email].Value
    //            );
    //        });

    //    ValidationScope(
    //        CommandMode.Create | CommandMode.Upsert,
    //        () =>
    //        {
    //            ValidateRequired(p => p.Data.Details[DetailKind.Identity].Identifiers[IdKind.Name].Value);
    //            ValidateRequired(p => p.Data.Identifiers[IdKind.Name].Value);
    //        }
    //    );
    //    ValidationScope(
    //        CommandMode.Create,
    //        () =>
    //        {
    //            ValidateNotExist<IEntryStore, Account>(
    //                (cmd) =>
    //                    (e) =>
    //                        e.Identifiers[IdKind.Email].Value == cmd.Identifiers[IdKind.Email].Value
    //                        || e.Identifiers[IdKind.Name].Value == cmd.Identifiers[IdKind.Name].Value
    //                        || e.Identifiers[IdKind.Phone].Value == cmd.Identifiers[IdKind.Phone].Value,
    //                "Same Name, Email or PhoneNumber"
    //            );
    //        }
    //    );
    //    ValidationScope(
    //        CommandMode.Update | CommandMode.Change,
    //        () =>
    //        {
    //            ValidateRequired(p => p.Data.Details[DetailKind.Identity].Identifiers[IdKind.Name].Value);
    //            ValidateRequired(p => p.Data.Identifiers[IdKind.Name].Value);
    //            ValidateExist<IEntryStore, Account>((cmd) => (e) => e.Id == cmd.Id);
    //        }
    //    );
    //    ValidationScope(
    //        CommandMode.Delete,
    //        () =>
    //        {
    //            ValidateRequired(a => a.Data.Id);

    //            ValidateRequired(a => a.Data.Details[DetailKind.Identity].Id);
    //            ValidateExist<IEntryStore, Account>((cmd) => (e) => e.Id == cmd.Id);
    //        }
    //    );
    //}
//}
