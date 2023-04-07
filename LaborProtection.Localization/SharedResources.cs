using System.Resources;

namespace LaborProtection.Localization
{
    public class SharedLocalizer
    {
        private readonly ResourceManager _resourceManager;

        public SharedLocalizer()
        {
            _resourceManager = new ResourceManager(typeof(ua_UA));
            var a = _resourceManager.BaseName;
        }

        public string? this[string key] => _resourceManager.GetString(key);
    }
}
