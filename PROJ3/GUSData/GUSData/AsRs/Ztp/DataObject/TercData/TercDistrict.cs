namespace GUSData.AsRs.Ztp.DataObject.TercData
{
    public class TercDistrict : TercCounty
    {
        public int DistrictId { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(DistrictId)}: {DistrictId}";
        }
    }
}