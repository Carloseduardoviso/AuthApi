using System.ComponentModel.DataAnnotations;

namespace Bussines.Helpers.Extensions
{
    public static class EnumDisplayName
    {
        public static string GetDisplayName<TEnum>(TEnum enumValue) where TEnum : Enum
        {
            var displayAttribute = typeof(TEnum)
                .GetField(enumValue.ToString())
                .GetCustomAttributes(typeof(DisplayAttribute), false)
                as DisplayAttribute[];

            return displayAttribute != null && displayAttribute.Length > 0
                ? displayAttribute[0].Name
                : enumValue.ToString();
        }
    }
}
