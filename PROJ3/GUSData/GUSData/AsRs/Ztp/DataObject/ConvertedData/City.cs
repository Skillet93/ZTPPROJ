namespace GUSData.AsRs.Ztp.DataObject.ConvertedData
{
    public class City
    {
        public int CitytId { get; set; }
        public string ProvinceName { get; set; }
        public string CountyName { get; set; }
        public string DistrictName { get; set; }
        public string CitytName { get; set; }

        public override string ToString()
        {
            return
                $"{nameof(CitytId)}: {CitytId}, {nameof(ProvinceName)}: {ProvinceName}, {nameof(CountyName)}: {CountyName}, {nameof(DistrictName)}: {DistrictName}, {nameof(CitytName)}: {CitytName}";
        }
    }
}