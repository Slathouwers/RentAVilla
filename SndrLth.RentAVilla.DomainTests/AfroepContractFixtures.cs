using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SndrLth.RentAVilla.Domain;
using SndrLth.RentAVilla.Domain.Enums;
using SndrLth.RentAVilla.Domain.Klanten;
using SndrLth.RentAVilla.Domain.Prijzen;
using SndrLth.RentAVilla.Domain.Prijzen.Promoties;
using SndrLth.RentAVilla.Domain.Reservaties;

namespace SndrLth.RentAVilla.DomainTests
{
    [TestClass]
    public class AfroepContractFixtures
    {
        [TestMethod]
        public void AfroepContractHeeftKlantPeriodeEnHuurobject()
        {
            Klant klant = new Klant(new KlantCategorie(KlantCategorieNaam.Reisbroker), "TravelSL");
            Periode periode = new Periode("01/04/2019", "31/12/2019");
            int overnachtingsQuota = 30;
            VastePrijsPromotie ContractBonus = new VastePrijsPromotie(-10000.00);
            // Korting korting = new Korting(PrijsEenheid toepassingsEenheid, double waarde);
            AfroepContract testContract = new AfroepContract(klant, periode, overnachtingsQuota,ContractBonus);
            Assert.IsTrue(testContract.GetType() == typeof(AfroepContract));
        }   
    }
}
