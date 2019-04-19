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
            TarievenPrijsLijst tarievenPrijsLijst = new TarievenPrijsLijst();
            //prijs voor 1 overnachting afhankelijk van de periode waarin gehuurd wordt
            var laagseizoenPerNacht = new Prijs(50.00, PrijsEenheid.PerNacht);
            
            tarievenPrijsLijst[TariefType.Laagseizoen] = laagseizoenPerNacht;
            Assert.IsTrue(Math.Abs(tarievenPrijsLijst[TariefType.Laagseizoen].Waarde - 50.00) < 0.001);
        }
    }
}