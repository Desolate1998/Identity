using IdentityPackage.Models.BuilderModels;

namespace IdentityPackage.Builders
{
    public class PasswordValidationBuilder
    {
        private readonly PasswordValidationRule rules = new();

        public PasswordValidationBuilder HasMaxLength(int length, string? message = null)
        {
            rules.MaxLength = length;
            rules.MaxLengthMessage = message is null ? rules.MaxLengthMessage : message;
            return this;
        }

        public PasswordValidationBuilder HasMinLength(int length, string? message = null)
        {
            rules.MinLength = length;
            rules.MinLengthMessage = message is null ? rules.MinLengthMessage : message;
            return this;
        }

        public PasswordValidationBuilder MustHaveSpecialCharacter(bool specialCharacter = true, string? message = null)
        {
            rules.MustHaveSpecialCharacter = specialCharacter;
            rules.SpecialCharacterMessage = message is null ? rules.SpecialCharacterMessage : message;
            return this;
        }

        public PasswordValidationBuilder MustHaveLowerCaseCharacter(bool lowerCaseCharacter = true, string? message = null)
        {
            rules.MustHaveLowerCaseCharacter = lowerCaseCharacter;
            rules.LowerCaseCharacterMessage = message is null ? rules.LowerCaseCharacterMessage : message;
            return this;
        }

        public PasswordValidationBuilder MustHaveUpperCaseCharacter(bool upperCaseCharacter = true, string? message = null)
        {
            rules.MustHaveUpperCaseCharacter = upperCaseCharacter;
            rules.UpperCharacterMessage = message is null ? rules.UpperCharacterMessage : message;
            return this;
        }

        public PasswordValidationRule Build() => rules;
    }
}
