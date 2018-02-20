using System;
using System.Collections.Generic;
using System.Linq;
using FinderLib.AsRs.Ztp.Elements;
using FinderLib.AsRs.Ztp.Finder;

namespace FinderLib.AsRs.Ztp.Selectors
{
    public abstract class LanguageSelector : ILanguageFinder
    {
        protected LanguageSelector()
        {
        }

        protected ILanguageFinder NextSelector;

        protected LanguageSelector(ILanguageFinder selector)
        {
            NextSelector = selector;
        }

        public abstract LanguageElement Find(ICollection<LanguageElement> collection, string langCode);

        public LanguageElement FindByLanguage(ICollection<LanguageElement> collection, string langCode)
        {
            var descriptions = collection.FirstOrDefault(desc => desc.Language.Equals(langCode));
            var message = descriptions ?? NextSelector.Find(collection, langCode);

            return message;
        }
    }
}