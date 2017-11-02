using System.Collections.Generic;
using GUSData.AsRs.Ztp.DataObject.ConvertedData;
using GUSData.AsRs.Ztp.DataObject.TercData;

namespace GUSData.AsRs.Ztp.Collection
{
    public static class CollectionContainer
    {
        public static List<TercElement> TercAllElementList { get; set; }

        public static List<TercProvince> TercProvinceList { get; set; }
        public static List<TercCounty> TercCountyList { get; set; }
        public static List<TercElement> TercDistrictList { get; set; }

        public static Dictionary<int, City> Citites { get; set; }
        public static List<Street> Streets { get; set; }
    }
}