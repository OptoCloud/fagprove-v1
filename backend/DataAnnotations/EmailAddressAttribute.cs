using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace backend.DataAnnotations;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
public class EmailAddressAttribute : DataTypeAttribute
{
    public bool Required { get; set; } = true;

    public EmailAddressAttribute()
        : base(DataType.EmailAddress)
    {
    }

    public override bool IsValid(object? value)
    {
        if (value == null)
        {
            return !Required;
        }

        if (value is not string valueAsString)
        {
            return false;
        }

        // Do simple check for '@' character before calling more expensive parser
        if (!valueAsString.Contains('@'))
        {
            return false;
        }

        return MailAddress.TryCreate(valueAsString, out _);
    }
}
