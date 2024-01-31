using System;
using System.Collections.Generic;

namespace Undersoft.SDK.Security
{
    public enum AccountAccessKind
    {
        None,
        SignIn,
        SignUp,
        SignOut,
        SetPassword,
        SetEmail,
        ConfirmPassword,
        ConfirmEmail,
        CompleteRegistration,
        Renew
    }
}