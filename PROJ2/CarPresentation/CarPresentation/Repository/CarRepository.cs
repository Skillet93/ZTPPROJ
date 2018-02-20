using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using CarPresentation.Data;
using CarPresentation.Models;
using FinderLib.AsRs.Ztp.Finder;
using FinderLib.AsRs.Ztp.Initializer;
using MongoDB.Driver;

namespace CarPresentation.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly IMongoDatabase _database;
        private readonly ILanguageFinder _finder;

        public CarRepository()
        {
            _finder = FinderChainInitializer.Initialize();
            _database = DatabaseInitializer.Initialize();
        }

        public CarForm FindCarDetails(string model, string langCode)
        {
            var collection = _database.GetCollection<Car>(Constants.Db.CollectionNameCar);

            try
            {
                var result = collection.AsQueryable().First(o => o.Model.Equals(model));

                var specLangDesc = _finder.Find(result.Descriptions, langCode);

                var specifiedCar = new CarForm
                {
                    Brand = result.Brand,
                    Model = result.Model,
                    Seats = result.NumberOfSeats,
                    MaxSpeed = result.MaxSpeed,
                    DescriptionLang = specLangDesc.Language,
                    Description = specLangDesc.Content
                };
                return specifiedCar;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}