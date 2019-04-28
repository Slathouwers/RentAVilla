using SndrLth.RentAVilla.Domain;
using SndrLth.RentAVilla.Domain.Enums;
using SndrLth.RentAVilla.Domain.Prijzen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SndrLth.RentAVilla.Domain.Klanten;
using SndrLth.RentAVilla.Domain.Panden;
using SndrLth.RentAVilla.Domain.Prijzen.PandPrijzen;
using SndrLth.RentAVilla.Domain.Prijzen.Promoties;
using SndrLth.RentAVilla.Domain.Reservaties;
using SndrLth.RentAVilla.Domain.Tarieven;

namespace SndrLth.RentAVilla.DomainTests
{
    public class TestDataGenerator
    {
        private static PandBuilder _pandBuilder = new PandBuilder();
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
            Pand p = _pandBuilder
                .CreatePand("testpand")
                .MetLocation(GetActiefLand(), 
                             GetRegio(),
                             "TestPlaats")
                .MetPrijzen((SchoonmaakPrijs)GetRandomDoubleBetween(50, 150),
                            (Waarborg)GetRandomDoubleBetween(500, 950),
                            (PersoonsToeslagPerNacht)GetRandomDoubleBetween(10, 25))
                .MetLimieten(GetRandomIntegerBetween(6, 15),
                             GetRandomIntegerBetween(1, 6))
                .Get();
            p.TariefKalender = GetTariefKalender();
            p.TarievenLijst = GetTestTarievenLijst();
            return p;
        }
        public static Pand GetTestPand(ActieveLanden actieveLand)
        {
            Pand p = _pandBuilder
                .CreatePand("testpand")
                .MetLocation(actieveLand,
                    GetRegio(),
                    "TestPlaats")
                .MetPrijzen((SchoonmaakPrijs)GetRandomDoubleBetween(50, 150),
                    (Waarborg)GetRandomDoubleBetween(500, 950),
                    (PersoonsToeslagPerNacht)GetRandomDoubleBetween(10, 25))
                .MetLimieten(GetRandomIntegerBetween(6, 15),
                    GetRandomIntegerBetween(1, 6))
                .Get();
            p.TariefKalender = GetTariefKalender();
            p.TarievenLijst = GetTestTarievenLijst();
            return p;
        }
        public static Staffelkorting GetGroteOmzetStaffelkorting()
        {
            int minimumAantalNachten = 7;
            Periode geldigheidsPeriode = new Periode("22/04/2019", "31/12/2999");
            PercentuelePromotie trancheKorting = new PercentuelePromotie(geldigheidsPeriode, -0.5 / 7);
            StaffelTranche testTranche0 = new StaffelTranche(minimumAantalNachten, trancheKorting);
            minimumAantalNachten = 1;
            trancheKorting = new PercentuelePromotie(geldigheidsPeriode, 0);
            StaffelTranche testTranche1 = new StaffelTranche(minimumAantalNachten, trancheKorting);
            minimumAantalNachten = 14;
            trancheKorting = new PercentuelePromotie(geldigheidsPeriode, -1 + (11.9 / 14));
            StaffelTranche testTranche2 = new StaffelTranche(minimumAantalNachten, trancheKorting);
            minimumAantalNachten = 28;
            trancheKorting = new PercentuelePromotie(geldigheidsPeriode, -1 + (22.4 / 28));
            StaffelTranche testTranche3 = new StaffelTranche(minimumAantalNachten, trancheKorting);

            string naam = "Grote Omzet";
            Staffelkorting staffelTest = new Staffelkorting(naam);
            staffelTest.StaffelTrancheLijst.Add(testTranche0);
            staffelTest.StaffelTrancheLijst.Add(testTranche1);
            staffelTest.StaffelTrancheLijst.Add(testTranche2);
            staffelTest.StaffelTrancheLijst.Add(testTranche3);

            return staffelTest;
        }
        
    }
}
