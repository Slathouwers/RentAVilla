using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SndrLth.RentAVilla.Domain.Enums;
using SndrLth.RentAVilla.Domain.Panden;

namespace SndrLth.RentAVilla.DomainTests
{


    [TestClass]
    public class PandFixtures
    {
        private static readonly PandBuilder PandBuilder = new PandBuilder();
        public Pand Pand { get; set; } = PandBuilder.CreatePand("testvilla").Get();

        [TestMethod]
        public void NewPandCreated()
        {
            Pand = PandBuilder.CreatePand("testvilla").Get();
            Assert.IsInstanceOfType(Pand, typeof(Pand));
        }

        [TestMethod]
        public void LandSetsToActieveLandenAndReturnsLand()
        {
            Pand.Land = ActieveLanden.Frankrijk;
            Assert.IsTrue(Pand.Land.ToString().Equals("Frankrijk"));
            Pand.Land = ActieveLanden.Italie;
            Assert.IsTrue(Pand.Land.ToString().Equals("Italie"));
            Pand.Land = ActieveLanden.Portugal;
            Assert.IsTrue(Pand.Land.ToString().Equals("Portugal"));
            Pand.Land = ActieveLanden.Spanje;
            Assert.IsTrue(Pand.Land.ToString().Equals("Spanje"));
        }

        [TestMethod]
        public void RegioAndPlaatsStringPropertiesGetaAndSet()
        {
            //Regio
            Pand.Regio = "Cote D'Azure";
            Assert.IsTrue(Pand.Regio.Equals("Cote D'Azure"));
            Pand.Regio = "Catalonia";
            Assert.IsTrue(Pand.Regio.Equals("Catalonia"));

            //Plaats
            Pand.Plaats = "Marseille";
            Assert.IsTrue(Pand.Plaats.Equals("Marseille"));
            Pand.Plaats = "Barcelona";
            Assert.IsTrue(Pand.Plaats.Equals("Barcelona"));
        }

        [TestMethod]
        public void MaxAantalPersonenCanSetAndGet()
        {
            //Aantal Personen
            Pand.MaxAantalPersonen = 6;
            Assert.IsTrue(Pand.MaxAantalPersonen == 6);
            Pand.MaxAantalPersonen = 4;
            Assert.IsTrue(Pand.MaxAantalPersonen == 4);
        }

        [TestMethod]
        public void NegativeMaxAantalPersonenThrowsArgOutOfRange()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Pand.MaxAantalPersonen = -1);
        }

        [TestMethod]
        public void ZeroMaxAantalPersonenThrowsArgOutOfRangeException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Pand.MaxAantalPersonen = 0);
        }

        [TestMethod]
        public void MinVerblijfsduurCanSetAndGet()
        {
            //Aantal Personen
            Pand.MinVerblijfsduur = 4;
            Assert.IsTrue(Pand.MinVerblijfsduur == 4);
        }

        [TestMethod]
        public void NegativeMinVerblijfsduurThrowsArgOutOfRange()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Pand.MinVerblijfsduur = -1);
        }


        [TestMethod]
        public void WaarborgPrijsTest()
        {
            //bedrag waarborg
            Pand.SetWaarborg(600.00);
            Assert.IsTrue(Math.Abs(Pand.Waarborg.Waarde - 600.00) < 0.001 && Pand.Waarborg.ToepassingsEenheid.HasFlag(PrijsEenheid.PerReservatie));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Pand.SetWaarborg(-100.00));
        }

        [TestMethod]
        public void PersoonstoeslagPerNachtPrijsTest()
        {
            //eventuele toeslag per overnachting per persoon
            Pand.SetDagPrijs(15.00);
            Assert.IsTrue(Math.Abs(Pand.PersoonsToeslagPerNacht.Waarde - 15.00) < 0.001);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Pand.SetDagPrijs(-15.00));
        }

        [TestMethod]
        public void SchoonmaakPrijsTest()
        {
            //prijs voor eindschoonmaak
            Pand.SetSchoonmaakPrijs(20.00);
            Assert.IsTrue(Math.Abs(Pand.SchoonmaakPrijs.Waarde - 20.00) < 0.001);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Pand.SetSchoonmaakPrijs(-15.00));
        }
    }
}
