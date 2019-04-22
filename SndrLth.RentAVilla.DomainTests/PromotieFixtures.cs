using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SndrLth.RentAVilla.Domain;
using SndrLth.RentAVilla.Domain.Enums;

namespace SndrLth.RentAVilla.DomainTests
{
    [TestClass]
    public class PromotieFixtures
    {
        [TestMethod]
        public void VastePrijsPromotieHeeftPeriodeEnIsPrijsComponent()
        {
            Periode periode = new Periode("22/04/2019", "26/04/2019");
            double waarde = 250.00;
            PrijsEenheid toepassingsEenheid = PrijsEenheid.PerReservatie;
            VastePrijsPromotie promotie = new VastePrijsPromotie(periode, toepassingsEenheid, waarde);
            Assert.IsTrue(promotie.GetType() == typeof(VastePrijsPromotie));
            Assert.IsTrue(promotie.Waarde == 250.00 && promotie.ToepassingsEenheid == PrijsEenheid.PerReservatie);
        }
        [TestMethod]
        public void PercentuelePromotieHeeftPeriodeEnIsPrijsComponent()
        {
            Periode periode = new Periode("22/04/2019", "26/04/2019");
            double percent = 0.25;
            PrijsEenheid toepassingsEenheid = PrijsEenheid.PerReservatie;
            PercentuelePromotie promotie = new PercentuelePromotie(periode, toepassingsEenheid, percent);
            Assert.IsTrue(promotie.GetType() == typeof(PercentuelePromotie));
            Assert.IsTrue(promotie.Waarde == 0 && promotie.ToepassingsEenheid == PrijsEenheid.PerReservatie);
            PercentuelePromotie concretePercentPromotie = promotie.GetConcretePromotieOp(new HuurPrijsPerNacht(Tarief.Laagseizoen, 250.00));
            Assert.IsTrue(concretePercentPromotie.Waarde == 250.00 * 0.25);
        }
    }
}
