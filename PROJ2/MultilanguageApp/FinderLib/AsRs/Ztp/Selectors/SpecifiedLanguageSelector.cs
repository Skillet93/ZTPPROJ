using System;
using System.Collections.Generic;
using System.Linq;
using FinderLib.AsRs.Ztp.Elements;
using FinderLib.AsRs.Ztp.Finder;

namespace FinderLib.AsRs.Ztp.Selectors
{
    public class SpecifiedLanguageSelector : LanguageSelector
    {
        public SpecifiedLanguageSelector(ILanguageFinder selector) : base(selector)
        {
        }

        public override LanguageElement Find(ICollection<LanguageElement> collection, string langCode)
        {
            return FindByLanguage(collection, langCode);
        }
    }
}