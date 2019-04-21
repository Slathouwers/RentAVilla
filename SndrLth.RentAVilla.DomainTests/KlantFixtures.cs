using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SndrLth.RentAVilla.Domain;

namespace SndrLth.RentAVilla.DomainTests
{
    [TestClass]
    public class KlantFixtures
    {
        [TestMethod]
        public void KlantHeeftPropertiesCategorieEnNaam()
        {
            Klant klant = new Klant(KlantCategorie.Particulier, "Lathouwers");
            Assert.IsTrue(klant.Categorie == KlantCategorie.Particulier && klant.Naam.Equals("Lathouwers"));
        }
    }
}
