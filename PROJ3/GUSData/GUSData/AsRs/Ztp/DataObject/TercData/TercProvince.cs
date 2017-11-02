namespace GUSData.AsRs.Ztp.DataObject.TercData
{
    public class TercProvince
    {
        public int ProvinceId { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{nameof(ProvinceId)}: {ProvinceId}, {nameof(Name)}: {Name}";
        }
    }
}