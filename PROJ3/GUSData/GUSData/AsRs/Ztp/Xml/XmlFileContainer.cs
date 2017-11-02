using System.Xml.Linq;

namespace GUSData.AsRs.Ztp.Xml
{
    public class XmlFileContainer
    {
        public XElement TercSet { get; set; }
        public XElement SimcSet { get; set; }
        public XElement UlicSet { get; set; }
    }
}