using System.Collections.Generic;

namespace SndrLth.RentAVilla.Domain
{
    public class Staffelkorting
    {
        public Staffelkorting()
        {
            Naam = "Geen Korting";
            KlantCategorieLijst = new List<KlantCategorieNaam>();
            StaffelTrancheLijst = new List<StaffelTranche>();
            StaffelTrancheLijst.Add(new StaffelTranche(1, new PrijsKlassen.PercentuelePromotie(0)));

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