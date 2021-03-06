﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SndrLth.RentAVilla.Domain.Klanten;
using SndrLth.RentAVilla.Domain.Prijzen.Promoties;
using SndrLth.RentAVilla.Domain.Reservaties;

namespace SndrLth.RentAVilla.DomainTests
{
    [TestClass]
    public class StaffelkortingFixtures
    {
        [TestMethod]
        public void MaakStaffelkorting()
        {
            string naam = "Grote Omzet";
            Staffelkorting staffelTest = new Staffelkorting(naam);
            Assert.IsTrue(staffelTest.Naam.Equals(naam));
        }

        [TestMethod]
        public void VoegStaffelTranchesToe()
        {
            int minimumAantalNachten = 7;
            Periode geldigheidsPeriode = new Periode("22/04/2019", "31/12/2999");
            PercentuelePromotie trancheKorting = new PercentuelePromotie(geldigheidsPeriode, -0.5 / 7);
            StaffelTranche testTranche0 = new StaffelTranche(minimumAantalNachten, trancheKorting);
            minimumAantalNachten = 1;
            trancheKorting = new PercentuelePromotie(geldigheidsPeriode, 0);
            StaffelTranche testTranche1 = new StaffelTranche(minimumAantalNachten, trancheKorting);
            minimumAantalNachten = 14;
            trancheKorting = new PercentuelePromotie(geldigheidsPeriode, -1 + 11.9 / 14);
            StaffelTranche testTranche2 = new StaffelTranche(minimumAantalNachten, trancheKorting);
            minimumAantalNachten = 28;
            trancheKorting = new PercentuelePromotie(geldigheidsPeriode, -1 + 22.4 / 28);
            StaffelTranche testTranche3 = new StaffelTranche(minimumAantalNachten, trancheKorting);

            string naam = "Grote Omzet";
            Staffelkorting staffelTest = new Staffelkorting(naam);
            staffelTest.StaffelTrancheLijst.Add(testTranche0);
            staffelTest.StaffelTrancheLijst.Add(testTranche1);
            staffelTest.StaffelTrancheLijst.Add(testTranche2);
            staffelTest.StaffelTrancheLijst.Add(testTranche3);
            Assert.IsTrue(staffelTest.StaffelTrancheLijst.Count == 4);
            Assert.IsTrue(0.00001 >
                          5.6 / 28 +
                          staffelTest.StaffelTrancheLijst
                              .Find(tr => tr.MinimumAantalNachten == 28)
                              .TrancheKorting.Percent);

        }
    }
}
