namespace GUSData.AsRs.Ztp.DataObject.TercData
{
    public class TercCounty : TercProvince
    {
        public int CountyId { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(CountyId)}: {CountyId}";
        }
    }
}