using Autofac;
using GUSData.AsRs.Ztp.Common;
using GUSData.AsRs.Ztp.Csv;
using GUSData.AsRs.Ztp.Xml;

namespace GUSData
{
    class Program
    {
        private static IContainer _container;
        private static IXmlConverter _converter;
        private static ICsvWriter _writer;
        private static IXmlLoader _loader;

        static void Main(string[] args)
        {
            _container = DependencyConfigurer.ConfigureDependencies();
            ResolveDependencies();
            _converter.LoadData(_loader.GetXmlFileContainer());
            _writer.WriteToCsvFile(_converter.GetLoadedStreetsCollection());
        }

        private static void ResolveDependencies()
        {
            _converter = _container.Resolve<IXmlConverter>();
            _writer = _container.Resolve<ICsvWriter>();
            _loader = _container.Resolve<IXmlLoader>();
        }
    }
}