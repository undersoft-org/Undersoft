﻿using Undersoft.SDK;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Application.GUI.View;
using Undersoft.SSC.Service.Contracts;

namespace Undersoft.SSC.Service.Application.GUI.Compound.Access;

public class AccountValidator : ViewValidator<Account>
{
    public AccountValidator(IServicer servicer) : base(servicer)
    {
        ValidationScope(
            OperationType.Any,
            () =>
            {
                ValidateEmail(p => p.Model.Personal.Email);
                ValidateRequired(p => p.Model.Personal.Email);
                ValidateRequired(p => p.Model.Personal.PhoneNumber);
                ValidateRequired(p => p.Model.Personal.FirstName);
                ValidateRequired(p => p.Model.Personal.LastName);
                ValidateRequired(p => p.Model.Personal.Birthdate);
                ValidateRequired(p => p.Model.Address.Country);
                ValidateRequired(p => p.Model.Address.CityName);
                ValidateRequired(p => p.Model.Address.Postcode);
                ValidateRequired(p => p.Model.Address.StreetName);
                ValidateRequired(p => p.Model.Address.BuildingNumber);
                ValidateRequired(p => p.Model.Address.ApartmentNumber);
                ValidateEmail(p => p.Model.Professional.Email);
                ValidateRequired(p => p.Model.Professional.Email);
                ValidateRequired(p => p.Model.Professional.PhoneNumber);
                ValidateRequired(p => p.Model.Professional.Profession);
                ValidateRequired(p => p.Model.Professional.Industry);
                ValidateRequired(p => p.Model.Professional.Experience);
            }
        );
    }
}
