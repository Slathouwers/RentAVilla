using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SndrLth.RentAVilla.Domain;

namespace SndrLth.RentAVilla.DomainTests
{
    [TestClass]
    public class PandFixtures
    {
        [TestMethod]
        public void PropertyTests()
        {
            Pand p = new Pand();
            Assert.IsInstanceOfType(p, typeof(Pand));
            
            //Land
            p.Land = ActieveLanden.Frankrijk;
            Assert.IsTrue(p.Land.ToString().Equals("Frankrijk"));
            p.Land = ActieveLanden.Italie;
            Assert.IsTrue(p.Land.ToString().Equals("Italie"));
            p.Land = ActieveLanden.Portugal;
            Assert.IsTrue(p.Land.ToString().Equals("Portugal"));
            p.Land = ActieveLanden.Spanje;
            Assert.IsTrue(p.Land.ToString().Equals("Spanje"));
            
            //Regio
            p.Regio = "Cote D'Azure";
            Assert.IsTrue(p.Regio.ToString().Equals("Cote D'Azure"));
            p.Regio = "Catalonia";
            Assert.IsTrue(p.Regio.ToString().Equals("Catalonia"));
            
            //Plaats
            p.Plaats = "Marseille";
            Assert.IsTrue(p.Plaats.ToString().Equals("Marseille"));
            p.Plaats = "Barcelona";
            Assert.IsTrue(p.Plaats.ToString().Equals("Barcelona"));
           
            //Aantal Personen
            p.MaxAantalPersonen = 6;
            Assert.IsTrue(p.MaxAantalPersonen == 6);
            p.MaxAantalPersonen = 4;
            Assert.IsTrue(p.MaxAantalPersonen == 4);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => p.MaxAantalPersonen = -1);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => p.MaxAantalPersonen = 0);
            //minimumduur verblijf(eventueel afhankelijk van de periode waarin gehuurd wordt)
            p.MinVerblijfsduur = 4;
            Assert.IsTrue(p.MinVerblijfsduur == 4);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => p.MinVerblijfsduur = -1);


            //prijs voor 1 overnachting afhankelijk van de periode waarin gehuurd wordt
            Prijs laagseizoenPerNacht = new Prijs(50.00, PrijsEenheid.PerNacht);
            p.TariefGebondenPrijsPerNacht[TariefType.Laagseizoen] = laagseizoenPerNacht;
            Assert.IsTrue(p.TariefGebondenPrijsPerNacht[TariefType.Laagseizoen].Waarde == 50.00);


            
            //Tarieftypen voor prijsbepaling
            TariefType onbeschikbaar = TariefType.Onbeschikbaar;
            TariefType hoogseizoen = TariefType.Hoogseizoen;
            TariefType tussenseizoen = TariefType.Tussenseizoen;
            TariefType laagseizoen = TariefType.Laagseizoen;
            
            //bedrag waarborg
            p.SetWaarborg(600.00);
            Assert.IsTrue(p.Waarborg.Waarde == 600.00 && p.Waarborg.ToepassingsEenheid.HasFlag(PrijsEenheid.PerReservatie));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => p.SetWaarborg(-100.00));

            //eventuele toeslag per overnachting per persoon
            p.SetPersoonstoeslagPerNacht(15.00);
            Assert.IsTrue(p.PersoonstoeslagPerNacht.Waarde == 15.00);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => p.SetPersoonstoeslagPerNacht( -15.00));

            //prijs voor eindschoonmaak
            p.SetSchoonmaakPrijs ( 20.00);
            Assert.IsTrue(p.SchoonmaakPrijs.Waarde == 20.00);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => p.SetSchoonmaakPrijs(-15.00));

            //Pandspecifieke Tarief en Planningsschema -> Laagseizoen vanaf 15/03, Onbeschikbaar vanaf 10/06, Tussenseizoen vanaf 20/07 etc...
            p.TariefKalender = new Dictionary<DateTime, TariefType>();
            p.TariefKalender.Add(DateTime.Parse("16/04/2019"), TariefType.Onbeschikbaar);
            p.TariefKalender.Add(DateTime.Parse("16/05/2019"), TariefType.Laagseizoen);
            p.TariefKalender.Add(DateTime.Parse("16/06/2019"), TariefType.Hoogseizoen);


            DateTime testdate = DateTime.Parse("15/06/2019"); //Laagseizoen
            DateTime testdate2 = DateTime.Parse("15/05/2019"); // Onbeschikbaar

            TimeSpan minimum = TimeSpan.Zero;
            DateTime tariefKey = DateTime.MinValue;
            foreach (DateTime key in p.TariefKalender.Keys)
            {
                if (key > testdate) continue;
                if (key.Subtract(testdate) >= minimum)
                {
                    minimum = key.Subtract(testdate);
                    tariefKey = key;
                }
            }

            Assert.IsTrue(p.TariefKalender[tariefKey] == TariefType.Laagseizoen);
        }
    }
}
