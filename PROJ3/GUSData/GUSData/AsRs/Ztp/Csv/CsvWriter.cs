using System.Collections.Generic;
using System.Diagnostics;
using GUSData.AsRs.Ztp.Common;
using GUSData.AsRs.Ztp.DataObject.ConvertedData;
using Serilog.Core;
using Constants = GUSData.AsRs.Ztp.Common.Constants;

namespace GUSData.AsRs.Ztp.Csv
{
    public class CsvWriter : ICsvWriter
    {
        private readonly Logger _operationLog;
        private readonly Logger _writerLog;

        public CsvWriter(Logger writerLog, Logger consoleLog)
        {
            _writerLog = writerLog;
            _operationLog = consoleLog;
        }

        public void WriteToCsvFile(List<Street> streets)
        {
            var watch = Stopwatch.StartNew();
            _writerLog.Information(Constants.FileConstant.FileHeaderFormat);
            streets.ForEach(x => _writerLog.Information(x.GetRowDescription()));
            LoggUtil.LoggingTime(watch, _operationLog, Constants.SetConstant.StreetsPrint);
        }
    }
}