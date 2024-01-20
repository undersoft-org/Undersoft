using Microsoft.AspNetCore.Identity;
using Undersoft.SDK.Uniques;
using System.Security.Claims;
using Undersoft.SDK.Security.Identity;

namespace Undersoft.SDK.Service.Server.Accounts
{
    public interface IAccountUser : IIdentifiable
    {
        public string UserName { get; set; }

        public string NormalizedUserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public bool EmailConfirmed { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public int AccessFailedCount { get; set; }
    }
}