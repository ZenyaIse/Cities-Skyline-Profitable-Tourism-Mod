using System;
using System.IO;
using System.Xml.Serialization;

namespace ProfitableTourismMod
{
    public class PTM_Options
    {
        private const string optionsFileName = "ProfitableTourismModOptions.xml";
        private static PTM_Options _instance;

        public static PTM_Options Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = CreateFromFile();
                }

                return _instance;
            }
        }

        public static int[] TourismIncomeMultipliers = new int[] { 2, 3, 5, 10, 20, 30, 50, 100, 200 };
        public static string[] TourismIncomeMultipliersStr = new string[] { "x2", "x3", "x5", "x10", "x20", "x30", "x50", "x100", "x200" };
        public int TourismIncomeMultiplier;

        public static int[] TaxiIncomeMultipliers = new int[] { 1, 2, 3, 5, 10 };
        public static string[] TaxiIncomeMultipliersStr = new string[] { "no change", "x2", "x3", "x5", "x10" };
        public int TaxiIncomeMultiplier;

        public PTM_Options()
        {
            TourismIncomeMultiplier = 20;
            TaxiIncomeMultiplier = 2;
        }

        public int GetTourismIncomeMultiplierIndex()
        {
            int index = Array.IndexOf(TourismIncomeMultipliers, TourismIncomeMultiplier);

            if (index == -1) return Array.IndexOf(TourismIncomeMultipliers, 20);

            return index;
        }

        public int GetTaxiIncomeMultiplierIndex()
        {
            int index = Array.IndexOf(TaxiIncomeMultipliers, TaxiIncomeMultiplier);

            if (index == -1) return Array.IndexOf(TaxiIncomeMultipliers, 2);

            return index;
        }

        public void Save()
        {
            XmlSerializer ser = new XmlSerializer(typeof(PTM_Options));
            TextWriter writer = new StreamWriter(optionsFileName);
            ser.Serialize(writer, this);
            writer.Close();
        }

        public static PTM_Options CreateFromFile()
        {
            if (!File.Exists(optionsFileName)) return new PTM_Options();

            XmlSerializer ser = new XmlSerializer(typeof(PTM_Options));
            TextReader reader = new StreamReader(optionsFileName);
            PTM_Options instance = (PTM_Options)ser.Deserialize(reader);
            reader.Close();

            return instance;
        }
    }
}