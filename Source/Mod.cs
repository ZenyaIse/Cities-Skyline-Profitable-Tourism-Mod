using ICities;

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
        
        public void OnSettingsUI(UIHelperBase helper)
        {
            helper.AddDropdown(
                "Tourism income",
                PTM_Options.TourismIncomeMultipliersStr,
                PTM_Options.Instance.GetTourismIncomeMultiplierIndex(),
                TourismIncomeMultiplierOnSelected
                );

            helper.AddDropdown(
                "Taxi income",
                PTM_Options.TaxiIncomeMultipliersStr,
                PTM_Options.Instance.GetTaxiIncomeMultiplierIndex(),
                TaxiIncomeMultiplierOnSelected
                );
        }

        private void TourismIncomeMultiplierOnSelected(int sel)
        {
            PTM_Options.Instance.TourismIncomeMultiplier = PTM_Options.TourismIncomeMultipliers[sel];
            PTM_Options.Instance.Save();
        }

        private void TaxiIncomeMultiplierOnSelected(int sel)
        {
            PTM_Options.Instance.TaxiIncomeMultiplier = PTM_Options.TaxiIncomeMultipliers[sel];
            PTM_Options.Instance.Save();
        }

        #endregion
    }
}
