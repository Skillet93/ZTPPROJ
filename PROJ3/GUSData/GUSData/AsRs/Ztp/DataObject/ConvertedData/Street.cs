namespace GUSData.AsRs.Ztp.DataObject.ConvertedData
{
    public class Street
    {
        public int StreetId { get; set; }
        public City City { get; set; }
        public string StreetName { get; set; }

        public override string ToString()
        {
            return $"{nameof(StreetId)}: {StreetId}, {nameof(City)}: {City}, {nameof(StreetName)}: {StreetName}";
        }

        public string GetRowDescription()
        {
            return $"{City.ProvinceName};{City.CountyName};{City.DistrictName};{City.CitytName};{StreetName}";
        }
    }
}