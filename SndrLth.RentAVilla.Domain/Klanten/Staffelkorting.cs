using System.Collections.Generic;
using SndrLth.RentAVilla.Domain.Prijzen.Promoties;

namespace SndrLth.RentAVilla.Domain.Klanten
{
    public class Staffelkorting
    {
        public Staffelkorting()
        {
            Naam = "Geen Korting";
            StaffelTrancheLijst = new List<StaffelTranche>();
            StaffelTrancheLijst.Add(new StaffelTranche(1, new PercentuelePromotie(0)));

        }

        public Staffelkorting(string naam)
        {
            Naam = naam;
            StaffelTrancheLijst = new List<StaffelTranche>();
        }

        public string Naam { get; }
        public List<StaffelTranche> StaffelTrancheLijst { get; set; }
    }
}
