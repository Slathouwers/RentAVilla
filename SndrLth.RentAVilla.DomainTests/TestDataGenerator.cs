using SndrLth.RentAVilla.Domain;
using SndrLth.RentAVilla.Domain.Enums;
using SndrLth.RentAVilla.Domain.PrijsKlassen;
using SndrLth.RentAVilla.Domain.TariefKlassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SndrLth.RentAVilla.DomainTests
{
    public class TestDataGenerator
    {
        public static TarievenLijst GetTestTarievenLijst()
        {
            TarievenLijst testTarievenLijst = new TarievenLijst();
            //tarievenLijstTestData
            testTarievenLijst[Tarief.Hoogseizoen] = (HuurPrijsPerNacht)198.00;
            testTarievenLijst[Tarief.Tussenseizoen] = (HuurPrijsPerNacht)137.00;
            testTarievenLijst[Tarief.Laagseizoen] = (HuurPrijsPerNacht)95.00;
            testTarievenLijst[Tarief.Onbeschikbaar] = (HuurPrijsPerNacht)0.00;
            testTarievenLijst[Tarief.Ongekend] = (HuurPrijsPerNacht)0.00;
            return testTarievenLijst;
        }
        public static TariefKalender GetTariefKalender()
        {
            return new TariefKalender
            {
                new TariefKalenderRegistratie(DateTime.Parse("16/04/2019"), Tarief.Onbeschikbaar),
                new TariefKalenderRegistratie(DateTime.Parse("16/05/2019"), Tarief.Laagseizoen),
                new TariefKalenderRegistratie(DateTime.Parse("16/06/2019"), Tarief.Hoogseizoen),
                new TariefKalenderRegistratie(DateTime.Parse("01/09/2019"), Tarief.Tussenseizoen),
                new TariefKalenderRegistratie(DateTime.Parse("01/11/2019"), Tarief.Laagseizoen),
                new TariefKalenderRegistratie(DateTime.Parse("31/12/2019"), Tarief.Ongekend)
            };
        }
        public static ActieveLanden GetActiefLand()
        {
            Random rd = new Random();
            return (ActieveLanden)rd.Next(0, 4);

        }
        public static string GetRegio()
        {
            string[] regios=new string[] { "Cote D'Azure", "Catalonia", "Marseille", "Barcelona" };
            Random rd = new Random();
            return regios[rd.Next(0,4)];

        }
        public static int GetRandomIntegerBetween(int min, int max)
        {
            Random rd = new Random();
            return rd.Next(min, max);
        }
        public static double GetRandomDoubleBetween(double min, double max)
        {
            Random rd = new Random();
            return min + (max -min) * rd.NextDouble();
        }
        public static Pand GetTestPand()
        {
            return new Pand(tarievenLijst: GetTestTarievenLijst(),
                            tariefKalender: GetTariefKalender(),
                            land: GetActiefLand(),
                            regio: GetRegio(),
                            plaats: "TestPlaats",
                            schoonmaakPrijs: (SchoonmaakPrijs)GetRandomDoubleBetween(50,150),
                            waarborg: (Waarborg)GetRandomDoubleBetween(500, 950),
                            persoonsToeslagPerNacht: (PersoonsToeslagPerNacht)GetRandomDoubleBetween(10, 25),
                            maxAantalPersonen: GetRandomIntegerBetween(2,15),
                            minVerblijfsduur: GetRandomIntegerBetween(1,6));
        }
        
    }
}
