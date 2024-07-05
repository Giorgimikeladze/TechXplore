using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
public class PasswordValidationAttribute : ValidationAttribute
{
    private readonly int _minLength;
    private readonly bool _requireUppercase;
    private readonly bool _requireLowercase;
    private readonly bool _requireDigit;
    private readonly bool _requireSpecialCharacter;

    public PasswordValidationAttribute(
        int minLength = 8,
        bool requireUppercase = true,
        bool requireLowercase = true,
        bool requireDigit = true,
        bool requireSpecialCharacter = false)
    {
        _minLength = minLength;
        _requireUppercase = requireUppercase;
        _requireLowercase = requireLowercase;
        _requireDigit = requireDigit;
        _requireSpecialCharacter = requireSpecialCharacter;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is string password)
        {
            if (password.Length < _minLength)
                return new ValidationResult($"Password must be at least {_minLength} characters long.");

            if (_requireUppercase && !Regex.IsMatch(password, "[A-Z]"))
                return new ValidationResult("Password must contain at least one uppercase letter.");

            if (_requireLowercase && !Regex.IsMatch(password, "[a-z]"))
                return new ValidationResult("Password must contain at least one lowercase letter.");

            if (_requireDigit && !Regex.IsMatch(password, @"\d"))
                return new ValidationResult("Password must contain at least one digit.");

            if (_requireSpecialCharacter && !Regex.IsMatch(password, @"[!@#$%^&*(),.?""':{}|<>]"))
                return new ValidationResult("Password must contain at least one special character.");
        }
        else
        {
            return new ValidationResult("Password is required.");
        }

        return ValidationResult.Success;
    }
}
