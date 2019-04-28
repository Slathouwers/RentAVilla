using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SndrLth.RentAVilla.Domain.Klanten;
using SndrLth.RentAVilla.Domain.Prijzen.Promoties;

namespace SndrLth.RentAVilla.DomainTests
{
    [TestClass]
    public class StaffelTrancheFixtures
    {
        [TestMethod]
        public void MaakStaffelTranche()
        {
            int minimumAantalNachten = 7;
            PercentuelePromotie trancheKorting = new PercentuelePromotie(-0.5 / 7);
            StaffelTranche testTranche = new StaffelTranche(minimumAantalNachten, trancheKorting);
            Assert.IsTrue(testTranche.MinimumAantalNachten == 7);
            Assert.IsTrue(Math.Abs(testTranche.TrancheKorting.Percent + 0.5 / 7) < 0.0001);
        }
    }
}
