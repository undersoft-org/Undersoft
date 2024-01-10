using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace Undersoft.SDK.Service.Client
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