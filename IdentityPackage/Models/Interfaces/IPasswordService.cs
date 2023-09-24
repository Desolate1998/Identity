using IdentityPackage.Models.ValidationResults;

namespace IdentityPackage.Models.Interfaces
{

    /// <summary>
    /// Interface used by <see cref="PasswordService"/>
    /// </summary>
    public interface IPasswordService
    {
        /// <summary>
        /// Validates the user password against the hashed password
        /// </summary>
        /// <param name="password"></param>
        /// <param name="hashedPassword"></param>
        /// <returns>Indication if the two passwords matches</returns>
        public bool ValidatePasswordLogin(string password, string hashedPassword);

        /// <summary>
        /// Hashes the users password
        /// </summary>
        /// <param name="password">The users password</param>
        public string HashPassword(string password);

        /// <summary>
        /// validates the users password for security 
        /// </summary>
        /// <param name="password">The users password</param>
        /// <returns>List of errors for the password field</returns>
        public FieldErrorMessage ValidatePassword(string password);
    }
}
