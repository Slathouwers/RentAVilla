﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SndrLth.RentAVilla.Domain;
using SndrLth.RentAVilla.Domain.Enums;
using SndrLth.RentAVilla.Domain.Klanten;
using SndrLth.RentAVilla.Domain.Panden;
using SndrLth.RentAVilla.Domain.Prijzen.PrijsOffertes;
using SndrLth.RentAVilla.Domain.Prijzen.Promoties;

namespace SndrLth.RentAVilla.DomainTests
{
    [TestClass]
    public class ReservatieFixtures
    {
        private static PandBuilder _pandBuilder = new PandBuilder();
        private static PrijsOfferteBuilder _prijsOfferteBuilder = new PrijsOfferteBuilder(new Promoties());
        [TestMethod]
        public void PandReserverenVoorPeriodeOpNaamVanKlant()
        {
            Pand pand = _pandBuilder.CreatePand("testvilla").Get();
            pand.MaxAantalPersonen = 6;
            Klant klant = new Klant(new KlantCategorie(KlantCategorieNaam.Particulier), "Lathouwers");
            int aantalPersonen = 6;
            Periode reservatiePeriode = new Periode("21/04/2019", "25/04/2019");
            Reservatie testReservatie = new Reservatie(pand, klant, reservatiePeriode, aantalPersonen, _prijsOfferteBuilder);
            Assert.IsTrue(testReservatie.GetType() == typeof(Reservatie));
        }
    }
}
