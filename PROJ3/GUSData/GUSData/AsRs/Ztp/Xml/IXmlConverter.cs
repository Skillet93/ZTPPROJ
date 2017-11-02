using System.Collections.Generic;
using GUSData.AsRs.Ztp.DataObject.ConvertedData;

namespace GUSData.AsRs.Ztp.Xml
{
    public interface IXmlConverter
    {
        void LoadData(XmlFileContainer fileContainer);
        List<Street> GetLoadedStreetsCollection();
    }
}