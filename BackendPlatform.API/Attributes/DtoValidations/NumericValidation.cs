using BackendPlatform.Core.Helpers;
using System.ComponentModel.DataAnnotations;

namespace BackendPlatform.API.Attributes.DtoValidations
{
    /// <summary>
    /// 數字 判斷
    /// </summary>
    public class Numeric: ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is null)
            {
                return true;
            }
            else
            {
                return ValidationHelper.IsNumeric(value.ToString());
            }
        }
    }
}
