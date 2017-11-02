using System.Collections.Generic;
using GUSData.AsRs.Ztp.DataObject.TercData;

namespace GUSData.AsRs.Ztp.Collection
{
    public class CollectionSeparator : ICollectionSeparator
    {
        public void CategorizeTercCollection()
        {
            CollectionContainer.TercProvinceList =
                new List<TercProvince>(
                    CollectionContainer.TercAllElementList.FindAll(x => x.DistrictId == -1 && x.CountyId == -1));
            CollectionContainer.TercCountyList =
                new List<TercCounty>(
                    CollectionContainer.TercAllElementList.FindAll(x => x.DistrictId == -1 && x.CountyId != -1));
            CollectionContainer.TercDistrictList =
                new List<TercElement>(
                    CollectionContainer.TercAllElementList.FindAll(x => x.DistrictId != -1 && x.CountyId != -1));
        }
    }
}