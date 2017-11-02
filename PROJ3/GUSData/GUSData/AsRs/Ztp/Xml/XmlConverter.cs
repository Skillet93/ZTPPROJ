using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using GUSData.AsRs.Ztp.Collection;
using GUSData.AsRs.Ztp.Common;
using GUSData.AsRs.Ztp.DataObject.ConvertedData;
using GUSData.AsRs.Ztp.DataObject.TercData;
using Serilog.Core;
using Constants = GUSData.AsRs.Ztp.Common.Constants;

namespace GUSData.AsRs.Ztp.Xml
{
    public class XmlConverter : IXmlConverter
    {
        private ICollectionElementsParser _collectionElementsParser;
        private ICollectionSeparator _collectionSeparator;
        private Logger _consoleLog;
        private XmlFileContainer XmlFileContainer { get; set; }


        public XmlConverter(ICollectionSeparator collectionSeparator, Logger consoleLog,
            ICollectionElementsParser collectionElementsParser)
        {
            _collectionSeparator = collectionSeparator;
            _consoleLog = consoleLog;
            _collectionElementsParser = collectionElementsParser;
        }

        public void LoadData(XmlFileContainer fileContainer)
        {
            XmlFileContainer = fileContainer;
            LoadTercElements();
            _collectionSeparator.CategorizeTercCollection();
            LoadCities();
            LoadStreets();
        }

        public List<Street> GetLoadedStreetsCollection()
        {
            if (CollectionContainer.Streets != null &&
                CollectionContainer.Streets.Any())
            {
                return CollectionContainer.Streets;
            }
            throw new NullReferenceException("Streets collection is null or empty");
        }

        private void LoadTercElements()
        {
            var watch = Stopwatch.StartNew();

            var tercElements =
                from tercElement in XmlFileContainer.TercSet.Descendants(Constants.XmlAttributeConstant.Row)
                select new TercElement
                {
                    ProvinceId = XmlParserUtil.GetProperValue(tercElement, Constants.XmlAttributeConstant.Woj),
                    CountyId = XmlParserUtil.GetProperValue(tercElement, Constants.XmlAttributeConstant.Pow),
                    DistrictId = XmlParserUtil.GetProperValue(tercElement, Constants.XmlAttributeConstant.Gmi),
                    Name = tercElement.Element(Constants.XmlAttributeConstant.Nazwa)?.Value,
                };
            CollectionContainer.TercAllElementList = tercElements.ToList();
            LoggUtil.LoggingTime(watch, _consoleLog, Constants.SetConstant.TercConversion);
        }

        private void LoadCities()
        {
            var watch = Stopwatch.StartNew();

            var citiesCollection =
                from simcElement in XmlFileContainer.SimcSet.Descendants(Constants.XmlAttributeConstant.Row)
                select new City
                {
                    CitytId = XmlParserUtil.GetProperValue(simcElement, Constants.XmlAttributeConstant.Sym),
                    ProvinceName =
                        _collectionElementsParser.GetProvinceName(
                            XmlParserUtil.GetProperValue(simcElement, Constants.XmlAttributeConstant.Woj)),
                    CountyName = _collectionElementsParser.GetContyName(XmlParserUtil.GetCountyData(simcElement)),
                    DistrictName =
                        _collectionElementsParser.GetDistrictName(XmlParserUtil.GetDistrictData(simcElement)),
                    CitytName = simcElement.Element(Constants.XmlAttributeConstant.Nazwa)?.Value,
                };

            CollectionContainer.Citites = citiesCollection.ToDictionary(x => x.CitytId, x => x);
            LoggUtil.LoggingTime(watch, _consoleLog, Constants.SetConstant.SimcConversion);
        }

        private void LoadStreets()
        {
            var watch = Stopwatch.StartNew();

            var streetCollection =
                from ulicElement in XmlFileContainer.UlicSet.Descendants(Constants.XmlAttributeConstant.Row)
                select new Street
                {
                    StreetId = XmlParserUtil.GetProperValue(ulicElement, Constants.XmlAttributeConstant.SymUl),
                    City = _collectionElementsParser.GetCity(
                        XmlParserUtil.GetProperValue(ulicElement, Constants.XmlAttributeConstant.Sym)),
                    StreetName = XmlParserUtil.GetFullStreetName(ulicElement),
                };
            CollectionContainer.Streets = streetCollection.ToList();
            LoggUtil.LoggingTime(watch, _consoleLog, Constants.SetConstant.UlicConversion);
        }
    }
}