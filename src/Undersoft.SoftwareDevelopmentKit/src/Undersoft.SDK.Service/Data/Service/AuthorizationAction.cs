using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace Undersoft.SDK.Service.Data
{
    public enum AuthorizationAction
    {
        None,
        SignIn,
        SignUp,
        SetPassword,
        SetEmail,
        ConfirmPassword,
        ConfirmEmail,
        CompleteRegistration,
        Renew
    }
}