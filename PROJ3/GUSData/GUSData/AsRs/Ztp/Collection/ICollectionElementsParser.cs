using GUSData.AsRs.Ztp.DataObject.ConvertedData;
using GUSData.AsRs.Ztp.DataObject.SimpleData;

namespace GUSData.AsRs.Ztp.Collection
{
    public interface ICollectionElementsParser
    {
        City GetCity(int cityId);
        string GetProvinceName(int provinceId);
        string GetCountyName(CountySimpleData county);
        string GetDistrictName(DistrictSimpleData districtData);
    }
}