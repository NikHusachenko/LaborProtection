using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace LaborProtection.Database.Enums
{
    public enum BulbType
    {
        [Display(Name = "ЛБ")]
        LB = 1,

        [Display(Name = "ЛД")]
        LD = 2,

        [Display(Name = "ЛБУ")]
        LBU = 3,
    }

    public static class BulbTypeDisplay
    {
        public static string GetDisplayName(BulbType bulbType)
        {
            Type type = bulbType.GetType();
            FieldInfo fieldInfo = type.GetField(bulbType.ToString());
            DisplayAttribute displayAttribute = fieldInfo.GetCustomAttribute<DisplayAttribute>();

            if (displayAttribute != null)
            {
                return displayAttribute.Name;
            }
            return bulbType.ToString();
        }

        public static string[] GetDisplayNames()
        {
            string[] names = Enum.GetNames(typeof(BulbType));
            for (int i = 0; i < names.Length; i++)
            {
                BulbType bulb = (BulbType)(i + 1);
                Type type = bulb.GetType();
                FieldInfo fieldInfo = type.GetField(bulb.ToString());
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