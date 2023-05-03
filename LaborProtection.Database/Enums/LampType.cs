using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace LaborProtection.Database.Enums
{
    public enum LampType
    {
        [Display(Name = "ЛПО")]
        LPO = 1,

        [Display(Name = "ОД")]
        OD = 2,

        [Display(Name = "ЛСП")]
        LSP = 3,

        [Display(Name = "ЛСО")]
        LSO = 4,
    }
    
    public static class LampTypeDisplay
    {
        public static string GetDisplayName(LampType lamp)
        {
            Type type = lamp.GetType();
            FieldInfo fieldInfo = type.GetField(lamp.ToString());
            DisplayAttribute displayAttribute = fieldInfo.GetCustomAttribute<DisplayAttribute>();

            if (displayAttribute != null)
            {
                return displayAttribute.Name;
            }
            return lamp.ToString();
        }

        public static string[] GetDisplayNames()
        {
            string[] names = Enum.GetNames(typeof(LampType));
            for (int i = 0; i < names.Length; i++)
            {
                LampType lamp = (LampType)(i + 1);
                Type type = lamp.GetType();
                FieldInfo fieldInfo = type.GetField(lamp.ToString());
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