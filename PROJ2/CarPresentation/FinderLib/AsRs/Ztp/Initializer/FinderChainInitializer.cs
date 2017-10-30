using Autofac;
using Autofac.Core;
using FinderLib.AsRs.Ztp.Finder;
using FinderLib.AsRs.Ztp.Selectors;

namespace FinderLib.AsRs.Ztp.Initializer
{
    public class FinderChainInitializer
    {
        public static ILanguageFinder Initialize()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<AnyLanguageSelector>()
                .Named<ILanguageFinder>("Any Lng");

            builder.RegisterType<PolishLanguageSelector>()
                .Named<ILanguageFinder>("Pl Lng")
                .WithParameter(ResolvedParameter.ForNamed<ILanguageFinder>("Any Lng"));

            builder.RegisterType<EnglishLanguageSelector>()
                .Named<ILanguageFinder>("En Lng")
                .WithParameter(ResolvedParameter.ForNamed<ILanguageFinder>("Pl Lng"));

            builder.RegisterType<SpecifiedLanguageSelector>()
                .Named<ILanguageFinder>("Spec Lng")
                .WithParameter(ResolvedParameter.ForNamed<ILanguageFinder>("En Lng"));

            var container = builder.Build();

            return container.ResolveNamed<ILanguageFinder>("Spec Lng");
        }
    }
}