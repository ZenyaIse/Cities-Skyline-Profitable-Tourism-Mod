using System.Reflection;
using ICities;
using ColossalFramework;

namespace ProfitableTourismMod
{
    public class Economy : EconomyExtensionBase
    {
        public override int OnAddResource(EconomyResource resource, int amount, Service service, SubService subService, Level level)
        {
            if (resource == EconomyResource.TourismIncome)
            {
                // Changing the "amount" value does change the tourism income value displayed in the Economy panel,
                // but does NOT add actual money to the player. Therefore
                // the increased cash amount should be added manually, taking into account m_taxMultiplier value.

                EconomyManager em = Singleton<EconomyManager>.instance;

                // Get taxMultiplier value
                FieldInfo field = em.GetType().GetField("m_taxMultiplier", BindingFlags.NonPublic | BindingFlags.Instance);
                int m_taxMultiplier = (int)field.GetValue(em);

                int newAmount = amount * PTM_Options.Instance.TourismIncomeMultiplier;

                em.AddPrivateIncome(
                    (int)((newAmount - amount) * 10000L / m_taxMultiplier), // Ectract "amount", because it is already added, and exclude the influence of m_taxMultiplier
                    (ItemClass.Service)service,
                    (ItemClass.SubService)subService,
                    (ItemClass.Level)level,
                    100 // Set 100% tax rate because we want to add actual money as it is.
                    );

                return newAmount;
            }

            // Bonus feature :)
            if ((ItemClass.SubService)subService == ItemClass.SubService.PublicTransportTaxi)
            {
                return amount * PTM_Options.Instance.TaxiIncomeMultiplier;
            }

            return amount;
        }
    }
}
