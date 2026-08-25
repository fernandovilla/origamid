using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Reflection;

namespace Gestao.App.Client.Libraries.Extensions
{
    public static class EnumExtension
    {
        public static string DisplayName(this Enum enumValue)
        {
            var enumType = enumValue.GetType();
            var memberInfo = enumType.GetMember(enumValue.ToString());

            if (memberInfo.Length > 0) {
                var displayAtt = memberInfo[0].GetCustomAttribute<DisplayAttribute>();
                if (displayAtt != null)
                {
                    if (!string.IsNullOrEmpty(displayAtt.Name))
                        return displayAtt.Name;
                }
            }

            return enumValue.ToString();
        }
    }
}
