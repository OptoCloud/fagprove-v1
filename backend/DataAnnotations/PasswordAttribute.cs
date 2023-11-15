using System.ComponentModel.DataAnnotations;

namespace backend.DataAnnotations;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
public class PasswordAttribute : DataTypeAttribute
{
    public bool Required { get; set; } = true;

    public PasswordAttribute()
        : base(DataType.Text)
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

        // Check length
        if (valueAsString.Length is < 5 or > 64)
        {
            return false;
        }

        return true;
    }
}
