using System;
using System.Collections.Generic;

namespace Undersoft.SDK.Security.Identity
{
    public enum AuthorizationAction
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