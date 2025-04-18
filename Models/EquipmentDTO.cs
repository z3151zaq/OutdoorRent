using System.ComponentModel.DataAnnotations;
using WebCoreApi.Data;

namespace WebCoreApi.Models;

public class EquipmentDTO
{
    public int Id { get; set; }
    public string Location { get; set; }
    public int ManagerId { get; set; }
    public string ManagerName { get; set; }
    public string Availability { get; set; }
    public string Type { get; set; }
    public float PricePerDay { get; set; }
    public string Descriptions { get; set; }
    [EnumCaseInsensitiveValidationAttribute(typeof(ConditionEnum))]
    public string Condition { get; set; }
}

public class EnumCaseInsensitiveValidationAttribute : ValidationAttribute
{
    private readonly Type _enumType;

    public EnumCaseInsensitiveValidationAttribute(Type enumType)
    {
        _enumType = enumType;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var valueAsString = value.ToString();

        if (Enum.TryParse(_enumType, valueAsString, true, out _))
        {
            return ValidationResult.Success;
        }

        // 如果无法转换，返回失败的验证结果
        return new ValidationResult($"Invalid value for enum {_enumType.Name}. The value '{valueAsString}' is not valid.");
    }
}