namespace Undersoft.SDK.Security
{
    public class AuthorizationNotes
    {
        public string Errors { get; set; }

        public string Success { get; set; }

        public string Info { get; set; }

        public SigningStatus? Status { get; set; }
    }
}
