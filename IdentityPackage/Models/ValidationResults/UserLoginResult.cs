namespace IdentityPackage.Models.ValidationResults
{
    public class UserLoginResult
    {
        /// <summary>
        /// Indication if the login was successful
        /// </summary>
        public bool IsSuccessful { get; set; }

        /// <summary>
        /// Message related to why the login failed
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The time remaining for this account lock out
        /// </summary>
        public int TimeRemaining { get; set; }
    }
}
