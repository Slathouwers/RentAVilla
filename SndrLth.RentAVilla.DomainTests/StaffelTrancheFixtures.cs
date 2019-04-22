using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SndrLth.RentAVilla.Domain;
using SndrLth.RentAVilla.Domain.Enums;

namespace SndrLth.RentAVilla.DomainTests.TODO
{
    [TestClass]
    public class StaffelTrancheFixtures
    {
        [TestMethod]
        public void MaakStaffelTranche()
        {
            int minimumAantalNachten = 7;
            Periode geldigheidsPeriode = new Periode("22/04/2019", "31/12/2999");
            PercentuelePromotie trancheKorting = new PercentuelePromotie(geldigheidsPeriode, PrijsEenheid.PerNacht, 0.5 / 7);
            StaffelTranche testTranche = new StaffelTranche(minimumAantalNachten, trancheKorting);
            Assert.IsTrue(testTranche.MinimumAantalNachten == 7);
            Assert.IsTrue(Math.Abs(testTranche.TrancheKorting.Percent - (0.5 / 7)) < 0.0001);
        }
    }
}
