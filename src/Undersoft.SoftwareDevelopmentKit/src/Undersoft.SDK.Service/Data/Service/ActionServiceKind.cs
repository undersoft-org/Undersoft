using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace Undersoft.SDK.Service.Data
{
    public enum ActionServiceKind
    {
        None,
        SignIn,
        SignUp,
        SetPassword,
        SetEmail,
        ConfirmPassword,
        ConfirmEmail,
        CompleteRegistration,
        Token
    }
}