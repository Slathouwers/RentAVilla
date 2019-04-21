using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SndrLth.RentAVilla.Domain;
using SndrLth.RentAVilla.Domain.Enums;

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
    }
}
