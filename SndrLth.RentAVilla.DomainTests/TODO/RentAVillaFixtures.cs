using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SndrLth.RentAVilla.Domain;
using SndrLth.RentAVilla.Domain.Enums;
using SndrLth.RentAVilla.Domain.Klanten;
using SndrLth.RentAVilla.Domain.Panden;
using SndrLth.RentAVilla.Domain.Prijzen.Promoties;
using SndrLth.RentAVilla.Domain.Reservaties;
using TestData = SndrLth.RentAVilla.DomainTests.TestDataGenerator;

namespace SndrLth.RentAVilla.DomainTests.TODO
{
    [TestClass]
    public class RentAVillaFixtures
    {
        private RentAVillaRentingService RentAVillaRentingService { get; set; }

        [TestMethod]
        public void CanCreateRentingServiceApplication()
        {
            CreateRentingService();
            Assert.IsNotNull(RentAVillaRentingService);
            Assert.IsTrue(RentAVillaRentingService.GetType() == typeof(RentAVillaRentingService));
        }

        [TestMethod]
        public void CanAddPandenToHuurPandenCatalogus()
        {
            CreateRentingService();
            AddTestPandenToCatalogus(4);
            Assert.IsTrue(RentAVillaRentingService.HuurPanden.Count == 4);
        }

        [TestMethod]
        public void CanCreateKlantCategorieenWithStaffelkortingen()
        {
            CreateRentingService();
            AddKlantCatergorieParticulierEnReisbureau();
            Assert.IsTrue(RentAVillaRentingService.KlantCategorieën.Count == 2);
            Assert.IsTrue(RentAVillaRentingService.KlantCategorieën.
                Exists(cat => cat.Naam == KlantCategorieNaam.Reisagentschap &&
                                    cat.Staffelkorting.Naam == "Grote Omzet"));
            Assert.IsTrue(RentAVillaRentingService.KlantCategorieën.
                Exists(cat => cat.Naam == KlantCategorieNaam.Particulier &&
                              cat.Staffelkorting.Naam == "Geen Korting"));
        }

        [TestMethod]
        public void CanCreatePromoties()
        {
            CreateRentingService();
            AddVastePrijsAndPercentuelePromotieToPromoties();
            Assert.IsTrue(RentAVillaRentingService.Promoties.Count == 2);
            Assert.IsTrue(RentAVillaRentingService.Promoties.Exists(el => el is PercentuelePromotie));
            Assert.IsTrue(RentAVillaRentingService.Promoties.Exists(el => el is VastePrijsPromotie));
        }

        [TestMethod]
        public void GivenCategorieAndStaffelkorting_CanCreateKlanten()
        {
            CreateRentingService();
            AddKlantCatergorieParticulierEnReisbureau();
            AddParticulierAndReisbureauToKlantenBestand();
            Assert.IsTrue(RentAVillaRentingService.KlantenBestand.Count == 2);
            Assert.IsTrue(RentAVillaRentingService.KlantenBestand.Exists(el => el.Naam == "Lathouwers" && el.Categorie.Staffelkorting.Naam == "Geen Korting"));
            Assert.IsTrue(RentAVillaRentingService.KlantenBestand.Exists(el => el.Naam == "Traveling Lathouwers NV" && el.Categorie.Staffelkorting.Naam == "Grote Omzet"));
        }

        [TestMethod]
        public void GivenPandenAndKlanten_CanCreateAfroepcontract()
        {
            CreateRentingService();
            AddTestPandenToCatalogus(4);
            AddKlantCatergorieParticulierEnReisbureau();
            AddParticulierAndReisbureauToKlantenBestand();
            AddAfroepContract();
            Assert.IsTrue(RentAVillaRentingService.AfroepContracten.Count == 1);
            Assert.IsTrue(RentAVillaRentingService.AfroepContracten.Exists(el =>
                el.Klant.Naam == "Traveling Lathouwers NV" && el.VastePrijsPromotie.Waarde == -2500));
        }

        [TestMethod]
        public void GivenPandenKlanten_CanCreateReservatieWithPrijsOfferteAndAddToReservatieBoek()
        {
            CreateRentingService();
            AddTestPandenToCatalogus(4);
            AddKlantCatergorieParticulierEnReisbureau();
            AddParticulierAndReisbureauToKlantenBestand();
            Periode reservatiePeriode = new Periode("10/06/2019", "19/06/2019");
            Klant particulier = RentAVillaRentingService.KlantenBestand.Find(kl => kl.Naam == "Lathouwers");
            Pand pand = RentAVillaRentingService.HuurPanden.Find(p => p.Land == ActieveLanden.Frankrijk);
            int aantalPersonen = 6;
            Reservatie testReservatie = RentAVillaRentingService.ReservatieBuilder.MaakReservatie(pand, particulier, reservatiePeriode, aantalPersonen);
            RentAVillaRentingService.ReservatieBoek.Add(testReservatie);

            Assert.IsTrue(RentAVillaRentingService.ReservatieBoek.GetAll().Count == 1);
            Assert.IsTrue(!RentAVillaRentingService.ReservatieBoek.PandIsVrijVoorPeriode(pand,reservatiePeriode));
        }
        [TestMethod]
        public void GivenPandenKlantenAndReservationMade_CannotAddReservationTwiceToReservatieBoek()
        {
            CreateRentingService();
            AddTestPandenToCatalogus(4);
            AddKlantCatergorieParticulierEnReisbureau();
            AddParticulierAndReisbureauToKlantenBestand();
            Periode reservatiePeriode = new Periode("10/06/2019", "19/06/2019");
            Klant particulier = RentAVillaRentingService.KlantenBestand.Find(kl => kl.Naam == "Lathouwers");
            Pand pand = RentAVillaRentingService.HuurPanden.Find(p => p.Land == ActieveLanden.Frankrijk);
            int aantalPersonen = 6;
            Reservatie testReservatie = RentAVillaRentingService.ReservatieBuilder.MaakReservatie(pand, particulier, reservatiePeriode, aantalPersonen);
            RentAVillaRentingService.ReservatieBoek.Add(testReservatie);
            Assert.ThrowsException<ArgumentException>(()=>RentAVillaRentingService.ReservatieBoek.Add(testReservatie));

            Assert.IsTrue(RentAVillaRentingService.ReservatieBoek.GetAll().Count == 1);
            Assert.IsTrue(!RentAVillaRentingService.ReservatieBoek.PandIsVrijVoorPeriode(pand, reservatiePeriode));
        }

        private void AddAfroepContract()
        {

            Klant klant = RentAVillaRentingService.KlantenBestand.Find(kl => kl.Naam == "Traveling Lathouwers NV");
            Pand pand = RentAVillaRentingService.HuurPanden.Find(p => p.Land == ActieveLanden.Frankrijk);
            VastePrijsPromotie vastePrijsPromotie = new VastePrijsPromotie(-2500);
            int overnachtingsQuota = 50;
            RentAVillaRentingService.AfroepContracten.Add(new AfroepContract(klant,
                pand,
                new Periode("01/04/2019",
                    ("01/09/2019")),
                overnachtingsQuota,
                vastePrijsPromotie));
        }

        private void AddVastePrijsAndPercentuelePromotieToPromoties()
        {
            VastePrijsPromotie vastePrijsPromotie = new VastePrijsPromotie(-250);
            PercentuelePromotie percentuelePromotie = new PercentuelePromotie(-0.10);
            RentAVillaRentingService.Promoties.Add(vastePrijsPromotie);
            RentAVillaRentingService.Promoties.Add(percentuelePromotie);
        }

        private void AddParticulierAndReisbureauToKlantenBestand()
        {
            Klant particulier = RentAVillaRentingService.KlantBuilder.MaakKlant("Lathouwers", KlantCategorieNaam.Particulier);
            Klant reisbureau = RentAVillaRentingService.KlantBuilder.MaakKlant("Traveling Lathouwers NV", KlantCategorieNaam.Reisagentschap);
            RentAVillaRentingService.KlantenBestand.Add(particulier);
            RentAVillaRentingService.KlantenBestand.Add(reisbureau);
        }

        private void AddKlantCatergorieParticulierEnReisbureau()
        {
            Staffelkorting groteOmzetStaffel = TestData.GetGroteOmzetStaffelkorting();
            KlantCategorie klantCategorieReisbureau = new KlantCategorie(KlantCategorieNaam.Reisagentschap, groteOmzetStaffel);
            KlantCategorie klantCategorieParticulier = new KlantCategorie(KlantCategorieNaam.Particulier);
            RentAVillaRentingService.KlantCategorieën.Add(klantCategorieParticulier);
            RentAVillaRentingService.KlantCategorieën.Add(klantCategorieReisbureau);
        }

        private void AddTestPandenToCatalogus(int aantal)
        {
            for (int i = 0; i < aantal; i++)
            {
                var pand = TestData.GetTestPand(ActieveLanden.Frankrijk);
                RentAVillaRentingService.HuurPanden.Add(pand);
            }
        }

        private void CreateRentingService()
        {
            RentAVillaRentingService = new RentAVillaRentingService();
        }
    }
}
