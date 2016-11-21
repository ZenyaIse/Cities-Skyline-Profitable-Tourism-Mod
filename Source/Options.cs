using System;
using System.IO;
using System.Xml.Serialization;
using ColossalFramework.Plugins;

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

        public static int[] TourismIncomeMultipliers = new int[] { 2, 3, 4, 5, 7, 10, 15, 20 };
        public static string[] TourismIncomeMultipliersStr = new string[] { "x2", "x3", "x4", "x5", "x7", "x10", "x15", "x20" };
        public int TourismIncomeMultiplier;

        public static int[] TaxiIncomeMultipliers = new int[] { 1, 2, 3, 5, 10 };
        public static string[] TaxiIncomeMultipliersStr = new string[] { "no change", "x2", "x3", "x5", "x10" };
        public int TaxiIncomeMultiplier;

        public PTM_Options()
        {
            TourismIncomeMultiplier = 5;
            TaxiIncomeMultiplier = 2;
        }

        public int GetTourismIncomeMultiplierIndex()
        {
            int index = Array.IndexOf(TourismIncomeMultipliers, TourismIncomeMultiplier);

            if (index == -1) return Array.IndexOf(TourismIncomeMultipliers, 5);

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
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(PTM_Options));
                TextWriter writer = new StreamWriter(optionsFileName);
                ser.Serialize(writer, this);
                writer.Close();
            }
            catch (Exception ex)
            {
                DebugOutputPanel.AddMessage(PluginManager.MessageType.Message, "ProfitableTourismMod: " + ex.Message);
            }
        }

        public static PTM_Options CreateFromFile()
        {
            if (!File.Exists(optionsFileName)) return new PTM_Options();

            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(PTM_Options));
                TextReader reader = new StreamReader(optionsFileName);
                PTM_Options instance = (PTM_Options)ser.Deserialize(reader);
                reader.Close();

                return instance;
            }
            catch (Exception ex)
            {
                DebugOutputPanel.AddMessage(PluginManager.MessageType.Message, "ProfitableTourismMod: " + ex.Message);

                return new PTM_Options();
            }
        }
    }
}