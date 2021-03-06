﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SndrLth.RentAVilla.Domain.Enums;
using SndrLth.RentAVilla.Domain.Klanten;
using SndrLth.RentAVilla.Domain.Panden;
using SndrLth.RentAVilla.Domain.Prijzen.PrijsOffertes;
using SndrLth.RentAVilla.Domain.Prijzen.Promoties;
using SndrLth.RentAVilla.Domain.Reservaties;

namespace SndrLth.RentAVilla.DomainTests
{
    [TestClass]
    public class ReservatieFixtures
    {
        private static readonly PandBuilder PandBuilder = new PandBuilder();
        private static readonly PrijsOfferteBuilder PrijsOfferteBuilder = new PrijsOfferteBuilder(new Promoties());

        [TestMethod]
        public void PandReserverenVoorPeriodeOpNaamVanKlant()
        {
            Pand pand = PandBuilder.CreatePand("testvilla").Get();
            pand.MaxAantalPersonen = 6;
            Klant klant = new Klant(new KlantCategorie(KlantCategorieNaam.Particulier), "Lathouwers");
            int aantalPersonen = 6;
            Periode reservatiePeriode = new Periode("21/04/2019", "25/04/2019");
            ReservatieBuilder reservatieBuilder = new ReservatieBuilder(PrijsOfferteBuilder);
            Reservatie testReservatie = reservatieBuilder.MaakReservatie(pand, klant, reservatiePeriode, aantalPersonen);
            Assert.IsTrue(testReservatie.GetType() == typeof(Reservatie));
        }
    }
}
