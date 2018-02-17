using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using MailReader.Data;
using MailReader.Reader.Constant;
using MailReader.Reader.Interface;

namespace MailReader.Reader.Loader
{
    public class MailReader : IMailReader
    {
        private static int _currentIndex = 0;
        
        public List<MailData> Read()
        { 
            List<MailData> users;
            using (var streamReader = File.OpenText(CsvReaderConst.File.Path))
            {
                var reader = new CsvReader(streamReader);
                reader.Configuration.Delimiter = CsvReaderConst.File.Delimiter;
                users = reader.GetRecords<MailData>().Skip(_currentIndex).Take(CsvReaderConst.File.Count).ToList();
                _currentIndex += CsvReaderConst.File.Count;
            }
            return users;
        }
    }
}