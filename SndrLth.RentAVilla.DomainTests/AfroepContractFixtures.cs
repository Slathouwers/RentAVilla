using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SndrLth.RentAVilla.Domain;

namespace SndrLth.RentAVilla.DomainTests
{
    [TestClass]
    public class AfroepContractFixtures
    {
        [TestMethod]
        public void AfroepContractHeeftKlantPeriodeEnHuurobject()
        {
            Klant klant = new Klant(KlantCategorie.Reisbroker, "TravelSL");
            Periode periode = new Periode("01/04/2019", "31/12/2019");
            int overnachtingsQuota = 30;
            // Korting korting = new Korting(PrijsEenheid toepassingsEenheid, double waarde);
            AfroepContract testContract = new AfroepContract(klant, periode, overnachtingsQuota);
            Assert.IsTrue(testContract.GetType() == typeof(AfroepContract));
        }   
    }
}
