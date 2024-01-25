namespace Undersoft.SDK.Security
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
    public class Credentials : ICredentials
    {
        public ServiceSite? Site { get; set; }
        public IdentityType? Type { get; set; }

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
