using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SndrLth.RentAVilla.Domain;
using SndrLth.RentAVilla.Domain.Enums;
using SndrLth.RentAVilla.Domain.TariefKlassen;

namespace SndrLth.RentAVilla.DomainTests
{
    [TestClass]
    public class TarievenPrijsLijstFixtures
    {

        [TestMethod]
        public void TarievenPrijsLijstAangemaaktEnGewijzigd()
        {
            TarievenLijst tarievenPrijsLijst = new TarievenLijst();
            //prijs voor 1 overnachting afhankelijk van de periode waarin gehuurd wordt
            Prijs laagseizoenPerNacht = new Prijs(50.00, PrijsEenheid.PerNacht);
            
            tarievenPrijsLijst[Tarief.Laagseizoen] = (DagPrijs)laagseizoenPerNacht;
            Assert.IsTrue(Math.Abs(tarievenPrijsLijst[Tarief.Laagseizoen].Waarde - 50.00) < 0.001);
        }
    }
}