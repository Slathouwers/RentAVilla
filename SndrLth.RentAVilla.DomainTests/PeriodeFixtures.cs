using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SndrLth.RentAVilla.Domain;

namespace SndrLth.RentAVilla.DomainTests
{
    [TestClass]
    public class PeriodeFixtures
    {
        private static DateTime start;
        private static DateTime eind;

        private static IEnumerable<object[]> GetInvalidPeriodeDefinitions =>
            new List<object[]>
            {
                new object[] {start, start},
                new object[] {start, start.AddHours(4)},
                new object[] {start, start.AddHours(-4)},
                new object[] {eind, start},
                new object[] {DateTime.Parse("2019-04-02"), DateTime.Parse("2019-04-01")},
                new object[] {DateTime.Parse("2019-04-02"), DateTime.Parse("2019-03-02")}
            };

        private static IEnumerable<object[]> GetOverlapTestCases
        {
            get
            {
                var basePeriod = new Periode(DateTime.Parse("2019-04-02"), DateTime.Parse("2019-04-10"));
                // Overlap = True
                var overlaptPerfect = new Periode(DateTime.Parse("2019-04-02"), DateTime.Parse("2019-04-10"));
                var overlaptEnd = new Periode(DateTime.Parse("2019-03-19"), DateTime.Parse("2019-04-05"));
                var overlaptStart = new Periode(DateTime.Parse("2019-04-05"), DateTime.Parse("2019-04-15"));
                var overlaptContainer = new Periode(DateTime.Parse("2019-03-19"), DateTime.Parse("2019-04-15"));
                var overlaptContent = new Periode(DateTime.Parse("2019-04-03"), DateTime.Parse("2019-04-09"));
                // Overlap = False
                var endTouch = new Periode(DateTime.Parse("2019-03-19"), DateTime.Parse("2019-04-02"));
                var startTouch = new Periode(DateTime.Parse("2019-04-10"), DateTime.Parse("2019-04-15"));
                var before = new Periode(DateTime.Parse("2019-03-19"), DateTime.Parse("2019-03-29"));
                var after = new Periode(DateTime.Parse("2019-04-19"), DateTime.Parse("2019-04-29"));

                return new List<object[]>
                {
                    new object[] {basePeriod, overlaptPerfect, true, "Perfecte overlap"},
                    new object[] {basePeriod, overlaptEnd, true, "Periode 2 eindigt in Periode 1"},
                    new object[] {basePeriod, overlaptStart, true, "Periode 2 start in Periode 1"},
                    new object[] {basePeriod, overlaptContainer, true, "Periode 2 bevat Periode 1"},
                    new object[] {basePeriod, overlaptContent, true, "Periode 2 volledig in Periode 1"},

                    new object[] {basePeriod, endTouch, false, "Periode 2 eindigt op start Periode 1"},
                    new object[] {basePeriod, startTouch, false, "Periode 2 start op einde Periode 1"},
                    new object[] {basePeriod, before, false, "Periode 2 stopt voor Periode 1"},
                    new object[] {basePeriod, after, false, "Periode 2 start na Periode 1"}
                };
            }
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext t)
        {
            start = DateTime.Today;
            eind = start.AddDays(7);
        }

        [TestMethod]
        public void CreatedPeriodHasStartAndEnd()
        {
            var periode = new Periode(start, eind);
            Assert.IsTrue(periode.Start.Equals(start) && periode.Eind.Equals(eind));
        }
        [TestMethod]
        public void PeriodeConstructorParsesDateStringArgument()
        {
            string startString = "21/04/2019";
            string eindString = "25/04/2019";
            var periode = new Periode(startString, eindString);
            Assert.IsTrue(periode.Start.Equals(DateTime.Parse(startString)) && periode.Eind.Equals(DateTime.Parse(eindString)));
        }
        [TestMethod]
        public void PeriodeConstructorThrowsExceptionOnInvalidStringArguments()
        {
            string startString = "abc9";
            string eindString = ".....";
            Assert.ThrowsException<ArgumentException>(()=> new Periode(startString, eindString));
        }

        [DataTestMethod]
        [DynamicData(nameof(GetInvalidPeriodeDefinitions))]
        public void ExceptionOnConstructWithEndSmallerOrEqualToStart(DateTime s, DateTime e)
        {
            Assert.ThrowsException<ArgumentException>(() => new Periode(s, e));
        }

        [DataTestMethod]
        [DynamicData(nameof(GetOverlapTestCases))]
        public void OverlapTest(Periode p1, Periode p2, bool caseResult, string caseDefinition)
        {
            Assert.IsTrue(p1.Overlapt(p2) == caseResult, $"Case '{caseDefinition}' failed.");
        }
        [TestMethod()]
        public void OverlaptDatumTest()
        {
            var periode = new Periode(start, eind);
            Assert.IsTrue(periode.Overlapt(start.AddDays(1)));
        }
    }
}
