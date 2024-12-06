using Microsoft.Extensions.Localization;
using System.Reflection;

namespace MedicalArticles.Services
{
    public class LanguageService
    {
        public readonly IStringLocalizer _localization;

        public class SharedResource
        {

        }
        public LanguageService(IStringLocalizerFactory factory)
        {
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localization = factory.Create(nameof(SharedResource), assemblyName.Name);
        }

        public  LocalizedString GetKey(string key)
        {
            return _localization[key];
        }
    }
}
