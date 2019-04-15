using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SndrLth.RentAVilla.Domain;

namespace UnitTestProject1
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
            
            //METHOD : prijs voor 1 overnachting afhankelijk van de periode waarin gehuurd wordt

            //minimumduur verblijf(eventueel afhankelijk van de periode waarin gehuurd wordt)

            //periodes voor prijzen
            TariefPeriodes onbeschikbaar = TariefPeriodes.Onbeschikbaar;
            TariefPeriodes hoogseizoen = TariefPeriodes.Hoogseizoen;
            TariefPeriodes tussenseizoen = TariefPeriodes.Tussenseizoen;
            TariefPeriodes laagseizoen = TariefPeriodes.Laagseizoen;
            //bedrag waarborg

            //eventuele toeslag per overnachting per persoon

            //prijs voor eindschoonmaak

        }
    }
}
