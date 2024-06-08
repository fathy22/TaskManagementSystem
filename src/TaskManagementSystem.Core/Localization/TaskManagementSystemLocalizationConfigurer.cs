using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace TaskManagementSystem.Localization
{
    public static class TaskManagementSystemLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(TaskManagementSystemConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(TaskManagementSystemLocalizationConfigurer).GetAssembly(),
                        "TaskManagementSystem.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
