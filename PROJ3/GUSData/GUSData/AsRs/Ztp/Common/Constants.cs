namespace GUSData.AsRs.Ztp.Common
{
    public static class Constants
    {
        public static class XmlAttributeConstant
        {
            public const string Row = "row";
            public const string Woj = "WOJ";
            public const string Pow = "POW";
            public const string Gmi = "GMI";
            public const string Nazwa = "NAZWA";
            public const string Sym = "SYM";
            public const string SymUl = "SYM_UL";
            public const string Cecha = "CECHA";
            public const string Nazwa1 = "NAZWA_1";
            public const string Nazwa2 = "NAZWA_2";
        }

        public static class SetConstant
        {
            public const string TercConversion = "converted TERC Set";
            public const string UlicConversion = "converted ULIC Set";
            public const string SimcConversion = "converted SIMC Set";
            public const string FilesLoad = "loaded ALL Files";
            public const string StreetsPrint = "printed STREETS";
            public const string TercFileNamePart = "TERC_Urzedowy_";
            public const string UlicFileNamePart = "ULIC_Urzedowy_";
            public const string SimcFileNamePart = "SIMC_Urzedowy_";
        }

        public static class FileConstant
        {
            public const string FileFormat = "{Message}{NewLine}";
            public const string FileNameFormat = "_GUSDESC_{HalfHour}.csv";
            public const string FileHeaderFormat = "WOJEWÓDZTWO;POWIAT;GMINA;MIEJSCOWOŚĆ;ULICA";
            public const int MaxFileNameIdNumberFormat = 9999;
        }

        public static class DependencyConstant
        {
            public const string WriteLogger = "writerLog";
            public const string ConsoleLogger = "consoleLog";
        }
    }
}