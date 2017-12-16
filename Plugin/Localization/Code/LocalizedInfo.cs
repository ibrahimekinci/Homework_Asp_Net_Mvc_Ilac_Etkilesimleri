using System.Collections.Generic;
using System.Linq;
using ilac_etkilesimleri.Plugin.Localization.Models;

namespace ilac_etkilesimleri.Plugin.Localization.Code
{
    public static class LocalizedInfo
    {
        public const string DefaultFileLanguageBinaryCode = "TR";
        private static string _defaultLanguageBinaryCode;
        public static string DefaultLanguageBinaryCode
        {
            get
            {
                if (!string.IsNullOrEmpty(_defaultLanguageBinaryCode)) return _defaultLanguageBinaryCode;
                if (_start)
                    return DefaultFileLanguageBinaryCode;
                Start();
                return DefaultLanguageBinaryCode;
            }
            set => _defaultLanguageBinaryCode = SearchByBinaryCode(value) ? value : null;
        }
        public static List<LangInfo> LangInfoList { get; } = new List<LangInfo>();
        private static bool _start;
        public static bool Start()
        {
            if (_start)
                return true;
            else
            {
                _start = true;
                return Refresh();
            }
        }
        public static bool Refresh()
        {
            if (!LangInfoListRefresh()) return false;

            return !LangInfoList.Any();
        }
        public static bool LangInfoListRefresh()
        {
            LangInfoList.Clear();
            LangInfoList.Add(new LangInfo { LanguageCulture = "TR", BinaryCode = "TR", TripleCode = "TUR", CountryName = "TURKEY" });
            LangInfoList.Add(new LangInfo { LanguageCulture = "EN", BinaryCode = "US", TripleCode = "USA", CountryName = "United States" });
            LangInfoList.Add(new LangInfo { LanguageCulture = "EN", BinaryCode = "US", TripleCode = "USA", CountryName = "United States" });
            LangInfoList.Add(new LangInfo { LanguageCulture = "IT", BinaryCode = "IT", TripleCode = "ITA", CountryName = "ITALY" });
            return true;
        }
        public static bool SearchByBinaryCode(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;
            if (!_start)
                Start();
            value = value.Trim().ToUpper();
            return LangInfoList.Count != 0 && LangInfoList.Any(item => item.LanguageCulture.ToUpper().Contains(value));
        }
        public static bool SearchByTripleCode(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;
            if (!_start)
                Start();
            value = value.Trim().ToUpper();
            return LangInfoList.Count != 0 && LangInfoList.Any(item => item.TripleCode.ToUpper().Contains(value));
        }
        public static bool SearchByCountryName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;
            if (!_start)
                Start();
            value = value.Trim().ToUpper();
            return LangInfoList.Count != 0 && LangInfoList.Any(item => item.CountryName.ToUpper().Contains(value));
        }
        public static string[] BinaryCodeList()
        {
            var itemsCount = LangInfoList.Count;
            var list = new string[itemsCount];
            for (var i = 0; i < itemsCount; i++)
                list[i] = LangInfoList[i].BinaryCode;
            return list;
        }
        public static string[] TripleCodeList()
        {
            var itemsCount = LangInfoList.Count;
            var list = new string[itemsCount];
            for (var i = 0; i < itemsCount; i++)
                list[i] = LangInfoList[i].TripleCode;
            return list;
        }
        public static string[] CountryNameList()
        {
            var itemsCount = LangInfoList.Count;
            var list = new string[itemsCount];
            for (var i = 0; i < itemsCount; i++)
                list[i] = LangInfoList[i].CountryName;
            return list;
        }
    }
}