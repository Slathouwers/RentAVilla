using Microsoft.VisualStudio.TestTools.UnitTesting;
using SndrLth.RentAVilla.Domain;
using SndrLth.RentAVilla.Domain.Enums;
using SndrLth.RentAVilla.Domain.PrijsKlassen;

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
        public void SetToepasbareKlantCategoriën()
        {
            string naam = "Grote Omzet";
            Staffelkorting staffelTest = new Staffelkorting(naam);
            staffelTest.KlantCategorieLijst.Add(KlantCategorie.Reisagentschap);
            staffelTest.KlantCategorieLijst.Add(KlantCategorie.Reisbroker);
            Assert.IsTrue(staffelTest.KlantCategorieLijst.Contains(KlantCategorie.Reisbroker));
            Assert.IsTrue(staffelTest.KlantCategorieLijst.Contains(KlantCategorie.Reisagentschap));
        }
        [TestMethod]
        public void VoegStaffelTranchesToe()
        {
            int minimumAantalNachten = 7;
            Periode geldigheidsPeriode = new Periode("22/04/2019", "31/12/2999");
            PercentuelePromotie trancheKorting = new PercentuelePromotie(geldigheidsPeriode, PrijsEenheid.PerNacht, 0.5 / 7);
            StaffelTranche testTranche1 = new StaffelTranche(minimumAantalNachten, trancheKorting);
            minimumAantalNachten = 1;
            trancheKorting = new PercentuelePromotie(geldigheidsPeriode, PrijsEenheid.PerNacht,0);
            StaffelTranche testTranche0 = new StaffelTranche(minimumAantalNachten, trancheKorting);
            minimumAantalNachten = 14;
            trancheKorting = new PercentuelePromotie(geldigheidsPeriode, PrijsEenheid.PerNacht, 1-(11.9/14));
            StaffelTranche testTranche2 = new StaffelTranche(minimumAantalNachten, trancheKorting);
            minimumAantalNachten = 28;
            trancheKorting = new PercentuelePromotie(geldigheidsPeriode, PrijsEenheid.PerNacht, 1 - (22.4 / 28));
            StaffelTranche testTranche3 = new StaffelTranche(minimumAantalNachten, trancheKorting);

            string naam = "Grote Omzet";
            Staffelkorting staffelTest = new Staffelkorting(naam);
            staffelTest.StaffelTrancheLijst.Add(testTranche0);
            staffelTest.StaffelTrancheLijst.Add(testTranche1);
            staffelTest.StaffelTrancheLijst.Add(testTranche2);
            staffelTest.StaffelTrancheLijst.Add(testTranche3);
            Assert.IsTrue(staffelTest.StaffelTrancheLijst.Count == 4);
            Assert.IsTrue(0.00001 > (5.6/28 - staffelTest.StaffelTrancheLijst
                .Find(tr => tr.MinimumAantalNachten == 28)
                .TrancheKorting.Percent));

        }
    }
}
