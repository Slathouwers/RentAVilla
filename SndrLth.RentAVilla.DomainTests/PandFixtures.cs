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

            //prijs voor 1 overnachting afhankelijk van de periode waarin gehuurd wordt
            p.TariefGebondenPrijsPerNacht = new Dictionary<Tarief, double>();
            foreach(Tarief tar in Enum.GetValues(typeof(Tarief)))
            {
                p.TariefGebondenPrijsPerNacht.Add(tar, 0.00);
            }
            p.TariefGebondenPrijsPerNacht[Tarief.Laagseizoen] = 50.00;
            Assert.IsTrue(p.TariefGebondenPrijsPerNacht[Tarief.Laagseizoen] == 50.00);

            //TODO: 
            //FAIL ---  Assert.ThrowsException<ArgumentOutOfRangeException>(() => p.TariefGebondenPrijsPerNacht[TariefPeriode.Laagseizoen] = -1);

            //minimumduur verblijf(eventueel afhankelijk van de periode waarin gehuurd wordt)
            p.MinVerblijfsduur = 4;
            Assert.IsTrue(p.MinVerblijfsduur == 4);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => p.MinVerblijfsduur = -1);
            
            //periodes voor prijzen
            Tarief onbeschikbaar = Tarief.Onbeschikbaar;
            Tarief hoogseizoen = Tarief.Hoogseizoen;
            Tarief tussenseizoen = Tarief.Tussenseizoen;
            Tarief laagseizoen = Tarief.Laagseizoen;
            
            //bedrag waarborg
            p.Waarborg = 600.00;
            Assert.IsTrue(p.Waarborg == 600.00);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => p.Waarborg = -100.00);

            //eventuele toeslag per overnachting per persoon
            p.ToeslagPersoonsOvernachting = 15.00;
            Assert.IsTrue(p.ToeslagPersoonsOvernachting == 15.00);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => p.ToeslagPersoonsOvernachting = -15.00);

            //prijs voor eindschoonmaak
            p.Schoonmaak = 20.00;
            Assert.IsTrue(p.Schoonmaak == 20.00);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => p.Schoonmaak = -15.00);

            //Pandspecifieke Tarief en Planningsschema -> Laagseizoen vanaf 15/03, Onbeschikbaar vanaf 10/06, Tussenseizoen vanaf 20/07 etc...
            p.TariefStartData = new Dictionary<DateTime, Tarief>();
            p.TariefStartData.Add(DateTime.Parse("16/04/2019"), Tarief.Onbeschikbaar);
            p.TariefStartData.Add(DateTime.Parse("16/05/2019"), Tarief.Laagseizoen);
            p.TariefStartData.Add(DateTime.Parse("16/06/2019"), Tarief.Hoogseizoen);

            //TODO: NOT WORKING!!
            DateTime testdate = DateTime.Parse("15/06/2019"); //Laagseizoen
            DateTime testdate2 = DateTime.Parse("15/05/2019"); // Onbeschikbaar

            TimeSpan minimum = TimeSpan.Zero;
            DateTime tariefKey = DateTime.MinValue;
            foreach (DateTime key in p.TariefStartData.Keys)
            {
                if (key > testdate) continue;
                if (key.Subtract(testdate) <= minimum)
                {
                    minimum = key.Subtract(testdate);
                    tariefKey = key;
                }
            }

            Assert.IsTrue(p.TariefStartData[tariefKey] == Tarief.Laagseizoen);
        }
    }
}
