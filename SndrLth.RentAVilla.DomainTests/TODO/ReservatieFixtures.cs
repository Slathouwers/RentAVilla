using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SndrLth.RentAVilla.Domain;

namespace SndrLth.RentAVilla.DomainTests
{
    [TestClass]
    public class ReservatieFixtures
    {
        [TestMethod]
        public void PandReserverenVoorPeriodeOpNaamVanKlant()
        {
            Pand pand = new Pand();
            Klant klant = new Klant(KlantCategorie.Particulier, "Lathouwers");
            Periode reservatiePeriode = new Periode("21/04/2019", "25/04/2019");
            Reservatie testReservatie = new Reservatie(pand, klant, reservatiePeriode);
            Assert.IsTrue(testReservatie.GetType() == typeof(Reservatie));
        }
    }
}
