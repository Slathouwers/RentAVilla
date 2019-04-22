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
            double laagseizoenPerNacht = 50.00;
            
            tarievenPrijsLijst[Tarief.Laagseizoen] = (HuurPrijsPerNacht)laagseizoenPerNacht;
            Assert.IsTrue(Math.Abs(tarievenPrijsLijst[Tarief.Laagseizoen].Waarde - 50.00) < 0.001);
        }
        [TestMethod]
        public void TarievenPrijsLijsUpdateWaarLaagseizoen()
        {
            TarievenLijst tarievenPrijsLijst = new TarievenLijst();
            //prijs voor 1 overnachting afhankelijk van de periode waarin gehuurd wordt
            double laagseizoenPerNacht = 50.00;

            tarievenPrijsLijst.Update(new HuurPrijsPerNacht(Tarief.Laagseizoen,laagseizoenPerNacht));
            Assert.IsTrue(Math.Abs(tarievenPrijsLijst[Tarief.Laagseizoen].Waarde - 50.00) < 0.001);
        }
    }
}