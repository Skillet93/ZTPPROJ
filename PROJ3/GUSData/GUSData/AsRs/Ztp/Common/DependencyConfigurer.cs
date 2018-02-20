using Autofac;
using Autofac.Core;
using GUSData.AsRs.Ztp.Collection;
using GUSData.AsRs.Ztp.Csv;
using GUSData.AsRs.Ztp.Xml;

namespace GUSData.AsRs.Ztp.Common
{
    public static class DependencyConfigurer
    {
        public static IContainer ConfigureDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<XmlFileContainer>();

            builder.RegisterType<XmlLoader>()
                .As<IXmlLoader>()
                .WithParameters(new Parameter[]
                {
                    new ResolvedParameter(
                        (pi, ctx) => pi.ParameterType == typeof(XmlFileContainer),
                        (pi, ctx) => ctx.Resolve<XmlFileContainer>()),
                    new NamedParameter(Constants.DependencyConstant.ConsoleLogger, LoggUtil.GetConsoleLogger())
                });

            builder.RegisterType<CollectionSeparator>()
                .As<ICollectionSeparator>();

            builder.RegisterType<CollectionElementsParser>()
                .As<ICollectionElementsParser>();

            builder.RegisterType<XmlConverter>()
                .As<IXmlConverter>()
                .WithParameters(new Parameter[]
                {
                    new ResolvedParameter(
                        (pi, ctx) => pi.ParameterType == typeof(ICollectionSeparator),
                        (pi, ctx) => ctx.Resolve<ICollectionSeparator>()),
                    new NamedParameter(Constants.DependencyConstant.ConsoleLogger, LoggUtil.GetConsoleLogger()),
                    new ResolvedParameter(
                        (pi, ctx) => pi.ParameterType == typeof(ICollectionElementsParser),
                        (pi, ctx) => ctx.Resolve<ICollectionElementsParser>())
                });

            builder.RegisterType<CsvWriter>()
                .As<ICsvWriter>().WithParameters(new Parameter[]
                {
                    new NamedParameter(Constants.DependencyConstant.WriteLogger, LoggUtil.GetWriterLogger()),
                    new NamedParameter(Constants.DependencyConstant.ConsoleLogger, LoggUtil.GetConsoleLogger())
                });

            return builder.Build();
        }
    }
}