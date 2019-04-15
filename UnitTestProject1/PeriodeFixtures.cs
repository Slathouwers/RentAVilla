using System;
using SndrLth.RentAVilla.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class PeriodeFixtures
    {
        private static DateTime start;
        private static DateTime eind;

        [ClassInitialize]   
        public static void ClassInitialize(TestContext t)
        {
            start = DateTime.Today;
            eind = start.AddDays(7);
        }

        [TestMethod]
        public void CreatedPeriodHasStartAndEnd()
        {
            Periode periode = new Periode(start, eind);
            Assert.IsTrue(periode.Start.Equals(start) && periode.Eind.Equals(eind));
        }

        [DataTestMethod]
        [DynamicData(nameof(GetInvalidPeriodeDefinitions))]
        public void ExceptionOnConstructWithEndSmallerOrEqualToStart(DateTime s,DateTime e)
        {
            Assert.ThrowsException<ArgumentException>(() => new Periode(s, e));
        }
        private static IEnumerable<object[]> GetInvalidPeriodeDefinitions
        {
            get
            {
                return new List<object[]>
                {
                    new object[] {start,start},
                    new object[] {start,start.AddHours(4)},
                    new object[] {start,start.AddHours(-4)},
                    new object[] {eind,start},
                    new object[] {DateTime.Parse("2019-04-02"), DateTime.Parse("2019-04-01") },
                    new object[] {DateTime.Parse("2019-04-02"), DateTime.Parse("2019-03-02") }
                };
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(GetOverlapTestCases))]
        public void OverlapTest(Periode p1, Periode p2, bool caseResult, string caseDefinition)
        {
            Assert.IsTrue(p1.Overlapt(p2) == caseResult, $"Case '{caseDefinition}' failed.");
        }
        private static IEnumerable<object[]> GetOverlapTestCases
        {
            get
            {
                Periode basePeriod = new Periode(DateTime.Parse("2019-04-02"), DateTime.Parse("2019-04-10"));
                // Overlap = True
                Periode overlapsPerfect = new Periode(DateTime.Parse("2019-04-02"), DateTime.Parse("2019-04-10"));
                Periode overlapsEnd = new Periode(DateTime.Parse("2019-03-19"), DateTime.Parse("2019-04-05"));
                Periode overlapsStart = new Periode(DateTime.Parse("2019-04-05"), DateTime.Parse("2019-04-15"));
                Periode overlapsContainer = new Periode(DateTime.Parse("2019-03-19"), DateTime.Parse("2019-04-15"));
                Periode overlapsContent = new Periode(DateTime.Parse("2019-04-03"), DateTime.Parse("2019-04-09"));
                // Overlap = False
                Periode endTouch = new Periode(DateTime.Parse("2019-03-19"), DateTime.Parse("2019-04-02"));
                Periode startTouch = new Periode(DateTime.Parse("2019-04-10"), DateTime.Parse("2019-04-15"));
                Periode before = new Periode(DateTime.Parse("2019-03-19"), DateTime.Parse("2019-03-29"));
                Periode after = new Periode(DateTime.Parse("2019-04-19"), DateTime.Parse("2019-04-29"));

                return new List<object[]>
                {
                    new object[] { basePeriod, overlapsPerfect, true, "Perfecte overlap"},
                    new object[] { basePeriod, overlapsEnd, true, "Periode 2 eindigt in Periode 1"},
                    new object[] { basePeriod, overlapsStart, true, "Periode 2 start in Periode 1"},
                    new object[] { basePeriod, overlapsContainer, true, "Periode 2 bevat Periode 1"},
                    new object[] { basePeriod, overlapsContent, true, "Periode 2 volledig in Periode 1"},

                    new object[] { basePeriod, endTouch, false,"Periode 2 eindigt op start Periode 1" },
                    new object[] { basePeriod, startTouch, false, "Periode 2 start op einde Periode 1" },
                    new object[] { basePeriod, before, false, "Periode 2 stopt voor Periode 1" },
                    new object[] { basePeriod, after, false, "Periode 2 start na Periode 1" }
                };
            }
        }
    }
}
