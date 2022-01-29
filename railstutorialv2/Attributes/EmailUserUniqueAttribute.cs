
using System.ComponentModel.DataAnnotations;
using railstutorialv2.Repository;
using System.Linq;

namespace railstutorialv2.Attributes;

public class EmailUserUniqueAttribute: ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        //return base.IsValid(value, validationContext);
        var _context = (IUsersRepository)validationContext.GetService(typeof(IUsersRepository));
        var _entity = _context.GetUserByEmailAsync(value.ToString());
        if(_entity?.Result != null)
        {
            return new ValidationResult(GetErrorMessage(value.ToString()));
        }
        //var _entity = _usersRepository.SingleOrDefault<IUsersRepository>(e => e.Email == value.ToString());
        //var _entity = _context.GetUserByEmailAsync(()value);
        return ValidationResult.Success;
    }

    public string GetErrorMessage(string email)
    {
        return $"Email {email} is already use.";
    }
}