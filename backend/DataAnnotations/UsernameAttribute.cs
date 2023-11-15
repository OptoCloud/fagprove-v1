using System.ComponentModel.DataAnnotations;

namespace backend.DataAnnotations;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
public class UsernameAttribute : DataTypeAttribute
{
    public bool Required { get; set; } = true;

    public UsernameAttribute()
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

        // Remove leading and trailing white spaces before checking length
        valueAsString = valueAsString.Trim();

        // Check length
        if (valueAsString.Length is < 3 or > 20)
        {
            return false;
        }

        // Username must start with a letter
        if (!char.IsLetter(valueAsString[0]))
        {
            return false;
        }

        return true;
    }
}
