using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SndrLth.RentAVilla.Domain;
using SndrLth.RentAVilla.Domain.Enums;
using SndrLth.RentAVilla.Domain.TariefKlassen;

namespace SndrLth.RentAVilla.DomainTests
{
    public class TariefKalenderFixtures
    {
        private static TariefKalender PandTariefKalenderVoorbeeld()
        {
            return new TariefKalender
            {
                new TariefKalenderRegistratie(DateTime.Parse("16/04/2019"), Tarief.Onbeschikbaar),
                new TariefKalenderRegistratie(DateTime.Parse("16/05/2019"), Tarief.Laagseizoen),
                new TariefKalenderRegistratie(DateTime.Parse("16/06/2019"), Tarief.Hoogseizoen)
            };
        }
        [TestMethod]
        public void TariefKalenderCreated()
        {
            //Pandspecifieke Tarief en Planningsschema -> Laagseizoen vanaf 15/03, Onbeschikbaar vanaf 10/06, Tussenseizoen vanaf 20/07 etc...
            var tk = PandTariefKalenderVoorbeeld();
        }
        [TestMethod]
        public void TariefKalendarKanOpzoeken()
        {
            var tk = PandTariefKalenderVoorbeeld();
            //Test date lookup in tariefkalender
            var testdate = DateTime.Parse("15/06/2019"); //Laagseizoen
            var testdate2 = DateTime.Parse("15/05/2019"); // Onbeschikbaar
            Assert.IsTrue(tk.GetTariefTypeVoorDatum(testdate) == Tarief.Laagseizoen);
            Assert.IsTrue(tk.GetTariefTypeVoorDatum(testdate2) == Tarief.Onbeschikbaar);
        }
    }

}
