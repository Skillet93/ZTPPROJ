using System;
using System.Collections.Generic;
using System.Linq;
using FinderLib.AsRs.Ztp.Constants;
using FinderLib.AsRs.Ztp.Elements;
using FinderLib.AsRs.Ztp.Finder;

namespace FinderLib.AsRs.Ztp.Selectors
{
    public class PolishLanguageSelector : LanguageSelector
    {
        public PolishLanguageSelector(ILanguageFinder selector) : base(selector)
        {
        }

        public override LanguageElement Find(ICollection<LanguageElement> collection, string langCode)
        {
            return FindByLanguage(collection, LanguageConstatnts.Pl);
        }
    }
}