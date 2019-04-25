using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SndrLth.RentAVilla.Domain.Panden;

namespace SndrLth.RentAVilla.DomainTests
{
   
    /// <summary>
    ///  HuurPandCollectie is verantwoordelijk voor beheren van verzameling huurpanden
    /// </summary>
    [TestClass]
    public class HuurPandCatalogusFixtures
    {
        private static HuurPandCatalogus catalogus;
        private static IEnumerable<object[]> GetPandenTestData =>
           new List<object[]>
           {
                new object[] {TestDataGenerator.GetTestPand()},
                new object[] {TestDataGenerator.GetTestPand()},
                new object[] {TestDataGenerator.GetTestPand()},
                new object[] {TestDataGenerator.GetTestPand()},
                new object[] {TestDataGenerator.GetTestPand()},
                new object[] {TestDataGenerator.GetTestPand()},
           };
        [DataTestMethod]
        [DynamicData(nameof(GetPandenTestData))]
        public void MaakCatalogusEnVoegPandenToe(Pand p)
        {
            if(catalogus==null) catalogus = new HuurPandCatalogus();
            catalogus.Add(p);
            Assert.IsTrue(catalogus.Contains(p));
        }
        [TestMethod]
        public void AddAllToCatalogusAndCount()
        {
            if (catalogus == null) catalogus = new HuurPandCatalogus();
            Assert.IsTrue(catalogus.Count == 6);

        }
    }
}
