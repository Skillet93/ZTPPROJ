using System.Collections.Generic;
using GUSData.AsRs.Ztp.DataObject.ConvertedData;
using GUSData.AsRs.Ztp.DataObject.SimpleData;
using GUSData.AsRs.Ztp.DataObject.TercData;

namespace GUSData.AsRs.Ztp.Collection
{
    public class CollectionElementsParser : ICollectionElementsParser
    {
        public City GetCity(int cityId)
        {
            return CollectionContainer.Citites.GetValueOrDefault(cityId);
        }


        public string GetProvinceName(int provinceId)
        {
            return CollectionContainer.TercProvinceList.Find(x => x.ProvinceId == provinceId).Name;
        }

        public string GetCountyName(CountySimpleData county)
        {
            return CollectionContainer.TercCountyList.Find(x => IsSpecifiedCounty(x, county)).Name;
        }


        public string GetDistrictName(DistrictSimpleData districtData)
        {
            return CollectionContainer.TercDistrictList.Find(x => IsSpecifiedDistrict(x, districtData)).Name;
        }

        private static bool IsSpecifiedCounty(TercCounty x, CountySimpleData county)
        {
            return x.CountyId == county.CountyId && x.ProvinceId == county.ProvinceId;
        }

        private static bool IsSpecifiedDistrict(TercElement x, DistrictSimpleData districtData)
        {
            return x.CountyId == districtData.CountyId && x.ProvinceId == districtData.ProvinceId &&
                   x.DistrictId == districtData.DistrictId;
        }
    }
}