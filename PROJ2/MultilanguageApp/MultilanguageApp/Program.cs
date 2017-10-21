using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Core;
using FinderLib;
using FinderLib.AsRs.Ztp.Initializer;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace MultilanguageApp
{
    internal class Program
    {
/*        private ILanguageFinder _finder;

        public Program(ILanguageFinder finder)
        {
            _finder = finder;
        }*/

/*        public Program()
        {
            FinderChainInitializer.Initialize();
            var builder = new ContainerBuilder();
            
            builder.Register(c => 
                new Program(c.Resolve<SpecifiedLanguageSelector>())).As<ILanguageFinder>();
            
        }*/

        public static void Main(string[] args)
        {
            
            var collection = DatabaseInitialaizer.GetCollection<Car>(Constants.Db.CollectionNameCar);
            var result = collection.AsQueryable().First(o => o.Brand.Equals("BMW"));
            try
            {
                var find = FinderChainInitializer.Initialize().Find(result.Descriptions, "ss");
                Console.WriteLine(find);
            }
            catch (Exception e)
            {
                Console.WriteLine("Przechwycony");
            }

        }
    }
}