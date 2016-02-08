﻿using System.Collections.Generic;
using System.Globalization;
using EPiServer.Framework.Localization;

namespace DbLocalizationProvider
{
    public class DatabaseLocalizationProvider : LocalizationProvider
    {
        private readonly LocalizationResourceRepository _repository;

        public DatabaseLocalizationProvider()
        {
            _repository = new LocalizationResourceRepository();
        }

        public override IEnumerable<CultureInfo> AvailableLanguages => _repository.GetAvailableLanguages();

        public override string GetString(string originalKey, string[] normalizedKey, CultureInfo culture)
        {
            return ConfigurationContext.Current.DisableLocalizationCallback() ? originalKey : _repository.GetTranslation(originalKey, culture);
        }

        public override IEnumerable<ResourceItem> GetAllStrings(string originalKey, string[] normalizedKey, CultureInfo culture)
        {
            return _repository.GetAllTranslations(originalKey, culture);
        }
    }
}
