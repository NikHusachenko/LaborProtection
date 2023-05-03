using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace LaborProtection.Database.Enums
{
    public enum LightType
    {
        [Display(Name = "Загальне")]
        Common = 1,

        [Display(Name = "Комбіноване")]
        Combined = 2,
    }

    public static class LightTypeDisplay
    {
        public static string GetDisplayName(LightType light)
        {
            Type type = light.GetType();
            FieldInfo fieldInfo = type.GetField(light.ToString());
            DisplayAttribute displayAttribute = fieldInfo.GetCustomAttribute<DisplayAttribute>();

            if (displayAttribute != null)
            {
                return displayAttribute.Name;
            }
            return light.ToString();
        }

        public static string[] GetDisplayNames()
        {
            string[] names = Enum.GetNames(typeof(LightType));
            for (int i = 0; i < names.Length; i++)
            {
                LightType light = (LightType)(i + 1);
                Type type = light.GetType();
                FieldInfo fieldInfo = type.GetField(light.ToString());
                DisplayAttribute displayAttribute = fieldInfo.GetCustomAttribute<DisplayAttribute>();

                if (displayAttribute != null)
                {
                    names[i] = displayAttribute.Name;
                }
            }
            return names;
        }
    }
}