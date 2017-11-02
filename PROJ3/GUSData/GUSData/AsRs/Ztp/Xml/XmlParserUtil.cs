using System.Xml.Linq;
using GUSData.AsRs.Ztp.Common;
using GUSData.AsRs.Ztp.DataObject.SimpleData;

namespace GUSData.AsRs.Ztp.Xml
{
    public static class XmlParserUtil
    {
        public static int GetProperValue(XContainer element, string attribute)
        {
            var convertedNum = -1;
            if (!string.IsNullOrEmpty(element.Element(attribute)?.Value))
            {
                convertedNum = int.Parse(element.Element(attribute)?.Value);
            }
            return convertedNum;
        }

        private static string GetProperString(XContainer element, string attribute)
        {
            var name = "";
            if (!string.IsNullOrEmpty(element.Element(attribute)?.Value))
            {
                name = element.Element(attribute)?.Value;
            }
            return name;
        }

        public static CountySimpleData GetCountyData(XContainer element)
        {
            var countyCode = GetProperValue(element, Constants.XmlAttributeConstant.Pow);
            var provinceCode = GetProperValue(element, Constants.XmlAttributeConstant.Woj);
            return new CountySimpleData
            {
                ProvinceId = provinceCode,
                CountyId = countyCode
            };
        }

        public static DistrictSimpleData GetDistrictData(XContainer element)
        {
            var countyCode = GetProperValue(element, Constants.XmlAttributeConstant.Pow);
            var provinceCode = GetProperValue(element, Constants.XmlAttributeConstant.Woj);
            var districtCode = GetProperValue(element, Constants.XmlAttributeConstant.Gmi);
            return new DistrictSimpleData
            {
                ProvinceId = provinceCode,
                CountyId = countyCode,
                DistrictId = districtCode
            };
        }

        public static string GetFullStreetName(XContainer element)
        {
            var streetPart1Name = GetProperString(element, Constants.XmlAttributeConstant.Cecha);
            var streetPart2Name = GetProperString(element, Constants.XmlAttributeConstant.Nazwa1);
            var streetPart3Name = GetProperString(element, Constants.XmlAttributeConstant.Nazwa2);
            var streetNameSeparator = " ";
            streetNameSeparator = string.IsNullOrEmpty(streetPart3Name) ? "" : streetNameSeparator;
            return $"{streetPart1Name} {streetPart3Name}{streetNameSeparator}{streetPart2Name}";
        }
    }
}