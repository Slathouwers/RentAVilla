﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SndrLth.RentAVilla.Domain;
using SndrLth.RentAVilla.Domain.Enums;
using SndrLth.RentAVilla.Domain.Klanten;
using SndrLth.RentAVilla.Domain.Panden;
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
        public void CanCreateKlantCategorieen()
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
                var pand = TestData.GetTestPand();
                RentAVillaRentingService.HuurPanden.Add(pand);
            }
        }
        private void CreateRentingService()
        {
            RentAVillaRentingService = new RentAVillaRentingService();
        }
    }
}
