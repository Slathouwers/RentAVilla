using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SndrLth.RentAVilla.Domain;
using SndrLth.RentAVilla.Domain.Enums;
using SndrLth.RentAVilla.Domain.PrijsKlassen;

namespace SndrLth.RentAVilla.DomainTests
{
    [TestClass]
    public class PrijsFixtures
    {
        //Waarborg
        [TestMethod]
        public void WaarborgHeeftPerReservatiePrijsEenheid()
        {
            Waarborg waarborg = new Waarborg(500.00);
            Assert.IsTrue(waarborg.ToepassingsEenheid == PrijsEenheid.PerReservatie);
        }
        [TestMethod]
        public void DoubleWordtGecastNaarWaarborg()
        {
            Waarborg waarborg = (Waarborg)500.00;
            Assert.IsTrue(waarborg.GetType().Equals(typeof(Waarborg)));
        }
        [TestMethod]
        public void NegatieveWaarborgThrowsArgumentOutOfRangeException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => (Waarborg) (-50.00));
        }
        //SchoonmaakPrijs
        [TestMethod]
        public void SchoonmaakPrijsHeeftPerReservatiePrijsEenheid()
        {
            SchoonmaakPrijs schoonmaakPrijs = new SchoonmaakPrijs(100.00);
            Assert.IsTrue(schoonmaakPrijs.ToepassingsEenheid == PrijsEenheid.PerReservatie);
        }
        [TestMethod]
        public void DoubleWordtGecastNaarSchoonmaakPrij()
        {
            SchoonmaakPrijs schoonmaak = (SchoonmaakPrijs)500.00;
            Assert.IsTrue(schoonmaak.GetType().Equals(typeof(SchoonmaakPrijs)));
        }
        [TestMethod]
        public void NegatieveSchoonmaakPrijThrowsArgumentOutOfRangeException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => (SchoonmaakPrijs)(-50.00));

        }
        //PersoonsToeslagPerNacht
        [TestMethod]
        public void PersoonsToeslagHeeftPerPersoonEnPerNachtPrijsEenheid()
        {
            PersoonsToeslagPerNacht persoonsToeslag = new PersoonsToeslagPerNacht(50.00);
            Assert.IsTrue(persoonsToeslag.ToepassingsEenheid == PrijsEenheid.PerPersoonPerNacht);
        }
        [TestMethod]
        public void DoubleWordtGecastNaarPersoonsToeslag()
        {
            PersoonsToeslagPerNacht persoonsToeslag = (PersoonsToeslagPerNacht)500.00;
            Assert.IsTrue(persoonsToeslag.GetType().Equals(typeof(PersoonsToeslagPerNacht)));
        }
        [TestMethod]
        public void NegatievePersoonsToeslagThrowsArgumentOutOfRangeException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => (PersoonsToeslagPerNacht)(-50.00));
        }
        //HuurPrijsPerNacht met Tarief = Seizoen/Bezetting
        [TestMethod]
        public void HuurPrijsHeeftPerNachtPrijsEenheid()
        {
            HuurPrijsPerNacht huurPrijs = new HuurPrijsPerNacht(Tarief.Ongekend, 120.00);
            Assert.IsTrue(huurPrijs.ToepassingsEenheid == PrijsEenheid.PerNacht);
        }
        [TestMethod]
        public void DoubleWordtGecastNaarHuurPrijs()
        {
            HuurPrijsPerNacht huurPrijs = (HuurPrijsPerNacht)500.00;
            Assert.IsTrue(huurPrijs.GetType().Equals(typeof(HuurPrijsPerNacht)));
        }
        [TestMethod]
        public void NegatieveHuurPrijsThrowsArgumentOutOfRangeException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => (HuurPrijsPerNacht)(-50.00));

        }
        [TestMethod]
        public void MaakPrijsOfferteMetPrijsComponenten()
        {
            int aantalPersonen = 6;
            int aantalNachten = 7;
            PrijsOfferte offerte = new PrijsOfferte();
            
            HuurPrijsPerNacht huurPrijsPerNacht = new HuurPrijsPerNacht(Tarief.Hoogseizoen, 127.00);
            Waarborg waarborg = new Waarborg(500.00);
            SchoonmaakPrijs schoonmaak = new SchoonmaakPrijs(100.00);
            PersoonsToeslagPerNacht persoonsToeslagPerNacht = new PersoonsToeslagPerNacht(25);
            Periode promotiePeriode = new Periode("21/04/2019", "31/12/2019");
            VastePrijsPromotie vastePrijsPromotie = new VastePrijsPromotie(promotiePeriode,-250.00);
            PercentuelePromotie reservatieKorting = new PercentuelePromotie(promotiePeriode, -0.10, offerte); 
            PercentuelePromotie huurPrijsPromotie = new PercentuelePromotie(promotiePeriode, -0.5, huurPrijsPerNacht);

            offerte.Add(huurPrijsPerNacht , 7);
            offerte.Add(waarborg);
            offerte.Add(schoonmaak);
            offerte.Add(persoonsToeslagPerNacht, 6*7);
            offerte.Add(vastePrijsPromotie);
            offerte.Add(reservatieKorting);
            offerte.Add(huurPrijsPromotie,7);
            Assert.IsTrue(offerte.Waarde != 0);
        }
    }
}
