namespace Undersoft.SDK.Security.Identity
{
    [Serializable]
    public enum ServiceSite
    {
        Client,
        Server
    }

    public enum DataSite
    {
        None,
        Client,
        Endpoint
    }

    public enum IdentityType
    {
        User,
        Server,
        Service
    }

    [Serializable]
    public class Credentials : Origin, ICredentials
    {
        public ServiceSite Site;
        public IdentityType Type;

        public string UserName { get; set; }

        public string NormalizedUserName { get; set; }

        public string Email { get; set; }

        public string OldPassword { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public bool EmailConfirmed { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool RegistrationCompleted { get; set; }

        public string SessionToken { get; set; }

        public string PasswordResetToken { get; set; }

        public string EmailConfirmationToken { get; set; }

        public string PhoneNumberConfirmationToken { get; set; }

        public string RegistrationCompleteToken { get; set; }

        public int AccessFailedCount { get; set; }

        public bool SaveAccountInCookies { get; set; }

        public bool Authorized { get; set; }

        public bool Authenticated { get; set; }
    }
}
