using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using GUSData.AsRs.Ztp.Common;
using Serilog.Core;
using Constants = GUSData.AsRs.Ztp.Common.Constants;

namespace GUSData.AsRs.Ztp.Xml
{
    public class XmlLoader : IXmlLoader
    {
        private readonly Logger _consoleLog;
        private readonly XmlFileContainer _xmlFileContainer;

        public XmlLoader()
        {
        }

        public XmlLoader(XmlFileContainer xmlFileContainer, Logger consoleLog)
        {
            _xmlFileContainer = xmlFileContainer;
            _consoleLog = consoleLog;
        }

        public XmlFileContainer GetXmlFileContainer()
        {
            var watch = Stopwatch.StartNew();
            _xmlFileContainer.TercSet = FilesInDir(Constants.SetConstant.TercFileNamePart);
            _xmlFileContainer.SimcSet = FilesInDir(Constants.SetConstant.SimcFileNamePart);
            _xmlFileContainer.UlicSet = FilesInDir(Constants.SetConstant.UlicFileNamePart);
            LoggUtil.LoggingTime(watch, _consoleLog, Constants.SetConstant.FilesLoad);
            return _xmlFileContainer;
        }

        private static XElement FilesInDir(string setName)
        {
            var gusDataInfo = new DirectoryInfo(@"Data\");
            var filesInDir = gusDataInfo.GetFiles(setName + "*.xml");
            var xmlDoc = XElement.Load(filesInDir.SingleOrDefault()?.FullName ?? throw new FileNotFoundException());
            return xmlDoc;
        }
    }
}