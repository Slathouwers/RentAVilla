using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SndrLth.RentAVilla.Domain;

namespace SndrLth.RentAVilla.DomainTests
{
    [TestClass]
    public class PandFixtures
    {
        public Pand pand { get; set; }
        [TestMethod]
        public void NewPandCreated()
        {
            pand = new Pand();
            Assert.IsInstanceOfType(pand, typeof(Pand));
        }
        [TestMethod]
        public void LandSetsToActieveLandenAndReturnsLand()
        {
            pand.Land = ActieveLanden.Frankrijk;
            Assert.IsTrue(pand.Land.ToString().Equals("Frankrijk"));
            pand.Land = ActieveLanden.Italie;
            Assert.IsTrue(pand.Land.ToString().Equals("Italie"));
            pand.Land = ActieveLanden.Portugal;
            Assert.IsTrue(pand.Land.ToString().Equals("Portugal"));
            pand.Land = ActieveLanden.Spanje;
            Assert.IsTrue(pand.Land.ToString().Equals("Spanje"));
        }
        [TestMethod]
        public void RegioAndPlaatsStringPropertiesGetaAndSet()
        {
            //Regio
            pand.Regio = "Cote D'Azure";
            Assert.IsTrue(pand.Regio.ToString().Equals("Cote D'Azure"));
            pand.Regio = "Catalonia";
            Assert.IsTrue(pand.Regio.ToString().Equals("Catalonia"));

            //Plaats
            pand.Plaats = "Marseille";
            Assert.IsTrue(pand.Plaats.ToString().Equals("Marseille"));
            pand.Plaats = "Barcelona";
            Assert.IsTrue(pand.Plaats.ToString().Equals("Barcelona"));
        }
        [TestMethod]
        public void MaxAantalPersonenCanSetAndGet()
        {
            //Aantal Personen
            pand.MaxAantalPersonen = 6;
            Assert.IsTrue(pand.MaxAantalPersonen == 6);
            pand.MaxAantalPersonen = 4;
            Assert.IsTrue(pand.MaxAantalPersonen == 4);
        }
        [TestMethod]
        public void NegativeMaxAantalPersonenThrowsArgOutOfRange()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => pand.MaxAantalPersonen = -1);
        }

        public void ZeroMaxAantalPersonenThrowsArgOutOfRangeException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => pand.MaxAantalPersonen = 0);

        }
        [TestMethod]
        public void MinVerblijfsduurCanSetAndGet()
        {
            //Aantal Personen
            pand.MinVerblijfsduur = 4;
            Assert.IsTrue(pand.MinVerblijfsduur == 4);
        }
        [TestMethod]
        public void NegativeMinVerblijfsduurThrowsArgOutOfRange()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => pand.MinVerblijfsduur = -1);
        }
        [TestMethod]
        public void TariefTypesExist()
        {

            ////Tarieftypen voor prijsbepaling
            //TariefType onbeschikbaar = TariefType.Onbeschikbaar;
            //TariefType hoogseizoen = TariefType.Hoogseizoen;
            //TariefType tussenseizoen = TariefType.Tussenseizoen;
            //TariefType laagseizoen = TariefType.Laagseizoen;
        }
        [TestMethod]
        public void TariefGebondenPrijsPerNachtAndCanBeSet()
        {
            //prijs voor 1 overnachting afhankelijk van de periode waarin gehuurd wordt
            Prijs laagseizoenPerNacht = new Prijs(50.00, PrijsEenheid.PerNacht);
            pand.TariefGebondenPrijsPerNacht[TariefType.Laagseizoen] = laagseizoenPerNacht;
            Assert.IsTrue(pand.TariefGebondenPrijsPerNacht[TariefType.Laagseizoen].Waarde == 50.00);
        }
//        //bedrag waarborg
//        pand.SetWaarborg(600.00);
//        Assert.IsTrue(pand.Waarborg.Waarde == 600.00 && pand.Waarborg.ToepassingsEenheid.HasFlag(PrijsEenheid.PerReservatie));
//        Assert.ThrowsException<ArgumentOutOfRangeException>(() => pand.SetWaarborg(-100.00));

//        //eventuele toeslag per overnachting per persoon
//        pand.SetPersoonstoeslagPerNacht(15.00);
//        Assert.IsTrue(pand.PersoonstoeslagPerNacht.Waarde == 15.00);
//        Assert.ThrowsException<ArgumentOutOfRangeException>(() => pand.SetPersoonstoeslagPerNacht(-15.00));

//        //prijs voor eindschoonmaak
//        pand.SetSchoonmaakPrijs(20.00);
//        Assert.IsTrue(pand.SchoonmaakPrijs.Waarde == 20.00);
//        Assert.ThrowsException<ArgumentOutOfRangeException>(() => pand.SetSchoonmaakPrijs(-15.00));

//        //Pandspecifieke Tarief en Planningsschema -> Laagseizoen vanaf 15/03, Onbeschikbaar vanaf 10/06, Tussenseizoen vanaf 20/07 etc...
//        pand.TariefKalender = new Dictionary<DateTime, TariefType>();
//        pand.TariefKalender.Add(DateTime.Parse("16/04/2019"), TariefType.Onbeschikbaar);
//        pand.TariefKalender.Add(DateTime.Parse("16/05/2019"), TariefType.Laagseizoen);
//        pand.TariefKalender.Add(DateTime.Parse("16/06/2019"), TariefType.Hoogseizoen);

//        //Test date lookup in tariefkalender
//        DateTime testdate = DateTime.Parse("15/06/2019"); //Laagseizoen
//        DateTime testdate2 = DateTime.Parse("15/05/2019"); // Onbeschikbaar

//        TimeSpan minimum = TimeSpan.Zero;
//        DateTime tariefKey = DateTime.MinValue;
//        foreach (DateTime key in pand.TariefKalender.Keys)
//        {
//            if (key > testdate) continue;
//            if (key.Subtract(testdate) >= minimum)
//            {
//                minimum = key.Subtract(testdate);
//                tariefKey = key;
//            }
//}

//Assert.IsTrue(pand.TariefKalender[tariefKey] == TariefType.Laagseizoen);
    }
}
