using System.Globalization;
using System.Resources;

namespace LaborProtection.Localization
{
    public static class LocalizationConfigurationManager
    {
        private static readonly List<CultureInfo> _locales;
        private static readonly List<Type> _resxFiles;

        private static CultureInfo _defaultCulture;
        private static Type _defaultResx;

        static LocalizationConfigurationManager()
        {
            _locales = new List<CultureInfo>();
            _resxFiles = new List<Type>();
        }

        public static CultureInfo DefaultCulture => _defaultCulture;

        /// <summary>
        /// Does registration of localization in program. Add corresponding culture to list of supported cultures
        /// </summary>
        /// <param name="culture"></param>
        /// <param name="resx">Type of .resx file in this directory</param>
        /// <returns></returns>
        public static bool RegisterCulture(CultureInfo culture, Type resx)
        {
            if (_locales.Find(cult => cult.Name == culture.Name) != null)
            {
                return false;
            }

            _locales.Add(culture);
            _resxFiles.Add(resx);

            if (_defaultCulture == null)
            {
                _defaultCulture = culture;
                _defaultResx = resx;
            }

            return true;
        }
        
        public static void SetDefaultCulture(CultureInfo culture, Type resx)
        {
            int cultureIndex = _locales.FindIndex(cult => cult.Name == culture.Name);
            if (cultureIndex == -1)
            {
                _locales.Add(culture);
                _resxFiles.Add(resx);

                _defaultCulture = culture;
                _defaultResx = resx;
            }
            else
            {
                _defaultCulture = _locales[cultureIndex];
                _defaultResx = _resxFiles[cultureIndex];
            }
        }

        public static SharedLocalizer SwitchLocale(CultureInfo culture)
        {
            int cultureIndex = _locales.FindIndex(cult => cult.Name == culture.Name);
            if (cultureIndex == -1)
            {
                if (_defaultResx == null)
                {
                    throw new Exception("Culture are not registered");
                }

                return new SharedLocalizer(_resxFiles[0]);
            }
            return new SharedLocalizer(_resxFiles[cultureIndex]);
        }

        public static SharedLocalizer SwitchLocale(string culture)
        {
            foreach (CultureInfo _culture in _locales)
            {
                if (_culture.Name.Contains(culture))
                {
                    return SwitchLocale(_culture);
                }
            }

            return SwitchLocale(new CultureInfo(culture));
        }
    }

    public class SharedLocalizer
    {
        private readonly ResourceManager _resourceManager;

        public SharedLocalizer(Type resx)
        {
            _resourceManager = new ResourceManager(resx);
        }

        public string? this[string key] => _resourceManager.GetString(key);
    }
}