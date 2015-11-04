using ICities;
using ColossalFramework;

namespace ProfitableTourismMod
{
    public class Economy : EconomyExtensionBase
    {
        public static int TourismIncomeMultiplier = 10;
        public static int[] TourismIncomeMultipliers = new int[] { 2, 3, 5, 10, 20, 30, 50, 100};
        public static string[] TourismIncomeMultipliersStr = new string[] { "x2", "x3", "x5", "x10", "x20", "x30", "x50", "x100"};
        
        public override int OnAddResource(EconomyResource resource, int amount, Service service, SubService subService, Level level)
        {
            if (resource == EconomyResource.TourismIncome)
            {
                return amount * TourismIncomeMultiplier;
            }

            return amount;
        }
    }
}
