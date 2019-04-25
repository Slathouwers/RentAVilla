using System.Collections.Generic;
using SndrLth.RentAVilla.Domain.Enums;
using SndrLth.RentAVilla.Domain.Prijzen.Promoties;

namespace SndrLth.RentAVilla.Domain.Klanten
{
    public class Staffelkorting
    {
        public Staffelkorting()
        {
            Naam = "Geen Korting";
            KlantCategorieLijst = new List<KlantCategorieNaam>();
            StaffelTrancheLijst = new List<StaffelTranche>();
            StaffelTrancheLijst.Add(new StaffelTranche(1, new PercentuelePromotie(0)));

        }

        public Staffelkorting(string naam)
        {
            Naam = naam;
            KlantCategorieLijst = new List<KlantCategorieNaam>();
            StaffelTrancheLijst = new List<StaffelTranche>();
        }

        public string Naam { get; }
        public List<KlantCategorieNaam> KlantCategorieLijst { get; set; }
        public List<StaffelTranche> StaffelTrancheLijst { get; set; }
    }
}
