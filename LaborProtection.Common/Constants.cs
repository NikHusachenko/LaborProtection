namespace LaborProtection.Common
{
    public class LightSystem
    {
        public enum LightType
        {
            Common = 1,
            Combined = 2,
        }
    }

    public class Localization
    {
        public const string EN = "en";
        public const string UA = "ua";
        public const string RU = "ru";
    }

    public class Errors
    {
        public const string CULTURE_NOT_FOUND_ERROR = "Culture not found. Maybe you have not registered selected culture";
    }
}