using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FinderLib.AsRs.Ztp.Elements;
using FinderLib.AsRs.Ztp.Finder;

namespace FinderLib.AsRs.Ztp.Selectors
{
    public class AnyLanguageSelector : LanguageSelector
    {
        public AnyLanguageSelector()
        {
        }

        public AnyLanguageSelector(ILanguageFinder selector) : base(selector)
        {
        }

        public override LanguageElement Find(ICollection<LanguageElement> collection, string langCode)
        {
            var isNotEmpty = collection.Any();
            LanguageElement element;

            if (isNotEmpty)
            {
                element = collection.First();
            }
            else
            {
                throw new InvalidDataException();
            }
            return element;
        }
    }
}