using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace OneToOneCrud.Localization
{
    public static class OneToOneCrudLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(OneToOneCrudConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(OneToOneCrudLocalizationConfigurer).GetAssembly(),
                        "OneToOneCrud.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
