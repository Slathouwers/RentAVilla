using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SndrLth.RentAVilla.Domain;
using SndrLth.RentAVilla.Domain.Enums;
using SndrLth.RentAVilla.Domain.PrijsKlassen;
using SndrLth.RentAVilla.Domain.TariefKlassen;

namespace SndrLth.RentAVilla.DomainTests.TODO
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
