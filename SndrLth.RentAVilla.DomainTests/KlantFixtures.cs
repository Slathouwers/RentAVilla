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
            Klant klant = new Klant(new KlantCategorie( KlantCategorieNaam.Particulier), "Lathouwers");
            Assert.IsTrue(klant.Categorie.Naam == KlantCategorieNaam.Particulier && klant.Naam.Equals("Lathouwers"));
        }
    }
}
