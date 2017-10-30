using System.Collections.Generic;
using FinderLib.AsRs.Ztp.Elements;

namespace FinderLib.AsRs.Ztp.Finder
{
    public interface ILanguageFinder
    {
        LanguageElement Find(ICollection<LanguageElement> collection, string langCode);
    }
}