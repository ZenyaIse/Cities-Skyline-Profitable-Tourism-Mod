using System.IO;
using ICities;
using ColossalFramework;
using ColossalFramework.UI;
using ColossalFramework.Globalization;
using UnityEngine;
using ColossalFramework.Plugins;

namespace ProfitableTourismMod
{
    public class Mod : IUserMod
    {
        public string Name
        {
            get { return "Profitable Tourism Mod"; }
        }

        public string Description
        {
            get { return "Helps you earn more from tourism."; }
        }


        #region Options UI
        
        public static string OptionFileName = "ProfitableTourism.txt";

        public void OnSettingsUI(UIHelperBase helper)
        {
            int index = 3;
            
            try
            {
                if (File.Exists(OptionFileName))
                {
                    string strValue = File.ReadAllText(OptionFileName);
                    int intValue = Int32.Parse(strValue);
                    index = Array.IndexOf(TourismIncomeMultipliers, intValue);
                }
            }
            catch (Exception ex)
            {
                DebugOutputPanel.AddMessage(PluginManager.MessageType.Message, "ProfitableTourismMod: " + ex.Message);
            }

            helper.AddDropdown(
                "Tourism income multiplier",
                Economy.TourismIncomeMultipliersStr,
                index,
                TourismIncomeMultiplierOnSelected
                );
        }

        private void TourismIncomeMultiplierOnSelected(int sel)
        {
            Economy.TourismIncomeMultiplier = Economy.TourismIncomeMultipliers[sel];
            
            File.WriteAllText(OptionFileName, Economy.TourismIncomeMultiplier.ToString());
        }

        #endregion
    }
}
