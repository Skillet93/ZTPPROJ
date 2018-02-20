using System.Collections.Generic;
using GUSData.AsRs.Ztp.DataObject.ConvertedData;

namespace GUSData.AsRs.Ztp.Csv
{
    public interface ICsvWriter
    {
        void WriteToCsvFile(List<Street> streets);
    }
}